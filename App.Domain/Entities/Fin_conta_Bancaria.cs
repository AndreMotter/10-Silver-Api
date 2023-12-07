using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class Fin_Conta_Bancaria
    {
        [Key]
        public int cba_codigo { get; set; }
        public string cba_descricao { get; set; }
        public string cba_numero { get; set; }
        public string cba_agencia { get; set; }
        public string cba_compe_banco { get; set; }
        public decimal cba_saldo { get; set; }
        public bool cba_status { get; set; }
        public int pes_codigo { get; set; }

        [ForeignKey("pes_codigo")]
        public virtual Fin_Pessoa FinPessoa { get; set; }
    }
}
