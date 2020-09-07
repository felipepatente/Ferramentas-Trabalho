using System;
using System.Threading;

namespace BLL
{
    public class ProcessoBasePRM : IProcesso
    {
        public void ProcessarBase()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Processando PRM");
                Thread.Sleep(1000);
            }
        }
    }
}
