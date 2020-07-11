using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
   public class ApplyPromotionParam
    {
        public string Code { get; set; }
        public double Price { get; set; }
        public long DoctorID { get; set; }
    }
    public class ApplyPromotionResponse
    {
        public int Status { get; set; }
        public string Reduce { get; set; }
        public string Price { get; set; }
    }
}
