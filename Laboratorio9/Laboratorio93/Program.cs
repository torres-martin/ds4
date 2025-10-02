internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Ingrese la longitud del primer lado:");
        double lado1 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese la longitud del segundo lado:");
        double lado2 = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Ingrese la longitud del tercer lado:");
        double lado3 = Convert.ToDouble(Console.ReadLine());

        if (lado1 + lado2 > lado3 && lado1 + lado3 > lado2 && lado2 + lado3 > lado1)
        {
            if (lado1 == lado2 && lado2 == lado3)
            {
                Console.WriteLine("El triángulo es equilátero.");
            }
            else if (lado1 == lado2 || lado1 == lado3 || lado2 == lado3)
            {
                Console.WriteLine("El triángulo es isósceles.");
            }
            else
            {
                Console.WriteLine("El triángulo es escaleno.");
            }
        }
        else
        {
            Console.WriteLine("Los valores ingresados no forman un triángulo válido.");
        }
    }
}