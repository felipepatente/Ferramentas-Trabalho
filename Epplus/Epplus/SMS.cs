namespace Epplus
{
    public class SMS
    {
        public string _Telefone { get; set; }
        public double _Valor { get; set; }
        public string _Conta { get; set; }
        public string _Transacao { get; set; }

        public string Telefone
        {
            get
            {
                return _Telefone;
            }

            set
            {
                _Telefone = value;
            }
        }

        public double Valor
        {
            get
            {
                return _Valor;
            }

            set
            {
                _Valor = value;
            }
        }

        public string Conta
        {
            get
            {
                return _Conta;
            }

            set
            {
                _Conta = value;
            }
        }

        public string Transacao
        {
            get
            {
                return _Transacao;
            }

            set
            {
                _Transacao = value;
            }
        }        
    }
}
