using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCreditos.MantenimientoReportes
{
    public partial class ReportarClientesPorCaracter : Form
    {
        ProyectoCreditos.ModeloReportes.ModeloDatos md = new ProyectoCreditos.ModeloReportes.ModeloDatos();
        public ReportarClientesPorCaracter()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Botón buscar
            if (textBox1.Text == "")
            {
                MessageBox.Show("ERROR, FATAN DATOS POR COMPLETAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                md.cargartodoslosclientespornombre(Convert.ToString(textBox1.Text));
                md.cargarcombosengriidclientes(dataGridView1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
}
