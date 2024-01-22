using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.ModeloDatos;
using ProyectoCreditos.ControlObjetosClientes;
namespace ProyectoCreditos.MantenimientoClientes
{
    public partial class ModificarClientes : Form
    {
        ControlObjetos co = new ControlObjetos();
        ModeloDato md = new ModeloDato();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public ModificarClientes()
        {
            InitializeComponent();
            co.bloquearobjetosmodificarclientes(textBox1, textBox2, textBox3, textBox4, textBox5, dateTimePicker1, button1, button2);
            md.cargarcomboidentificacion(comboBox1);
        }

        private void label1_Click(object sender, EventArgs e)
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
                if (md.buscaridentificacion(textBox1.Text) == 1)
                {
                    MessageBox.Show("CLIENTE ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    md.mostrarclienteModificar(textBox1.Text, textBox2, textBox3, textBox4, textBox5, dateTimePicker1);
                    co.desbloquearobjetosmodificarclientes(textBox1, textBox2, textBox3, textBox4, textBox5, dateTimePicker1, button1, button2);
                }
                else
                {
                    MessageBox.Show(
                        "CLIENTE NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.bloquearobjetosmodificarclientes(textBox1, textBox2, textBox3, textBox4, textBox5, dateTimePicker1, button1, button2);
                    co.limpiarcampostextos(textBox1, textBox2, textBox3, textBox4, textBox5);
                    textBox1.Focus();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ModificarClientes r = new ModificarClientes();
            //Botón Modificar

            //Este fechaformato es la que vamos a llamar cuando se modifica el cliente y lo que se hace acá es convertir lo del
            //DateTimePicker a formato datetime

            //Botón modificar
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
               (textBox3.Text == "") || (textBox4.Text == ""))
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                co.limpiarcampostextos(
                    textBox1, textBox2, textBox3, textBox4, textBox5);
                textBox1.Focus();
            }
            else
            {
                //Aquí llama al procedimiento modificarcliente del modelo datos
                md.Modificar(this.textBox1.Text, this.textBox2.Text,
                    this.textBox3.Text, this.textBox4.Text, this.textBox5.Text);

                //Aquí le especificamos a cada uno de los parámetros el campo
                //texto del formulario de donde va a obtener el dato para el
                //parámetro
                md.oDataAdapter.UpdateCommand.Parameters["@id"].Value =
                    this.textBox1.Text;
                md.oDataAdapter.UpdateCommand.Parameters["@nombre"].Value =
                    this.textBox2.Text;
                md.oDataAdapter.UpdateCommand.Parameters["@tel"].Value =
                    this.textBox3.Text;
                md.oDataAdapter.UpdateCommand.Parameters["@dir"].Value =
                    this.textBox4.Text;
                md.oDataAdapter.UpdateCommand.Parameters["@correo"].Value =
                    this.textBox5.Text;

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

                md.oConexion.Open(); //Abre la conexión
                md.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                //Aquí ejecuta el InsertCommand para que se inserte un
                //nuevo registro en la tablaclientes
                md.oConexion.Close(); //Cierra la conexión

                MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Aquí llama a limpiarcampostextos y bloquearobjetos
                //para que vuelva el form como al principio para que
                //se registre un nuevo cliente
                co.limpiarcampostextos(textBox1, textBox2, textBox3, textBox4, textBox5);
                co.bloquearobjetosmodificarclientes(textBox1, textBox2, textBox3, textBox4, textBox5, dateTimePicker1, button1, button2);
                textBox1.Focus();
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void ModificarClientes_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }
    }
    }
