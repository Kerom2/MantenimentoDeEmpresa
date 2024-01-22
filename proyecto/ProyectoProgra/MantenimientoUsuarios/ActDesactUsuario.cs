using ProyectoCreditos.ConexionBaseDeDatos;
using ProyectoCreditos.MantenimientoCuentas;
using ProyectoCreditos.ModeloDatos;
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

namespace ProyectoCreditos.MantenimientoUsuarios
{
    public partial class ActDesactUsuario : Form
    {

        //Instancia la clase ConectarBaseDatos
        ConectarBD cn = new ConectarBD();
        ModeloUsuarios.ModeloDatos mo = new ModeloUsuarios.ModeloDatos();
        ModeloDatos.ModeloDato md = new ModeloDatos.ModeloDato();
        ControlObjetosCuentas.ControlObjetos co =
            new ControlObjetosCuentas.ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public ActDesactUsuario()
        {
            InitializeComponent();
            comboBox2.Items.Add("Activa");
            comboBox2.Items.Add("Desactiva");
            mo.cargarcomboidentificacion(comboBox1);
            co.bloquearobjetosActDesactcuentas(textBox1,textBox2,textBox3,
                comboBox1, comboBox2, button1, button2);     
        }

        //boton buscar
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Aquí llama al formulario 
                //para que vuelva el form como al principio para que
                //se registre una nueva cuenta 
                ActDesactUsuario r = new ActDesactUsuario();
                r.Show();
                this.Hide();
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (mo.buscarlogin(textBox1.Text) == 1)
                {
                    MessageBox.Show("USUARIO ESTÁ REGISTRADA PUEDE MODIFICARLO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.desbloquearobjetosActDesactcuentas(textBox1, textBox2, textBox3, comboBox1,
                comboBox2, button1, button2);
                    mo.mostrarusuarioActDes(this.textBox1.Text, textBox2, textBox3);
                }
                else
                {
                    MessageBox.Show(
                        "CUENTA  NO ESTÁ REGISTRADO.. Necesita Registrarlo..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Aquí llama al formulario 
                    //para que vuelva el form como al principio para que
                    //se registre una nueva cuenta 
                    ActDesactUsuario r = new ActDesactUsuario();
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
            ActDesactUsuario r = new ActDesactUsuario();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }

        //boton regresar
        private void button2_Click(object sender, EventArgs e)
        {
            ActDesactUsuario a = new ActDesactUsuario();
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else
            {
                //Aquí llama al procedimiento modificarcliente del modelo datos
                mo.modificarActDesact(this.textBox1.Text, textBox3.Text);
                //Aquí le especificamos a cada uno de los parámetros el campo
                //texto del formulario de donde va a obtener el dato para el
                //parámetro
                mo.oDataAdapter.UpdateCommand.Parameters["@condiUS"].Value =
                    this.textBox3.Text;

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

                mo.oConexion.Open(); //Abre la conexión
                mo.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                //Aquí ejecuta el InsertCommand para que se inserte un
                //nuevo registro en la tablaclientes
                mo.oConexion.Close(); //Cierra la conexión

                MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Aquí llama al formulario 
                //para que vuelva el form como al principio para que
                //se registre una nueva cuenta 
                ActDesactUsuario r = new ActDesactUsuario();
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

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox3.Text = Convert.ToString(comboBox2.SelectedItem);
        }
    }
}
