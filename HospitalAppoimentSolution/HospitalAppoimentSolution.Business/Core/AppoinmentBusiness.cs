using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppoimentSolution.Services.Infrastructure;

namespace HospitalAppoimentSolution.Business.Core
{
    public interface IAppoinmentBusiness
    {
        IEnumerable<AppoinmentView> GetByPatient(int id);
        IEnumerable<AppoinmentView> GetByDoctor(int id);
        IEnumerable<AppoinmentView> GetAll();
        bool Add(AppoinmentView model);
        AppoinmentView GetByCode(string code);
        bool UpdateStatus(long id, int status);
        bool UpdatePayment(long id);
        bool CheckTimeExists(string date, string time, int id);
        void Save();
    }
   public class AppoinmentBusiness : IAppoinmentBusiness
    {
        private IAppoinmentRepository _appoinment;
        private IUnitOfWork _unitOfWork;
        public AppoinmentBusiness(IAppoinmentRepository appoinment, IUnitOfWork unitOfWork)
        {
            _appoinment = appoinment;
            _unitOfWork = unitOfWork;
        }

        public bool Add(AppoinmentView model)
        {
            return _appoinment.Add(model);
        }

        public bool CheckTimeExists(string date, string time, int id)
        {
            return _appoinment.CheckTimeExists(date, time, id);
        }

        public IEnumerable<AppoinmentView> GetAll()
        {
            return _appoinment.GetAll();
        }

        public AppoinmentView GetByCode(string code)
        {
            return _appoinment.GetByCode(code);
        }

        public IEnumerable<AppoinmentView> GetByDoctor(int id)
        {
            return _appoinment.GetByDoctor(id);
        }

        public IEnumerable<AppoinmentView> GetByPatient(int id)
        {
            return _appoinment.GetByPatient(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public bool UpdatePayment(long id)
        {
            return _appoinment.UpdatePayment(id);
        }

        public bool UpdateStatus(long id, int status)
        {
            return _appoinment.UpdateStatus(id, status);
        }
    }
}
