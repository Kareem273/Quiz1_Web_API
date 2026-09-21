using AutoMapper;
using Quiz1.Dto.SubjectDto;
using Quiz1.Models;

namespace Quiz1.Profiles
{
    public class SubjectProfile : Profile
    {
        public SubjectProfile()
        {
            CreateMap<Subject, SubjectDto>()
                .ForMember(dest => dest.TeacherName, opt => opt.MapFrom(src => $"{src.Teacher.FirstName} {src.Teacher.LastName}"));
            CreateMap<CreateSubjectDto, Subject>();

        }
    }
}
