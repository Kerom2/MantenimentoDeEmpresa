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
using ProyectoCreditos.ModeloDatos;
namespace ProyectoCreditos.MantenimientoReportes
{
    public partial class ReportarMovimientosDeCuenta : Form
    {
        ModeloDato md = new ModeloDato();
        ProyectoCreditos.ModeloReportes.ModeloDatos mdr = new ModeloReportes.ModeloDatos();
        public ReportarMovimientosDeCuenta()
        {
            InitializeComponent();
            md.cargarcombocuentas(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Botón Buscar
            if (comboBox1.SelectedItem == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (md.buscarNumC(comboBox1.Text) == 1)
                {
                    MessageBox.Show("CUENTA YA ESTÁ REGISTRADA, SE MOSTRARÁN SUS MOVIMIENTOS", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mdr.cargartodoslosmovimientospornumerocuenta(Convert.ToString(comboBox1 .Text));
                    mdr.cargarcombosengriidmovimientos(dataGridView1);
                }
                else
                {
                    MessageBox.Show(
                        "CUENTA NO ESTÁ REGISTRADA O NO TIENE MOVIMIENTOS", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void ReportarMovimientosDeCuenta_Load(object sender, EventArgs e)
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
}
