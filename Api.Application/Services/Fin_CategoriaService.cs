using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Services
{
    public class Fin_categoriaService : IFin_categoriaService
    {
        private IRepositoryBase<Fin_categoria> _repository { get; set; }
        public Fin_categoriaService(IRepositoryBase<Fin_categoria> repository)
        {
            _repository = repository;
        }

        public Fin_categoria buscaPorId(int id)
        {
            if (id == 0)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.cat_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<Fin_categoria> lista(int pes_codigo, string cat_sigla)
        {
            cat_sigla = cat_sigla ?? "";
            var query = _repository.Query(x => x.pes_codigo == pes_codigo && EF.Functions.Like(x.cat_sigla, $"%{cat_sigla}%"));

            var lista = query.Select(p => new Fin_categoria
            {
                cat_codigo = p.cat_codigo,
                cat_descricao = p.cat_descricao,
                cat_sigla = p.cat_sigla,
                cat_tipo = p.cat_tipo,
            }).OrderByDescending(x => x.cat_codigo).ToList();
            return lista;
        }


        public List<Fin_categoria> listaSelect(int pes_codigo)
        {
           var query = _repository.Query(x => x.pes_codigo == pes_codigo);
           var lista = query.Select(p => new Fin_categoria
           {
               cat_codigo = p.cat_codigo,
               cat_descricao = p.cat_descricao,
               cat_sigla = p.cat_sigla,
               cat_tipo = p.cat_tipo,
           }).OrderByDescending(x => x.cat_codigo).ToList();
           
           return lista;
        }

        public void remover(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void salvar(Fin_categoria obj)
        {

            if (obj.cat_codigo == 0)
            {
                _repository.Save(obj);
            }
            else
            {
                _repository.Update(obj);
            }
            _repository.SaveChanges();
        }
    }
}
