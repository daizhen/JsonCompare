using JsonCompare.DiffService;
using JsonCompareLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Xsl;

namespace JsonCompare
{
    public partial class TestDiff : Form
    {
        public TestDiff()
        {
            InitializeComponent();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            var originalJson = GetJsonString(textBoxTableName.Text, textBoxQuery1.Text);
            var newJson = GetJsonString(textBoxTableName.Text, textBoxQuery2.Text);

            JObject jobject = JObject.Parse(originalJson);
            JObject jobject2 = JObject.Parse(newJson);
            CompareHandler handler = new CompareHandler();
            CompareStruct compareResult = handler.CompareStruct(jobject, jobject2);
            string diffXML = compareResult.ToXML("descriptor");
            string xslContent = GetXSL(textBoxTableName.Text);
            webBrowserResult.DocumentText = XslTransform(diffXML, xslContent);
        }

        private string GetJsonString(string tableName, string queryString)
        {
            SaveCompareServiceRequest request = new SaveCompareServiceRequest();
            request.model = new CompareServiceModelType();
            request.model.keys = new CompareServiceKeysType();
            request.model.instance = new CompareServiceInstanceType();
            request.model.instance.Name = new StringType { Value = tableName };
            request.model.instance.QueryString = new StringType { Value = queryString };
            CompareService compareService = new CompareService();
            CredentialCache credentialCache = new CredentialCache();
            NetworkCredential credentials = new NetworkCredential("ASIAPACIFIC_DAIZHEN", "", "");
            credentialCache.Add(new Uri(compareService.Url), "Basic", credentials);
            compareService.Credentials = credentialCache;

            XmlSerializer ser = new XmlSerializer(request.GetType());
            MemoryStream memstream = new MemoryStream();
            ser.Serialize(memstream, request);
            memstream.Seek(0, SeekOrigin.Begin);
            var buffer = new byte[memstream.Length];
            memstream.Read(buffer, 0, (int)memstream.Length);

            string requestXML = Encoding.UTF8.GetString(buffer);

            memstream.Close();


            var response = compareService.SaveCompareService(request);
            return response.model.instance.Content.Value;
        }

        private string GetXSL(string tableName)
        {
            string xslFileName = Application.StartupPath + "\\XSL_Files\\" + tableName + ".xsl";
            FileStream fileStream = new FileStream(xslFileName, FileMode.Open, FileAccess.Read);
            using (fileStream)
            {
                StreamReader reader = new StreamReader(fileStream);
                return reader.ReadToEnd();
            }
        }

        private String XslTransform(string inputXmlConent, string inuptXslContent)
        {
            XmlReader readerXml = XmlReader.Create(new MemoryStream(UTF8Encoding.UTF8.GetBytes(inputXmlConent)));
            XmlReader readerXsl = XmlReader.Create(new MemoryStream(UTF8Encoding.UTF8.GetBytes(inuptXslContent)));
            XslCompiledTransform transform = new XslCompiledTransform();
            transform.Load(readerXsl, new XsltSettings { EnableScript = true }, new XmlUrlResolver());

            StringBuilder sb = new StringBuilder();
            XmlWriterSettings Settings = new XmlWriterSettings()
            {
                Indent = true,
                ConformanceLevel = ConformanceLevel.Auto,
            };
            XmlWriter writer = XmlWriter.Create(sb, Settings);
            transform.Transform(readerXml, writer);

            return sb.ToString();
        }
    }
}
