using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolsaTrabajoWeb.Models
{
    public class OfertaCreateVM
    {
        [Required]
        public string Titulo { get; set; }
        [Required]
        public string Descripcion { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }
        public decimal? Salario { get; set; }
    }

    public class OfertaSearchVM
    {
        public string Texto { get; set; }
        public string Ubicacion { get; set; }
        public string Tipo { get; set; }
    }
}