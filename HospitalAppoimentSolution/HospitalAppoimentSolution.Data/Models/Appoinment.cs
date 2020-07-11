using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.Models
{
    [Table("Appoinments")]
   public class Appoinment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(16)]
        public string Code { get; set; }
        public int Patient { get; set; }
        public int Doctor { get; set; }
        public DateTime Date { get; set; }
        [MaxLength(20)]
        public string Time { get; set; }
        public int Status { get; set; }
        public bool IsPayment { get; set; }
        public double Price { get; set; }
        public double Reduce { get; set; }
        public double Amount { get; set; }
    }
}
