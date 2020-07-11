
using HospitalAppoimentSolution.Business.Core;
using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HospitalAppoimentSolution.Data.Models;

namespace HospitalAppoimentSolution.Admin.Controllers
{
    [CheckLogin]
    public class DashboardController : Controller
    {
        // GET: Dashboard
        IDoctorBusiness _doctorBusiness;
        IPatientBusiness _patientBusiness;
        IAppoinmentBusiness _appoinmentBusiness;
        public DashboardController(IDoctorBusiness doctorBusiness,IAppoinmentBusiness appoinmentBusiness,IPatientBusiness patientBusiness)
        {
            this._appoinmentBusiness = appoinmentBusiness;
            this._doctorBusiness = doctorBusiness;
            this._patientBusiness = patientBusiness;
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult TopWidget()
        {
            try
            {
                ViewBag.NumberDoctor = _doctorBusiness.GetAll().Count();
                ViewBag.NumberPatient = _patientBusiness.GetAll().Count();
                ViewBag.NumberAppointment = _appoinmentBusiness.GetAll().Count();
                ViewBag.Revenue = _appoinmentBusiness.GetAll().Sum(x => x.Amount);
                return PartialView();
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Doctors()
        {
            try
            {
                var result = _doctorBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Patients()
        {
            try
            {
                var result = _patientBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Appointments()
        {
            try
            {
                var result = _appoinmentBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }

    }
}