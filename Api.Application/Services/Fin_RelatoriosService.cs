using App.Domain.Entities;
using App.Domain.Interfaces.Application;
using App.Domain.Interfaces.Repositories;
using SelectPdf;
using System.Text;

namespace Api.Application.Services
{
    public class Fin_RelatoriosService : IFin_RelatoriosService
    {
        private IRepositoryBase<Fin_Movimentacao> _repositoryMovimentos { get; set; }
        public Fin_RelatoriosService(IRepositoryBase<Fin_Movimentacao> repositoryMovimentos)
        {
            _repositoryMovimentos = repositoryMovimentos;
        }

        public byte[] imprimirMovimentos(int pes_codigo, int mov_tipo, int cat_codigo, DateTime? data_inicial, DateTime? data_final)
        {

            StringBuilder html = new StringBuilder();
            var query = _repositoryMovimentos.Query(x => x.pes_codigo == pes_codigo);
            if (mov_tipo != 9999)
            {
                query = query.Where(x => x.mov_tipo == mov_tipo);
            }
            if (cat_codigo != 0)
            {
                query = query.Where(x => x.cat_codigo == cat_codigo);
            }
            if (data_inicial.HasValue && data_final.HasValue)
            {
                query = query.Where(x => x.mov_data >= Convert.ToDateTime(data_inicial).ToUniversalTime() && x.mov_data <= Convert.ToDateTime(data_final).ToUniversalTime());
            }
            var movimentos = query.Select(x => new Fin_Movimentacao
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

            html.Append($@"
            <table style='width: 100%;font-size: 14px;font-family:Helvetica;padding: 10px;'>
                <tr>
                    <td style='text-align: left; width: 50%;'>
                        <h2>Relatório de Movimentos</h2>
                    </td>
                    <td style='text-align: right; width: 50%;'>
                        <p>Data de Emissão: <strong>{DateTime.Now.ToString("dd 'de' MMMM 'de' yyyy")}</strong></p>
                        <p><strong>Sistema Silver Finanças</strong></p>
                    </td>
                </tr>
            </table>");

            var receitas = movimentos.Where(x => x.mov_tipo == 1).ToList();

            if (receitas.Count() > 0)
            {
                html.Append($@"
                <div style='width: 100%;font-size: 14px;font-family:Helvetica;margin-top: 10px'>
                        <strong>Receitas</strong>
                </div>");

                html.Append($@"<table style='width: 100%;font-size: 14px;font-family:Helvetica; page-break-inside: avoid;margin-top: 12px;border: solid black 1px;background-color: #B2CFDB;'>
                            <tbody>
                                <tr>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Data Movimento</strong></td>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Categoria</strong></td>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Conta</strong></td>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Valor</strong></td
                                </tr>
                            </tbody>
                 </table>");



                foreach (var mov in receitas)
                {

                    html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.mov_data.ToString("dd/MM/yyyy")}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.Fin_Categoria.cat_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.Fin_contaBancaria.cba_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.mov_valor.ToString("n2")}</td>
                            </tr>
                        </tbody>
                    </table>");
                }

                html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'><strong>Totais<strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'></td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'></td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'><strong>{receitas.Sum(x => x.mov_valor).ToString("n2")}</strong></td>
                            </tr>
                        </tbody>
                </table>");

            }

            var despesas = movimentos.Where(x => x.mov_tipo == 0).ToList();

            if (despesas.Count > 0)
            {
                html.Append($@"
                <div style='width: 100%;font-size: 14px;font-family:Helvetica;margin-top: 10px'>
                    <strong>Despesas</strong>
                </div>");

                    html.Append($@"<table style='width: 100%;font-size: 14px;font-family:Helvetica; page-break-inside: avoid;margin-top: 12px;border: solid black 1px;background-color: #B2CFDB;'>
                            <tbody>
                                <tr>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Data Movimento</strong></td>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Categoria</strong></td>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Conta</strong></td>
                                    <td style='text-align:left; padding: 3px; width:25%;'><strong>Valor</strong></td
                                </tr>
                            </tbody>
                 </table>");


                foreach (var mov in despesas)
                {

                    html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.mov_data.ToString("dd/MM/yyyy")}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.Fin_Categoria.cat_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.Fin_contaBancaria.cba_descricao}</td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'>{mov.mov_valor.ToString("n2")}</td>
                            </tr>
                        </tbody>
                    </table>");
                }

                html.Append($@"
                       <table style='width: 100%;font-size: 12px;font-family:Helvetica;border-bottom: solid black 1px;border-right: solid black 1px;border-left:solid black 1px;'>
                        <tbody>
                            <tr>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'><strong>Totais<strong></td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'></td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'></td>
                                <td style='text-align:left; padding: 3px; width:25%;page-break-inside: avoid'><strong>{despesas.Sum(x => x.mov_valor).ToString("n2")}<strong></td>
                            </tr>
                        </tbody>
                 </table>"); 
            }

            html.Append($@"
            <div style='width: 100%;font-size: 14px;font-family:Helvetica;margin-top: 10px'>
                <strong>Resumo Movimentos:</strong></br>
                Receitas: {receitas.Sum(x => x.mov_valor).ToString("n2")}</br>
                Despesas: {despesas.Sum(x => x.mov_valor).ToString("n2")}</br>
                <strong>Saldo: {(receitas.Sum(x => x.mov_valor) - despesas.Sum(x => x.mov_valor)).ToString("n2")}</strong></br>
            </div>");

            HtmlToPdf converter = new HtmlToPdf();
            converter.Options.PdfPageSize = PdfPageSize.A4;
            converter.Options.PdfPageOrientation = PdfPageOrientation.Portrait;
            PdfDocument doc = converter.ConvertHtmlString(html.ToString());
            using (MemoryStream ms = new MemoryStream())
            {
                doc.Save(ms);
                byte[] bytes = ms.ToArray();
                doc.Close();

                return bytes;
            }
        }

    }
}
