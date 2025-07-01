using LMS.API.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using LMS.API.Profiles;

var builder = WebApplication.CreateBuilder(args);

// EF Core + SQLite
builder.Services.AddDbContext<LMSDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

// Repository + AutoMapper
builder.Services.AddScoped<StudentRepository>();
builder.Services.AddAutoMapper(typeof(StudentProfile));
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
