using App.Domain.DTO;
using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IFin_MovimentacaoService
    {
        Fin_Movimentacao buscaPorId(int id);
        List<Fin_Movimentacao> lista(string pessoa, int status);
        void salvar(Fin_Movimentacao obj);
        void remover(int id);
        Fin_Movimentacao_Resumo_MensalDTO resumoMensal(int pes_codigo, DateTime? mov_data_inicial, DateTime? mov_data_final);
    }
}
