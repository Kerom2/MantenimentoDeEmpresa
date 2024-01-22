using ProyectoCreditos.ConexionBaseDeDatos;
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
using ProyectoCreditos.ControlObjetosCuentas;
using ProyectoCreditos.ModeloDatos;
using ProyectoCreditos.ConexionBaseDeDatos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoCreditos.MantenimientoCuentas
{
    public partial class ActivarDesactivarCuentas : Form
    {
        //Instancia la clase ConectarBaseDatos
        ConectarBD cn = new ConectarBD();
        ModeloDato m = new ModeloDato();
        ControlObjetos co = new ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public ActivarDesactivarCuentas()
        {
            InitializeComponent(); 
            comboBox2.Items.Add("Activa");
            comboBox2.Items.Add("Desactiva");
            co.bloquearobjetosActDesactcuentas(textBox1,textBox2,textBox3, comboBox1,
                comboBox2, button1, button2);
            m.cargarcombocuentas(comboBox1);
        }

        private void ActivarDesactivarCuentas_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

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
                ActivarDesactivarCuentas r = new ActivarDesactivarCuentas();
                r.Show();
                this.Hide();
                textBox1.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (m.buscarNumC(textBox1.Text) == 1)
                {
                    MessageBox.Show("CUENTA ESTÁ REGISTRADA PUEDE MODIFICARLA", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.desbloquearobjetosActDesactcuentas(textBox1, textBox2, textBox3, comboBox1,
                comboBox2, button1, button2);
                    m.mostrarestadodecuenta(this.textBox1.Text,textBox2);
                }
                else
                {
                    MessageBox.Show(
                        "CUENTA  NO ESTÁ REGISTRADO.. Necesita Registrarlo..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //Aquí llama al formulario 
                    //para que vuelva el form como al principio para que
                    //se registre una nueva cuenta 
                    ActivarDesactivarCuentas r = new ActivarDesactivarCuentas();
                    r.Show();
                    this.Hide();
                    textBox1.Focus();
                }
            }
        }

        //boton agregar
        private void button2_Click(object sender, EventArgs e)
        {
            ActivarDesactivarCuentas r = new ActivarDesactivarCuentas();
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else
            {
                    //Aquí llama al procedimiento modificarcliente del modelo datos
                    m.modificarActDesact (this.textBox1.Text, textBox3.Text);
                //Aquí le especificamos a cada uno de los parámetros el campo
                //texto del formulario de donde va a obtener el dato para el
                //parámetro
                m.oDataAdapter.UpdateCommand.Parameters["@condiCuen"].Value = this.textBox3.Text;

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
                    m.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                    //Aquí ejecuta el InsertCommand para que se inserte un
                    //nuevo registro en la tablaclientes
                    m.oConexion.Close(); //Cierra la conexión

                    MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                    "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                //Aquí llama al formulario 
                //para que vuelva el form como al principio para que
                //se registre una nueva cuenta 
                ActivarDesactivarCuentas p = new ActivarDesactivarCuentas();
                p.Show();
                this.Hide();
                textBox1.Focus();

            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox3.Text = Convert.ToString(comboBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Aquí llama al formulario 
            //para que vuelva el form como al principio para que
            //se registre una nueva cuenta 
            ActivarDesactivarCuentas r = new ActivarDesactivarCuentas();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Aquí llama al formulario 
            //para que vuelva el form como al principio para que
            //se registre una nueva cuenta 
            MenuPrincipal.Menu r = new MenuPrincipal.Menu();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }
    }//final
}
