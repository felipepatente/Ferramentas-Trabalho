namespace DicionarioInterface
{
    public class Divisao : ICalculoConta
    {
        public double Calcular(Calculo calculo)
        {
            return calculo.Numero1 / calculo.Numero2;
        }
    }
}
