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
    public interface IShiftTimeBusiness
    {
        IEnumerable<ShiftTimeView> GetAll();
        bool Add(ShiftTimeView model);
        bool Edit(ShiftTimeView model);
        bool Delete(int id);
        ShiftTimeView GetByID(int id);
        void Save();
    }
    public class ShiftTimeBusiness : IShiftTimeBusiness
    {
        IShiftTimeRepository _shift;
        IUnitOfWork _unitOfWork;
        public ShiftTimeBusiness(IShiftTimeRepository shift,IUnitOfWork unitOfWork)
        {
            this._shift = shift;
            this._unitOfWork = unitOfWork;
        }

        public bool Add(ShiftTimeView model)
        {
            return _shift.Add(model);
        }

        public bool Delete(int id)
        {
            return _shift.Delete(id);
        }

        public bool Edit(ShiftTimeView model)
        {
            return _shift.Edit(model);
        }

        public IEnumerable<ShiftTimeView> GetAll()
        {
            return _shift.GetAll();
        }

        public ShiftTimeView GetByID(int id)
        {
            return _shift.GetByID(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
