using System;
using System.Configuration;
using System.IO;

namespace LeiuraEscritaArquivo
{
    public class Leitura
    {
        private string caminhoArquivo;

        public Leitura()
        {
            string data = (DateTime.Now.Day.ToString().PadLeft(2, '0') + DateTime.Now.Month.ToString().PadLeft(2, '0') + DateTime.Now.Year).ToString();
            caminhoArquivo = ConfigurationManager.AppSettings["diretorioArquivo"].ToString() + data + ".txt";
        }

        public void Processar1()
        {            
            if (File.Exists(caminhoArquivo))
            {
                using (Stream entrada = File.Open(caminhoArquivo, FileMode.Open))
                {
                    using (StreamReader leitor = new StreamReader(entrada))
                    {
                        string linha = leitor.ReadLine();

                        Console.WriteLine(linha);
                        while (linha != null)
                        {
                            linha = leitor.ReadLine();
                            Console.WriteLine(linha);
                        }
                    }
                }                
            }            
        }

        public string Processar2()
        {
            string arquivo = "";

            if (File.Exists(caminhoArquivo))
            {
                using (Stream entrada = File.Open(caminhoArquivo, FileMode.Open))
                {
                    using (StreamReader leitor = new StreamReader(entrada))
                    {
                        arquivo = leitor.ReadToEnd();
                        Console.WriteLine(arquivo);
                    }
                }                
            }

            return arquivo;
        }
    }
}
