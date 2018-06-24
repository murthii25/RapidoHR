using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RapidoHR.WebApi.Model
{
    public class ReportEmpPayRollModel
    {
        public string EmpName { get; set; }
        public string Designation { get; set; }
        public string Basic { get; set; }
        public string DA { get; set; }
        public string HRA { get; set; }
        public string conveyance { get; set; }
        public string Adhoc_allow { get; set; }
        public string Total { get; set; }
        public string PF_bank_by_banj { get; set; }
        public string PF_by_emp { get; set; }
        public string Professional_tax { get; set; }
        public string Festival_advance { get; set; }
        public string HG_Insurance { get; set; }
        public string LIC { get; set; }
        public string Net_Pay { get; set; }
    }
}
