using System;
using System.Threading;

namespace BLL
{
    public class ProcessoBaseC3DS : IProcesso
    {
        public void ProcessarBase()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Processando C - 3DS");
                Thread.Sleep(1000);
            }
        }
    }
}
