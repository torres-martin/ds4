using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BolsaTrabajoWeb.Models
{
    public class PerfilEmpleadoVM
    {
        [Required]
        public string NombreCompleto { get; set; }
        public string Telefono { get; set; }
        public string Ubicacion { get; set; }
        public string Resumen { get; set; }
        public string CvUrl { get; set; }
    }

    public class PerfilEmpleadorVM
    {
        [Required]
        public string Empresa { get; set; }
        public string SitioWeb { get; set; }
        public string Descripcion { get; set; }
    }
}