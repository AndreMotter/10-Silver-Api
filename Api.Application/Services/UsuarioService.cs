using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;


namespace Api.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private IRepositoryBase<Usuario> _repository { get; set; }
        public UsuarioService(IRepositoryBase<Usuario> repository)
        {
            _repository = repository;
        }
        public Usuario BuscaPorId(int id)
        {
            if (id == 0)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.Id == id).FirstOrDefault();
            return obj;
        }

        public List<Usuario> listaUsuarios(string usuario, int status)
        {

            usuario = usuario ?? "";
            return _repository.Query(x => x.Nome.ToUpper().Contains(usuario.ToUpper())
            && status == 0 ? (x.Ativo == false || x.Ativo == true) : x.Ativo == (status == 1 ? true : false)
            ).Select(p => new Usuario
            {
                Id = p.Id,
                Nome = p.Nome
            }).OrderByDescending(x => x.Nome).ToList();
        }
        public void Remover(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }
        public void Salvar(Usuario obj)
        {
            if (String.IsNullOrEmpty(obj.Nome))
            {
                throw new Exception("Informe o nome");
            }
            if (obj.Permissao == 0)
            {
                throw new Exception("Informe um permissão");
            }

            if (obj.Id == 0)
            {
                _repository.Save(obj);
            }
            else
            {
                _repository.Update(obj);
            }
            _repository.SaveChanges();
        }
        public void Ativar(int id)
        {
            var obj = BuscaPorId(id);
            if (obj.Ativo)
            {
                obj.Ativo = false;
            }
            else
            {
                obj.Ativo = true;
            }
            _repository.Update(obj);
            _repository.SaveChanges();
        }
    }
}
