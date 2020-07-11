using HospitalAppoimentSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls.WebParts;

namespace HospitalAppoimentSolution.Client.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        IDepartmentBusiness _departmentBusiness;
        INewsBusiness _newsBusiness;
        IDoctorBusiness _doctorBusiness;
        IPromotionBusiness _promotionBusiness;
        public HomeController(IDepartmentBusiness departmentBusiness,INewsBusiness newsBusiness,IDoctorBusiness doctorBusiness,IPromotionBusiness promotionBusiness)
        {
            this._departmentBusiness = departmentBusiness;
            this._doctorBusiness = doctorBusiness;
            this._newsBusiness = newsBusiness;
            this._promotionBusiness = promotionBusiness;
        }
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Deparment()
        {
            try
            {
                var result = _departmentBusiness.GetAll(true);
                return PartialView(result);
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
        public ActionResult Promotions()
        {
            try
            {
                var result = _promotionBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult News()
        {
            try
            {
                var result = _newsBusiness.GetAll();
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
    }
}