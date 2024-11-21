using AutoMapper;
using Boo_Store_Portal_Api.Dto;
using Boo_Store_Portal_Api.Models;

namespace Boo_Store_Portal_Api.BookMapping
{
    public class Mapping : Profile
    {
        public Mapping()
        {
            CreateMap<Employee, CreateEmployeeDto>().ReverseMap();
            CreateMap<Employee, UpdateEmployeeDto>().ReverseMap();
            CreateMap<Employee, ResponseEmployeeDto>().ReverseMap();
            CreateMap<Employee, PatchEmployeeDto>().ReverseMap();
            CreateMap<Job, CreateJobDto>().ReverseMap();
            CreateMap<Job, ResponseJobDto>().ReverseMap();
        }
    }
}
