using AutoMapper;
using NorthwindBase.Dto.Employee;
using NorthwindBase.Service.Employee;
using NorthwindBase.Utility.Helper;
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
        private IEmployeeService _employeeService;
        private IMapper _mapper;

        /// <summary>
        /// 建構子
        /// </summary>
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
            _mapper = new MapperConfiguration(cfg =>
                cfg.CreateMap<EmployeeDto, EmployeeModel>()
            ).CreateMapper();
        }

        /// <summary>
        /// 員工資訊
        /// </summary>
        /// <returns></returns>
        public ActionResult Information()
        {
            EmployeeModel model = new EmployeeModel()
            {
                ActionMode = ActionType.Query
            };
            model.EmployeeList = _employeeService.GetAllEmployees();

            return View(model);
        }

        /// <summary>
        /// 新增員工頁
        /// </summary>
        /// <returns></returns>
        public ActionResult Add()
        {
            EmployeeModel model = new EmployeeModel()
            {
                ActionMode = ActionType.Add,
                TitleOfCourtesyDDL = new SelectList(DropDownListHelper.TitleOfCourtesy(), "key", "value")
            };
            return View("Detail", model);
        }

        /// <summary>
        /// 新增員工存檔
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddDetail(EmployeeModel model)
        {
            var isSuccess = _employeeService.AddEmployee(model);
            return Json(new { Result = isSuccess }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 員工明細
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Detail(int id)
        {
            var des = _mapper.Map<EmployeeModel>(_employeeService.GetEmployee(id));
            des.ActionMode = ActionType.Edit;
            des.TitleOfCourtesyDDL = new SelectList(DropDownListHelper.TitleOfCourtesy(), "key", "value");
            return View(des);
        }

        /// <summary>
        /// 員工明細存檔
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult SaveDetail(EmployeeModel model)
        {
            var isSuccess = _employeeService.EditEmployee(model);
            return Json(new { Result = isSuccess }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// 刪除員工資料
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Delete(int id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Information");
        }
    }
}