using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Models
{
    public class Medico
    {
        [Key]
        public string CRM { get; set; }
        public string Nome { get; set; }
        public string Telefone { get; set; }
        public decimal ValorConsulta { get; set; }
    }
}
