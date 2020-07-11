using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.Models
{
    [Table("Patients")]
   public class Patient
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(250)]
        public string BirthDay { get; set; }
        [MaxLength(850)]
        public string Address { get; set; }
        [MaxLength(250)]
        public string Phone { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Account { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
