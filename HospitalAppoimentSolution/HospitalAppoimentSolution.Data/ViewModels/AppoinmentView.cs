using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
   public class AppoinmentView
    {
        public long ID { get; set; }
        [MaxLength(16)]
        public string Code { get; set; }
        public int Patient { get; set; }
        public string PatientName { get; set; }
        public int Doctor { get; set; }
        public string DoctorName { get; set; }
        [MaxLength(20)]
        public string Date { get; set; }
        [MaxLength(20)]
        public string Time { get; set; }
        /// <summary>
        /// -1 Cancel | 0 Waiting | 1 Process | 2 Complete
        /// </summary>
        public int Status { get; set; }
        public bool IsPayment { get; set; }
        public double Price { get; set; }
        public double Reduce { get; set; }
        public double Amount { get; set; }
    }
}
