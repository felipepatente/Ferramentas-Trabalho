using BLL;
using System.Threading;

namespace Multithreading
{
    public static class ProcessandoBases
    {
        public static void ProcessarBases()
        {            
            Thread baseA3DS = new Thread(new ThreadStart(ProcessoBaseA3DS));            
            baseA3DS.Start();

            Thread baseB3DS = new Thread(new ThreadStart(ProcessoBaseB3DS));
            baseB3DS.Start();

            Thread baseC3DS = new Thread(new ThreadStart(ProcessoBaseC3DS));
            baseC3DS.Start();

            Thread baseClassificacaoRisco = new Thread(new ThreadStart(ProcessoBaseClassificacaoRisco));
            baseClassificacaoRisco.Start();

            Thread basePRM = new Thread(new ThreadStart(ProcessoBaseAPRM));
            basePRM.Start();
        }

        static void ProcessoBaseA3DS()
        {
            IProcesso processo = new ProcessoBaseA3DS();
            processo.ProcessarBase();
        }

        static void ProcessoBaseB3DS()
        {
            IProcesso processo = new ProcessoBaseB3DS();
            processo.ProcessarBase();
        }

        static void ProcessoBaseC3DS()
        {
            IProcesso processo = new ProcessoBaseC3DS();
            processo.ProcessarBase();
        }

        static void ProcessoBaseClassificacaoRisco()
        {
            IProcesso processo = new ProcessoClassificacaoRisco();
            processo.ProcessarBase();
        }

        static void ProcessoBaseAPRM()
        {
            IProcesso processo = new ProcessoBasePRM();
            processo.ProcessarBase();
        }
    }
}
