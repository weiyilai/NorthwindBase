using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBase.Utility
{
    public enum ActionType
    {
        /// <summary>
        /// 新增
        /// </summary>
        Add = 0,
        /// <summary>
        /// 修改
        /// </summary>
        Edit = 1,
        /// <summary>
        /// 查詢
        /// </summary>
        Query = 2,
        /// <summary>
        /// 刪除
        /// </summary>
        Delete = 3
    }
}
