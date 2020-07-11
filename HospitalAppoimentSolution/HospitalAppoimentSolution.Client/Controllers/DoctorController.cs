using HospitalAppoimentSolution.Business.Core;
using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Helper.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HospitalAppoimentSolution.Client.Controllers
{
    public class DoctorController : Controller
    {
        // GET: Doctor
        IDoctorBusiness _doctorBusiness;
        IAppoinmentBusiness _appoinmentBusiness;
        IDoctorScheduleBusiness _scheduleBusiness;
        IShiftTimeBusiness _shiftTimeBusiness;
        IPromotionBusiness _promotionBusiness;
        public DoctorController(IDoctorBusiness doctorBusiness,IAppoinmentBusiness appoinmentBusiness,IDoctorScheduleBusiness scheduleBusiness,IShiftTimeBusiness shiftTimeBusiness,IPromotionBusiness promotionBusiness)
        {
            this._appoinmentBusiness = appoinmentBusiness;
            this._doctorBusiness = doctorBusiness;
            this._shiftTimeBusiness = shiftTimeBusiness;
            this._scheduleBusiness = scheduleBusiness;
            this._promotionBusiness = promotionBusiness;
        }
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
        public ActionResult DList(int id)
        {
            try
            {
                var result = _doctorBusiness.GetByDeparment(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult Detail(int id)
        {
            try
            {
                var result = _doctorBusiness.GetByID(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult PartialDetail(int id)
        {
            try
            {
                var result = _scheduleBusiness.GetByDoctor(id);
                return PartialView(result);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult Schedule(int id)
        {
            try
            {
                var result = _doctorBusiness.GetByID(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        public ActionResult PartialSchedule(int id)
        {
            try
            {
                var scheduleViews = _scheduleBusiness.GetByDoctor(id);
                ViewBag.DoctorID = id;
                DateTime dateTime = DateTime.Now.AddDays(1);
                List<ScheduleDayView> shedules = new List<ScheduleDayView>();
                if (scheduleViews != null && scheduleViews.Count() > 0)
                {
                    for (int i = 0; i < 30; i++)
                    {
                        if ((int)dateTime.DayOfWeek != 0)
                        {
                            ScheduleDayView schedule = new ScheduleDayView();
                            schedule.Date = dateTime.ToString("dd/MM/yyyy");
                            schedule.DateName = dateTime.ToString("dd MMM yyyy");
                            schedule.DayOfWeek = dateTime.DayOfWeek.ToString();
                            var time = scheduleViews.FirstOrDefault(x => x.Day == (int)dateTime.DayOfWeek);
                            if (time != null)
                            {
                                List<Time> lstTimes = new List<Time>();
                                foreach (var item in time.ShiftTimes)
                                {
                                    int start = item.StartTime.Contains(':') ? Convert.ToInt32(item.StartTime.Split(':')[0]) : 7;
                                    int end = item.EndTime.Contains(':') ? Convert.ToInt32(item.EndTime.Split(':')[0]) : 16;
                                    for (int j = start; j <= end; j++)
                                    {
                                        Time lstTime = new Time();
                                        lstTime.Name = j + ":00";
                                        if (_appoinmentBusiness.CheckTimeExists(dateTime.ToString("dd/MM/yyyy"), j + ":00", id))
                                            lstTime.IsSold = true;
                                        else
                                            lstTime.IsSold = false;
                                        lstTimes.Add(lstTime);
                                    }
                                }
                                if (lstTimes != null && lstTimes.Count() > 0)
                                    schedule.LstTime = lstTimes;
                            }
                            shedules.Add(schedule);
                            
                        }
                        dateTime = dateTime.AddDays(1);
                    }
                }

                return PartialView(shedules);
            }
            catch (Exception)
            {

                return PartialView();
            }
        }
        public ActionResult ConfirmBooking(int id,string date,string time)
        {
            try
            {
                ViewBag.Date = date;
                ViewBag.Time = time;
                var result = _doctorBusiness.GetByID(id);
                return View(result);
            }
            catch (Exception)
            {

                return View();
            }
        }
        [HttpPost]
        public ActionResult CheckPromotion(ApplyPromotionParam model)
        {
            try
            {
                if (model != null && model.Code != "")
                {
                    var promotion = _promotionBusiness.ApplyPromotion(model.Code);
                    if (promotion != null && promotion.ID != 0)
                    {
                        double reduce = 0;
                        if(promotion.DoctorApply!=null && promotion.DoctorApply != "")
                        {
                            if (promotion.DoctorApply.Contains(model.DoctorID.ToString()))
                            {
                                if (promotion.Type == 1)

                                    reduce = promotion.AmountReduced;
                                else
                                    reduce = (model.Price * promotion.PercentReduced) / 100;
                                return Json(new ApplyPromotionResponse { Status = 1, Price = String.Format("{0:0,00}", model.Price - reduce), Reduce = String.Format("{0:0,00}", reduce) });
                            }
                        }
                        else
                        {
                            if (promotion.Type == 1)

                                reduce = promotion.AmountReduced;
                            else
                                reduce = (model.Price * promotion.PercentReduced) / 100;
                            return Json(new ApplyPromotionResponse { Status = 1, Price = String.Format("{0:0,00}", model.Price - reduce), Reduce = String.Format("{0:0,00}", reduce) });
                        }

                    }
                }
                return Json(new ApplyPromotionResponse { Status = -1, Price = String.Format("{0:0,00}", model.Price), Reduce = "0" });
            }
            catch (Exception)
            {

                return Json(new ApplyPromotionResponse { Status = -1, Price = String.Format("{0:0,00}", model.Price), Reduce = "0" });
            }
        }
        [HttpPost]
        public ActionResult Payment(PaymentParam model)
        {
            try
            {
                HttpCookie reqCookies = Request.Cookies["MemberLoginCookie"];
                ResponseMemberLogin login = JsonConvert.DeserializeObject<ResponseMemberLogin>(reqCookies.Value.ToString().UrlDecode());
                if (login == null || login.ID == 0)
                    return Json(new PaymentResult { Status = -1, Uri = "" });

                double reduce = 0;

                var doctor = _doctorBusiness.GetByID(model.DoctorID);

                if (doctor != null && doctor.ID != 0)
                {

                    if (model.PCode != "")
                    {
                        var promotion = _promotionBusiness.ApplyPromotion(model.PCode);
                        if (promotion != null && promotion.ID != 0)
                        {
                            if (promotion.DoctorApply == "" || promotion.DoctorApply == null)
                            {
                                if (promotion.Type == 1)
                                    reduce = promotion.AmountReduced;
                                else
                                    reduce = (doctor.Price * promotion.PercentReduced) / 100;
                            }
                            else
                            {
                                if (promotion.DoctorApply.Contains(doctor.ID.ToString()))
                                {
                                    if (promotion.Type == 1)
                                        reduce = promotion.AmountReduced;
                                    else
                                        reduce = (doctor.Price * promotion.PercentReduced) / 100;
                                }
                            }
                        }
                    }

                    AppoinmentView appoinment = new AppoinmentView();
                    appoinment.Amount = doctor.Price - reduce;
                    appoinment.Code= $"{DateTime.Now.ToString("ddMMyy")}{RandomUtils.RandomString(6, 8, true, true, false)}";
                    appoinment.Date = model.Date;
                    appoinment.Doctor = doctor.ID;
                    appoinment.IsPayment = false;
                    appoinment.Patient = login.ID;
                    appoinment.Price = doctor.Price;
                    appoinment.Reduce = reduce;
                    appoinment.Status = 0;
                    appoinment.Time = model.Time;
                    
                    if (_appoinmentBusiness.Add(appoinment))
                    {
                        _appoinmentBusiness.Save();
                        if (model.TypePay == 1)
                        {
                            string uri = CreateRequestPaymentPort((appoinment.Amount*100).ToString(), appoinment.Code, login.ID.ToString());
                            return Json(new PaymentResult { Status = 1, Uri = uri });
                        }
                        if (model.TypePay == 2)
                        {
                            string uri = CreateRequestPaymentPortGlobal((appoinment.Amount * 100).ToString(), appoinment.Code, login.ID.ToString());
                            return Json(new PaymentResult { Status = 1, Uri = uri });
                        }
                    }


                }
                return Json(new PaymentResult { Status = -1, Uri = "" });
            }
            catch (Exception)
            {

                return Json(new PaymentResult { Status = -1, Uri = "" });
            }
        }
        public ActionResult Confirm(string vpc_AdditionData, string vpc_Amount, string vpc_Command, string vpc_CurrencyCode, string vpc_Locale, string vpc_MerchTxnRef, string vpc_Merchant, string vpc_OrderInfo,
           string vpc_TransactionNo, string vpc_TxnResponseCode, string vpc_Version, string vpc_SecureHash)
        {
            Utils.WriteLogToFile("[Date]=[" + DateTime.Now + "]|[vpc_AdditionData]=[" + vpc_AdditionData + "]|[vpc_Amount]=[" + vpc_Amount + "]|[vpc_Command]=[" + vpc_Command + "]|[vpc_CurrencyCode]=[" + vpc_CurrencyCode + "]|[vpc_Locale]=[" + vpc_Locale + "]|[vpc_MerchTxnRef]=[" + vpc_MerchTxnRef + "]|[vpc_Merchant]=[" + vpc_Merchant + "]|[vpc_OrderInfo]=[" + vpc_OrderInfo + "]|[vpc_TransactionNo]=[" + vpc_TransactionNo + "]|[vpc_TxnResponseCode]=[" + vpc_TxnResponseCode + "]|[vpc_Version]=[" + vpc_Version + "]|[vpc_SecureHash]=[" + vpc_SecureHash + "]");

            AppoinmentView appointment = new AppoinmentView();
            appointment = _appoinmentBusiness.GetByCode(vpc_OrderInfo);

            bool status = false;
            if (appointment != null && appointment.ID != 0)
            {
                if (vpc_TxnResponseCode == "0")
                {
                    status = true;
                    if (!appointment.IsPayment)
                    {
                        if (_appoinmentBusiness.UpdatePayment(appointment.ID))
                            _appoinmentBusiness.Save();
                        
                    }

                }
                else
                {
                    status = false;
                    if (_appoinmentBusiness.UpdateStatus(appointment.ID, -1))
                        _appoinmentBusiness.Save();
                }
            }
            ViewBag.StatusPayment = status;
            return View(appointment);
        }
        public ActionResult Confirm_Global(string vpc_OrderInfo, string vpc_3DSECI, string vpc_AVS_Street01, string vpc_Merchant, string vpc_Card, string vpc_AcqResponseCode, string AgainLink, string vpc_AVS_Country,
            string vpc_AuthorizeId, string vpc_3DSenrolled, string vpc_RiskOverallResult, string vpc_ReceiptNo, string vpc_TransactionNo, string vpc_AVS_StateProv, string vpc_Locale, string vpc_TxnResponseCode, string vpc_VerToken,
            string vpc_Amount, string vpc_BatchNo, string vpc_Version, string vpc_AVSResultCode, string vpc_VerStatus, string vpc_Command, string vpc_Message, string Title, string vpc_3DSstatus, string vpc_SecureHash, string vpc_AVS_PostCode,
            string vpc_CSCResultCode, string vpc_MerchTxnRef, string vpc_VerType, string vpc_VerSecurityLevel, string vpc_3DSXID, string vpc_AVS_City)
        {
            string log = "[Date]=[" + DateTime.Now + "]|[vpc_OrderInfo]=[" + vpc_OrderInfo + "]|[vpc_3DSECI]=[" + vpc_3DSECI + "]|[vpc_AVS_Street01]=[" + vpc_AVS_Street01 + "]|[vpc_Merchant]=[" + vpc_Merchant + "]|[vpc_Card]=[" + vpc_Card + "]|[vpc_AcqResponseCode]=[" + vpc_AcqResponseCode + "]|";
            log += "[AgainLink]=[" + AgainLink + "]|[vpc_AVS_Country]=[" + vpc_AVS_Country + "]|[vpc_AuthorizeId]=[" + vpc_AuthorizeId + "]|[vpc_3DSenrolled]=[" + vpc_3DSenrolled + "]|[vpc_RiskOverallResult]=[" + vpc_RiskOverallResult + "]|";
            log += "[vpc_ReceiptNo] =[" + vpc_ReceiptNo + "]|[vpc_TransactionNo]=[" + vpc_TransactionNo + "]|[vpc_TxnResponseCode]=[" + vpc_TxnResponseCode + "]|[vpc_MerchTxnRef]=[" + vpc_MerchTxnRef + "]|[vpc_AVSResultCode]=[" + vpc_AVSResultCode + "]|";
            Utils.WriteLogToFile(log);
            AppoinmentView appointment = new AppoinmentView();
            appointment = _appoinmentBusiness.GetByCode(vpc_OrderInfo);

            bool status = false;
            if (appointment != null && appointment.ID != 0)
            {
                if (vpc_TxnResponseCode == "0")
                {
                    status = true;
                    if (!appointment.IsPayment)
                    {
                        if (_appoinmentBusiness.UpdatePayment(appointment.ID))
                            _appoinmentBusiness.Save();
                    }
                }
                else
                {
                    status = false;
                    if (_appoinmentBusiness.UpdateStatus(appointment.ID, -1))
                        _appoinmentBusiness.Save();
                }
            }
            ViewBag.StatusPayment = status;
            return View(appointment);
        }
        public string CreateRequestPaymentPort(string amount, string barCode, string phone)
        {
            string SECURE_SECRET = ConfigurationManager.AppSettings["SerectPaymentPort"].ToString();
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan
            VPCRequest_VN conn = new VPCRequest_VN(ConfigurationManager.AppSettings["UrlPaymentLocal"].ToString());
            conn.SetSecureSecret(SECURE_SECRET);
            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields
            conn.AddDigitalOrderField("Title", "onepay paygate");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", ConfigurationManager.AppSettings["MerchantPaymentPort"].ToString());
            conn.AddDigitalOrderField("vpc_AccessCode", ConfigurationManager.AppSettings["AccessCodePayMentPort"].ToString());
            conn.AddDigitalOrderField("vpc_MerchTxnRef", barCode.Split('-')[0]);
            conn.AddDigitalOrderField("vpc_OrderInfo", barCode);
            conn.AddDigitalOrderField("vpc_Amount", amount);
            conn.AddDigitalOrderField("vpc_Currency", "VND");
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://localhost:44345/xac-nhan-thanh-toan-noi-dia.html");
            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", "");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", "");
            conn.AddDigitalOrderField("vpc_SHIP_City", "");
            conn.AddDigitalOrderField("vpc_SHIP_Country", "");
            conn.AddDigitalOrderField("vpc_Customer_Phone", "");
            conn.AddDigitalOrderField("vpc_Customer_Email", "");
            conn.AddDigitalOrderField("vpc_Customer_Id", "");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", GetUserIP());
            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            return url;
        }
        public string CreateRequestPaymentPortGlobal(string amount, string barCode, string phone)
        {

            string SECURE_SECRET = ConfigurationManager.AppSettings["SerectPaymentPortGlobal"].ToString();
            // Khoi tao lop thu vien va gan gia tri cac tham so gui sang cong thanh toan
            VPCRequest_Global conn = new VPCRequest_Global(ConfigurationManager.AppSettings["UrlPaymentGlobal"].ToString());
            conn.SetSecureSecret(SECURE_SECRET);
            // Add the Digital Order Fields for the functionality you wish to use
            // Core Transaction Fields

            conn.AddDigitalOrderField("AgainLink", "http://onepay.vn");
            conn.AddDigitalOrderField("Title", "onepay paygate");
            conn.AddDigitalOrderField("vpc_Locale", "vn");//Chon ngon ngu hien thi tren cong thanh toan (vn/en)
            conn.AddDigitalOrderField("vpc_Version", "2");
            conn.AddDigitalOrderField("vpc_Command", "pay");
            conn.AddDigitalOrderField("vpc_Merchant", ConfigurationManager.AppSettings["MerchantPaymentPortGlobal"].ToString());
            conn.AddDigitalOrderField("vpc_AccessCode", ConfigurationManager.AppSettings["AccessCodePayMentPortGlobal"].ToString());
            conn.AddDigitalOrderField("vpc_MerchTxnRef", barCode.Split('-')[0]);
            conn.AddDigitalOrderField("vpc_OrderInfo", barCode);
            conn.AddDigitalOrderField("vpc_Amount", amount);
            conn.AddDigitalOrderField("vpc_ReturnURL", "http://localhost:44345/xac-nhan-thanh-toan-quoc-te.html");
            // Thong tin them ve khach hang. De trong neu khong co thong tin
            conn.AddDigitalOrderField("vpc_SHIP_Street01", " ");
            conn.AddDigitalOrderField("vpc_SHIP_Provice", " ");
            conn.AddDigitalOrderField("vpc_SHIP_City", " ");
            conn.AddDigitalOrderField("vpc_SHIP_Country", " ");
            conn.AddDigitalOrderField("vpc_Customer_Phone", " ");
            conn.AddDigitalOrderField("vpc_Customer_Email", " ");
            conn.AddDigitalOrderField("vpc_Customer_Id", " ");
            // Dia chi IP cua khach hang
            conn.AddDigitalOrderField("vpc_TicketNo", GetUserIP());

            // Chuyen huong trinh duyet sang cong thanh toan
            String url = conn.Create3PartyQueryString();
            return url;
        }
        private string GetUserIP()
        {
            string ipList = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];

            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}