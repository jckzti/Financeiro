using FinanceiroServico.Data.Configuracao;
using FinanceiroServico.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FinanceiroServico
{
    class Program
    {
        static void Main(string[] args)
        {
            Int64 contador = 0;
            Int64 contadorExecucaoDia = 0;

            while (true)
            {
                string diaExecucao = System.Configuration.ConfigurationManager.AppSettings["diaExecucao"];

                if (DateTime.Now.Day == Convert.ToInt32(diaExecucao))
                {
                    contadorExecucaoDia++;

                    EnumerableExecutor();
                    Console.Clear();
                    Console.WriteLine(string.Concat("Serviço Ligado versão 1.0.0 - ", DateTime.Now.ToString(), " Execução : ", contadorExecucaoDia.ToString()));
                    Log(string.Concat("Serviço Ligado versão 1.0.0  - ", DateTime.Now.ToString(), " Execução: ", contadorExecucaoDia.ToString()));

                    Thread.Sleep(60000);
                }
                else
                {
                    contadorExecucaoDia = 0;
                    Console.WriteLine(string.Concat("Serviço Ligado versão 1.0.0 - ", DateTime.Now.ToString(), " Execução : ", contador.ToString()));

                    Thread.Sleep(60000);
                }

            }
        }



        private static void EnumerableExecutor()
        {

            try
            {
                string diaExecucao = System.Configuration.ConfigurationManager.AppSettings["diaExecucao"];

                if (DateTime.Now.Day == Convert.ToInt32(diaExecucao))
                {

                    //  Log("Cria Contexto");
                    using (var _contexto = new Contexto())
                    {
                        // Log("Cria Contexto - Sucesso ");
                        var lista = _contexto.SistemaFinanceiro.Where(s => s.GerarCopiaDespesa).ToList();

                        // Log("Lista Sistemas ");
                        if (lista.Any())
                        {
                            // Log("Gera Despesas Inicio ");
                            GerarDispesas(lista);
                        }

                    }
                }

            }
            catch (Exception erro)
            {
                Log(erro.Message);
            }
        }

        private static void GerarDispesas(List<SistemaFinanceiro> listaSistemaFinanceiro)
        {

            Log("Gera Despesas - Inicio Foreach ");
            foreach (var item in listaSistemaFinanceiro)
            {

                // Log("Gera Despesas Inicio Cria Contexto ");
                using (var _contexto = new Contexto())
                {

                    var dataAtual = DateTime.Now;
                    var mes = dataAtual.Month;
                    var ano = dataAtual.Year;

                    //  Log("Gera Despesas - Verifica se já existe esse mes ");

                    var dispesasJáCadastradas = (from d in _contexto.Despesa
                                                 join c in _contexto.Categoria on d.IdCategoria equals c.Id
                                                 where c.IdSistema == item.Id
                                                 && d.Mes == mes
                                                 && d.Ano == ano
                                                 select d.Id).Any();


                    if (!dispesasJáCadastradas)
                    {

                        //  Log("Gera Despesas Inicio  - lista novas dipesas para o mês");

                        var despesasSistema = (from d in _contexto.Despesa
                                               join c in _contexto.Categoria on d.IdCategoria equals c.Id
                                               where c.IdSistema == item.Id
                                               && d.Mes == item.MesCopia
                                               && d.Ano == item.AnoCopia
                                               select d).ToList();

                        despesasSistema.ForEach(d =>
                    {
                        d.DataVencimento = new DateTime(ano, mes, d.DataVencimento.Day);  //  d.DataVencimento.AddMonths(1);
                        d.Mes = mes;
                        d.Ano = ano;
                        d.DataAlteracao = DateTime.MinValue; ;
                        d.DataCadastro = dataAtual;
                        d.DataPagamento = DateTime.MinValue;
                        d.Pago = false;

                    });


                        // NOVO MES
                        item.Mes = mes;
                        item.Ano = ano;
                        item.DiaFechamento = 1;
                        _contexto.Entry(item).State = EntityState.Modified;

                        //  Log("Gera Despesas - insere dispesas e altera sistema ");

                        _contexto.Despesa.AddRange(despesasSistema);
                        _contexto.SaveChanges();

                        //  Log("Gera Despesas final ");


                    }


                }
            }


        }

        private static void AppendLog(string logMensagem, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entrada : ");
                txtWriter.WriteLine($"{DateTime.Now.ToLongTimeString()} {DateTime.Now.ToLongDateString()}");
                txtWriter.WriteLine("  :");
                txtWriter.WriteLine($"  :{logMensagem}");
                txtWriter.WriteLine("------------------------------------");
            }
            catch (Exception ex)
            {

            }
        }

        public static bool Log(string strMensagem, string strNomeArquivo = "ArquivoLog.txt")
        {
            try
            {

                string caminhoArquivo = Path.Combine(@"C:\Log\", strNomeArquivo);
                if (!File.Exists(caminhoArquivo))
                {
                    FileStream arquivo = File.Create(caminhoArquivo);
                    arquivo.Close();
                }
                using (StreamWriter w = File.AppendText(caminhoArquivo))
                {
                    AppendLog(strMensagem, w);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }



    }
}
