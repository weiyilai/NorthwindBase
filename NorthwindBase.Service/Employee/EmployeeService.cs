using AutoMapper;
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
        private IMapper _mapper;

        public EmployeeService()
        {
            _mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<Employees, EmployeeDto>()
            ).CreateMapper();
        }

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
                    var des = _mapper.Map<List<EmployeeDto>>(query.ToList());
                    return des;
                }
                else
                {
                    return new List<EmployeeDto>();
                }
            }
        }

        /// <summary>
        /// 取得指定員工資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public EmployeeDto GetEmployee(int id)
        {
            using (EmployeeRepository employeeRepository = new EmployeeRepository(_dbEntities))
            {
                var query = employeeRepository.Get(q => q.EmployeeID == id);
                if (query.Any())
                {
                    var des = _mapper.Map<EmployeeDto>(query.SingleOrDefault());
                    return des;
                }
                else
                {
                    return new EmployeeDto();
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
                var query = employeeRepository.Get(q => q.EmployeeID == id);
                if (query.Any())
                {
                    var entity = query.SingleOrDefault();
                    employeeRepository.Delete(entity);
                    employeeRepository.SaveChanges();
                }
            }
        }
    }
}
