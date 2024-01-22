using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.ConexionBd;
using Proyecto.ModeloDatos;
using Proyecto.ControlObjetos;
using Proyecto.Cuentas;

namespace Proyecto.Cuentas
{
    public partial class ConsultarCT : Form
    {
        //Instancia la clase ConectarBaseDatos
        ConectarBD cn = new ConectarBD();
        ModelodeDatos m = new ModelodeDatos();
        COCuentas co = new COCuentas();

        public ConsultarCT()
        {
            InitializeComponent();
            co.bloquearobjetosconsultarcuentas(textBox1,textBox2, 
                textBox3, textBox4, textBox5, textBox6, textBox7, button1);
            m.cargarcombocuentas(comboBox1);
        }

        //boton buscar
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (m.buscarNumC(textBox1.Text) == 1)
                {
                    MessageBox.Show("CUENTA ESTÁ REGISTRADA., se Mostrarán sus Datos..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox1.Enabled = false;
                    m.mostrarcuenta(Convert.ToString(textBox1.Text),
                      textBox2, textBox3, textBox4, textBox5, textBox6, textBox7);
                }
                else
                {
                    MessageBox.Show(
                        "CUENTA NO ESTÁ REGISTRADA.., Debe Registrarlo..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //llamamos al formulario para que se reinicie
                    ConsultarCT c = new ConsultarCT();
                    c.Show();
                    this.Hide();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //permite que el dato seleccionado de un combo se imprima en un campo texto
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        //BOTON LIMPIAR
        private void button3_Click(object sender, EventArgs e)
        {
            //llamamos al formulario para que se reinicie
            ConsultarCT c = new ConsultarCT();
            c.Show();
            this.Hide();
        }

      
        private void button2_Click(object sender, EventArgs e)
        {
           
        }


    }//final
}
