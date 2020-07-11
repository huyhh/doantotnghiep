using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
   public class DoctorView
    {
        public int ID { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Chỉ có thể nhập tối đa 500 ký tự")]
        public string Avatar { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string BirthDay { get; set; }
        [MaxLength(850, ErrorMessage = "Chỉ có thể nhập tối đa 850 ký tự")]
        public string Address { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Phone { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Email { get; set; }
        
        public int Department { get; set; }
        public string DepartmentName { get; set; }
        public DateTime DateCreate { get; set; }
        public double Price { get; set; }
    }
}
