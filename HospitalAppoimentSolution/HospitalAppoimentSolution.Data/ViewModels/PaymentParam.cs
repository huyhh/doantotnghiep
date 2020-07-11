using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalAppoimentSolution.Data.ViewModels
{
   public class PaymentParam
    {
        public int DoctorID { get; set; }
        public int TypePay { get; set; }
        public string PCode { get; set; }
        public string Date { get; set; }
        public string Time { get; set; }
    }
    public class PaymentResult
    {
        public int Status { get; set; }
        public string Uri { get; set; }
    }
}
