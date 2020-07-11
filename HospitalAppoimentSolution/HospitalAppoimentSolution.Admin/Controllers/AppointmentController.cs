using HospitalAppoimentSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalAppoimentSolution.Admin.Controllers
{
    [CheckLogin]
    public class AppointmentController : Controller
    {
        // GET: Appointment
        IAppoinmentBusiness _appoinmentBusiness;
        public AppointmentController(IAppoinmentBusiness appoinmentBusiness)
        {
            this._appoinmentBusiness = appoinmentBusiness;
        }
        public ActionResult List()
        {
            try
            {
                var result = _appoinmentBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public string UpdateStatus(int id,int status)
        {
            try
            {
                if (id == 0)
                {
                    return "Mã không tồn tại!";
                }

                if (_appoinmentBusiness.UpdateStatus(id,status))
                {
                    _appoinmentBusiness.Save();
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