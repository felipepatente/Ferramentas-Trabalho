namespace DicionarioInterface
{
    public class Subtracao : ICalculoConta
    {
        public double Calcular(Calculo calculo)
        {
            return calculo.Numero1 - calculo.Numero2;
        }
    }
}
