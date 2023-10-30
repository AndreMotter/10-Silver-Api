using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IUsuarioService
    {
        Usuario BuscaPorId(int id);
        List<Usuario> listaUsuarios(string usuario, int status);
        void Salvar(Usuario obj);
        void Remover(int id);
        void Ativar(int id);
    }
}
