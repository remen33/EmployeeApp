namespace EmployeePayroll.Infrastructure.Mappings
{
    using AutoMapper;
    using EmployeePayroll.Core.DTOs;
    using EmployeePayroll.Core.Entities;

    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Employee, EmployeeDto>().ReverseMap();
        }
    }
}
