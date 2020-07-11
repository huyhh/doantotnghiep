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
    public interface IPatientBusiness
    {
        IEnumerable<PatientView> GetAll();
        bool Add(PatientView model);
        bool Edit(PatientView model);
        bool CheckExistsAccount(string account,int id);
        ResponseMemberLogin Login(LoginModel model);
        bool ChangePass(ChangePassView model);
        PatientView GetByID(int id);
        void Save();
    }
   public class PatientBusiness : IPatientBusiness
    {
        IPatientRepository _patient;
        IUnitOfWork _unitOfWork;
        public PatientBusiness(IPatientRepository patient,IUnitOfWork unitOfWork)
        {
            this._patient = patient;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(PatientView model)
        {
            return _patient.Add(model);
        }

        public bool ChangePass(ChangePassView model)
        {
            return _patient.ChangePass(model);
        }

        public bool CheckExistsAccount(string account, int id)
        {
            return _patient.CheckExistsAccount(account,id);
        }

        public bool Edit(PatientView model)
        {
            return _patient.Edit(model);
        }

        public IEnumerable<PatientView> GetAll()
        {
            return _patient.GetAll();
        }

        public PatientView GetByID(int id)
        {
            return _patient.GetByID(id);
        }

        public ResponseMemberLogin Login(LoginModel model)
        {
            return _patient.Login(model);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
