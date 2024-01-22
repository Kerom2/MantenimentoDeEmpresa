using ProyectoCreditos.MantenimientoNiveles;
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
    public partial class RegistrarUsuarios : Form
    {

        //Instancia las clases a utilizar
        ModeloNiveles.ModeloDatos md = new ModeloNiveles.ModeloDatos();
        ModeloUsuarios.ModeloDatos mu = new ModeloUsuarios.ModeloDatos();
        ControlOjetosUsuarios.ControlObjetos co = new ControlOjetosUsuarios.ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public RegistrarUsuarios()
        {
            InitializeComponent();
           co.bloquearobjetosusuarios(textBox1, textBox2, textBox3, textBox4,textBox5,
                dateTimePicker1, button1, button2);
            comboBox2.Items.Add("ACTIVO");
            comboBox2.Items.Add("DESACTIVO");
            md.cargarcombonivelesFUNNIV(comboBox1);//Se cargan los niveles en el Combo
            mu.cargarcomboidentificacion(comboBox3);

        }

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
                //Aquí busca si el login está registrado con la función
                if (mu.buscarlogin(textBox1.Text) == 1)
                {
                    MessageBox.Show("USUARIO YA ESTÁ REGISTRADO..", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //se llama al mismo formulario para que se reinice
                    RegistrarUsuarios m = new RegistrarUsuarios();
                    m.Show(); this.Hide();
                }
                else
                {
                    MessageBox.Show(
                        "USUARIO NO ESTÁ REGISTRADO.., Puede Registrarlo..",
                        "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.desbloquearobjetosusuarios(textBox1, textBox2, textBox3, textBox4, textBox5,
                dateTimePicker1, button1, button2);
                }
            }
        }

        private void RegistrarUsuarios_Load(object sender, EventArgs e)
        {

        }

        //registrar
        private void button2_Click(object sender, EventArgs e)
        {

            RegistrarUsuarios r = new RegistrarUsuarios();
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //se llama al mismo formulario para que se reinice
                RegistrarUsuarios m = new RegistrarUsuarios();
                m.Show(); this.Hide();
                
            }
            else
            {
                //Aquí llama al ingresarusuario para que se registre un usuario
                mu.ingresarusuario(this.textBox1.Text, this.textBox4.Text, this.textBox5.Text,
                    Convert.ToDateTime(dateTimePicker1.Text),
                    this.textBox2.Text,
                    this.textBox3.Text,
                    md.devuelvecodigonivel(Convert.ToString(this.comboBox1.SelectedItem)),
                    Convert.ToString(this.comboBox2.SelectedItem));

                //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el 
                //modelo de datos y los que son double y dateTimePicker se convierten al tipo de dato
                mu.oDataAdapter.InsertCommand.Parameters["@loginUS"].Value =
                    this.textBox1.Text;
                mu.oDataAdapter.InsertCommand.Parameters["@nombreUS"].Value =
                    this.textBox4.Text;
                mu.oDataAdapter.InsertCommand.Parameters["@apellidoUS"].Value =
                    this.textBox5.Text;
                mu.oDataAdapter.InsertCommand.Parameters["@f_regiUS"].Value =
                    Convert.ToDateTime(this.dateTimePicker1.Text);
                mu.oDataAdapter.InsertCommand.Parameters["@passworUS"].Value =
                    this.textBox2.Text;
                mu.oDataAdapter.InsertCommand.Parameters["@idUS"].Value =
                    this.textBox3.Text;
                mu.oDataAdapter.InsertCommand.Parameters["@codNivUS"].Value =
                    md.devuelvecodigonivel(Convert.ToString(this.comboBox1.SelectedItem));
                mu.oDataAdapter.InsertCommand.Parameters["@condiUS"].Value =
                    this.comboBox2.SelectedItem;

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
                mu.oConexion.Open();

                //Aquí ejecuta la inserción del cliente
                mu.oDataAdapter.InsertCommand.ExecuteNonQuery();

                MessageBox.Show("Datos Almacenados Correctamente..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                mu.oConexion.Close(); //Cierra la conexión

                //se llama al mismo formulario para que se reinice
                RegistrarUsuarios m = new RegistrarUsuarios();
                m.Show(); this.Hide();
            }
        }


        //boton limpiar
        private void button3_Click(object sender, EventArgs e)
        {
            //se llama al mismo formulario para que se reinice
            RegistrarUsuarios m = new RegistrarUsuarios();
            m.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //se llama al mismo formulario para que se reinice
            MenuPrincipal.Menu m = new MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox3.SelectedItem);
        }
    }
}
