using App.Domain.DTO;
using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Api.Application.Services
{
    public class Fin_MovimentacaoService : IFin_MovimentacaoService
    {
        private IRepositoryBase<Fin_Movimentacao> _repository { get; set; }
        public Fin_MovimentacaoService(IRepositoryBase<Fin_Movimentacao> repository)
        {
            _repository = repository;
        }
        public Fin_Movimentacao buscaPorId(int id)
        {
            if (id == 0)
            {
                throw new Exception("Informe o id");
            }
            var obj = _repository.Query(x => x.pes_codigo == id).FirstOrDefault();
            return obj;
        }

        public List<Fin_Movimentacao> lista(int pes_codigo, int mov_tipo)
        {
            var query = _repository.Query(x => x.mov_tipo == mov_tipo);
            if (pes_codigo != 0)
            {
                query = query.Where(x => x.pes_codigo == pes_codigo);
            }
            var lista = query
            .Select(x => new Fin_Movimentacao
             {
                 mov_codigo = x.mov_codigo,
                 mov_valor = x.mov_valor,
                 mov_tipo = x.mov_tipo,
                 mov_data = x.mov_data,
             }).OrderByDescending(x => x.pes_codigo).ToList();
            return lista;
        }

        public void remover(int id)
        {
            _repository.Delete(id);
            _repository.SaveChanges();
        }

        public void salvar(Fin_Movimentacao obj)
        {
            if (obj.mov_codigo == 0)
            {
                _repository.Save(obj);
            }
            else
            {
                _repository.Update(obj);
            }
            _repository.SaveChanges();
        }

        public Fin_Movimentacao_Resumo_MensalDTO resumoMensal(int pes_codigo, DateTime? mov_data_inicial, DateTime? mov_data_final)
        {

            // Verifique se as datas não são nulas
            if (!mov_data_inicial.HasValue || !mov_data_final.HasValue)
            {
                throw new Exception("As datas de início e fim devem ser fornecidas.");
            }

            // Corrigir a verificação da data aqui - deve ser mov_data_final
            if (mov_data_final.Value < mov_data_inicial.Value)
            {
                throw new Exception("A data final não pode ser anterior à data inicial.");
            }

            // Certifique-se de que as datas estão com o Kind correto
            mov_data_inicial = DateTime.SpecifyKind(mov_data_inicial.Value, DateTimeKind.Utc);
            mov_data_final = DateTime.SpecifyKind(mov_data_final.Value, DateTimeKind.Utc);

            var query = _repository.Query(x =>
               x.pes_codigo == pes_codigo &&
               x.mov_data >= mov_data_inicial.Value &&
               x.mov_data <= mov_data_final.Value);

            //receita é 1
            decimal soma_receitas = 0; 
            if(query.Where(x => x.mov_tipo == 1).Select(x => x.mov_valor).Count() > 0)
            {
                soma_receitas = query.Where(x => x.mov_tipo == 1).Select(x => x.mov_valor).Sum();
            }

            //despesa é 0
            decimal soma_despesas = 0;
            if (query.Where(x => x.mov_tipo == 0).Select(x => x.mov_valor).Count() > 0)
            {
                soma_despesas = query.Where(x => x.mov_tipo == 0).Select(x => x.mov_valor).Sum();
            }

            return new Fin_Movimentacao_Resumo_MensalDTO
            {
                saldo = soma_receitas - soma_despesas,
                receita = soma_receitas,
                despesas = soma_despesas
            };
        }

    }
}
