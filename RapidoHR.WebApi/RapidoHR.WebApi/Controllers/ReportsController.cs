using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using RapidoHR.WebApi.Repository.Entity;
using RapidoHR.WebApi.Model;

namespace RapidoHR.WebApi.Controllers
{
    public class ReportsController : ApiController
    {
        private RapidoERP_KMBEntities db = new RapidoERP_KMBEntities();

        [HttpGet, Route("api/ReportEmpPayroll")]
        [ResponseType(typeof(ReportEmpPayRollModel))]
        // GET: api/empPayReports
        public async Task<IHttpActionResult> GetEmployeePayReport()
        {
            try
            {
                var result = await (from e in db.EmployeeDetails
                                    join p in db.EmpPayrolls on e.EmpID equals p.EmpID into dp
                                    from dpj in dp.DefaultIfEmpty()
                                    select new
                                    {
                                        empPayrollModel = new ReportEmpPayRollModel
                                        {
                                            EmpName = e.FirstName + " " + e.MiddleName + " " + e.LastName,
                                            Designation = e.Designation,
                                            Basic = dpj.basic.ToString(),
                                            DA = dpj.DA.ToString(),
                                            HRA = dpj.HRA.ToString(),
                                            conveyance = dpj.conveyance.ToString(),
                                            Adhoc_allow = dpj.Adhoc_allow.ToString(),
                                            Total = (dpj.basic + dpj.DA + dpj.HRA + dpj.Adhoc_allow).ToString(),
                                            PF_bank_by_banj = dpj.PF_bank_by_banj.ToString(),
                                            PF_by_emp = dpj.PF_by_emp.ToString(),
                                            Professional_tax = dpj.Professional_tax.ToString(),
                                            Festival_advance = dpj.Festival_advance.ToString(),
                                            HG_Insurance = dpj.HG_Insurance != null ? "False" : (dpj.HG_Insurance).ToString(),
                                            LIC = dpj.LIC != null ? "False" : (dpj.LIC).ToString(),
                                            Net_Pay = ((dpj.basic + dpj.DA + dpj.HRA + dpj.Adhoc_allow) - (dpj.PF_bank_by_banj + dpj.PF_by_emp + dpj.Professional_tax + dpj.Festival_advance)).ToString()
                                        }

                                    }).ToListAsync();
                return Ok(result.Select(x=>x.empPayrollModel));
               // return Ok(result);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }
    }
}
