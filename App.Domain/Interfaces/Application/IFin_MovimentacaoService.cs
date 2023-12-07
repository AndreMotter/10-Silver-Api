using App.Domain.DTO;
using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IFin_MovimentacaoService
    {
        Fin_Movimentacao buscaPorId(int id);
        List<Fin_Movimentacao> lista(int pes_codigo, int mov_tipo, int cat_codigo, DateTime? data_inicial, DateTime? data_final);
        void salvar(Fin_Movimentacao obj);
        void remover(int id);
        Fin_Movimentacao_Resumo_MensalDTO resumoMensal(int pes_codigo, DateTime? mes_ano);
        Fin_Movimentacao_Resumo_AnualDTO resumoAnual(int pes_codigo, int ano);
    }
}
