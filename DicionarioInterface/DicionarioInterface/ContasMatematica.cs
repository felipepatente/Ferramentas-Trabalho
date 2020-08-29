using System.Collections.Generic;

namespace DicionarioInterface
{
    public class ContasMatematica
    {
        public IList<ICalculoConta> GetCalculos()
        {
            IList<ICalculoConta> calculos = new List<ICalculoConta>();

            calculos.Add(new Soma());
            calculos.Add(new Subtracao());
            calculos.Add(new Multiplicacao());
            calculos.Add(new Divisao());

            return calculos;
        }

        public IDictionary<string, ICalculoConta> GetCalculosDic()
        {

            IDictionary<string, ICalculoConta> dicCalculos = new Dictionary<string, ICalculoConta>();
            dicCalculos.Add("+", new Soma());
            dicCalculos.Add("/", new Divisao());
            dicCalculos.Add("*", new Multiplicacao()); 
            dicCalculos.Add("-", new Subtracao());

            return dicCalculos;
        }
    }
}
