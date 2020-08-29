namespace DicionarioInterface
{
    public class Multiplicacao : ICalculoConta
    {
        public double Calcular(Calculo calculo)
        {
            return calculo.Numero1 * calculo.Numero2;
        }
    }
}
