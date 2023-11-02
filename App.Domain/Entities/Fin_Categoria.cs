using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class Fin_categoria
    {
        [Key]
        public int cat_codigo { get; set; }
        public string cat_descricao { get; set; }
        public string cat_sigla { get; set; }
        public int cat_tipo { get; set; }
        public int pes_codigo { get; set; }
        [ForeignKey("pes_codigo")]
        public virtual Fin_Pessoa FinPessoa { get; set; }
    }
}
