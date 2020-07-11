using HospitalAppoimentSolution.Data.Models;
using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Services.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using HospitalAppoimentSolution.Helper.Core;

namespace HospitalAppoimentSolution.Services.Repositories
{
    public interface IPromotionRepository : IRepository<Promotion>
    {
        IEnumerable<PromotionView> GetAll();
        PromotionView GetByID(long id);
        bool Add(PromotionView model);

        bool Edit(PromotionView model);
        bool Delete(long id);
        bool CheckExistsCode(string code);
        PromotionView ApplyPromotion(string code);
    }
    public class PromotionRepository : RepositoryBase<Promotion>, IPromotionRepository
    {
        public PromotionRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
        public bool CheckExistsCode(string code)
        {
            try
            {
                var _item = DbContext.Promotions.FirstOrDefault(x => x.Code == code);
                if (_item != null && _item.ID != 0)
                    return true;
                return false;
            }
            catch (Exception)
            {

                return true;
            }
        }
        public bool Add(PromotionView model)
        {
            try
            {
                int year, month, day;
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                if (model.StartDate == "" || model.EndDate == "")
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                    day = DateTime.Now.Day;
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = DateTime.Now.AddYears(1).Year;
                    month = DateTime.Now.AddYears(1).Month;
                    day = DateTime.Now.AddYears(1).Day;
                    end = new DateTime(year, month, day, 23, 59, 0);
                }
                else
                {
                    year = Convert.ToInt32(model.StartDate.Split('/')[2]);
                    month = Convert.ToInt32(model.StartDate.Split('/')[1]);
                    day = Convert.ToInt32(model.StartDate.Split('/')[0]);
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = Convert.ToInt32(model.EndDate.Split('/')[2]);
                    month = Convert.ToInt32(model.EndDate.Split('/')[1]);
                    day = Convert.ToInt32(model.EndDate.Split('/')[0]);
                    end = new DateTime(year, month, day, 0, 0, 0);
                }

                Promotion promotion = new Promotion();
                promotion.Avatar = "http://localhost:44351" + model.Avatar;
                promotion.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                promotion.Desc = model.Desc;
                promotion.EndDate = end;
                promotion.ID = model.ID;
                promotion.StartDate = start;
                promotion.Status = model.Status;
                promotion.Title = model.Title;
                promotion.Type = model.Type;
                promotion.Code = $"{DateTime.Now.ToString("ddMMyy")}-{RandomUtils.RandomString(4, 6, true, true, false)}";
                promotion.DoctorApply = model.DoctorApply;
                promotion.AmountReduced = model.AmountReduced;
                promotion.PercentReduced = model.PercentReduced;

                DbContext.Promotions.Add(promotion);

                return true;
            }
            catch (System.Exception ex)
            {

                return false;
            }
        }

