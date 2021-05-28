using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Models
{
    public class Medico
    {
        [Key]
        [Column(TypeName = "varchar(10)")]
        public string CRM { get; set; }

        [Required]
        [Column(TypeName = "varchar(100)")]
        public string Nome { get; set; }

        [Required]
        [Column(TypeName = "varchar(20)")]
        public string Telefone { get; set; }

        [Required]
        [Column(TypeName = "decimal(10,2)")]
        public decimal ValorConsulta { get; set; }
    }
}
