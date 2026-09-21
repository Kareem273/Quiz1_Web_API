using AutoMapper;
using Quiz1.Dto.ClassRoomDto;
using Quiz1.Models;

namespace Quiz1.Profiles
{
    public class ClassRoomProfile : Profile 
    {
        public ClassRoomProfile()
        {

            CreateMap<Classroom, ClassroomDto>();

            CreateMap<Classroom, ClassRoomIDDto>();

            CreateMap<ClassRoomIDDto, Classroom>();

        }
    }
}
