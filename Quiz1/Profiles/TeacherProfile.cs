using AutoMapper;
using Quiz1.Dto.TeacherDTO;
using Quiz1.Models;

namespace Quiz1.Profiles
{
    public class TeacherProfile : Profile
    {

        public TeacherProfile()
        {
            CreateMap<Teacher, TeacherDto>()
                .ForMember(des => des.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            
            CreateMap<Teacher, TeacherIDDto>()
                .ForMember(des => des.FullName,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));

            CreateMap<CreateTeacherDto, Teacher>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[0]))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]));
           
            CreateMap<EditTeacherDto, Teacher>()
            .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FullName.Split(new[]{' ' }, StringSplitOptions.RemoveEmptyEntries)[0]))
            .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)[1]));

            // .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.FullName.Split('')[1]));


        }
    }
}
