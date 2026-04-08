using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using tB_University.Models;

namespace tB_University.Data;

public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
{
    // tabelas relacionados com cursos e UCs respetivamente
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Course> Courses { get; set; }
    
    // tabelas de utilizadores
    public DbSet<MyUser> MyUsers { get; set; }
    public DbSet<Student> Students { get; set; }
    public DbSet<Teacher> Teachers { get; set; }
    
    
    // tabelas de relacionamentos
    public DbSet<Registration> Registrations { get; set; }
}