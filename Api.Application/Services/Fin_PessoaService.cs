using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;


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

        public List<Fin_Pessoa> lista(string pessoa, int status)
        {

            pessoa = pessoa ?? "";
            return _repository.Query(x => x.pes_nome.ToUpper().Contains(pessoa.ToUpper())
            && status == 0 ? (x.pes_ativo == false || x.pes_ativo == true) : x.pes_ativo == (status == 1 ? true : false)
            ).Select(p => new Fin_Pessoa
            {
                pes_codigo = p.pes_codigo,
                pes_nome = p.pes_nome
            }).OrderByDescending(x => x.pes_nome).ToList();
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
                _repository.Save(obj);
            }
            else
            {
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
