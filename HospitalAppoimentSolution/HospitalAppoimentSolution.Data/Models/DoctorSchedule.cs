using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.Models
{
    [Table("DoctorSchedules")]
    public class DoctorSchedule
    {
        /// <summary>
        /// DoctorID
        /// </summary>
        [Key]
        [Column(Order = 0)]
        public int ID { get; set; }
        /// <summary>
        /// Day of week
        /// </summary>
        [Key]
        [Column(Order = 1)]
        public int Day { get; set; }
        /// <summary>
        /// List ID ShiftTime
        /// </summary>
        public string Shift { get; set; }
    }
}
