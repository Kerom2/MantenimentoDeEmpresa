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
    public partial class ReportarTodosLosUSPorNivel : Form
    {
        ProyectoCreditos.ModeloReportes.ModeloDatos md = new ModeloReportes.ModeloDatos();
        public ReportarTodosLosUSPorNivel()
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
                md.cargartodoslosUSporNivel(Convert.ToString(textBox1.Text));
                md.cargarcombosengridUS(dataGridView1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
}
