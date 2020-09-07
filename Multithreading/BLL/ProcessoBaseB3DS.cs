using System;
using System.Threading;

namespace BLL
{
    public class ProcessoBaseB3DS: IProcesso
    {
        public void ProcessarBase()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Processando B - 3DS");
                Thread.Sleep(1000);
            }
        }
    }
}
