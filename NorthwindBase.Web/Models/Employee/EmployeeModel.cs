using NorthwindBase.Dto.Employee;
using NorthwindBase.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindBase.Web.Models.Employee
{
    public class EmployeeModel : EmployeeDto
    {
        public ActionType ActionMode { get; set; }
        public List<EmployeeDto> EmployeeList { get; set; }
        public SelectList TitleOfCourtesyDDL { get; set; }

        /// <summary>
        /// 建構子
        /// </summary>
        public EmployeeModel()
        {
            EmployeeList = new List<EmployeeDto>();
        }
    }
}