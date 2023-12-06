using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;

namespace Api.Application.Services
{
    public class LoginService : ILoginService
    {
        private IRepositoryBase<Fin_Pessoa> _repository { get; set; }
        public LoginService(IRepositoryBase<Fin_Pessoa> repository)
        {
            _repository = repository;
        }

        public RetornoLoginDTO Logar(LoginDTO login)
        {
            var obj = _repository.Query(x => x.pes_senha.Trim() == login.Senha.Trim() && x.pes_login.Trim() == login.Usuario.Trim()).FirstOrDefault();

            if (obj != null)
            {
                return new RetornoLoginDTO()
                {
                    autenticado = true,
                    dadosUsuario = new DadosUsuarioDTO()
                    {
                        pes_codigo = obj.pes_codigo,
                        pes_login = obj.pes_login,
                        pes_permissao = obj.pes_permissao
                    }
                };
            }
            else
            {
                return new RetornoLoginDTO()
                {
                    autenticado = false,
                    dadosUsuario = null
                };
            }
        }
    }
}
