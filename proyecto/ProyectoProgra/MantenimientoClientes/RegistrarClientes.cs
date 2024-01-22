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
using ProyectoCreditos.ConexionBaseDeDatos;
using ProyectoCreditos.ControlObjetosClientes;
namespace ProyectoCreditos.MantenimientoClientes
{
    public partial class RegistrarClientes : Form
    {
        ModeloDato m = new ModeloDato();
        ControlObjetos co = new ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public RegistrarClientes()
        {
            InitializeComponent();
            co.bloquearobjetosregistrarclientes(
                    textBox1, textBox2, textBox3, textBox4, textBox5,
                    button1, button2);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RegistrarClientes r = new RegistrarClientes();  
            //Botón Agregar
            if ((textBox1.Text == "") || (textBox2.Text == "") ||
                (textBox3.Text == "") || (textBox4.Text == "") || (textBox5.Text == ""))
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                co.limpiarcampostextos(
                    textBox1, textBox2, textBox3, textBox4, textBox5);
                textBox1.Focus();
            }
            else
            {
                //Aquí llama al procedimiento insertarcliente del modelo datos
                m.insertarcliente(this.textBox1.Text, this.textBox2.Text,
                    this.textBox3.Text, this.textBox4.Text, this.textBox5.Text,
                    Convert.ToDateTime(dateTimePicker1.Text));

                //Aquí le especificamos a cada uno de los parámetros el campo
                //texto del formulario de donde va a obtener el dato para el
                //parámetro
                m.oDataAdapter.InsertCommand.Parameters["@id"].Value =
                    this.textBox1.Text;
                m.oDataAdapter.InsertCommand.Parameters["@nombre"].Value =
                    this.textBox2.Text;
                m.oDataAdapter.InsertCommand.Parameters["@tel"].Value =
                    this.textBox3.Text;
                m.oDataAdapter.InsertCommand.Parameters["@dir"].Value =
                    this.textBox4.Text;
                m.oDataAdapter.InsertCommand.Parameters["@correo"].Value =
                    this.textBox5.Text;
                m.oDataAdapter.InsertCommand.Parameters["@f_regi"].Value =
                    Convert.ToDateTime(this.dateTimePicker1.Text);

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

                m.oConexion.Open(); //Abre la conexión
                m.oDataAdapter.InsertCommand.ExecuteNonQuery();
                //Aquí ejecuta el InsertCommand para que se inserte un
                //nuevo registro en la tablaclientes
                m.oConexion.Close(); //Cierra la conexión

                MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                "Información",
                MessageBoxButtons.OK, MessageBoxIcon.Information);

                //Aquí llama a limpiarcampostextos y bloquearobjetos
                //para que vuelva el form como al principio para que
                //se registre un nuevo cliente
                co.limpiarcampostextos(textBox1, textBox2, textBox3, textBox4, textBox5);
                co.bloquearobjetosregistrarclientes(
                    textBox1, textBox2, textBox3, textBox4, textBox5,
                    button1, button2);
                textBox1.Focus();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Botón Buscar
            if (textBox1.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (m.buscaridentificacion(textBox1.Text) == 1)
                {
                    MessageBox.Show("CLIENTE YA ESTÁ REGISTRADO..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.limpiarcampostextos(
                        textBox1, textBox2, textBox3, textBox4, textBox5);
                }
                else
                {
                    MessageBox.Show(
                        "CLIENTE NO ESTÁ REGISTRADO.., PUEDE REGISTRARLO..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.desbloquearobjetosregistrarclientes(
                        textBox1, textBox2, textBox3, textBox4, textBox5,
                        button1, button2);
                    textBox2.Focus();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botón Limpiar 
            co.limpiarcampostextos(textBox1, textBox2, textBox3, textBox4, textBox5);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
