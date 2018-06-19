using RapidoHR.WebApi.Repository.Entity;
using RapidoHR.WebApi.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace RapidoHR.WebApi.Repository.Repositories
{
    public class EmployeeDetailRepository : IEmployeeDetailRepository
    {
        #region Members

        private readonly RapidoERP_KMBEntities _context;

        #endregion

        #region Constructor

        public EmployeeDetailRepository(RapidoERP_KMBEntities context)
        {
            _context = context;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public IEnumerable<EmployeeDetail> GetAll()
        {
            return _context.EmployeeDetails.AsEnumerable();
        }

        /// <inheritdoc />
        public void Add(EmployeeDetail employee)
        {
            try
            {
                if (employee != null)
                {
                    _context.EmployeeDetails.Add(employee);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Update(EmployeeDetail employee)
        {
            try
            {
                var local = _context.EmployeeDetails.SingleOrDefault(c => c.EmpID == employee.EmpID);
                if (employee != null)
                {
                    //Todo add other columns
                    local.EmpCode = employee.EmpCode;
                    local.Createdby = employee.Createdby;
                    local.DateCreated = DateTime.Now;
                    _context.Entry(local).State = EntityState.Modified;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Delete(Guid empId)
        {
            try
            {
                var entity = _context.EmployeeDetails.SingleOrDefault(c => c.EmpID == empId);

                if (entity != null)
                {
                    _context.EmployeeDetails.Remove(entity);
                }
                else
                {
                    throw new ArgumentException("Record doesn't exist");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public EmployeeDetail GetById(Guid id)
        {
            return _context.EmployeeDetails.SingleOrDefault(c => c.EmpID == id);
        }
        #endregion
    }
}
