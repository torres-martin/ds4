using System;

namespace Laboratorio21
{
    public class Program
    {
        public static void Main()
        {
            //Asignado valor a variable estastica.
            MyClass.Valor = 1;
            Console.WriteLine(MyClass.Valor);
        }
    }
    public class MyClass
    {
        //Declarando variable estatica.
        public static int Valor;
    }
}