using NorthwindBase.Dto.Employee;
using NorthwindBase.Model.Northwind;
using NorthwindBase.Repository.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBase.Service.Employee
{
    public class EmployeeService
    {
        private NorthwindEntities _dbEntities = new NorthwindEntities();

        /// <summary>
        /// 取得所有員工資料
        /// </summary>
        /// <returns></returns>
        public List<EmployeeDto> GetAllEmployees()
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository(_dbEntities))
            {
                var query = employeeRepository.GetAll();

                if (query.Any())
                {
                    return query.Select(q => new EmployeeDto
                    {
                        EmployeeID = q.EmployeeID,
                        LastName = q.LastName,
                        FirstName = q.FirstName,
                        Title = q.Title,
                        TitleOfCourtesy = q.TitleOfCourtesy,
                        BirthDate = q.BirthDate,
                        HireDate = q.HireDate,
                        Address = q.Address,
                        City = q.City,
                        Region = q.Region,
                        PostalCode = q.PostalCode,
                        Country = q.Country,
                        HomePhone = q.HomePhone,
                        Extension = q.Extension,
                        Photo = q.Photo,
                        Notes = q.Notes,
                        ReportsTo = q.ReportsTo,
                        PhotoPath = q.PhotoPath
                    }).ToList();
                }
                else
                {
                    return new List<EmployeeDto>();
                }
            }
        }

        /// <summary>
        /// 刪除指定員工
        /// </summary>
        /// <param name="id"></param>
        public void DeleteEmployee(int id)
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository(_dbEntities))
            {
                var entity = employeeRepository.Get(q => q.EmployeeID == id);
                employeeRepository.Delete(entity);
                employeeRepository.SaveChanges();
            }
        }
    }
}
