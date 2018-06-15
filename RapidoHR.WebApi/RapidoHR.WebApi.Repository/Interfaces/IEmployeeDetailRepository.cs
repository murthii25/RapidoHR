
using RapidoHR.WebApi.Repository.Entity;
using System;
using System.Collections.Generic;

namespace RapidoHR.WebApi.Repository.Interfaces
{
    public interface IEmployeeDetailRepository
    {
        /// <summary>
        /// Gets a list of all <see cref="EmployeeDetail"/> instances.
        /// </summary>
        /// <returns>List of all <see cref="EmployeeDetail"/> instances.</returns>
        IEnumerable<EmployeeDetail> GetAll();

        /// <summary>
        /// Gets an instance of <see cref="EmployeeDetail"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of instance that needs to be returned.</param>
        /// <returns>The found instance of <see cref="EmployeeDetail"/>.</returns>
        EmployeeDetail GetById(Guid id);

        /// <summary>
        /// Adds/stores a new instance of <see cref="EmployeeDetail"/>.
        /// </summary>
        /// <param name="EmployeeDetail">The instance that needs to be stored.</param>
        void Add(EmployeeDetail EmployeeDetail);

        /// <summary>
        /// Updates an excisting instance of <see cref="EmployeeDetail"/>.
        /// </summary>
        /// <param name="EmployeeDetail">The customer data that needs to be stored.</param>
        void Update(EmployeeDetail EmployeeDetail);

        /// <summary>
        /// Delete an instance of <see cref="EmployeeDetail"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the instance that needs to be deleted.</param>
        void Delete(Guid id);
    }
}
