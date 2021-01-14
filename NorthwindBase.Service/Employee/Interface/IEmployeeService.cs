using NorthwindBase.Dto.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindBase.Service.Employee
{
    public interface IEmployeeService
    {
        List<EmployeeDto> GetAllEmployees();
        bool AddEmployee(EmployeeDto dto);
        EmployeeDto GetEmployee(int id);
        bool EditEmployee(EmployeeDto dto, string account);
        void DeleteEmployee(int id);
    }
}
