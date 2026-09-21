using AutoMapper;
using Quiz1.Dto.EnrollmentDto;
using Quiz1.Models;

namespace Quiz1.Profiles
{
    public class EnrollmentProfile : Profile
    {
        public EnrollmentProfile()
        {
            CreateMap<Enrollment, EnrollmentDto>()
                .ForMember(dest => dest.StudentName,
                    opt => opt.MapFrom(src =>
                        src.Student.Firstname + " " + src.Student.Lastname))

                .ForMember(dest => dest.SubjectName,
                    opt => opt.MapFrom(src =>
                        src.Subject.Name));

            CreateMap<CreateEnrollmentDto, Enrollment>();
        }
    }
}
