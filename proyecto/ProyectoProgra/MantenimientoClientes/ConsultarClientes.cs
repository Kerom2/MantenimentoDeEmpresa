using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.ControlObjetosClientes;
using ProyectoCreditos.MantenimientoCuentas;
using ProyectoCreditos.ModeloDatos;
namespace ProyectoCreditos.MantenimientoClientes
{
    public partial class ConsultarClientes : Form
    {
        ControlObjetos co = new ControlObjetos();
        ModeloDato m = new ModeloDato();
        public ConsultarClientes()
        {
            InitializeComponent();

            m.cargarcomboidentificacion(comboBox1);
            co.bloquearobjetosconsultarclientes(textBox1, textBox2, textBox3, textBox4, textBox5, button1);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //se llama al propio formulario para reiniciar el formulaario
            ConsultarClientes r = new ConsultarClientes();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }

        private void ConsultarClientes_Load(object sender, EventArgs e)
        {

        }

        //boton volver
        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Botón buscar
            if (textBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (m.buscaridentificacion(textBox1.Text) == 1)
                {
                    MessageBox.Show("CLIENTE ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m.mostrarcliente(Convert.ToString(textBox1.Text), textBox2, textBox3, textBox4, textBox5, textBox6);
                }
                else
                {
                    MessageBox.Show(
                        "CLIENTE NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //se llama al propio formulario para reiniciar el formulaario
                    ConsultarClientes r = new ConsultarClientes();
                    r.Show();
                    this.Hide();
                    textBox1.Focus();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //se llama al propio formulario para reiniciar el formulaario
            ConsultarClientes r = new ConsultarClientes();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }
    }
}
