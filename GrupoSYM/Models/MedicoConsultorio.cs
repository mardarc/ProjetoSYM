using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Models
{
    public class MedicoConsultorio
    {
        [Key]
        public int ID { get; set; }
        public int MedicoId{ get; set; }
        public Medico Medico { get; set; }
        public int ConsultorioId { get; set; }
        public Consultorio Consultorio { get; set; }
    }
}
