using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.Models
{
    [Table("Doctors")]
   public class Doctor
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(250)]
        public string Name { get; set; }
        [MaxLength(500)]
        public string Avatar { get; set; }
        [MaxLength(250)]
        public string BirthDay { get; set; }
        [MaxLength(850)]
        public string Address { get; set; }
        [MaxLength(250)]
        public string Phone { get; set; }
        [MaxLength(250)]
        public string Email { get; set; }
        
        public int Department { get; set; }
        public DateTime DateCreate { get; set; }
        public double Price { get; set; }
    }
}
