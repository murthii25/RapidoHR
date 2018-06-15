using RapidoHR.WebApi.Model;
using System;
using System.Collections.Generic;

namespace RapidoHR.WebApi.Services.Interfaces
{
    //To do check spellings ,replace department with employee
    public interface IEmployeeDetailService
    {

        /// <summary>
        /// Gets a list of all <see cref="EmployeeDetailModel"/> instances.
        /// </summary>
        /// <returns>List of all <see cref="EmployeeDetailModel"/> instances.</returns>
        IEnumerable<EmployeeDetailModel> GetEmployeeDetails();

        /// <summary>
        /// Gets an instance of <see cref="EmployeeDetailModel"/> by its unique identifier.
        /// </summary>
        /// <param name="id">The identifier of instance that needs to be returned.</param>
        /// <returns>The found instance of <see cref="EmployeeDetailModel"/>.</returns>
        EmployeeDetailModel GetEmployee(Guid id);

        /// <summary>
        /// Creates a new instance of <see cref="Employee"/>.
        /// </summary>
        /// <param name="employee">The instance that needs to be stored.</param>
        Guid Create(EmployeeDetailModel employee);

        /// <summary>
        /// Updates an existing instance of <see cref="Employee"/>.
        /// </summary>
        /// <param name="employee">The department data that needs to be stored.</param>
        void Update(EmployeeDetailModel employee);

        /// <summary>
        /// Delete an instance of <see cref="Employee"/> by its identifier.
        /// </summary>
        /// <param name="id">The identifier of the instance that needs to be deleted.</param>
        void Delete(Guid id);
    }
}
