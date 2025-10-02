using System;

public class Aleatorios
{
    Random ramdom = new Random();
    public int GenerarNumeroEntre(int min, int max)
    {
        return ramdom.Next(min, max + 1);
    }

    public int[] GenerarArregloEntre(int min, int max, int cantidad)
    {
        int[] arreglo = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = GenerarNumeroEntre(min, max);
        }
        return arreglo;
    }
    static void Main(string[] args)
    {
        Aleatorios aleatorios = new Aleatorios();

        Console.WriteLine("Ingrese el valor minimo:");
        int min = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese el valor maximo:");
        int max = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Ingrese la cantidad de numeros para el arreglo:");
        int cantidad = Convert.ToInt32(Console.ReadLine());

        int numero = aleatorios.GenerarNumeroEntre(min, max);
        Console.WriteLine($"Numero aleatorio entre {min} y {max}: {numero}");

        int[] arreglo = aleatorios.GenerarArregloEntre(min, max, cantidad);
        Console.WriteLine($"Arreglo de números aleatorios entre {min} y {max}:");
        Console.WriteLine(string.Join(", ", arreglo));
    }
}