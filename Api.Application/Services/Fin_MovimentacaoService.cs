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

        public List<Fin_Movimentacao> lista(int pes_codigo, int mov_tipo, int cat_codigo, DateTime? data_inicial, DateTime? data_final)
        {
            var query = _repository.Query(x => x.pes_codigo == pes_codigo);
            if(mov_tipo != 9999)
            {              
               query = query.Where(x => x.mov_tipo == mov_tipo);
            }
            if(cat_codigo != 0)
            {
                query = query.Where(x => x.cat_codigo == cat_codigo);
            }
            if (data_inicial.HasValue && data_final.HasValue)
            {
                query = query.Where(x => x.mov_data >= Convert.ToDateTime(data_inicial).ToUniversalTime() && x.mov_data <= Convert.ToDateTime(data_final).ToUniversalTime());
            }
            var lista = query.Select(x => new Fin_Movimentacao
            {
                mov_codigo = x.mov_codigo,
                mov_valor = x.mov_valor,
                mov_tipo = x.mov_tipo,
                mov_data = x.mov_data,
                Fin_Categoria = new Fin_categoria
                {
                    cat_codigo = x.Fin_Categoria.cat_codigo,
                    cat_sigla = x.Fin_Categoria.cat_sigla,
                },
                Fin_contaBancaria = new Fin_Conta_Bancaria
                {
                    cba_numero = x.Fin_contaBancaria.cba_numero,
                    cba_descricao = x.Fin_contaBancaria.cba_descricao
                },
            }).OrderByDescending(x => x.mov_codigo).ToList();

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

        public Fin_Movimentacao_Resumo_AnualDTO resumoAnual(int pes_codigo, int ano)
        {
            Fin_Movimentacao_Resumo_AnualDTO fin_movimentacao_resumo_anual = new Fin_Movimentacao_Resumo_AnualDTO();

            var lista_datas = new List<DateTime>();

            for (int mes = 1; mes <= 12; mes++)
            {
                lista_datas.Add(new DateTime(ano, mes, 1));
            }
            for (int i = 0; i < 12; i++)
            {
                var dados_mes = resumoMensal(pes_codigo, lista_datas[i]);

                switch (i)
                {
                    case 0: // janeiro
                        fin_movimentacao_resumo_anual.janeiro_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.janeiro_receita = dados_mes.receitas;
                        break;
                    case 1: // fevereiro
                        fin_movimentacao_resumo_anual.fevereiro_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.fevereiro_receita = dados_mes.receitas;
                        break;
                    case 2: // março
                        fin_movimentacao_resumo_anual.marco_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.marco_receita = dados_mes.receitas;
                        break;
                    case 3: // abril
                        fin_movimentacao_resumo_anual.abril_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.abril_receita = dados_mes.receitas;
                        break;
                    case 4: // maio
                        fin_movimentacao_resumo_anual.maio_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.maio_receita = dados_mes.receitas;
                        break;
                    case 5: // junho
                        fin_movimentacao_resumo_anual.junho_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.junho_receita = dados_mes.receitas;
                        break;
                    case 6: // julho
                        fin_movimentacao_resumo_anual.julho_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.julho_receita = dados_mes.receitas;
                        break;
                    case 7: // agosto
                        fin_movimentacao_resumo_anual.agosto_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.agosto_receita = dados_mes.receitas;
                        break;
                    case 8: // setembro
                        fin_movimentacao_resumo_anual.setembro_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.setembro_receita = dados_mes.receitas;
                        break;
                    case 9: // outubro
                        fin_movimentacao_resumo_anual.outubro_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.outubro_receita = dados_mes.receitas;
                        break;
                    case 10: // novembro
                        fin_movimentacao_resumo_anual.novembro_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.novembro_receita = dados_mes.receitas;
                        break;
                    case 11: // dezembro
                        fin_movimentacao_resumo_anual.dezembro_despesa = dados_mes.despesas;
                        fin_movimentacao_resumo_anual.dezembro_receita = dados_mes.receitas;
                        break;
                }
            }

            return fin_movimentacao_resumo_anual;

        }
        public Fin_Movimentacao_Resumo_MensalDTO resumoMensal(int pes_codigo, DateTime? mes_ano)
        {
            
            DateTime inicioDoMes = GetFirstDayOfMonth((DateTime)mes_ano);
            DateTime fimDoMes = GetLastDayOfMonth((DateTime)mes_ano);

            var query = _repository.Query(x => x.pes_codigo == pes_codigo && x.mov_data >= inicioDoMes.ToUniversalTime() && x.mov_data <= fimDoMes.ToUniversalTime());

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
                receitas = soma_receitas,
                despesas = soma_despesas
            };
        }

        public DateTime GetLastDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1).AddMonths(1).AddDays(-1);
        }

        public DateTime GetFirstDayOfMonth(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }
    }
}
