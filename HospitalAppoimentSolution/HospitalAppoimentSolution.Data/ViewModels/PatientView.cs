using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
   public class PatientView
    {
        public int ID { get; set; }
        [MaxLength(250,ErrorMessage ="Chỉ có thể nhập tối đa 250 ký tự")]
        public string Name { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string BirthDay { get; set; }
        [MaxLength(850, ErrorMessage = "Chỉ có thể nhập tối đa 850 ký tự")]
        public string Address { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Phone { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Email { get; set; }
        [MaxLength(50, ErrorMessage = "Chỉ có thể nhập tối đa 50 ký tự")]
        public string Account { get; set; }
        [MaxLength(50, ErrorMessage = "Chỉ có thể nhập tối đa 50 ký tự")]
        public string Password { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
