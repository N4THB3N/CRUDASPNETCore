namespace SchoolProjectASPNET.Data
{
    using Microsoft.EntityFrameworkCore;
    using SchoolProjectASPNET.Models;

    public class SchoolDbContext : DbContext
    {

        public SchoolDbContext() { }
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options) : base(options) { }

        public DbSet<Alumno> Alumnos { get; set; }

        public DbSet<Profesor> Profesores { get; set; }

        public DbSet<Grado> Grados { get; set; }
        public DbSet<AlumnoGrado> AlumnoGrados { get; set; }
    }
}