        public bool Delete(long id)
        {
            try
            {
                Promotion promotion = DbContext.Promotions.Find(id);
                if (promotion != null)
                {
                    promotion.Status = false;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }

        public bool Edit(PromotionView model)
        {
            try
            {
                int year, month, day;
                DateTime start = DateTime.Now;
                DateTime end = DateTime.Now;

                if (model.StartDate == "" || model.EndDate == "")
                {
                    year = DateTime.Now.Year;
                    month = DateTime.Now.Month;
                    day = DateTime.Now.Day;
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = DateTime.Now.AddYears(1).Year;
                    month = DateTime.Now.AddYears(1).Month;
                    day = DateTime.Now.AddYears(1).Day;
                    end = new DateTime(year, month, day, 23, 59, 0);
                }
                else
                {
                    year = Convert.ToInt32(model.StartDate.Split('/')[2]);
                    month = Convert.ToInt32(model.StartDate.Split('/')[1]);
                    day = Convert.ToInt32(model.StartDate.Split('/')[0]);
                    start = new DateTime(year, month, day, 0, 0, 0);
                    year = Convert.ToInt32(model.EndDate.Split('/')[2]);
                    month = Convert.ToInt32(model.EndDate.Split('/')[1]);
                    day = Convert.ToInt32(model.EndDate.Split('/')[0]);
                    end = new DateTime(year, month, day, 0, 0, 0);
                }

                Promotion promotion = DbContext.Promotions.Find(model.ID);
                if (promotion != null)
                {
                    if (!model.Avatar.Contains("http"))
                        promotion.Avatar = "http://localhost:44351" + model.Avatar;
                    else
                        promotion.Avatar = model.Avatar;
                    promotion.Content = model.Content.Replace("\"/Content/FileUploads/", "\"http://localhost:44351/Content/FileUploads/");
                    promotion.Desc = model.Desc;
                    promotion.EndDate = end;
                    promotion.ID = model.ID;
                    promotion.StartDate = start;
                    promotion.Status = model.Status;
                    promotion.Title = model.Title;
                    promotion.Type = model.Type;
                    promotion.DoctorApply = model.DoctorApply;
                    promotion.AmountReduced = model.AmountReduced;
                    promotion.PercentReduced = model.PercentReduced;
                    return true;
                }
                return false;
            }
            catch (System.Exception)
            {

                return false;
            }
        }


        public IEnumerable<PromotionView> GetAll()
        {
            try
            {
                List<PromotionView> promotions = new List<PromotionView>();
                var _lst = from p in DbContext.Promotions
                           where p.EndDate >= DateTime.Now
                           && p.Status == true
                           select new
                           {
                               ID = p.ID,
                               Title = p.Title,
                               Avatar = p.Avatar,
                               Desc = p.Desc,
                               Content = p.Content,
                               StartDate = p.StartDate,
                               EndDate = p.EndDate,
                               Type = p.Type,
                               Code = p.Code,
                               DoctorApply = p.DoctorApply,
                               AmountReduced = p.AmountReduced,
                               PercentReduced = p.PercentReduced
                           };
                if (_lst != null && _lst.Count() > 0)
                {
                    foreach (var item in _lst)
                    {
                        PromotionView promotion = new PromotionView();
                        promotion.Avatar = item.Avatar;
                        promotion.Content = item.Content;
                        promotion.Desc = item.Desc;
                        promotion.EndDate = item.EndDate.ToString("dd/MM/yyyy");
                        promotion.ID = item.ID;
                        promotion.StartDate = item.StartDate.ToString("dd/MM/yyyy");
                        promotion.Title = item.Title;
                        promotion.Type = item.Type;
                        promotion.Code = item.Code;
                        promotion.AmountReduced = item.AmountReduced;
                        promotion.PercentReduced = item.PercentReduced;
                        promotion.DoctorApply = item.DoctorApply;
                        promotions.Add(promotion);
                    }
                    return promotions;
                }
                return null;
            }
            catch (System.Exception)
            {

                return null;
            }
        }


        public PromotionView GetByID(long id)
        {
            try
            {
                var _item = DbContext.Promotions.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    PromotionView promotion = new PromotionView();
                    promotion.Avatar = _item.Avatar;
                    promotion.Content = _item.Content;
                    promotion.Desc = _item.Desc;
                    promotion.EndDate = _item.EndDate.ToString("dd/MM/yyyy");
                    promotion.ID = _item.ID;
                    promotion.StartDate = _item.StartDate.ToString("dd/MM/yyyy");
                    promotion.Title = _item.Title;
                    promotion.Type = _item.Type;
                    promotion.Code = _item.Code;
                    promotion.DoctorApply = _item.DoctorApply;
                    promotion.AmountReduced = _item.AmountReduced;
                    promotion.PercentReduced = _item.PercentReduced;
                    return promotion;
                }
                return null;
            }
            catch (Exception)
            {

                return null;
            }
        }

        public PromotionView ApplyPromotion(string code)
        {
            try
            {
                var _item = DbContext.Promotions.FirstOrDefault(x => x.Code == code);
                if (_item != null && _item.ID != 0)
                {
                    DateTime date = DateTime.Now;
                    DateTime start = _item.StartDate;
                    DateTime end = _item.EndDate;
                    if ((date - start).TotalDays >= 0 && (end - date).TotalDays >= 0)
                    {
                        PromotionView promotion = new PromotionView();
                        promotion.AmountReduced = _item.AmountReduced;
                        promotion.Avatar = _item.Avatar;
                        promotion.Code = _item.Code;
                        promotion.ID = _item.ID;
                        promotion.PercentReduced = _item.PercentReduced;
                        promotion.DoctorApply = _item.DoctorApply;
                        promotion.Type = _item.Type;
                        return promotion;
                    }    
                }
                return new PromotionView();
            }
            catch (Exception)
            {

                return new PromotionView();
            }
        }
    }
}
