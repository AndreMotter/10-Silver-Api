using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Interfaces.Application
{
    public interface IFin_RelatoriosService
    {
        byte[] imprimirMovimentos(int pes_codigo, int mov_tipo, int cat_codigo, DateTime? data_inicial, DateTime? data_final);
        byte[] imprimirResumoExercicio(int pes_codigo, int ano);
    }
}
