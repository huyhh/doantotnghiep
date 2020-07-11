using HospitalAppoimentSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalAppoimentSolution.Admin.Controllers
{
    [CheckLogin]
    public class PatientController : Controller
    {
        IPatientBusiness _patientBusiness;
        public PatientController(IPatientBusiness patientBusiness)
        {
            this._patientBusiness = patientBusiness;
        }
        // GET: Patient
        public ActionResult List()
        {
            try
            {
                var result = _patientBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {
                return View();
            }
        }
    }
}