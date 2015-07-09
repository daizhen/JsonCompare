using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JsonCompareLib
{
	public class CompareBasic: IXML
	{
		public ChangeType Type
		{
			get;
			set;
		}

		public string OriginalValue
		{
			get;
			set;
		}

		public string NewValue
		{
			get;
			set;
		}

        public string ToXML(string rootName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            var rootElement = xmlDocument.CreateElement(rootName);

            var typeElement = xmlDocument.CreateElement("Type");
            typeElement.InnerText = Type.ToString();

            var originalValueElement = xmlDocument.CreateElement("OriginalValue");
            originalValueElement.InnerText = OriginalValue;

            var newValueElement = xmlDocument.CreateElement("NewValue");
            newValueElement.InnerText = NewValue;

            rootElement.AppendChild(typeElement);
            rootElement.AppendChild(originalValueElement);
            rootElement.AppendChild(newValueElement);
            return rootElement.OuterXml;
        }
    }
}
