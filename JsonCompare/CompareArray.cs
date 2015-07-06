using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompare
{
	public class CompareArray
	{
		private Collection<object> items = new Collection<object>();
		public Collection<object> Items
		{
			get
			{
				return items;
			}
		}
	}
}
