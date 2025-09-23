internal class Program
{
    private static void Main(string[] args)
    {
        int primerNumero;
        double operacion;

        Console.WriteLine("Ingrese el radio del circulo: ");
        primerNumero = Convert.ToInt32(Console.ReadLine());

        CalculosMatematicos calculos = new CalculosMatematicos();
        operacion = calculos.calculoArea(primerNumero);

        Console.WriteLine("Si el radio es {0} el area de la circuferancia es: {1} ", primerNumero, operacion);
    }
    public class CalculosMatematicos
    {
        public int Calcular(int a, int b)
        {
            return (a + b) * (a - b);
        }
        public double calculoArea(int area)
        {
            return 3.1416 * (area *area);
        }
    }
}