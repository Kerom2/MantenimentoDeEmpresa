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
    public partial class ReporteMovimientosPorTransaccion : Form
    {

        ProyectoCreditos.ModeloReportes.ModeloDatos md = new ModeloReportes.ModeloDatos();
        ProyectoCreditos.ControlObjetosMovimientos.ControlObjetos co = new ControlObjetosMovimientos.ControlObjetos();
        public ReporteMovimientosPorTransaccion()
        {
            InitializeComponent();
            co.cargarcombotipomovimiento(comboBox1);

        }

        private void ReporteMovimientosPorTransaccion_Load(object sender, EventArgs e)
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
                md.cargartodoslosmovimientosportransaccion(Convert.ToString(comboBox1.Text));
                md.cargarcombosengriidmovimientos(dataGridView1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
