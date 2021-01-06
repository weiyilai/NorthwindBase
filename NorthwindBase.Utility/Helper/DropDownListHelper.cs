using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBase.Utility.Helper
{
    public class DropDownListHelper
    {
        /// <summary>
        /// 下拉選單設定 TitleOfCourtesy
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> TitleOfCourtesy()
        {
            return new Dictionary<string, string>()
            {
                {"Ms.", "Ms."}, {"Mrs.", "Mrs."}, {"Mr.", "Mr."}, {"Dr.", "Dr."}
            };
        }
    }
}
