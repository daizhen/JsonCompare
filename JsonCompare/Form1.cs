using JsonCompareLib;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Xsl;

namespace JsonCompare
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			//TestJson();
		}


		private void TestJson()
		{
			string jsonStr = "{'name':'dd','array':[11,22,33],'struct':{'name2':'xxx','name3':'xxx9999'},'arrayOfArray':[[1,2,3],[4,5,6],[3]]}";
            string jsonStr2 = "{'name':'dd updated','array':[11,22,33,55],'struct':{'name2':'xxx','name3':'xxx9999'},'arrayOfArray':[[1,2],[4,5,6]]}";
			JObject jobject = JObject.Parse(jsonStr);
			JObject jobject2 = JObject.Parse(jsonStr2);

			CompareHandler handler = new CompareHandler();

			CompareStruct compareResult = handler.CompareStruct(jobject, jobject2);

            string xml = compareResult.ToXML("descriptor");
			//foreach (var childNode in jobject.Children())
			//{
			//	//JValue, JArray, JObject
			//	var property = childNode as JProperty;
			//	string name = property.Name;
			//	var value = property.Value;
			//	var node = jobject[name];

			//	Console.WriteLine("name:" + name);
			//	Console.WriteLine("value:" + value);

			//}
		}

		private void Form1_Load(object sender, EventArgs e)
		{

		}

        private void buttonCompare_Click(object sender, EventArgs e)
        {
            string jsonStr = textBoxOriginal.Text;
            string jsonStr2 = textBoxNew.Text;

            JObject jobject = JObject.Parse(jsonStr);
            JObject jobject2 = JObject.Parse(jsonStr2);

            CompareHandler handler = new CompareHandler();

            CompareStruct compareResult = handler.CompareStruct(jobject, jobject2);

            string xml = compareResult.ToXML("descriptor");
            textBoxResultXML.Text = xml;
        }

        private void buttonHTML_Click(object sender, EventArgs e)
        {
            string xmlStr = textBoxResultXML.Text;
            string xslStr = richTextBoxXSL.Text;

            richTextBoxHTML.Text = XslTransform(xmlStr, xslStr);

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


        private void button1_Click(object sender, EventArgs e)
        {
            Collection<MultiLineDiff> result = new LineDiff().Diff(textBoxOriginal.Text, textBoxNew.Text);

        }

    }

  
}
