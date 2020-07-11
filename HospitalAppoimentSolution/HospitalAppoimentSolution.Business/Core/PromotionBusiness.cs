using HospitalAppoimentSolution.Data.Models;
using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Services.Infrastructure;
using HospitalAppoimentSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using HospitalAppoimentSolution.Helper.Core;

namespace HospitalAppoimentSolution.Business.Core
{
    public interface IPromotionBusiness
    {
        IEnumerable<Promotion> GetAlls(string[] includes, Expression<Func<Promotion, bool>> filter);
        IEnumerable<Promotion> GetAlls();
        IEnumerable<PromotionView> GetAll();
        PromotionView GetByID(long id);
        bool Add(PromotionView entity);
        bool Edit(PromotionView entity);
        bool Delete(long id);
        Promotion Update(Promotion entity, List<Expression<Func<Promotion, object>>> update = null, List<Expression<Func<Promotion, object>>> exclude = null);
        bool CheckExistsCode(string code);
        Promotion Delete(Promotion entity);
        PromotionView ApplyPromotion(string code);
        void Save();
    }
   public class PromotionBusiness : IPromotionBusiness
    {
        private IPromotionRepository _promotion;
        private IUnitOfWork _unitOfWork;
        public PromotionBusiness(IPromotionRepository promotion,IUnitOfWork unitOfWork)
        {
            _promotion = promotion;
            _unitOfWork = unitOfWork;
        }

        

        

        public Promotion Delete(Promotion entity)
        {
            return _promotion.Delete(entity);
        }

        public IEnumerable<Promotion> GetAlls()
        {
            return _promotion.GetAll(null);
        }

        public IEnumerable<Promotion> GetAlls(string[] includes, Expression<Func<Promotion, bool>> filter)
        {
            return _promotion.GetAll(includes, filter);
        }

        public Promotion Update(Promotion entity, List<Expression<Func<Promotion, object>>> update = null, List<Expression<Func<Promotion, object>>> exclude = null)
        {
            return _promotion.Update(entity, update, exclude);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

       

        public PromotionView GetByID(long id)
        {
            return _promotion.GetByID(id);
        }

        public bool Add(PromotionView entity)
        {
            
            return _promotion.Add(entity);
        }

        public bool Edit(PromotionView entity)
        {
            return _promotion.Edit(entity);
        }

        public bool Delete(long id)
        {
            return _promotion.Delete(id);
        }



        public IEnumerable<PromotionView> GetAll()
        {
            return _promotion.GetAll();
        }

        public bool CheckExistsCode(string code)
        {
            return _promotion.CheckExistsCode(code);
        }

        public PromotionView ApplyPromotion(string code)
        {
            return _promotion.ApplyPromotion(code);
        }
    }
}
