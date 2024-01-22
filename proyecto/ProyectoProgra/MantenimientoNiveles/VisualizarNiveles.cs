using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoCreditos.MantenimientoNiveles
{
    public partial class VisualizarNiveles : Form
    {
        ModeloNiveles.ModeloDatos mn = new ModeloNiveles.ModeloDatos();
        public VisualizarNiveles()
        {
            InitializeComponent();
            mn.cargarcomboniveles(comboBox1);
            textBox1.Enabled = false;
            textBox2.Enabled = false;   
        }

        private void VisualizarNiveles_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }


        //boton buscar
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                //Aquí busca el código de nivel en la tabla de la BD
                if (mn.buscarcodigonivel(textBox1.Text) == 1)
                {
                    MessageBox.Show("NIVEL ESTÁ REGISTRADO SE MOSTRARÁN SUS DATOS", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mn.mostrarNiveles(textBox1.Text,textBox2);
                    
                }
                else
                {
                    MessageBox.Show(
                        "NIVEL NO ESTÁ REGISTRADO.., Puede Registrarlo..",
                        "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //se llama al mismo formulario para que se reinicie
                    VisualizarNiveles m = new VisualizarNiveles();
                    m.Show(); this.Hide();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //se llama al mismo formulario para que se reinicie
            VisualizarNiveles m = new VisualizarNiveles();
            m.Show(); this.Hide();
        }
    }
}
