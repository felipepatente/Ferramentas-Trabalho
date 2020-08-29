using System.Collections.Generic;

namespace DicionarioInterface
{
    public class ContaMatematica
    {
        public IDictionary<string, ICalculoConta> dicCalculos = new Dictionary<string, ICalculoConta>();
        
        public IDictionary<string, ICalculoConta> GetCalculos()
        {
            dicCalculos.Add("+", new Soma());
            dicCalculos.Add("-", new Subtracao());
            dicCalculos.Add("/", new Divisao());
            dicCalculos.Add("*", new Multiplicacao());

            return dicCalculos;
        }
    }
}
