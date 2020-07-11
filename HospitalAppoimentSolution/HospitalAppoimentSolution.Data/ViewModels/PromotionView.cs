using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
    public class PromotionView
    {
        public long ID { get; set; }
        [MaxLength(4, ErrorMessage = "Chỉ có thể nhập tối đa 4 ký tự")]
        public string Code { get; set; }
        [MaxLength(250, ErrorMessage = "Chỉ có thể nhập tối đa 250 ký tự")]
        public string Title { get; set; }
        public string Avatar { get; set; }
        [MaxLength(350, ErrorMessage = "Chỉ có thể nhập tối đa 350 ký tự")]
        public string Desc { get; set; }
        public string Content { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
        public int AmountReduced { get; set; }
        public double PercentReduced { get; set; }
        public string DoctorApply { get; set; }
        /// <summary>
        /// 1 Reduced for amount of money | 2 Reduced for percent
        /// </summary>
        public int Type { get; set; }
        public bool Status { get; set; }
    }
}
