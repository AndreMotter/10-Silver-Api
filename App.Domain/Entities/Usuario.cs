using System.ComponentModel.DataAnnotations;


namespace App.Domain.Entities
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Ativo { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
        public int Permissao { get; set; }
    }
}
