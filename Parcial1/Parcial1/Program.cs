using System;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.Write("Ingrese el valor de n: ");
        int n = int.Parse(Console.ReadLine());
        int parImpar = n % 2;
        if (parImpar == 0)
        {
            Console.WriteLine("N debe ser IMPAR");
            return;
        }

        int[,] matriz = new int[n, n];

        Aleatorios aleatorios = new Aleatorios();
        int[] valoresCruz = aleatorios.GenerarArregloEntre(1, 100, 5);

        int centro = n / 2;
        //matriz [x, y] = randoms
        matriz[centro, centro] = valoresCruz[0];
        matriz[centro - 1, centro] = valoresCruz[1];
        matriz[centro + 1, centro] = valoresCruz[2];
        matriz[centro, centro - 1] = valoresCruz[3]; 
        matriz[centro, centro + 1] = valoresCruz[4]; 

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (matriz[i, j] != 0)
                {
                    Console.Write(matriz[i, j] + "  ");
                }
                else
                {
                    Console.Write("0  ");
                }
            }
            Console.WriteLine();
        }
        int temp = 1;
        for(int v = 0; v < 5; v++)
        {
            temp *= valoresCruz[v];
        }
        Console.WriteLine($"LA multipicacion de todos los randoms es: {temp}");
    }
}

class Aleatorios
{
    Random ramdom = new Random();
    public int GenerarRandom(int min, int max)
    {
        return ramdom.Next(min, max + 1);
    }
    public int[] GenerarArregloEntre(int min, int max, int cantidad)
    {
        int[] arreglo = new int[cantidad];
        for (int i = 0; i < cantidad; i++)
        {
            arreglo[i] = GenerarRandom(min, max);
        }
        return arreglo;
    }
}
class Multiplicacion
{
    public int Cantidad;

}