using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Parcial3.Clases
{
    public class Casos
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public string TipoCaso { get; set; }
        public string Abogado { get; set; }
        public DateTime FechaLimite { get; set; }
        public string Estado { get; set; } = "Abierto";
    }
}