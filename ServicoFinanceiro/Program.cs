using System;
using System.Threading;

namespace ServicoFinanceiro
{
    class Program
    {
        static void Main(string[] args)
        {


            var contador = 0;

            while (true)
            {
                contador++;
                Console.Clear();

                Console.WriteLine(string.Concat("Serviço Ligado - ", DateTime.Now.ToString(), " Execução : ", contador.ToString()));

                Thread.Sleep(10000);
            }

        }
    }
}
