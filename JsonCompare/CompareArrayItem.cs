using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare
{
	public class CompareArrayItem
	{
		public ChangeType Type
		{
			get;
			set;
		}

		public object CompareResult
		{
			get;
			set;
		}
	}
}
