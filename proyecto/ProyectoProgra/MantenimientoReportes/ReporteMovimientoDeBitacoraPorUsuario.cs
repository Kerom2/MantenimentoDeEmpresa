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
    public partial class ReporteMovimientoDeBitacoraPorUsuario : Form
    {
        ProyectoCreditos.ModeloReportes.ModeloDatos mdr = new ModeloReportes.ModeloDatos();
        ProyectoCreditos.ModeloUsuarios.ModeloDatos mu = new ModeloUsuarios.ModeloDatos();
        public ReporteMovimientoDeBitacoraPorUsuario()
        {
            InitializeComponent();
            mu.cargarcomboidentificacion(comboBox1);

            textBox1.Enabled=false;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mdr.cargartodoslosmovimientosdeBitacoraporUS(textBox1.Text);
            mdr.cargarcombosengribitacora(dataGridView1);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
}
