using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;

namespace Parcial2
{
    public partial class Form1 : Form
    {
        string connectionString = @"Server=.\sqlexpress;Database=Registro;Trusted_Connection=True;";
        private object command;

        public Form1()
        {
            InitializeComponent();
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            txtConversion.Clear();
            txtValor.Clear();
            txtConversion.Focus();
        }



        private void btnGalones_Click(object sender, EventArgs e)
        {

            try
            {
                double valor1 = Convert.ToDouble(txtValor.Text);

                double resultado = valor1 * 0.2642;
                txtConversion.Text = resultado.ToString();
                string sql = "INSERT INTO Historial(valor1, conversion)"
                     + "VALUES('" + float.Parse(txtValor.Text) + "', '" + float.Parse(txtConversion.Text) + "')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro insertado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un valor numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLitros_Click(object sender, EventArgs e)
        {
            try
            {
                double valor1 = Convert.ToDouble(txtValor.Text);

                double resultado = valor1 * 3.785;
                txtConversion.Text = resultado.ToString();
                string sql = "INSERT INTO HISTORIAL(valor1, conversion)"// aqui puedo agregar "tipo" de conversion
                     + "VALUES('" + float.Parse(txtValor.Text) + "', '" + float.Parse(txtConversion.Text) + "')";
                SqlConnection con = new SqlConnection(connectionString);
                SqlCommand cmd = new SqlCommand(sql, con);
                cmd.CommandType = CommandType.Text;
                con.Open();
                try
                {
                    int i = cmd.ExecuteNonQuery();
                    if (i > 0)
                    {
                        MessageBox.Show("Registro insertado correctamente");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.ToString());
                }
                finally
                {
                    con.Close();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Por favor ingrese un valor numérico válido.", "Error de formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBD.Items.Clear();
            string sql = "SELECT id, valor1, conversion FROM Historial";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                cmd.CommandType = CommandType.Text;
                con.Open();

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string id = reader["id"].ToString();
                        string valor = reader["valor1"].ToString();
                        string conversion = reader["conversion"].ToString();//aqui puedo agregar "tipo" de conversion
                        listBD.Items.Add($"ID: {id} | Valor: {valor} | Conversion: {conversion}");
                    }
                }
            }
        }
    }
}
