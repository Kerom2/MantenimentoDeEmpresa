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
    public partial class ReporteDeTodosLosUS : Form
    {

        ProyectoCreditos.ModeloReportes.ModeloDatos md = new ModeloReportes.ModeloDatos();
        public ReporteDeTodosLosUS()
        {
            InitializeComponent();
            md.cargartodoslosdatosUS();
            md.cargarcombosengridUS(dataGridView1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
}
