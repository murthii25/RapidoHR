using AutoMapper;
using RapidoHR.WebApi.Model;
using RapidoHR.WebApi.Repository.Entity;

namespace RapidoHR.WebApi.AutoMapper
{
    public class EmployeeDetailProfile : Profile
    {
        public EmployeeDetailProfile()
        {
            CreateMap<EmployeeDetail, EmployeeDetailModel>();
            CreateMap<EmployeeDetailModel, EmployeeDetail>();
        }
    }
}