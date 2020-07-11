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
    public interface IDoctorScheduleBusiness
    {
        IEnumerable<DoctorScheduleView> GetAll();
        IEnumerable<DoctorScheduleView> GetByDoctor(int id);
        bool Add(DoctorScheduleView model);
        bool Edit(DoctorScheduleView model);
        DoctorScheduleView GetEdit(int id, int day);
        bool Delete(int id, int day);
        void Save();
    }
    public class DoctorScheduleBusiness : IDoctorScheduleBusiness
    {
        IDoctorScheduleRepository _schedule;
        IUnitOfWork _unitOfWork;
        public DoctorScheduleBusiness(IUnitOfWork unitOfWork,IDoctorScheduleRepository schedule)
        {
            this._schedule = schedule;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(DoctorScheduleView model)
        {
            return _schedule.Add(model);
        }

        public bool Delete(int id, int day)
        {
            return _schedule.Delete(id, day);
        }

        public bool Edit(DoctorScheduleView model)
        {
            return _schedule.Edit(model);
        }

        public IEnumerable<DoctorScheduleView> GetAll()
        {
            return _schedule.GetAll();
        }

        public IEnumerable<DoctorScheduleView> GetByDoctor(int id)
        {
            return _schedule.GetByDoctor(id);
        }

        public DoctorScheduleView GetEdit(int id, int day)
        {
            return _schedule.GetEdit(id, day);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
