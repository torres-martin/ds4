using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Clases
{
    public class BibliotecaCasos
    {
        public static List<Casos> Casos { get; } = new List<Casos>();

        public static void Agregar(Casos caso)
        {
            Casos.Add(caso);
        }

        public static List<Casos> ObtenerTodos()
        {
            return Casos;
        }

        public static Casos BuscarPorId(int id)
        {
            return Casos.FirstOrDefault(c => c.Id == id);
        }
    }
}