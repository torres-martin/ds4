internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero, operacion;

        Console.WriteLine("Ingrese el primer numero: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el segundo numero: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();
        operacion = calculos.Calcular(primerNumero, segundoNumero);

        Console.WriteLine("El resultado de ({0} + {1})*({0} - {1}) es {2} ", primerNumero, segundoNumero, operacion);
    }
    public class CalculosMatematicos
    {
        public int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
    }
}