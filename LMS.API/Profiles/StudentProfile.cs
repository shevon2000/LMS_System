using AutoMapper;
using LMS.API.Models;
using LMS.API.Dtos;

namespace LMS.API.Profiles;

public class StudentProfile : Profile
{
    public StudentProfile()
    {
        CreateMap<Student, StudentDto>();
        CreateMap<StudentCreateDto, Student>();
    }
}
