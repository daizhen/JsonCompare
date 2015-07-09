using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonCompareLib
{
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
