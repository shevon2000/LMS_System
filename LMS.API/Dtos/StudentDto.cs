namespace LMS.API.Dtos;

public class StudentDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<string> EnrolledCourses { get; set; } = new();
}
