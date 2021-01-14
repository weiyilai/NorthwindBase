﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBase.Dto.Employee
{
    /// <summary>
    /// 員工資料
    /// </summary>
    public class EmployeeDto
    {
        /// <summary>
        /// 員工編號
        /// </summary>
        public int EmployeeID { get; set; }
        /// <summary>
        /// 員工名字
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// 員工姓氏
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// 抬頭
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 稱謂
        /// </summary>
        public string TitleOfCourtesy { get; set; }
        public DateTime? BirthDate { get; set; }
        public DateTime? HireDate { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string PostalCode { get; set; }
        public string Country { get; set; }
        public string HomePhone { get; set; }
        public string Extension { get; set; }
        public byte[] Photo { get; set; }
        public string Notes { get; set; }
        public int? ReportsTo { get; set; }
        public string PhotoPath { get; set; }
    }
}
