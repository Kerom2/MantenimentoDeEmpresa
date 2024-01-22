using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.ControlObjetosMovimientos;
namespace ProyectoCreditos.Mantenimiento_Movimientos
{
    public partial class ConsultarMovimiento : Form
    {
        ControlObjetos co = new ControlObjetos();
        ProyectoCreditos.ModeloMovimientos.ModeloDatos mdm = new ProyectoCreditos.ModeloMovimientos.ModeloDatos();
        public ConsultarMovimiento()
        {
            InitializeComponent();
            mdm.cargarcombomovimiento(comboBox1);
            co.bloquearobjetosconsultarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1);
            textBox8.Focus();
        }

        private void ConsultarMovimiento_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Botón buscar
            if (textBox8.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (mdm.buscarmovimiento(textBox8.Text) == 1)
                {
                    MessageBox.Show("MOVIMIENTO ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mdm.mostrarmovimiento(Convert.ToString(textBox8.Text), textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
                    co.bloquearobjetosconsultarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1);
                }
                else
                {
                    MessageBox.Show(
                        "MOVIMIENTO NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.bloquearobjetosconsultarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1);
                    co.limpiarcampostextosconsultar(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
                    textBox8.Focus();
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botón Limpiar
            co.limpiarcampostextosconsultar(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
            co.bloquearobjetosconsultarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1);
            textBox8.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox8.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox8.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
