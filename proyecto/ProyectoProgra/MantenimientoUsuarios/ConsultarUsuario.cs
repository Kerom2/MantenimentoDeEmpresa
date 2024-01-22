using ProyectoCreditos.MantenimientoCuentas;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCreditos.MantenimientoUsuarios
{
    public partial class ConsultarUsuario : Form
    {
        ModeloUsuarios.ModeloDatos md = new ModeloUsuarios.ModeloDatos();
        ControlOjetosUsuarios.ControlObjetos co = new ControlOjetosUsuarios.ControlObjetos();
        public ConsultarUsuario()
        {
            InitializeComponent();
            co.bloquearobjetosConsultarusuarios(textBox1, textBox2, textBox3, textBox4, textBox5, 
                textBox6, textBox7, textBox8);
            md.cargarcomboidentificacion(comboBox1);

        }

        private void ConsultarUsuario_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
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
                if (md.buscarlogin(textBox1.Text) == 1)
                {
                    MessageBox.Show("USUARIO ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    md.mostrarusuario(textBox1.Text, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8);
                }
                else
                {
                    MessageBox.Show(
                        "USUARIO NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Aquí llama al formulario 
                    //para que vuelva el form como al principio para que
                    //se registre una nueva cuenta 
                    ConsultarUsuario r = new ConsultarUsuario();
                    r.Show();
                    this.Hide();
                    textBox1.Focus();
                }
            }
        }

        //boton limpiar
        private void button3_Click(object sender, EventArgs e)
        {
            //Aquí llama al formulario 
            //para que vuelva el form como al principio para que
            //se registre una nueva cuenta 
            ConsultarUsuario r = new ConsultarUsuario();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            MenuPrincipal.Menu r = new MenuPrincipal.Menu();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }
    }
}
 