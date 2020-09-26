using System;
using System.Collections.Generic;

namespace ProjetoAccess
{
    class Program
    {
        static void Main(string[] args)
        {
            List<SMS> smss = new List<SMS>();

            smss.Add(new SMS() {
                Telefone = "11958803521",
                Valor = 25,
                Transacao = "TED/DOC",
                Conta = "142500362514",
                RespostaCliente = "NÂO",
                DataEnvio = DateTime.Now,
                DataRecibimento = DateTime.Now
            });

            smss.Add(new SMS()
            {
                Telefone = "11958803544",
                Valor = 25,
                Transacao = "TED/DOC",
                Conta = "142500362544",
                RespostaCliente = "SIM",
                DataEnvio = DateTime.Now,
                DataRecibimento = DateTime.Now
            });

            smss.Add(new SMS()
            {
                Telefone = "11958803555",
                Valor = 25,
                Transacao = "TED/DOC",
                Conta = "142500362555",
                RespostaCliente = "SIM",
                DataEnvio = DateTime.Now,
                DataRecibimento = DateTime.Now
            });

            new AcessoAccess().GravarAccessSMS(smss);
            new AcessoAccess().GravarAccessSMS(smss);

            Console.WriteLine("Finalizou com sucesso");
        }
    }
}
