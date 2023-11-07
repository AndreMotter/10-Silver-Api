﻿using App.Domain.Entities;

namespace App.Domain.Interfaces.Application
{
    public interface IFin_categoriaService
    {
        Fin_categoria buscaPorId(int id);
        List<Fin_categoria> lista(string cat_sigla, int cat_tipo);
        void salvar(Fin_categoria obj);
        void remover(int id);
    }
}
