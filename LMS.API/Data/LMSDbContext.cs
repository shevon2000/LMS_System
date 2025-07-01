using Microsoft.EntityFrameworkCore;
using LMS.API.Models;

namespace LMS.API.Data;

public class LMSDbContext : DbContext
{
    public LMSDbContext(DbContextOptions<LMSDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
}
