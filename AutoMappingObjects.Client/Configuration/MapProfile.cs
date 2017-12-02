using AutoMapper;
using AutoMappingObjects.Client.DTO;
using AutoMappingObjects.Models;

namespace AutoMappingObjects.Client.Configuration
{
    public class MapProfile : Profile
    {
        public MapProfile()
        {
            CreateMap<Employee, EmployeeDTO>();
        }
    }
}
