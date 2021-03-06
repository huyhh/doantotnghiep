﻿using HospitalAppoimentSolution.Data.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppoimentSolution.Data.Models
{
    [Table("Staffs")]
    public class Staff : Partialtable
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [MaxLength(150)]
        public string Name { get; set; }
        [MaxLength(350)]
        public string Address { get; set; }
        public DateTime? BirthDay { get; set; }
        [MaxLength(50)]
        public string Phone { get; set; }
        public int Gender { get; set; }
        [MaxLength(150)]
        public string Mail { get; set; }
        [MaxLength(50)]
        public string Account { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
