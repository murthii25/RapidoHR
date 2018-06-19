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

namespace RapidoHR.WebApi.Controllers
{
    public class EmpPayrollsController : ApiController
    {
        private RapidoERP_KMBEntities db = new RapidoERP_KMBEntities();

        // GET: api/EmpPayrolls
        public IQueryable<EmpPayroll> GetEmpPayrolls()
        {
            return db.EmpPayrolls;
        }

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

        // PUT: api/EmpPayrolls/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmpPayroll(Guid id, EmpPayroll empPayroll)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != empPayroll.EmpPRID)
            {
                return BadRequest();
            }

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
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

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