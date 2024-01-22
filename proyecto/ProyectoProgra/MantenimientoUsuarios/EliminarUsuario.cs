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

namespace ProyectoCreditos.MantenimientoUsuarios
{
    public partial class EliminarUsuario : Form
    {
        ModeloUsuarios.ModeloDatos mu = new ModeloUsuarios.ModeloDatos();
        ControlOjetosUsuarios.ControlObjetos co = new ControlOjetosUsuarios.ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public EliminarUsuario()
        {
            InitializeComponent();
            co.bloquearobjetosElminarusuarios(textBox1, textBox2, textBox3, textBox4, textBox5,
                textBox6, textBox7, textBox8, button1, button2);
            mu.cargarcomboidentificacion(comboBox1);
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón buscar
            if (textBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Aquí llama al formulario 
                //para que vuelva el form como al principio para que
                //se registre una nueva cuenta 
                EliminarUsuario r = new EliminarUsuario();
                r.Show();
                this.Hide();
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (mu.buscarlogin(textBox1.Text) == 1)
                {
                    MessageBox.Show("USUARIO ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mu.mostrarusuario(textBox1.Text, textBox2, textBox3, textBox4, textBox5, textBox6, textBox7, textBox8);
                    co.desbloquearobjetosElminarusuarios(textBox1, textBox2, textBox3, textBox4, textBox5,
                textBox6, textBox7, textBox8, button1, button2);
                }
                else
                {
                    MessageBox.Show(
                        "USUARIO NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Aquí llama al formulario 
                    //para que vuelva el form como al principio para que
                    //se registre una nueva cuenta 
                    EliminarUsuario r = new EliminarUsuario();
                    r.Show();
                    this.Hide();
                    textBox1.Focus();
                }
            }
        }

        //boton eliminar
        private void button2_Click(object sender, EventArgs e)
        {
            EliminarUsuario a = new EliminarUsuario();
            //Botón Eliminar
            if (MessageBox.Show("¿Desea Eliminar el Usuario?", "Eliminar", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                    mu.eliminarusuario(textBox1.Text);

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
                    a.Name;
                //La propiedad Name obtiene el nombre del formulario y nótese que arriba
                //antes se instancia el formulario de iniciar sesión

                mu.oConexion.Open(); //Abre la conexión
                    mu.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                    //Aquí ejecuta el InsertCommand para que se inserte un
                    //nuevo registro en la tablaclientes
                    mu.oConexion.Close(); //Cierra la conexión
                
                MessageBox.Show("Usuario ha sido Eliminado Correctamente...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Aquí llama al formulario 
                //para que vuelva el form como al principio para que
                //se registre una nueva cuenta 
                EliminarUsuario r = new EliminarUsuario();
                r.Show();
                this.Hide();
                textBox1.Focus();
            }
            else
            {
                MessageBox.Show("Movimiento NO ha sido Eliminado Correctamente...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Aquí llama al formulario 
                //para que vuelva el form como al principio para que
                //se registre una nueva cuenta 
                EliminarUsuario r = new EliminarUsuario();
                r.Show();
                this.Hide();
                textBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Aquí llama al formulario 
            //para que vuelva el form como al principio para que
            //se registre una nueva cuenta 
            EliminarUsuario r = new EliminarUsuario();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }
    }
}
