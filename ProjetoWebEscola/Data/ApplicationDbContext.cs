using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProjetoWebEscola.Models;

namespace ProjetoWebEscola.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Student> Student { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Classes> Classes { get; set; }
        public DbSet<Discipline> Disciplines { get; set; }
        public DbSet<Note> Notes { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurações adicionais de mapeamento
            modelBuilder.Entity<Student>()
             .HasMany(a => a.Notes)
             .WithOne(n => n.Student)
             .HasForeignKey(n => n.StudentId);

            modelBuilder.Entity<Discipline>()
                .HasMany(d => d.Notes)
                .WithOne(n => n.Discipline)
                .HasForeignKey(n => n.DisciplineId);

            modelBuilder.Entity<Classes>()
                .HasMany(t => t.Disciplines)
                .WithOne(d => d.Classes)
                .HasForeignKey(d => d.ClassId);
        }
    }
}
