using HospitalAppoimentSolution.Business.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalAppoimentSolution.Client.Controllers
{
    public class PromotionController : Controller
    {
        // GET: Promotion
        IPromotionBusiness _promotionBusiness;
        public PromotionController(IPromotionBusiness promotionBusiness)
        {
            this._promotionBusiness = promotionBusiness;
        }
        // GET: News
        public ActionResult List()
        {
            try
            {
                var result = _promotionBusiness.GetAll();
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Detail(long id)
        {
            try
            {
                var result = _promotionBusiness.GetByID(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
    }
}