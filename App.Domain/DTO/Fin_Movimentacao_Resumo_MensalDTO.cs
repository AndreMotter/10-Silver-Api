using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTO
{
    public class Fin_Movimentacao_Resumo_MensalDTO
    {
        public decimal saldo {  get; set; }
        public decimal despesas {  get; set; }
        public decimal receita {  get; set; }
    }
}
