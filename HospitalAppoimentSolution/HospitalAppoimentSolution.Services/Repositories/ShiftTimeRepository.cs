using HospitalAppoimentSolution.Data.Models;
using HospitalAppoimentSolution.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppoimentSolution.Services.Infrastructure;

namespace HospitalAppoimentSolution.Services.Repositories
{
    public interface IShiftTimeRepository : IRepository<ShiftTime>
    {
        IEnumerable<ShiftTimeView> GetAll();
        bool Add(ShiftTimeView model);
        bool Edit(ShiftTimeView model);
        ShiftTimeView GetByID(int id);
        bool Delete(int id);
    }
    public class ShiftTimeRepository : RepositoryBase<ShiftTime>, IShiftTimeRepository
    {
        public ShiftTimeRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public bool Add(ShiftTimeView model)
        {
            try
            {
                ShiftTime shift = new ShiftTime();
                shift.EndTime = model.EndTime;
                shift.ID = model.ID;
                shift.Name = model.Name;
                shift.StartTime = model.StartTime;
                DbContext.ShiftTimes.Add(shift);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                var _item = DbContext.ShiftTimes.Find(id);
                if (_item != null && _item.ID != 0)
                {
                    DbContext.ShiftTimes.Remove(_item);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(ShiftTimeView model)
        {
            try
            {
                var _item = DbContext.ShiftTimes.Find(model.ID);
                if (_item != null && _item.ID != 0)
                {
                    _item.EndTime = model.EndTime;
                    _item.Name = model.Name;
                    _item.StartTime = model.StartTime;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<ShiftTimeView> GetAll()
        {
            try
            {
                var _lst = DbContext.ShiftTimes;
                if(_lst!=null && _lst.Count() > 0)
                {
                    List<ShiftTimeView> shifts = new List<ShiftTimeView>();
                    foreach(var item in _lst)
                    {
                        ShiftTimeView shift = new ShiftTimeView();
                        shift.EndTime = item.EndTime;
                        shift.ID = item.ID;
                        shift.Name = item.Name;
                        shift.StartTime = item.StartTime;
                        shifts.Add(shift);
                    }
                    return shifts;
                }
                return new List<ShiftTimeView>();
            }
            catch (Exception)
            {

                return new List<ShiftTimeView>();
            }
        }

        public ShiftTimeView GetByID(int id)
        {
            try
            {
                var _item = DbContext.ShiftTimes.Find(id);
                if(_item!=null && _item.ID != 0)
                {
                    ShiftTimeView shiftTime = new ShiftTimeView();
                    shiftTime.ID = _item.ID;
                    shiftTime.EndTime = _item.EndTime;
                    shiftTime.Name = _item.Name;
                    shiftTime.StartTime = _item.StartTime;
                    return shiftTime;
                }
                return new ShiftTimeView();
            }
            catch (Exception)
            {

                return new ShiftTimeView();
            }
        }
    }
}
