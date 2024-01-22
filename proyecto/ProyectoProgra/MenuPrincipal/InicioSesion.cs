using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCreditos.MenuPrincipal
{
    public partial class InicioSesion : Form
    {
        ModeloUsuarios.ModeloDatos mu = new ModeloUsuarios.ModeloDatos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public InicioSesion()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        //boton salir
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        //boton iniciar
        private void button2_Click(object sender, EventArgs e)
        {
            InicioSesion r = new InicioSesion();

            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscarloginpassword para que busque
                //el login y el password
                if (mu.buscarloginpassword(textBox1.Text, textBox2.Text) == 1)
                {
                    MessageBox.Show("USUARIO ENCONTRADO..", "INFORMACIÓN",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Aquí llamamos al insertar en bitácora para que inserte 
                    //un nuevo movimiento en la tabla bitácora para que quede
                    //registrado los datos del usuario que inicia la sesión

                    //Obtiene la fecha de actual                    
                    DateTime fecha = DateTime.Now;
                    mb.ingresarbitacora(Convert.ToDateTime(fecha), "" + textBox1.Text, " ");

                    //Especifica los tipos de datos de los parámetros para la bitácora
                    mb.oDataAdapter.InsertCommand.Parameters["@f_mov"].Value =
                        fecha;
                    mb.oDataAdapter.InsertCommand.Parameters["@loginUS"].Value =
                        this.textBox1.Text;
                    mb.oDataAdapter.InsertCommand.Parameters["@detalle"].Value =
                        r.Name;
                    //La propiedad Name obtiene el nombre del formulario y nótese que arriba
                    //antes se instancia el formulario de iniciar sesión

                    //Abre la conexión
                    mb.oConexion.Open();
                    //Aquí ejecuta la inserción en la tabla bitácora
                    mb.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    mb.oConexion.Close(); //Cierra la conexión

                    //Aquí se instancia y llama al Menú, 
                    Menu m = new Menu();
                    m.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "USUARIO NO REGISTRADO ó NO ESTÁ ACTIVO, Inténtelo Nuevamente..",
                        "Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //Aquí se instancia y llama al mismo formulario para reinicar, 
                    InicioSesion m = new InicioSesion();
                    m.Show();
                    this.Hide();
                }
            }
        }
    }
}
