﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace App.Domain.Entities
{
    public class Fin_Movimentacao
    {
        [Key]
        public int mov_codigo { get; set; }
        public decimal mov_valor { get; set; }
        public int mov_tipo { get; set; }
        public string mov_observacao { get; set; }
        public DateTime mov_data { get; set; }
        public int pes_codigo { get; set; }
        [ForeignKey("pes_codigo")]
        public virtual Fin_Pessoa FinPessoa { get; set; }
        public int cat_codigo { get; set; }
        [ForeignKey("cat_codigo")]
        public virtual Fin_categoria Fin_Categoria { get; set; }
        public int cba_codigo { get; set; }
        [ForeignKey("cba_codigo")]
        public virtual Fin_Conta_Bancaria Fin_contaBancaria { get; set; }
    }
}
