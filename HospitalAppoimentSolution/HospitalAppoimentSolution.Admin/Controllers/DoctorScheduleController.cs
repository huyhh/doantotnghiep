using HospitalAppoimentSolution.Business.Core;
using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Helper.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalAppoimentSolution.Admin.Controllers
{
    [CheckLogin]
    public class DoctorScheduleController : Controller
    {
        IDoctorScheduleBusiness _scheduleBusiness;
        IShiftTimeBusiness _shiftTimeBusiness;
        public DoctorScheduleController(IDoctorScheduleBusiness scheduleBusiness,IShiftTimeBusiness shiftTimeBusiness)
        {
            this._scheduleBusiness = scheduleBusiness;
            this._shiftTimeBusiness = shiftTimeBusiness;
        }
        // GET: DoctorSchedule
        public ActionResult List(int id)
        {
            try
            {
                ViewBag.DoctorID = id;
                var result = _scheduleBusiness.GetByDoctor(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        public ActionResult Add(int id)
        {
            try
            {
                ViewBag.ShiftLst = _shiftTimeBusiness.GetAll();
                ViewBag.DayLst = CreateDay.getLstDay();
                DoctorScheduleView view = new DoctorScheduleView();
                view.ID = id;
                return View(view);
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Add(DoctorScheduleView model)
        {
            try
            {
                var check = _scheduleBusiness.GetEdit(model.ID, model.Day);
                if (check != null && check.ID!=0)
                {
                    ModelState.AddModelError("ExistsDataError", "Lịch làm việc này đã được thêm. Vui lòng chỉnh sửa chi tiết, không thêm mới");
                    ViewBag.ShiftLst = _shiftTimeBusiness.GetAll();
                    ViewBag.DayLst = CreateDay.getLstDay();
                    return View(model);
                }
                if (_scheduleBusiness.Add(model))
                {
                    _scheduleBusiness.Save();
                    return Redirect($"/DoctorSchedule/List/{model.ID}");
                }
                ViewBag.ShiftLst = _shiftTimeBusiness.GetAll();
                ViewBag.DayLst = CreateDay.getLstDay();
                return View(model);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Edit(int id,int day)
        {
            try
            {
                ViewBag.ShiftLst = _shiftTimeBusiness.GetAll();
                ViewBag.DayLst = CreateDay.getLstDay();
                var result = _scheduleBusiness.GetEdit(id, day);

                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult Edit(DoctorScheduleView model)
        {
            try
            {
                if (_scheduleBusiness.Edit(model))
                {
                    _scheduleBusiness.Save();
                    return Redirect($"/DoctorSchedule/List/{model.ID}");
                }
                ViewBag.ShiftLst = _shiftTimeBusiness.GetAll();
                ViewBag.DayLst = CreateDay.getLstDay();
                return View(model);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}