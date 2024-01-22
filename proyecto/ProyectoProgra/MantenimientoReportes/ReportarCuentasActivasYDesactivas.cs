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

namespace ProyectoCreditos.MantenimientoReportes
{
    public partial class ReportarCuentasActivasYDesactivas : Form
    {
        ProyectoCreditos.ModeloReportes.ModeloDatos mdr = new ModeloReportes.ModeloDatos();
        ProyectoCreditos.ControlObjetosCuentas.ControlObjetos co = new ControlObjetosCuentas.ControlObjetos();
        public ReportarCuentasActivasYDesactivas()
        {
            InitializeComponent();
            co.cargarcombocondicion(comboBox1);
        }

        private void ReportarCuentasActivasYDesactivas_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Botón buscar
            if (comboBox1.Text == "")
            {
                MessageBox.Show("ERROR, FATAN DATOS POR COMPLETAR", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mdr.cargartodoslosdatosporestadocuenta(Convert.ToString(comboBox1.Text));
                mdr.cargarcombosengriidcuentas(dataGridView1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
}
