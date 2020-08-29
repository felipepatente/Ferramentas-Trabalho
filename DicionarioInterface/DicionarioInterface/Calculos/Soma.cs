namespace DicionarioInterface
{
    public class Soma : ICalculoConta
    {
        public double Calcular(Calculo calculo)
        {
            return calculo.Numero1 + calculo.Numero2;
        }
    }
}
