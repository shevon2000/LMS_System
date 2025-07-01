using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LMS.API.Models;

public class Student
{
    [Key]
    public int Id { get; set; }

    [Required]
    public required string Name { get; set; }

    public List<string> EnrolledCourses { get; set; } = new List<string>();
}
