#region Using
using System;
using Unity.Attributes;
using RapidoHR.WebApi.Repository.Interfaces;
using RapidoHR.WebApi.Repository.Entity;
#endregion

namespace RapidoHR.WebApi.Repository
{
    public class UnitOfWork : IDisposable, IUnitOfWork
    {
        #region Private Members

        private readonly RapidoERP_KMBEntities context;

        #endregion

        /// <summary>
        /// Constructor injecting an instance of <see cref="RapidoERP_KMBEntities"/>.
        /// </summary>
        /// <param name="RapidoERP_KMBEntities">The injected <see cref="RapidoERP_KMBEntities"/>.</param>
        public UnitOfWork(RapidoERP_KMBEntities context)
        {
            this.context = context;
        }

        #region Public Members

        [Dependency]
        public IEmployeeDetailRepository EmployeeDetailRepository { get; set; }
        
        #endregion


        #region Public Methods

        public void Dispose()
        {
            if (this.context != null)
            {
                this.context.Dispose();
            }
        }

        public void Save()
        {
            this.context.SaveChanges();
        }

        #endregion
    }
}
