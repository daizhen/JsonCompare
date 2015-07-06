using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JsonCompare
{
    public class CompareArray : IXML
	{
		private Collection<object> items = new Collection<object>();
		public Collection<object> Items
		{
			get
			{
				return items;
			}
		}

        public string ToXML(string rootName)
        {
            XmlDocument xmlDocument = new XmlDocument();
            var rootElement = xmlDocument.CreateElement(rootName);

            foreach (var item in items)
            {
                rootElement.InnerXml += (item as IXML).ToXML(rootName);
            }
            //xmlDocument.DocumentElement.AppendChild(rootElement);
            return rootElement.OuterXml;
        }
    }
}
