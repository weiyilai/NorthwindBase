using NorthwindBase.Model.Northwind;
using NorthwindBase.Repository.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace NorthwindBase.Repository.Employee
{
    public class EmployeeRepository : CommonRepository<Employees>
    {
        /// <summary>
        /// 建構子
        /// </summary>
        /// <param name="dbContext"></param>
        public EmployeeRepository(DbContext dbContext) : 
            base(dbContext)
        {
        }
    }
}
