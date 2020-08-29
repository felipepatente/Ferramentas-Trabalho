using DicionarioInterface.Base;
using System;
using System.Collections.Generic;

namespace DicionarioInterface
{
    public class ProcessoCalculo: IProcesso
    {
        public void Processar()
        {
            IList<ICalculoConta> calculos = new ContasMatematica().GetCalculos();
            MostrarCalculosList(calculos);

            IList<Calculo> calculoDic = new CalculosBase().GetCalculos();
            MostrarCalculosDic(calculoDic);
        }

        private void MostrarCalculosList(IList<ICalculoConta> calculos)
        {
            Calculo oCalculo = new Calculo();
            oCalculo.Numero1 = 20;
            oCalculo.Numero2 = 10;

            foreach (var calculo in calculos)
            {
                double resultado = calculo.Calcular(oCalculo);
                Console.WriteLine(resultado);
            }
        }

        private void MostrarCalculosDic(IList<Calculo> calculos)
        {
            ContasMatematica contaMatematica = new ContasMatematica();

            IDictionary<string, ICalculoConta> contaMatematicaDic = contaMatematica.GetCalculosDic();

            foreach (var calculo in calculos)
            {
                ICalculoConta calculoConta = contaMatematicaDic[calculo.Operador];
                double resultado = calculoConta.Calcular(calculo);
                Console.WriteLine($"{calculo.Numero1} {calculo.Operador} {calculo.Numero2} = {resultado}");
            }
        }
    }
}
