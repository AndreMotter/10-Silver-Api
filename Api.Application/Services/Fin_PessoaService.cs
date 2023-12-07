using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Api.Application.Services
{
    public class Fin_PessoaService : IFin_PessoaService
    {
        private IRepositoryBase<Fin_Pessoa> _repository { get; set; }
        public Fin_PessoaService(IRepositoryBase<Fin_Pessoa> repository)
        {
            _repository = repository;
        }
        public Fin_Pessoa buscaPorId(int id)
        {
            if (id == 0)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.pes_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<Fin_Pessoa> lista(string pessoa, string cpf)
        {
            var query = _repository.Query(x => 1 == 1);
           
            if (!String.IsNullOrWhiteSpace(pessoa))
            {
                query = query.Where(x => EF.Functions.Like(x.pes_nome.Trim().ToUpper(), $"%{pessoa.Trim().ToUpper()}%"));
            }

            if (!String.IsNullOrWhiteSpace(cpf))
            {
                query = query.Where(x => EF.Functions.Like(x.pes_cpf.Trim(), $"%{Regex.Replace(cpf.Trim(), @"[\.-/]", "")}%"));
            }

            var lista = query.Select(p => new Fin_Pessoa
            {
                pes_codigo = p.pes_codigo,
                pes_nome = p.pes_nome,
                pes_cpf = p.pes_cpf,
                pes_ativo = p.pes_ativo,
                pes_email = p.pes_email,
                pes_data_nascimento = p.pes_data_nascimento,
            }).OrderByDescending(x => x.pes_codigo).ToList();

            return lista;
        }
        public void remover(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void salvar(Fin_Pessoa obj)
        {
            if (String.IsNullOrEmpty(obj.pes_nome))
            {
                throw new Exception("Informe o nome");
            }

            if (obj.pes_codigo == 0)
            {
                obj.pes_ativo = true;
                obj.pes_data_nascimento = obj.pes_data_nascimento.ToUniversalTime();
                _repository.Save(obj);
            }
            else
            {
                obj.pes_data_nascimento = obj.pes_data_nascimento.ToUniversalTime();
                _repository.Update(obj);
            }
            _repository.SaveChanges();
        }
        public void ativar(int id)
        {
            var obj = buscaPorId(id);
            if (obj.pes_ativo)
            {
                obj.pes_ativo = false;
            }
            else
            {
                obj.pes_ativo = true;
            }
            _repository.Update(obj);
            _repository.SaveChanges();
        }
    }
}
