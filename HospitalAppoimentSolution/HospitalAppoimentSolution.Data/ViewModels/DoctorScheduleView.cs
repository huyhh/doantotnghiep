using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
   public class DoctorScheduleView
    {
        /// <summary>
        /// DoctorID
        /// </summary>
        public int ID { get; set; }
        public string Doctor { get; set; }
        /// <summary>
        /// Day of week
        /// </summary>
        
        public int Day { get; set; }
        public string DayName { get; set; }
        /// <summary>
        /// List ID ShiftTime
        /// </summary>
        public string Shift { get; set; }
        public List<ShiftTimeView> ShiftTimes { get; set; }
    }
    public class ScheduleDayView
    {
        public string Date { get; set; }
        public string DateName { get; set; }
        public string DayOfWeek { get; set; }
        public List<Time> LstTime { get; set; }
    }
    public class Time
    {
        public string Name { get; set; }
        public bool IsSold { get; set; }
    }
}
