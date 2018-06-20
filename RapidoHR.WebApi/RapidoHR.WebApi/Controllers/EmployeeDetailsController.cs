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
    public class EmployeeDetailsController : ApiController
    {
        private RapidoERP_KMBEntities db = new RapidoERP_KMBEntities();
        private string createdBy = "user";
        // GET: api/EmployeeDetails
        public IQueryable<EmployeeDetail> GetEmployeeDetails()
        {
            return db.EmployeeDetails;
        }

        // GET: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetail))]
        public async Task<IHttpActionResult> GetEmployeeDetail(Guid id)
        {
            EmployeeDetail employeeDetail = await db.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            return Ok(employeeDetail);
        }

        // PUT: api/EmployeeDetails/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEmployeeDetail(Guid id, EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != employeeDetail.EmpID)
            {
                return BadRequest();
            }
            employeeDetail.DateCreated = DateTime.Now;
            employeeDetail.Createdby = createdBy;

            db.Entry(employeeDetail).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeDetailExists(id))
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

        // POST: api/EmployeeDetails
        [ResponseType(typeof(EmployeeDetail))]
        public async Task<IHttpActionResult> PostEmployeeDetail(EmployeeDetail employeeDetail)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            employeeDetail.EmpID = employeeDetail.EmpID == Guid.Empty ? Guid.NewGuid() : employeeDetail.EmpID;
            employeeDetail.DateCreated = DateTime.Now;
            employeeDetail.Createdby = createdBy;
            db.EmployeeDetails.Add(employeeDetail);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (EmployeeDetailExists(employeeDetail.EmpID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = employeeDetail.EmpID }, employeeDetail);
        }

        // DELETE: api/EmployeeDetails/5
        [ResponseType(typeof(EmployeeDetail))]
        public async Task<IHttpActionResult> DeleteEmployeeDetail(Guid id)
        {
            EmployeeDetail employeeDetail = await db.EmployeeDetails.FindAsync(id);
            if (employeeDetail == null)
            {
                return NotFound();
            }

            db.EmployeeDetails.Remove(employeeDetail);
            await db.SaveChangesAsync();

            return Ok(employeeDetail);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EmployeeDetailExists(Guid id)
        {
            return db.EmployeeDetails.Count(e => e.EmpID == id) > 0;
        }
    }
}