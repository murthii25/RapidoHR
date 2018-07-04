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
    public class EmpPayrollsController : ApiController
    {
        private RapidoERP_KMBEntities db = new RapidoERP_KMBEntities();
        private string createdBy = "user";       

        // GET: api/EmpPayrolls/5
        [ResponseType(typeof(EmpPayroll))]
        public async Task<IHttpActionResult> GetEmpPayroll(Guid id)
        {
            EmpPayroll empPayroll = await db.EmpPayrolls.FindAsync(id);
            if (empPayroll == null)
            {
                return NotFound();
            }

            return Ok(empPayroll);
        }

        // GET: api/EmpCodePayroll/5321
        [HttpGet, Route("api/EmpCodePayroll/{empCode}")]
        [ResponseType(typeof(EmpPayroll))]
        public async Task<IHttpActionResult> GetEmpCodePayroll(string empCode)
        {
            var result = await (from e in db.EmployeeDetails
                                join p in db.EmpPayrolls on e.EmpID equals p.EmpID into dp
                                from dpj in dp.DefaultIfEmpty()
                                where e.EmpCode == empCode
                                select new
                                {
                                    empPayrollModel = new EmpPayrollModel
                                    {
                                        EmpPRID = dpj.EmpPRID == null ? Guid.Empty : dpj.EmpPRID,
                                        EmpID = e.EmpID == null ? Guid.Empty : e.EmpID,
                                        basic = dpj.basic,
                                        DA = dpj.DA,
                                        HRA = dpj.HRA,
                                        conveyance = dpj.conveyance,
                                        Adhoc_allow = dpj.Adhoc_allow,
                                        PF_bank_by_banj = dpj.PF_bank_by_banj,
                                        PF_by_emp = dpj.PF_by_emp,
                                        Professional_tax = dpj.Professional_tax,
                                        Festival_advance = dpj.Festival_advance,
                                        HG_Insurance = dpj.HG_Insurance,
                                        LIC = dpj.LIC,
                                        Net_Pay = dpj.Net_Pay,
                                        Date_created = dpj.Date_created,
                                        Createdby = dpj.Createdby
                                    }

                                }).FirstOrDefaultAsync();
            return Ok(result);
        }

        // PUT: api/EmpPayrolls/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpPayroll(Guid id, EmpPayroll empPayroll)
        {
            if (!ModelState.IsValid || empPayroll.EmpID == Guid.Empty)
            {
                return BadRequest(ModelState);
            }

            if (id != empPayroll.EmpPRID)
            {
                return BadRequest();
            }
            empPayroll.Date_created = DateTime.Now;
            empPayroll.Createdby = createdBy;
            db.Entry(empPayroll).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpPayrollExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/EmpPayrolls
        [ResponseType(typeof(EmpPayroll))]
        public async Task<IHttpActionResult> PostEmpPayroll(EmpPayroll empPayroll)
        {
            if (!ModelState.IsValid || empPayroll.EmpID == Guid.Empty)
            {
                return BadRequest(ModelState);
            }
            empPayroll.EmpPRID = empPayroll.EmpPRID == Guid.Empty ? Guid.NewGuid() : empPayroll.EmpPRID;
            empPayroll.Date_created = DateTime.Now;
            empPayroll.Createdby = createdBy;
            db.EmpPayrolls.Add(empPayroll);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmpPayrollExists(empPayroll.EmpPRID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = empPayroll.EmpPRID }, empPayroll);
        }

        // DELETE: api/EmpPayrolls/5
        [ResponseType(typeof(EmpPayroll))]
        public async Task<IHttpActionResult> DeleteEmpPayroll(Guid id)
        {
            EmpPayroll empPayroll = await db.EmpPayrolls.FindAsync(id);
            if (empPayroll == null)
            {
                return NotFound();
            }

            db.EmpPayrolls.Remove(empPayroll);
            await db.SaveChangesAsync();

            return Ok(empPayroll);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmpPayrollExists(Guid id)
        {
            return db.EmpPayrolls.Count(e => e.EmpPRID == id) > 0;
        }
    }
}