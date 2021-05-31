using GrupoSYM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Entities
{
    public class SymContext : DbContext
    {
        public SymContext(DbContextOptions<SymContext> options) : base(options) { }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
        public DbSet<MedicoConsultorio> MedicosConsultorios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Medico>().ToTable("medicos");

            modelBuilder.Entity<Medico>().HasKey(x => x.Id);
            modelBuilder.Entity<Medico>().Property(x => x.Id).HasColumnName("Id").IsRequired();

            modelBuilder.Entity<Consultorio>().ToTable("consultorios");

            modelBuilder.Entity<Consultorio>().HasKey(x => x.ID);
            modelBuilder.Entity<Consultorio>().Property(x => x.ID).HasColumnName("ID").IsRequired();

            modelBuilder.Entity<MedicoConsultorio>().ToTable("medicosconsultorios");

            modelBuilder.Entity<MedicoConsultorio>().HasKey(a => new { a.MedicoId, a.ConsultorioId });

            modelBuilder.Entity<MedicoConsultorio>().Property(a => a.MedicoId).IsRequired().HasColumnName("medicoId");
            modelBuilder.Entity<MedicoConsultorio>().Property(a => a.ConsultorioId).IsRequired().HasColumnName("consultorioId");

            modelBuilder.Entity<MedicoConsultorio>().HasOne(m => m.Medico)
                .WithMany(m => m.MedicosConsultorio)
                .HasForeignKey(m => m.MedicoId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MedicoConsultorio>().HasOne(c => c.Consultorio)
                .WithMany(c => c.MedicoConsultorios)
                .HasForeignKey(c => c.ConsultorioId).OnDelete(DeleteBehavior.NoAction);
        }
    }
}
