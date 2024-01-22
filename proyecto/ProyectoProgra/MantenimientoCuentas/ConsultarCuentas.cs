using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.ConexionBaseDeDatos;
using ProyectoCreditos.ControlObjetosCuentas;
using ProyectoCreditos.ModeloDatos;
namespace ProyectoCreditos.MantenimientoCuentas
{
    public partial class ConsultarCuentas : Form
    {
        //Instancia la clase ConectarBaseDatos
        ConectarBD cn = new ConectarBD();
        ModeloDato md = new ModeloDato();
        ControlObjetos co = new ControlObjetos();
        public ConsultarCuentas()
        {
            InitializeComponent();
            co.bloquearobjetosconsultarcuentas(textBox1, textBox2, textBox3, textBox4, textBox5,
                textBox6, textBox7, button1);
            md.cargarcombocuentas(comboBox1);
        }

       
        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {

            //Botón buscar
            if (textBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (md.buscarNumC(textBox1.Text) == 1)
                {
                    MessageBox.Show("CLIENTE ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    md.mostrarcuenta(Convert.ToString(textBox1.Text), textBox3, textBox4, textBox5, textBox6, textBox7, textBox2);
                }
                else
                {
                    MessageBox.Show(
                        "CLIENTE NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.bloquearobjetosconsultarcuentas(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, button1);
                    co.limpiarcampostextosconsultar(textBox1, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7);
                    textBox1.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Aquí llama al formulario 
            //para que vuelva el form como al principio para que
            //se registre una nueva cuenta 
            ConsultarCuentas r = new ConsultarCuentas();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
}
