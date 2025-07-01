using AutoMapper;
using LMS.API.Data;
using LMS.API.Dtos;
using LMS.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace LMS.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class StudentsController(StudentRepository repo, IMapper mapper) : ControllerBase
{
    private readonly StudentRepository _repo = repo;
    private readonly IMapper _mapper = mapper;

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var students = await _repo.GetAllAsync();
        return Ok(_mapper.Map<List<StudentDto>>(students));
    }

    [HttpPost]
    public async Task<IActionResult> AddStudent(StudentCreateDto dto)
    {
        var student = _mapper.Map<Student>(dto);
        await _repo.AddAsync(student);
        return CreatedAtAction(nameof(GetAll), new { id = student.Id }, _mapper.Map<StudentDto>(student));
    }

    [HttpPost("{id}/enroll")]
    public async Task<IActionResult> EnrollCourse(int id, EnrollCourseDto dto)
    {
        try
        {
            await _repo.EnrollCourseAsync(id, dto.CourseName);
            return Ok("Enrolled successfully.");
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}
