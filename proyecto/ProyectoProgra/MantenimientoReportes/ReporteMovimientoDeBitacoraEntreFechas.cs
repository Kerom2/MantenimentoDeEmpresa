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
    public partial class ReporteMovimientoDeBitacoraEntreFechas : Form
    {
        ProyectoCreditos.ModeloReportes.ModeloDatos mdr = new ModeloReportes.ModeloDatos();
        public ReporteMovimientoDeBitacoraEntreFechas()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Boton Buscar
            string fechaformato1 = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            string fechaformato2 = dateTimePicker2.Value.ToString("yyyy-MM-dd");

            mdr.cargartodoslosmovimientosdeBitacoraporfechas(fechaformato1, fechaformato2);
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
