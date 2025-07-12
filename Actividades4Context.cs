using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Actividad4Prog3.Models
{
    public partial class Actividades4Context : DbContext
    {
        public Actividades4Context()
        {
        }

        public Actividades4Context(DbContextOptions<Actividades4Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Estudiante> Estudiantes { get; set; }

        public virtual DbSet<Calificacione> Calificaciones { get; set; }

        public virtual DbSet<Materia> Materias { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning Para proteger la cadena de conexión, muévela a un archivo de configuración.
            => optionsBuilder.UseSqlServer("Server=LOCALHOST;Database=ACTIVIDADES4;Trusted_Connection=True;TrustServerCertificate=True");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración de Calificaciones
            modelBuilder.Entity<Calificacione>(entity =>
            {
                entity.HasKey(e => e.Id).HasName("PK__Califica__3214EC07F4F667FC");

                entity.Property(e => e.MatriculaEstudiante).HasMaxLength(50);
                entity.Property(e => e.Periodo).HasMaxLength(20);

                entity.HasOne(d => d.CodigoMateriaNavigation)
                      .WithMany(p => p.Calificaciones)
                      .HasForeignKey(d => d.CodigoMateria)
                      .OnDelete(DeleteBehavior.ClientSetNull)
                      .HasConstraintName("FK__Calificac__Codig__3D5E1FD2");
            });

            // Configuración de Materias
            modelBuilder.Entity<Materia>(entity =>
            {
                entity.HasKey(e => e.Codigo).HasName("PK__Materias__06370DAD199ED2F2");

                entity.Property(e => e.Codigo).ValueGeneratedNever();
                entity.Property(e => e.Carrera).HasMaxLength(100);
                entity.Property(e => e.Nombre).HasMaxLength(100);
            });

            // ✅ NUEVA configuración de Estudiantes
            modelBuilder.Entity<Estudiante>(entity =>
            {
                entity.HasKey(e => e.Matricula);

                entity.Property(e => e.Matricula).HasMaxLength(20);
                entity.Property(e => e.Nombre).HasMaxLength(100);
                entity.Property(e => e.Carrera).HasMaxLength(100);
                entity.Property(e => e.Turno).HasMaxLength(50);
                entity.Property(e => e.TipoIngreso).HasMaxLength(50);
                entity.Property(e => e.Genero).HasMaxLength(20);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
