using HospitalAppoimentSolution.Data.Models;
using HospitalAppoimentSolution.Data.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HospitalAppoimentSolution.Services.Infrastructure;
using HospitalAppoimentSolution.Helper.Core;

namespace HospitalAppoimentSolution.Services.Repositories
{
    public interface IDoctorScheduleRepository : IRepository<DoctorSchedule>
    {
        IEnumerable<DoctorScheduleView> GetAll();
        IEnumerable<DoctorScheduleView> GetByDoctor(int id);
        bool Add(DoctorScheduleView model);
        bool Edit(DoctorScheduleView model);
        bool Delete(int id, int day);
        DoctorScheduleView GetEdit(int id, int day);
    }
    public class DoctorScheduleRepository : RepositoryBase<DoctorSchedule>, IDoctorScheduleRepository
    {
        public DoctorScheduleRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }

        public bool Add(DoctorScheduleView model)
        {
            try
            {
                DoctorSchedule schedule = new DoctorSchedule();
                schedule.Day = model.Day;
                schedule.ID = model.ID;
                schedule.Shift = model.Shift;
                DbContext.DoctorSchedules.Add(schedule);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Delete(int id, int day)
        {
            try
            {
                var _item = DbContext.DoctorSchedules.FirstOrDefault(x => x.ID == id && x.Day == day);
                if (_item != null && _item.ID != 0)
                {
                    DbContext.DoctorSchedules.Remove(_item);
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public bool Edit(DoctorScheduleView model)
        {
            try
            {
                var _item = DbContext.DoctorSchedules.FirstOrDefault(x => x.ID == model.ID && x.Day == model.Day);
                if (_item != null && _item.ID != 0)
                {
                    _item.Shift = model.Shift;
                    return true;
                }
                return false;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<DoctorScheduleView> GetAll()
        {
            try
            {
                var _lst = DbContext.DoctorSchedules;
                if (_lst != null && _lst.Count() > 0)
                {
                    List<DoctorScheduleView> schedules = new List<DoctorScheduleView>();
                    foreach (var item in _lst)
                    {
                        DoctorScheduleView schedule = new DoctorScheduleView();
                        schedule.Day = item.Day;
                        schedule.ID = item.ID;
                        schedule.Shift = item.Shift;
                        schedules.Add(schedule);
                    }
                    return schedules;
                }
                return new List<DoctorScheduleView>();
            }
            catch (Exception)
            {

                return new List<DoctorScheduleView>();
            }
        }

        public IEnumerable<DoctorScheduleView> GetByDoctor(int id)
        {
            try
            {
                var _lst = DbContext.DoctorSchedules.Where(x => x.ID == id);
                if (_lst != null && _lst.Count() > 0)
                {
                    List<DoctorScheduleView> schedules = new List<DoctorScheduleView>();
                    foreach (var item in _lst)
                    {
                        DoctorScheduleView schedule = new DoctorScheduleView();
                        schedule.Day = item.Day;
                        schedule.ID = item.ID;
                        schedule.Shift = item.Shift;
                        schedule.Doctor = DbContext.Doctors.Find(item.ID).Name;
                        schedule.DayName = CreateDay.getLstDay().FirstOrDefault(x => x.ID == item.Day).Name;
                        

                        List<ShiftTimeView> shiftTimes = new List<ShiftTimeView>();
                        if(item.Shift!=null && item.Shift != "")
                        {
                            foreach (var s in item.Shift.Trim('|').Split('|'))
                            {
                                var shiftTime = DbContext.ShiftTimes.Find(Convert.ToInt32(s));
                                ShiftTimeView shiftTimeView = new ShiftTimeView();
                                shiftTimeView.EndTime = shiftTime.EndTime;
                                shiftTimeView.ID = shiftTime.ID;
                                shiftTimeView.Name = shiftTime.Name;
                                shiftTimeView.StartTime = shiftTime.StartTime;
                                shiftTimes.Add(shiftTimeView);

                            }
                        }
                        schedule.ShiftTimes = shiftTimes;
                        schedules.Add(schedule);
                    }
                    return schedules;
                }
                return new List<DoctorScheduleView>();
            }
            catch (Exception)
            {

                return new List<DoctorScheduleView>();
            }
        }

        public DoctorScheduleView GetEdit(int id, int day)
        {
            try
            {
                var _item = DbContext.DoctorSchedules.FirstOrDefault(x => x.ID == id && x.Day == day);
                if(_item!=null && _item.ID != 0)
                {
                    DoctorScheduleView scheduleView = new DoctorScheduleView();
                    scheduleView.Day = _item.Day;
                    scheduleView.ID = _item.ID;
                    scheduleView.Shift = _item.Shift;
                    return scheduleView;
                }
                return new DoctorScheduleView();
            }
            catch (Exception)
            {

                return new DoctorScheduleView();
            }
        }
    }
}
