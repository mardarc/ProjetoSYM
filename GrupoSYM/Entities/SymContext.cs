using GrupoSYM.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Entities
{
    public class SymContext : DbContext
    {
        public SymContext(DbContextOptions<SymContext> options) : base(options)
        {
        }
        public DbSet<Medico> Medicos { get; set; }
        public DbSet<Consultorio> Consultorios { get; set; }
    }
}
