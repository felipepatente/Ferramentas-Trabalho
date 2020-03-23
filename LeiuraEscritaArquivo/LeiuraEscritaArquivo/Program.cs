namespace LeiuraEscritaArquivo
{
    class Program
    {
        static void Main(string[] args)
        {
            Leitura leitura = new Leitura();            
            string textoOld = leitura.Processar2();

            Escrita escrita = new Escrita();
            escrita.Processar(textoOld);

        }
    }
}
