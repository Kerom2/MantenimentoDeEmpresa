using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using ProyectoCreditos.ModeloMovimientos;
namespace ProyectoCreditos.MantenimientoReportes
{
    public partial class ReportarMovimientosPorDetalle : Form
    {
        ProyectoCreditos.ModeloMovimientos.ModeloDatos mdm = new ProyectoCreditos.ModeloMovimientos.ModeloDatos();
        ProyectoCreditos.ModeloReportes.ModeloDatos mdr = new ProyectoCreditos.ModeloReportes.ModeloDatos();
        public ReportarMovimientosPorDetalle()
        {
            InitializeComponent();
            mdm.cargarcombodetalle(comboBox1);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Botón buscar
            if (comboBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (mdm.buscardetalle(comboBox1.Text) == 1)
                {
                    MessageBox.Show("MOVIMIENTO ESTÁ REGISTRADO, SE MOSTRARÁ SU DETALLE DE COMPRA", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mdr.cargartodoslosmovimientospordetalle(Convert.ToString(comboBox1.Text));
                    mdr.cargarcombosengriidmovimientos(dataGridView1);
                }
                else
                {
                    MessageBox.Show(
                        "MOVIMIENTO NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
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
