using GrupoSYM.Entities;
using GrupoSYM.Interfaces;
using GrupoSYM.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Repositories
{
    public class MedicoRepository : IMedicoService
    {
        private SymContext _db;

        public MedicoRepository (IHttpContextAccessor httpContextAccessor, SymContext db)
        {
            _db = db;
        }
        public Medico addMedico(Medico medico)
        {
            _db.Medicos.Add(medico);
            _db.SaveChanges();
            return medico;
        }

        public Medico updateMedico(Medico medico)
        {

            var med = _db.Medicos.Where(m => m.CRM == medico.CRM).First();
            med.Nome = medico.Nome;
            med.Telefone = medico.Telefone;
            med.ValorConsulta = medico.ValorConsulta;
            _db.SaveChanges();
            return medico;
        }
    }
}
