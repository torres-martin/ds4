using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Linq.Expressions;
using System.Data;
using System.Data.SqlClient;

namespace Proyecto1
{
    public partial class Calculadora : Form
    {
        private double valor1 = 0;
        private double valor2 = 0;
        private string operacion;
        string connectionString = @"Server=.\sqlexpress;Database=Calculos;Trusted_Connection=True;";
        public Calculadora()
        {
            InitializeComponent();
        }

        private void btnBorrar_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
            txtOperacion.Clear();
        }

        private void btnCE_Click(object sender, EventArgs e)
        {
            txtResultado.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "1";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "2";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "3";
        }

        private void button4_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "4";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "5";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "6";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "7";
        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "8";
        }

        private void button9_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "9";
        }

        private void button0_Click(object sender, EventArgs e)
        {
            txtResultado.Text += "0";
        }

        private void btnPunto_Click(object sender, EventArgs e)
        {
            txtResultado.Text += ".";
        }

        private void btnIgual_Click(object sender, EventArgs e)
        {
            //PROBLEMAS A LA HORA DE REALIZAR RAIZ CUADRADA Y CUADRADO
            valor2 = double.Parse(txtResultado.Text);
            txtOperacion.Text += txtResultado.Text;
            string formula = txtOperacion.Text;
            switch (operacion)
            {
                case "+": txtResultado.Text = (valor1 + valor2).ToString(); break;
                case "-": txtResultado.Text = (valor1 - valor2).ToString(); break;
                case "×": txtResultado.Text = (valor1 * valor2).ToString(); break;
                case "÷": txtResultado.Text = valor2 != 0 ? (valor1 / valor2).ToString() : "Error"; break;
                case "√": txtResultado.Text = valor2 >= 0 ? Math.Sqrt(valor2).ToString() : "Error"; break;
                case "x²": txtResultado.Text = Math.Pow(valor1, 2).ToString(); break;
            }
            double resultado = txtResultado.Text != "Error" ? double.Parse(txtResultado.Text) : 0;
            // Guardar el calculo en la base de datos
            string sql = "INSERT INTO HISTORIAL(FORMULA, RESULTADO)"
                            + "VALUES('" + formula + "', '" + resultado + "')";

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

        private void btnSuma_Click(object sender, EventArgs e)
        {
            valor1 = double.Parse(txtResultado.Text);
            txtOperacion.Text += txtResultado.Text + "+";
            operacion = "+";
            txtResultado.Clear();

        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            valor1 = double.Parse(txtResultado.Text);
            txtOperacion.Text += txtResultado + "-";
            operacion = "-";
            txtResultado.Clear();
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            valor1 = double.Parse(txtResultado.Text);
            txtOperacion.Text += txtResultado.Text + "×";
            operacion = "×";
            txtResultado.Clear();
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            valor1 = double.Parse(txtResultado.Text);
            txtOperacion.Text += txtResultado.Text + "÷";
            operacion = "÷";
            txtResultado.Clear();
        }

        private void btnRaiz_Click(object sender, EventArgs e)
        {
            //valor1 = double.Parse(txtResultado.Text);
            txtOperacion.Text = "√";
            operacion = "√";
            txtResultado.Clear();
        }

        private void btnCuadrado_Click(object sender, EventArgs e)
        {
            valor1 = double.Parse(txtResultado.Text);
            txtOperacion.Text += txtResultado.Text + "²";
            operacion = "x²";
            txtResultado.Text = "0";

        }

        private void btnSigno_Click(object sender, EventArgs e)
        {
            if (txtResultado.Text != "0")
                txtResultado.Text = (-1 * Convert.ToDouble(txtResultado.Text)).ToString();
        }

        private void btnHistorial_Click(object sender, EventArgs e)
        {
            string sql = "SELECT * FROM HISTORIAL";

            SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.CommandType = CommandType.Text;

            try
            {
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                string resultados = "";

                while (reader.Read())
                {
                    resultados += "Fórmula: " + reader["FORMULA"].ToString() + "\n";
                    resultados += "Resultado: " + reader["RESULTADO"].ToString() + "\n";
                    resultados += "------------------------\n";
                }

                if (resultados == "")
                    resultados = "No hay registros en la tabla.";

                MessageBox.Show(resultados, "Registros de HISTORIAL");

                reader.Close();
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
    }
}
