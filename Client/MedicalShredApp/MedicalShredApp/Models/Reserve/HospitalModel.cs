using System;
using System.ComponentModel;

namespace MedicalShredApp.Reserve.Models
{
    public class HospitalModel 
    {
        public string HosCode { get; set; }
        public string HosName { get; set; }
        public string Notice { get; set; }
        public string ReservePhone { get; set; }
        public string Summary { get; set; }
        public string Address { get; set; }
        public int RankCode { get; set; }
        public string Nature { get; set; }
        public string License { get; set; }
        public string Response { get; set; }
        public string TelNo { get; set; }
        public string Notes { get; set; }
        public DateTime LastUpdateDate { get; set; }

    }
}
