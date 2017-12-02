using AutoMapper;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Models;

namespace AutoMappingObjects.Client.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<Employee, ManagerDTO>();
        }
    }
}
