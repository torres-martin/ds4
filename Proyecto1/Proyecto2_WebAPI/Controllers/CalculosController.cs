using Proyecto2_WebAPI.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Http;
namespace Proyecto2_WebAPI.Controllers
{
    public class CalculosController : ApiController
    {
        string cnn = ConfigurationManager.ConnectionStrings["cnn"].ConnectionString;
        [HttpGet]
        [Route("api/calculos")]
        public List<Calculo> GetTodos()
        {
            string sql = "SELECT formula, resultado FROM Historial";
            return ObtenerLista(sql);
        }
        [HttpGet]
        [Route("api/calculos/sumas")]
        public List<Calculo> GetSumas()
        {
            string sql = "SELECT formula, resultado FROM Historial WHERE formula LIKE '%+%'";
            return ObtenerLista(sql);
        }
        [HttpGet]
        [Route("api/calculos/restas")]
        public List<Calculo> GetRestas()
        {
            string sql = "SELECT formula, resultado FROM Historial WHERE formula LIKE '%-%'";
            return ObtenerLista(sql);
        }
        [HttpGet]
        [Route("api/calculos/multiplicaciones")]
        public List<Calculo> GetMultiplicaciones()
        {
            string sql = "SELECT formula, resultado FROM Historial WHERE formula LIKE '%×%'";
            return ObtenerLista(sql);
        }
        [HttpGet]
        [Route("api/calculos/divisiones")]
        public List<Calculo> GetDivisiones()
        {
            string sql = "SELECT formula, resultado FROM Historial WHERE formula LIKE '%÷%'";
            return ObtenerLista(sql);
        }
        [HttpGet]
        [Route("api/calculos/mayores/{valor}")]
        public List<Calculo> GetMayoresQue(double valor)
        {
            string sql = "SELECT formula, resultado FROM Historial WHERE resultado IS NOT NULL AND resultado > @valor";

            List<Calculo> lista = new List<Calculo>();

            using (SqlConnection con = new SqlConnection(cnn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@valor", valor);

                    SqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        Calculo c = new Calculo();
                        c.Formula = dr["formula"].ToString();

                        if (dr["resultado"] == DBNull.Value)
                            c.Resultado = null;
                        else
                            c.Resultado = Convert.ToDouble(dr["resultado"]);

                        lista.Add(c);
                    }
                }
            }
            return lista;
        }
        [HttpPost]
        [Route("api/calculos")]
        public string InsertarCalculo([FromBody] Calculo calculo)
        {
            string sql = "INSERT INTO Historial (formula, resultado) VALUES (@f, @r)";

            using (SqlConnection con = new SqlConnection(cnn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@f", calculo.Formula ?? "");

                    if (calculo.Resultado.HasValue)
                        cmd.Parameters.AddWithValue("@r", calculo.Resultado.Value);
                    else
                        cmd.Parameters.AddWithValue("@r", DBNull.Value);

                    cmd.ExecuteNonQuery();
                }
            }
            return "Registro insertado correctamente";
        }
        private List<Calculo> ObtenerLista(string sql)
        {
            List<Calculo> lista = new List<Calculo>();

            using (SqlConnection con = new SqlConnection(cnn))
            {
                con.Open();
                using (SqlCommand cmd = new SqlCommand(sql, con))
                {
                    SqlDataReader dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        Calculo c = new Calculo();
                        c.Formula = dr["formula"].ToString();
                        if (dr["resultado"] == DBNull.Value)
                            c.Resultado = null;
                        else
                            c.Resultado = Convert.ToDouble(dr["resultado"]);

                        lista.Add(c);
                    }
                }
            }
            return lista;
        }
    }
}