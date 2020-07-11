using HospitalAppoimentSolution.Business.Core;
using HospitalAppoimentSolution.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalAppoimentSolution.Admin.Controllers
{
    [CheckLogin]
    public class ShiftTimeController : Controller
    {
        // GET: ShiftTime
        IShiftTimeBusiness _shiftBusiness;
        public ShiftTimeController(IShiftTimeBusiness shiftTimeBusiness)
        {
            this._shiftBusiness = shiftTimeBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _shiftBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(ShiftTimeView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_shiftBusiness.Add(model))
                    {
                        _shiftBusiness.Save();
                        return Redirect("/ShiftTime/List");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                var result = _shiftBusiness.GetByID(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(ShiftTimeView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_shiftBusiness.Edit(model))
                    {
                        _shiftBusiness.Save();
                        return Redirect("/ShiftTime/List");
                    }
                }
                return View(model);
            }
            catch (Exception)
            {

                return View(model);
            }
        }
        public string Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_shiftBusiness.Delete(id))
                {
                    _shiftBusiness.Save();
                }
                return "";
            }
            catch (Exception)
            {
                return "Đã xảy ra lỗi!";
            }
        }
    }
}