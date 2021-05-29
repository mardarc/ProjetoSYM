using GrupoSYM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GrupoSYM.Interfaces
{
    public interface IMedicoService
    {
        Medico addMedico(Medico medico);
        Medico updateMedico(Medico medico);
    }
}
