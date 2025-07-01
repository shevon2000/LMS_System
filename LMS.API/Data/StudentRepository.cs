using LMS.API.Models;
using Microsoft.EntityFrameworkCore;

namespace LMS.API.Data;

public class StudentRepository
{
    private readonly LMSDbContext _context;

    public StudentRepository(LMSDbContext context)
    {
        _context = context;
    }

    public async Task<List<Student>> GetAllAsync() => await _context.Students.ToListAsync();

    public async Task<Student?> GetByIdAsync(int id) => await _context.Students.FindAsync(id);

    public async Task AddAsync(Student student)
    {
        _context.Students.Add(student);
        await _context.SaveChangesAsync();
    }

    public async Task EnrollCourseAsync(int studentId, string courseName)
    {
        var student = await GetByIdAsync(studentId);
        if (student == null)
            throw new Exception("Student not found.");

        if (student.EnrolledCourses.Contains(courseName))
            throw new Exception("Student already enrolled in this course.");

        if (student.EnrolledCourses.Count >= 3)
            throw new Exception("Cannot enroll in more than 3 courses.");

        student.EnrolledCourses.Add(courseName);
        await _context.SaveChangesAsync();
    }
}
