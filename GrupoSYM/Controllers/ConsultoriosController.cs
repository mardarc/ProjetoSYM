using GrupoSYM.Entities;
using GrupoSYM.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConsultoriosController : ControllerBase
    {

        public SymContext _symContext;
        public ConsultoriosController(IHttpContextAccessor httpContextAccessor,
                                    SymContext symContext)
        {
            _symContext = symContext;
        }


        // GET: api/<ConsultoriosController>
        [HttpGet("getConsultorios")]
        public ActionResult<List<Consultorio>> getMedicos()
        {
            return _symContext.Consultorios.ToList();
        }

        // GET api/<ConsultoriosController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ConsultoriosController>
        [HttpPost("saveConsultorio")]
        public ActionResult saveConsultorio([FromBody] Consultorio consultorio)
        {
            if (consultorio.ID == 0)
            {
                _symContext.Consultorios.Add(consultorio);
            }
            else
            {
                _symContext.Consultorios.Update(consultorio);
            }
            _symContext.SaveChanges();
            return Ok();
        }

        // PUT api/<ConsultoriosController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ConsultoriosController>/5
        [HttpDelete("deletarconsultorio/{id}")]
        public ActionResult Delete(int id)
        {
            var cons = _symContext.Consultorios.Find(id);

            if (cons == null) { return NotFound("Atividade inexistente"); }

            _symContext.Remove(cons);
            _symContext.SaveChanges();
            return Ok();
        }
    }
}
