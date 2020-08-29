using System.Collections.Generic;

namespace DicionarioInterface.Base
{
    public class CalculosBase
    {
        public IList<Calculo> calculos = new List<Calculo>();

        public IList<Calculo> GetCalculos()
        {
            PreencherLista();
            return calculos;
        }

        private void PreencherLista()
        {
            calculos.Add(new Calculo()
            {
                Numero1 = 10,
                Operador = "+",
                Numero2 = 30
            });

            calculos.Add(new Calculo()
            {
                Numero1 = 12,
                Operador = "-",
                Numero2 = 14
            });

            calculos.Add(new Calculo()
            {
                Numero1 = 12,
                Operador = "*",
                Numero2 = 14
            });

            calculos.Add(new Calculo()
            {
                Numero1 = 12,
                Operador = "/",
                Numero2 = 14
            });

            calculos.Add(new Calculo()
            {
                Numero1 = 12,
                Operador = "*",
                Numero2 = 14
            });
        }
    }
}
