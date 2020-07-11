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
    public class DoctorController : Controller
    {
        IDoctorBusiness _doctorBusiness;
        IDepartmentBusiness _departmentBusiness;
        public DoctorController(IDoctorBusiness doctorBusiness,IDepartmentBusiness departmentBusiness)
        {
            this._doctorBusiness = doctorBusiness;
            this._departmentBusiness = departmentBusiness;
        }
        // GET: Doctor
        public ActionResult List()
        {
            try
            {
                var result = _doctorBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Add()
        {
            ViewBag.DepartmentLst = _departmentBusiness.GetAll(true);
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Add(DoctorView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    model.DateCreate = DateTime.Now;
                    if (_doctorBusiness.Add(model))
                    {
                        _doctorBusiness.Save();
                        return Redirect("/Doctor/List");
                    }
                }
                ViewBag.DepartmentLst = _departmentBusiness.GetAll(true);
                return View(model);
            }
            catch (Exception)
            {
                ViewBag.DepartmentLst = _departmentBusiness.GetAll(true);
                return View(model);
            }
        }
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.DepartmentLst = _departmentBusiness.GetAll(true);
                var result = _doctorBusiness.GetByID(id);
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Edit(DoctorView model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (_doctorBusiness.Edit(model))
                    {
                        _doctorBusiness.Save();
                        return Redirect("/Doctor/List");
                    }
                }
                ViewBag.DepartmentLst = _departmentBusiness.GetAll(true);
                return View(model);
            }
            catch (Exception)
            {
                ViewBag.DepartmentLst = _departmentBusiness.GetAll(true);
                return View(model);
            }
        }
    }
}