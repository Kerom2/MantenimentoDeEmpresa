using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoCreditos.MantenimientoUsuarios
{
    public partial class ModificarUsusarios : Form
    {

        ModeloUsuarios.ModeloDatos mu = new ModeloUsuarios.ModeloDatos();
        ModeloNiveles.ModeloDatos mn = new ModeloNiveles.ModeloDatos();
        ControlOjetosUsuarios.ControlObjetos co = new ControlOjetosUsuarios.ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public ModificarUsusarios()
        {
            InitializeComponent();
            co.bloquearobjetosModificarusuarios(textBox1,textBox2,textBox3,textBox4,textBox5,
                textBox6, button1,button2);
            mu.cargarcomboidentificacion(comboBox3);
            mn.cargarcomboniveles(comboBox1);
            comboBox2.Items.Add("ACTIVO");
            comboBox2.Items.Add("DESACTIVO");

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
                if (mu.buscarlogin(textBox1.Text) == 1)
                {
                    MessageBox.Show("CUENTA ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mu.mostrarusuarioModificar(textBox1.Text, textBox2, textBox3, textBox4, textBox5, textBox6);
                    co.desbloquearobjetosModificarusuarios(textBox1, textBox2, textBox3, textBox4, textBox5,
               textBox6, button1, button2);
                }
                else
                {
                    MessageBox.Show(
                        "CUENTA NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //se llama al mismo formulario para que se reinice
                    ModificarUsusarios m = new ModificarUsusarios();
                    m.Show(); this.Hide();
                }
            }
        }

        //boton limpiar
        private void button3_Click(object sender, EventArgs e)
        {
            //se llama al mismo formulario para que se reinice
            ModificarUsusarios m = new ModificarUsusarios();
            m.Show(); this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //se llama al mismo formulario para que se reinice
            MenuPrincipal.Menu m = new MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        //boton modificar
        private void button2_Click(object sender, EventArgs e)
        {
            ModificarUsusarios r = new ModificarUsusarios();
            //Botón modificar
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
               (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //se llama al mismo formulario para que se reinice
                MenuPrincipal.Menu m = new MenuPrincipal.Menu();
                m.Show(); this.Hide();
            }
            else
            {
                //Aquí llama al procedimiento modificarcliente del modelo datos
                mu.ModificarUS(this.textBox1.Text, this.textBox3.Text,
                    this.textBox4.Text, this.textBox5.Text, this.textBox6.Text);

                //Aquí le especificamos a cada uno de los parámetros el campo
                //texto del formulario de donde va a obtener el dato para el
                //parámetro
                mu.oDataAdapter.UpdateCommand.Parameters["@nombreUS"].Value =
                    this.textBox3.Text;
                mu.oDataAdapter.UpdateCommand.Parameters["@apellidoUS"].Value =
                    this.textBox4.Text;
                mu.oDataAdapter.UpdateCommand.Parameters["@codNivUS"].Value =
                    this.textBox5.Text;
                mu.oDataAdapter.UpdateCommand.Parameters["@condiUS"].Value =
                    this.textBox6.Text;

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

                mu.oConexion.Open(); //Abre la conexión
                mu.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                //Aquí ejecuta el InsertCommand para que se inserte un
                //nuevo registro en la tablaclientes
                mu.oConexion.Close(); //Cierra la conexión

                MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                //se llama al mismo formulario para que se reinice
                ModificarUsusarios m = new ModificarUsusarios();
                m.Show(); this.Hide();
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox3.SelectedItem);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox5.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox6.Text = Convert.ToString(comboBox2.SelectedItem);
        }
    }
}
