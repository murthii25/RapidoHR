using System;

namespace RapidoHR.WebApi.Model
{
    public class EmployeeDetailModel
    {
        public Guid EmpId { get; set; }
        public string EmpCode { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public string Designation { get; set; }
        public string Address { get; set; }
        public string EmailId { get; set; }
        public int? ContactNo { get; set; }
        public DateTime? DateCreated { get; set; }
        public string Createdby { get; set; }
    }
}
