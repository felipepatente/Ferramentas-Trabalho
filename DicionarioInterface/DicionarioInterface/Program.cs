namespace DicionarioInterface
{
    class Program
    {        
        static void Main(string[] args)
        {
            IProcesso processo = new ProcessoCalculo();
            processo.Processar();
        }
    }
}
