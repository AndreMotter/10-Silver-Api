﻿using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;

namespace Api.Application.Services
{
    public class Fin_Conta_BancariaService : IFin_Conta_BancariaService
    {
        private IRepositoryBase<Fin_Conta_Bancaria> _repository { get; set; }
        public Fin_Conta_BancariaService(IRepositoryBase<Fin_Conta_Bancaria> repository)
        {
            _repository = repository;
        }
        public Fin_Conta_Bancaria buscaPorId(int id)
        {
            if (id == 0)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.pes_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<Fin_Conta_Bancaria> lista(int pes_codigo)
        {
            var query = _repository.Query(x => x.pes_codigo == pes_codigo);

            var lista = query.Select(p => new Fin_Conta_Bancaria
            {
                pes_codigo = p.pes_codigo,
            }).OrderByDescending(x => x.cba_codigo).ToList();
            return lista;
        }
        public void remover(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void salvar(Fin_Conta_Bancaria obj)
        {
            if (obj.pes_codigo == 0)
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
