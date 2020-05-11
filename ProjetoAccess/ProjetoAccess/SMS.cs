using System;

namespace ProjetoAccess
{
    public class SMS
    {
        public string Telefone { get; set; }
        public float Valor { get; set; }
        public string Transacao { get; set; }
        public string Conta { get; set; }
        public DateTime DataEnvio { get; set; }
        public string RespostaCliente { get; set; }
        public DateTime DataRecibimento { get; set; }
    }
}
