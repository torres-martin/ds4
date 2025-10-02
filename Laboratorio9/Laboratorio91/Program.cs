internal class Program
{
    private static void Main(string[] args)
    {
        try
        {
            double costo =0;
            string formaPago;
            string numeroCuenta;
            Console.WriteLine("Cual es el costo del producto:");
            costo = Convert.ToDouble(Console.ReadLine());
            if (costo < 0)
            {
                while (costo < 0)
                {
                    Console.WriteLine("El costo debe ser un valor positivo.");
                    costo = Convert.ToDouble(Console.ReadLine());
                }
            }
            Console.WriteLine("Forma de pago?(Efectivo o Tarjeta)");
            formaPago = Console.ReadLine().ToLower();
            if (formaPago == "efectivo")
            {
                Console.WriteLine($"El costo final es de: {costo}");
            }
            else if (formaPago == "tarjeta")
            {
                Console.WriteLine("Ingrese el numero de cuenta");
                numeroCuenta = Console.ReadLine();
                if (numeroCuenta.Length == 16)
                {
                    Console.WriteLine("Numero de cuenta válido.");
                    Console.WriteLine($"El costo final es de: {costo}");
                }
                else
                {
                    Console.WriteLine("El número de cuenta debe tener exactamente 16 caracteres.");
                }
            }
            else
            {
                Console.WriteLine("Forma de pago no valida.");
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}