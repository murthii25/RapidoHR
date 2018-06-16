using RapidoHR.WebApi.Model;
using RapidoHR.WebApi.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace RapidoHR.WebApi.Controllers
{
   
            /// <summary>
        /// Endpoint for EmployeeDetail related information.
        /// </summary>
        [RoutePrefix("api/employee")]
        public class EmployeeController : ApiController
        {
            #region Members

            private readonly IEmployeeDetailService _employeedetailService;

            #endregion

            #region Constructor

            /// <summary>
            /// Constructor injecting an instance of <see cref="IEmployeeDetailService"/>.
            /// </summary>
            /// <param name="EmployeeDetailService">The injected service.</param>
            public EmployeeController(IEmployeeDetailService EmployeeDetailService)
            {
                _employeedetailService = EmployeeDetailService;
            }

            #endregion

            #region Public Methods

            /// <summary>
            /// Gets and returns all EmployeeDetails.
            /// </summary>
            /// <returns>All found EmployeeDetails.</returns>
            [HttpGet, Route("")]
            [ResponseType(typeof(IEnumerable<EmployeeDetailModel>))]
            public IHttpActionResult Get()
            {
                try
                {
                    return Ok(_employeedetailService.GetEmployeeDetails());
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            /// <summary>
            /// Gets a EmployeeDetail by its unique identifier.
            /// </summary>
            /// <param name="id">The identifier of the EmployeeDetail that is requested.</param>
            /// <returns>The instance of the found EmployeeDetail.</returns>
            [HttpGet, Route("{id}")]
            [ResponseType(typeof(EmployeeDetailModel))]
            public IHttpActionResult Get(Guid id)
            {
                try
                {
                    if (id == Guid.Empty)
                    {
                        return BadRequest("EmployeeDetail Id cannot be empty.");
                    }

                    EmployeeDetailModel EmployeeDetail = _employeedetailService.GetEmployee(id);

                    if (EmployeeDetail == null)
                    {
                        return NotFound();
                    }

                    return Ok(EmployeeDetail);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            /// <summary>
            /// Creates a new instance of a EmployeeDetail.
            /// </summary>
            /// <param name="EmployeeDetail">The EmployeeDetail that needs to be created.</param>
            /// <returns>Created when the instance is created.</returns>
            [HttpPost, Route("")]
            [ResponseType(typeof(void))]
            public IHttpActionResult Post(EmployeeDetailModel EmployeeDetail)
            {
                try
                {
                    if (EmployeeDetail == null)
                    {
                        return BadRequest("EmployeeDetail cannot be null or empty.");
                    }

                    Guid result = _employeedetailService.Create(EmployeeDetail);

                    return Created(result.ToString(), EmployeeDetail);
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            /// <summary>
            /// Updates a existing EmployeeDetail instance.
            /// </summary>
            /// <param name="EmployeeDetail">The EmployeeDetail data that needs to be percisted.</param>
            /// <returns>Ok when the instance is updated.</returns>
            [HttpPut, Route("")]
            [ResponseType(typeof(void))]
            public IHttpActionResult Put(EmployeeDetailModel EmployeeDetail)
            {
                try
                {
                    if (EmployeeDetail == null)
                    {
                        return BadRequest("EmployeeDetail cannot be null or empty.");
                    }

                    _employeedetailService.Update(EmployeeDetail);

                    return Ok();
                }
                catch (Exception ex)
                {
                    throw new ArgumentException(ex.Message);
                }
            }

            /// <summary>
            /// Deletes an instance of a EmployeeDetail by it's unique identifier.
            /// </summary>
            /// <param name="id">the indentifier of the instance that needs to be deleted.</param>
            /// <returns>Ok when the instance is deleted.</returns>
            [HttpDelete, Route("{id}")]
            [ResponseType(typeof(void))]
            public IHttpActionResult Delete(Guid id)
            {
                try
                {
                    if (id == Guid.Empty)
                    {
                        return BadRequest("EmployeeDetail Id cannot be empty.");
                    }

                    _employeedetailService.Delete(id);

                    return Ok();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }

            #endregion

        }
    }



