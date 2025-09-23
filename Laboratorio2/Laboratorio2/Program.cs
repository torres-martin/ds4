using System;

namespace Laboratorio2
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            //Ejemplo utilizando las variables de instancia de clase.
            client.FirstName = "Martin";
            client.LastName = "Torres";
            client.Age = 20;
            client.Id = 1;

            Console.WriteLine(client.GetFullName());
        }
    }
    public class Client
    {        
        //Declarando variables de instancia en clase.
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }

        public string GetFullName()
        {
            //Utilizando las variables de instancia dentro de metodos de la clase.
            return FirstName + " " + LastName;
        }
    }

}