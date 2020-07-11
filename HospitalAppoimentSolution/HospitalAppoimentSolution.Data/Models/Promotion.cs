using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.Models
{
    [Table("Promotions")]
    public   class Promotion
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long ID { get; set; }
        [MaxLength(12)]
        public string Code { get; set; }
        [MaxLength(250)]
        public string Title { get; set; }
        public string Avatar { get; set; }
        [MaxLength(350)]
        public string Desc { get; set; }
        public string Content { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string DoctorApply { get; set; }
        public int AmountReduced { get; set; }
        public double PercentReduced { get; set; }
        /// <summary>
        /// 0 Reduced for amount of money | 1 Reduced for percent
        /// </summary>
        public int Type { get; set; }
        public bool Status { get; set; }
    }
}
