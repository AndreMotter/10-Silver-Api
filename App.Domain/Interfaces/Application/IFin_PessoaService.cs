using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IFin_PessoaService
    {
        Fin_Pessoa buscaPorId(int id);
        List<Fin_Pessoa> lista(string pessoa, string cpf);
        void salvar(Fin_Pessoa obj);
        void remover(int id);
        void ativar(int id);
    }
}
