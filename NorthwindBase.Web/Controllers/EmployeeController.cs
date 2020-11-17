using AutoMapper;
using NorthwindBase.Dto.Employee;
using NorthwindBase.Service.Employee;
using NorthwindBase.Web.Models.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NorthwindBase.Web.Controllers
{
    public class EmployeeController : Controller
    {
        private EmployeeService _employeeService;

        public EmployeeController()
        {
            _employeeService = new EmployeeService();
        }

        // GET: Employee
        public ActionResult Information()
        {
            EmployeeModel model = new EmployeeModel();

            model.EmployeeList = _employeeService.GetAllEmployees();

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            EmployeeModel model = new EmployeeModel();

            var config = new MapperConfiguration(cfg =>
                cfg.CreateMap<EmployeeDto, EmployeeModel>()
            );
            var mapper = config.CreateMapper();
            var des = mapper.Map<EmployeeModel>(_employeeService.GetEmployee(id));
            
            return View(des);
        }

        public ActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Information");
        }
    }
}