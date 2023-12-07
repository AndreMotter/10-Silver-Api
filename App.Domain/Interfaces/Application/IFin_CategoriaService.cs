using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IFin_categoriaService
    {
        Fin_categoria buscaPorId(int id);
        List<Fin_categoria> lista(int pes_codigo, string cat_sigla);
        List<Fin_categoria> listaSelect(int pes_codigo);
        void salvar(Fin_categoria obj);
        void remover(int id);
    }
}
