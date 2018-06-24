using System;


namespace RapidoHR.WebApi.Model
{
    public class EmpPayrollModel
    {
        public Guid EmpPRID { get; set; }
        public Guid EmpID { get; set; }
        public decimal ? basic { get; set; }
        public decimal ? DA { get; set; }
        public decimal ? HRA { get; set; }
        public decimal ? conveyance { get; set; }
        public decimal ? Adhoc_allow { get; set; }
        public decimal ? PF_bank_by_banj { get; set; }
        public decimal ? PF_by_emp { get; set; }
        public decimal ? Professional_tax { get; set; }
        public decimal ? Festival_advance { get; set; }
        public bool ? HG_Insurance { get; set; }
        public bool ? LIC { get; set; }
        public decimal ? Net_Pay { get; set; }
        public DateTime ? Date_created { get; set; }
        public string Createdby { get; set; }
    }
}
