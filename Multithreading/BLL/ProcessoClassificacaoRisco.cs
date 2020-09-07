using System;
using System.Threading;

namespace BLL
{
    public class ProcessoClassificacaoRisco : IProcesso
    {
        public void ProcessarBase()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Processando Classificação Risco");
                Thread.Sleep(1000);
            }
        }
    }
}
