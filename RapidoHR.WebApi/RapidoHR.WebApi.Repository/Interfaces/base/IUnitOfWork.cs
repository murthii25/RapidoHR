
namespace RapidoHR.WebApi.Repository.Interfaces
{
    /// <summary>
    /// Interface for the unit of work implementation.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// The repository to access the EmployeeRepository data.
        /// </summary>
        IEmployeeDetailRepository EmployeeDetailRepository { get; }               

        /// <summary>
        /// Saves the current state.
        /// </summary>
        void Save();

        /// <summary>
        /// Dispose all resources.
        /// </summary>
        void Dispose();
    }
}