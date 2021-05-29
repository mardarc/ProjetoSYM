using GrupoSYM.Entities;
using GrupoSYM.Interfaces;
using GrupoSYM.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GrupoSYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MedicoController : ControllerBase
    {
        public SymContext _symContext;
        private IMedicoService _medicoService;
        public MedicoController (IHttpContextAccessor httpContextAccessor, 
                                    SymContext symContext,
                                    IMedicoService medicoService)
        {
            _symContext = symContext;
            _medicoService = medicoService;
        }

        // GET: api/<ValuesController>
        [HttpGet ("getMedicos")]
        public ActionResult<List<Medico>> getMedicos()
        {
            return _symContext.Medicos.ToList();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost("createMedico")]
        public ActionResult createMedico([FromBody] Medico medico)
        {
            var hasMedico = _symContext.Medicos.Where(m => m.CRM == medico.CRM).FirstOrDefault();

            if (hasMedico != null) {
                _medicoService.updateMedico(medico);
            } else {
                _medicoService.addMedico(medico);
            }
            return Ok();

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("deletarMedico/{crm}")]
        public ActionResult Delete(string crm)
        {
            var med = _symContext.Medicos.Find(crm);

            if (med == null) { return NotFound("Médico inexistente"); }

            _symContext.Remove(med);
            _symContext.SaveChanges();
            return Ok();
        }
    }
}
