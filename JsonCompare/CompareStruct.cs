using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare
{
	public class CompareStruct
	{
		private Dictionary<string, object> fields = new Dictionary<string, object>();

		public Dictionary<string, object> Fields
		{
			get
			{
				return fields;
			}
		}
	}
}
