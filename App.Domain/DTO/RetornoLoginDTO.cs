using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.DTO
{
    public class RetornoLoginDTO
    {
        public bool autenticado {  get; set; }
        public DadosUsuarioDTO dadosUsuario {  get; set; }
    }

    public class DadosUsuarioDTO
    {
        public int pes_codigo { get; set; }
        public string pes_login { get; set; }
        public int pes_permissao { get; set; }
    }
}
