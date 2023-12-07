using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IFin_Conta_BancariaService
    {
        Fin_Conta_Bancaria buscaPorId(int id);
        List<Fin_Conta_Bancaria> lista(int pes_codigo);
        List<Fin_Conta_Bancaria> listaSelect(int pes_codigo);
        void salvar(Fin_Conta_Bancaria obj);
        void remover(int id);
    }
}
