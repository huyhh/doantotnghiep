using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
    public class ShiftTimeView
    {
        public int ID { get; set; }
        [MaxLength(50, ErrorMessage = "Chỉ có thể nhập tối đa 50 ký tự")]
        public string StartTime { get; set; }
        [MaxLength(50, ErrorMessage = "Chỉ có thể nhập tối đa 50 ký tự")]
        public string EndTime { get; set; }
        [MaxLength(50, ErrorMessage = "Chỉ có thể nhập tối đa 50 ký tự")]
        public string Name { get; set; }
    }
}
