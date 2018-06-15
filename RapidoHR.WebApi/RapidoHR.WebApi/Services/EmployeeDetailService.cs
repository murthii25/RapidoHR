using AutoMapper;
using RapidoHR.WebApi.Model;
using RapidoHR.WebApi.Repository.Entity;
using RapidoHR.WebApi.Repository.Interfaces;
using RapidoHR.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace RapidoHR.WebApi.Services
{
    public class EmployeeDetailService : IEmployeeDetailService
    {
        #region Members

        private readonly IUnitOfWork _unitofWork;

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor injecting an instance of <see cref="IUnitOfWork"/>.
        /// </summary>
        /// <param name="unitofWork">The injected instance of <see cref="IUnitOfWork"/>.</param>
        public EmployeeDetailService(IUnitOfWork unitofWork)
        {
            _unitofWork = unitofWork;
        }

        #endregion

        #region Public Methods

        /// <inheritdoc />
        public IEnumerable<EmployeeDetailModel> GetEmployeeDetails()
        {
            try
            {
                var result = _unitofWork.EmployeeDetailRepository.GetAll();
                return Mapper.Map<IEnumerable<EmployeeDetail>, IEnumerable<EmployeeDetailModel>>(result);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        /// <inheritdoc />
        public EmployeeDetailModel GetEmployee(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    var result = _unitofWork.EmployeeDetailRepository.GetById(id);
                    if (result == null)
                    {
                        return null;
                    }

                    return Mapper.Map<EmployeeDetail, EmployeeDetailModel>(result);
                }

                throw new ArgumentException("EmployeeDetail Id cannot be null (or) empty.");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public Guid Create(EmployeeDetailModel EmployeeDetail)
        {
            try
            {
                if (EmployeeDetail != null)
                {
                    //To do
                    EmployeeDetail.EmpId = EmployeeDetail.EmpId == Guid.Empty ? Guid.NewGuid() : EmployeeDetail.EmpId;
                    var result = Mapper.Map<EmployeeDetailModel, EmployeeDetail>(EmployeeDetail);
                    _unitofWork.EmployeeDetailRepository.Add(result);
                    _unitofWork.Save();
                    return EmployeeDetail.EmpId;
                }
                throw new ArgumentException("EmployeeDetail is empty");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Update(EmployeeDetailModel EmployeeDetail)
        {
            try
            {
                if (EmployeeDetail != null)
                {
                    var result = Mapper.Map<EmployeeDetailModel, EmployeeDetail>(EmployeeDetail);
                    _unitofWork.EmployeeDetailRepository.Update(result);
                    _unitofWork.Save();
                }
                else
                {
                    throw new ArgumentException("EmployeeDetail is empty");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <inheritdoc />
        public void Delete(Guid id)
        {
            try
            {
                if (id != Guid.Empty)
                {
                    _unitofWork.EmployeeDetailRepository.Delete(id);
                    _unitofWork.Save();
                }
                else
                {
                    throw new ArgumentException("EmployeeDetail Id cannot be null (or) empty.");
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}