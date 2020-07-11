using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace HospitalAppoimentSolution.Client
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
                name: "PatientLogin",
                url: "dang-nhap.html",
                defaults: new { controller = "Patient", action = "Login", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PatientRegister",
                url: "dang-ky.html",
                defaults: new { controller = "Patient", action = "Register", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PatientInfoChange",
                url: "cap-nhat-tai-khoan.html",
                defaults: new { controller = "Patient", action = "InfoChange", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "PatientProfile",
                url: "thong-tin-tai-khoan.html",
                defaults: new { controller = "Patient", action = "Profiles", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "NewsList",
                url: "tin-tuc.html",
                defaults: new { controller = "News", action = "List", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "NewsDetail",
                url: "tin-tuc/{title}-{id}.html",
                defaults: new { controller = "News", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PromotionList",
                url: "khuyen-mai.html",
                defaults: new { controller = "Promotion", action = "List", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PromotionDetail",
                url: "khuyen-mai/{title}-{id}.html",
                defaults: new { controller = "Promotion", action = "Detail", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "DoctorList",
                url: "bac-si.html",
                defaults: new { controller = "Doctor", action = "List", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DoctorDList",
                url: "phong-ban/{title}-{id}.html",
                defaults: new { controller = "Doctor", action = "DList", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DoctorDetail",
                url: "bac-si/{title}-{id}.html",
                defaults: new { controller = "Doctor", action = "Detail", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DoctorBook",
                url: "book-{id}.html",
                defaults: new { controller = "Doctor", action = "Schedule", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "DoctorConfirmBook",
                url: "xac-nhan-dat-lich.html",
                defaults: new { controller = "Doctor", action = "ConfirmBooking", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Payment",
                url: "thanh-toan.html",
                defaults: new { controller = "Doctor", action = "Payment", id = UrlParameter.Optional }
            );
            
            routes.MapRoute(
                name: "PaymentCofirm",
                url: "xac-nhan-thanh-toan-noi-dia.html",
                defaults: new { controller = "Doctor", action = "Confirm", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "PaymentGlobalConfirm",
                url: "xac-nhan-thanh-toan-quoc-te.html",
                defaults: new { controller = "Doctor", action = "Confirm_Global", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Home",
                url: "",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
