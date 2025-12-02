using Parcial3.Clases;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Parcial3
{
    public partial class _Default : Page
    {
        private string cadenaConexion = ConfigurationManager.ConnectionStrings["ConexionCasos"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarGrid();
            }
        }

        private void CargarGrid()
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string sql = "SELECT Id, Cliente, TipoCaso, Abogado, FechaLimite, Estado FROM CasosLegales";
                    SqlDataAdapter da = new SqlDataAdapter(sql, con);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    gvCasos.DataSource = dt;
                    gvCasos.DataBind();
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cargar los casos: " + ex.Message;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string sql = @"INSERT INTO CasosLegales (Id, Cliente, TipoCaso, Abogado, FechaLimite, Estado)
                                   VALUES (@Id, @Cliente, @TipoCaso, @Abogado, @FechaLimite, @Estado)";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));
                        cmd.Parameters.AddWithValue("@Cliente", txtCliente.Text);
                        cmd.Parameters.AddWithValue("@TipoCaso", txtTipoCaso.Text);
                        cmd.Parameters.AddWithValue("@Abogado", txtAbogado.Text);
                        cmd.Parameters.AddWithValue("@FechaLimite", DateTime.Parse(txtFechaLimite.Text));
                        cmd.Parameters.AddWithValue("@Estado", "Abierto");

                        con.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                lblMensaje.Text = "Caso registrado correctamente en la base de datos.";
                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al registrar el caso: " + ex.Message;
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string sql = @"SELECT Id, Cliente, TipoCaso, Abogado, FechaLimite, Estado 
                                   FROM CasosLegales 
                                   WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                        con.Open();
                        using (SqlDataReader dr = cmd.ExecuteReader())
                        {
                            if (dr.Read())
                            {
                                txtCliente.Text = dr["Cliente"].ToString();
                                txtTipoCaso.Text = dr["TipoCaso"].ToString();
                                txtAbogado.Text = dr["Abogado"].ToString();
                                txtFechaLimite.Text = Convert.ToDateTime(dr["FechaLimite"]).ToString("yyyy-MM-dd");
                                lblMensaje.Text = "Caso encontrado. Estado: " + dr["Estado"].ToString();
                            }
                            else
                            {
                                lblMensaje.Text = "No se encontró un caso con ese ID.";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error en la búsqueda: " + ex.Message;
            }
        }

        protected void btnCerrar_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(cadenaConexion))
                {
                    string sql = @"UPDATE CasosLegales 
                                   SET Estado = 'Cerrado'
                                   WHERE Id = @Id";

                    using (SqlCommand cmd = new SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@Id", int.Parse(txtId.Text));

                        con.Open();
                        int filas = cmd.ExecuteNonQuery();

                        if (filas > 0)
                        {
                            lblMensaje.Text = "Caso cerrado correctamente.";
                        }
                        else
                        {
                            lblMensaje.Text = "No existe un caso con ese ID.";
                        }
                    }
                }

                CargarGrid();
            }
            catch (Exception ex)
            {
                lblMensaje.Text = "Error al cerrar el caso: " + ex.Message;
            }
        }

        protected void btnListar_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }
    }
}