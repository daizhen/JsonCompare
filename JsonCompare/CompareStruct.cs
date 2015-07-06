using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace JsonCompare
{
    public class CompareStruct : IXML
	{
		private Dictionary<string, object> fields = new Dictionary<string, object>();

		public Dictionary<string, object> Fields
		{
			get
			{
				return fields;
			}
		}

        public string ToXML(string rootName)
        {
            StringBuilder xmlStr = new StringBuilder();

            foreach (var item in fields)
            {
                xmlStr.Append((item.Value as IXML).ToXML(item.Key));
            }

            return "<" + rootName + ">" + (xmlStr.ToString()) + "</" + rootName + ">";
        }
    }
}
