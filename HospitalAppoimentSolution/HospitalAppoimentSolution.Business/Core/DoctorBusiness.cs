using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Services.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppoimentSolution.Data.ViewModels;
using HospitalAppoimentSolution.Services.Infrastructure;

namespace HospitalAppoimentSolution.Business.Core
{
    public interface IDoctorBusiness
    {
        IEnumerable<DoctorView> GetAll();
        bool Add(DoctorView model);
        bool Edit(DoctorView model);
        IEnumerable<DoctorView> GetByDeparment(int id);
        DoctorView GetByID(int id);
        void Save();
    }
   public class DoctorBusiness:IDoctorBusiness
    {
        IDoctorRepository _doctor;
        IUnitOfWork _unitOfWork;
        public DoctorBusiness(IDoctorRepository doctor,IUnitOfWork unitOfWork)
        {
            this._doctor = doctor;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(DoctorView model)
        {
            return _doctor.Add(model);
        }


        public bool Edit(DoctorView model)
        {
            return _doctor.Edit(model);
        }

        public IEnumerable<DoctorView> GetAll()
        {
            return _doctor.GetAll();
        }

        public IEnumerable<DoctorView> GetByDeparment(int id)
        {
            return _doctor.GetByDeparment(id);
        }

        public DoctorView GetByID(int id)
        {
            return _doctor.GetByID(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
