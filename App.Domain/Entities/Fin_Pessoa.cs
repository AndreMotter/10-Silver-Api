using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities
{
    public class Fin_Pessoa
    {
        [Key]
        public int pes_codigo { get; set; }
        public string pes_nome { get; set; }
        public string pes_login { get; set; }
        public string pes_senha { get; set; }
        public string pes_cpf { get; set; }
        public string pes_email { get; set; }
        public bool pes_ativo { get; set; }
        public DateTime pes_data_nascimento { get; set; }
    }
}
