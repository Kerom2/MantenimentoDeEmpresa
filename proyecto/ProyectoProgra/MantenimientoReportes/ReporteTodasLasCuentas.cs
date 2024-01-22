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
    public partial class ReporteTodasLasCuentas : Form
    {
        ProyectoCreditos.ModeloReportes.ModeloDatos md = new ModeloReportes.ModeloDatos();
        public ReporteTodasLasCuentas()
        {
            InitializeComponent();
            md.cargartodoslosdatoscuentas();
            md.cargarcombosengriidcuentas(dataGridView1);
        }

        private void ReporteTodasLasCuentas_Load(object sender, EventArgs e)
        {

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
    }
}
