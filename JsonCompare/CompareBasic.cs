using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare
{
	public class CompareBasic
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
	}
}
