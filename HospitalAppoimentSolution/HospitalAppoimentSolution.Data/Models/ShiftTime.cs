using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.Models
{
    [Table("ShiftTimes")]
   public class ShiftTime
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(50)]
        public string StartTime { get; set; }
        [MaxLength(50)]
        public string EndTime { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
