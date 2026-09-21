using AutoMapper;
using Quiz1.Dto.DepartmentDto;
using Quiz1.Models;

namespace Quiz1.Profiles
{
    public class DepartmentProfile : Profile
    {
        public DepartmentProfile()
        {
            CreateMap<Department,DepartmentDto>();
            CreateMap<CreateDepartmentDto, Department>();
        }
    }
}
