using AutoMapper;
using Quiz1.Dto.StudentDto;
using Quiz1.Models;

namespace Quiz1.Profiles
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            CreateMap<Student, StudentDto>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => $"{src.Firstname} {src.Lastname}"));

            CreateMap<CreateStudentDto, Student>()
                .ForMember(dest => dest.Firstname, opt => opt.MapFrom(src => src.FullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]))
                .ForMember(dest => dest.Lastname, opt => opt.MapFrom(src => src.FullName.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]));
        }
    }
}
