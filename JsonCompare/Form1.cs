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

        private Collection<MultiLineDiff> Diff(string originalStr, string newStr)
        {
            Regex reg = new Regex(@"\r\n");
            string[] originalLines = reg.Split(originalStr);
            string[] newLines = reg.Split(newStr);


            Collection<MultiLineDiff> trances = new Collection<MultiLineDiff>();

            int[][] tracesMatrix = new int[originalLines.Length + 1][];
            //Init matrix
            for (int i = 0; i < originalLines.Length + 1; i++)
            {
                tracesMatrix[i] = new int[newLines.Length + 1];
                for (int j = 0; j < newLines.Length + 1; j++)
                {
                    tracesMatrix[i][j] = -1;
                }
            }

             int minEditLength = MinEditLength(originalLines, newLines, 0, 0, tracesMatrix);
            trances = GetTraces(originalLines, newLines, tracesMatrix);

            string html = GenerateDiffHTML(trances, originalLines, newLines);

            return trances;

        }

        private Collection<MultiLineDiff> GetTraces(string[] originalStrs, string[] newStrs, int[][] buffer)
        {
            Collection<MultiLineDiff> trances = new Collection<MultiLineDiff>();

            int y =0;
            int x = 0;

            while (y < buffer.Length -1 && x < buffer[0].Length -1)
            {
                MultiLineDiff diffItem = new MultiLineDiff();
                diffItem.NewLine = x;
                diffItem.OriginalLine = y;

                int currentValue = buffer[y][x];

                int addLength = buffer[y][x + 1];
                int deleteLength = buffer[y + 1][x];
                int updateLength = buffer[y + 1][x + 1];

                if (currentValue == addLength + 1)
                {
                    diffItem.ChangeType = 1;
                    x++;
                }
                else if (currentValue == deleteLength + 1)
                {
                    diffItem.ChangeType = -1;
                    y++;
                }
                else
                {
                    if (originalStrs[y] == newStrs[x])
                    {
                        diffItem.ChangeType = 0;
                    }
                    else
                    {
                        diffItem.ChangeType = 2;
                    }
                    x = x + 1;
                    y = y + 1;
                }
                trances.Add(diffItem);
            }

            if (y == buffer.Length -1)
            {
                //Add
                while (x < newStrs.Length)
                {
                    MultiLineDiff diffItem = new MultiLineDiff();
                    diffItem.NewLine = x;
                    diffItem.OriginalLine = -1;
                    diffItem.ChangeType = 1;

                    trances.Add(diffItem);
                    x++;
                }
            }
            else if (x == buffer[0].Length -1)
            {
                //delete
                while (y < originalStrs.Length)
                {
                    MultiLineDiff diffItem = new MultiLineDiff();
                    diffItem.NewLine = -1;
                    diffItem.OriginalLine = y;
                    diffItem.ChangeType = -1;
                    trances.Add(diffItem);
                    y++;
                }
            }
            return trances;
        }

        private int MinEditLength(string[] originalStrs, string[] newStrs, int originalIndex, int newIndex, int[][] buffer)
        {
            if(originalIndex == originalStrs.Length && newIndex == newStrs.Length)
            {
                buffer[originalIndex][newIndex] = 0;
                return 0;
            }

            if(originalIndex == originalStrs.Length)
            {
                // Add
                buffer[originalIndex][ newIndex] = newStrs.Length - newIndex;
                return newStrs.Length - newIndex;
            }

            if(newIndex == newStrs.Length)
            {
                //Deleted
                buffer[originalIndex][newIndex] = originalStrs.Length - originalIndex;
                return originalStrs.Length - originalIndex;
            }

            if (buffer[originalIndex][newIndex] >= 0)
            {
                return buffer[originalIndex][newIndex];
            }
            else
            {
                int minLength = 0;
                if (originalStrs[originalIndex] == newStrs[newIndex])
                {
                    //Not change length
                    int lengthNonChanged = MinEditLength(originalStrs, newStrs, originalIndex + 1, newIndex + 1, buffer);

                    //Min length if delete it
                    int lengthDelete = MinEditLength(originalStrs, newStrs, originalIndex + 1, newIndex, buffer) + 1;

                    //Min length if add it
                    int lengthAdd = MinEditLength(originalStrs, newStrs, originalIndex, newIndex + 1, buffer) + 1;

                    int minTem = Math.Min(lengthNonChanged, lengthDelete);
                    if ( minTem == lengthNonChanged)
                    {
                        minLength = lengthNonChanged;
                    }
                    else
                    {
                        minLength = lengthDelete;
                    }

                    if (Math.Min(minTem, lengthAdd) == lengthAdd)
                    {
                        minLength = lengthAdd;
                    }

                }
                else
                {
                    //Min length if update  it
                    int lengthEdit = MinEditLength(originalStrs, newStrs, originalIndex + 1, newIndex + 1, buffer) + 1; 
                    //Min length if delete it
                    int lengthDelete = MinEditLength(originalStrs, newStrs, originalIndex + 1, newIndex, buffer) + 1;

                    //Min length if add it
                    int lengthAdd = MinEditLength(originalStrs, newStrs, originalIndex, newIndex + 1, buffer) + 1;

                    int minTem = Math.Min(lengthEdit, lengthDelete);
                    if (minTem == lengthEdit)
                    {
                        minLength = lengthEdit;
                    }
                    else
                    {
                        minLength = lengthDelete;
                    }

                    if (Math.Min(minTem, lengthAdd) == lengthAdd)
                    {
                        minLength = lengthAdd;
                    }
                }
                buffer[originalIndex][newIndex] = minLength;

                return minLength;
            }
        }

        private  string GenerateDiffHTML(Collection<MultiLineDiff> trances,string[] originalStrs, string[] newStrs)
        {
            StringBuilder htmlStr = new StringBuilder();

            htmlStr.Append("<table>");
            foreach (MultiLineDiff diffItem in trances)
            {
                htmlStr.Append("<tr>");
                if (diffItem.ChangeType == 0)
                {
                    htmlStr.Append("<td>").Append(EscapeHtmlString(originalStrs[diffItem.OriginalLine])).Append("</td>");
                    htmlStr.Append("<td>").Append(EscapeHtmlString(newStrs[diffItem.NewLine])).Append("</td>");

                }
                else if (diffItem.ChangeType == 1)
                {
                    htmlStr.Append("<td>").Append("&nbsp;").Append("</td>");
                    htmlStr.Append("<td>").Append(EscapeHtmlString(newStrs[diffItem.NewLine])).Append("</td>");
                }
                else if (diffItem.ChangeType == -1)
                {
                    htmlStr.Append("<td>").Append(EscapeHtmlString(originalStrs[diffItem.OriginalLine])).Append("</td>");
                    htmlStr.Append("<td>").Append("&nbsp;").Append("</td>");
                }
                else
                {
                    htmlStr.Append("<td bgcolor='yellow'>").Append(EscapeHtmlString(originalStrs[diffItem.OriginalLine])).Append("</td>");
                    htmlStr.Append("<td> bgcolor='yellow'").Append(EscapeHtmlString(newStrs[diffItem.NewLine])).Append("</td>");
                }
                htmlStr.Append("</tr>"); 
            }

            htmlStr.Append("</table>");
            return htmlStr.ToString();
        }
        private string EscapeHtmlString(string rawString)
        {
            return rawString;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Collection<MultiLineDiff> result = Diff(textBoxOriginal.Text, textBoxNew.Text);

        }

    }

    public class MultiLineDiff
    {

        public int OriginalLine
        {
            get;
            set;
        }

        public int NewLine
        {
            get;
            set;
        }

        /// <summary>
        /// 0: not changed
        /// 1: add
        /// -1: delete
        /// 2: Update
        /// </summary>
        public int ChangeType
        {
            get;
            set;
        }
    }
}
