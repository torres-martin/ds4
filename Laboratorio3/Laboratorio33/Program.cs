internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero, segundoNumero, operacion;

        Console.WriteLine("Ingrese el alto del rectangulo: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el ancho del rectangulo: ");
        segundoNumero = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();
        operacion = calculos.calculoPerimetro(primerNumero, segundoNumero);

        Console.WriteLine("Si el alto es {0} y el ancho es {1}, el perimetro del rectangulo es: {2}  ", primerNumero, segundoNumero, operacion);
    }
    public class CalculosMatematicos
    {
        public int calculoPerimetro(int a, int b)
        {
            return 2*(a + b);
        }
    }
}