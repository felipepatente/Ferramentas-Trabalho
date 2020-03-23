using System;
using System.Configuration;
using System.IO;

namespace LeiuraEscritaArquivo
{
    public class Escrita
    {
        private string caminhoArquivo;

        public Escrita()
        {
            string data = (DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year).ToString();
            caminhoArquivo = ConfigurationManager.AppSettings["diretorioArquivo"].ToString() + data + ".txt";
        }

        public void Processar(string textoOld)
        {
            using (Stream saida = File.Open(caminhoArquivo, FileMode.Create))//FileMode.Open
            {
                using (StreamWriter escritor = new StreamWriter(saida))
                {
                    escritor.WriteLine(textoOld);
                    escritor.WriteLine("minha outra mensagem 1");
                    escritor.WriteLine("minha outra mensagem 2");
                    escritor.WriteLine("minha outra mensagem 3");
                }
            }            
        }
    }
}
