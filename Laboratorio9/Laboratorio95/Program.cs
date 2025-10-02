using System;
using System.Collections.Generic;
public class Aleatorios
{
    Random ramdom = new Random();

    public int GenerarNumeroEntre(int min, int max)
    {
        return ramdom.Next(min, max + 1);
    }

    public int[] GenerarArregloNoRepetidos(int min, int max, int cantidad)
    {
        if (cantidad > (max - min + 1))
            throw new ArgumentException("La cantidad solicitada excede el rango disponible.");

        HashSet<int> numeros = new HashSet<int>();
        while (numeros.Count < cantidad)
        {
            int num = GenerarNumeroEntre(min, max);
            numeros.Add(num);
        }
        int[] arreglo = new int[cantidad];
        numeros.CopyTo(arreglo);
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

        int[] arreglo = aleatorios.GenerarArregloNoRepetidos(min, max, cantidad);
        Console.WriteLine($"Arreglo de numeros aleatorios no repetidos entre {min} y {max}:");
        Console.WriteLine(string.Join(", ", arreglo));
    }
}