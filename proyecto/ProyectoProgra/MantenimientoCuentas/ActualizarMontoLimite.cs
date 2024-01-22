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
using ProyectoCreditos.ControlObjetosCuentas;
namespace ProyectoCreditos.MantenimientoCuentas
{
    public partial class ActualizarMontoLimite : Form
    {
        ModeloDato md = new ModeloDato();
        ControlObjetos co = new ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();

        Decimal montolimite = 0;

        public ActualizarMontoLimite()
        {
            InitializeComponent();
            md.cargarcombocuentas(comboBox1);
        }

        private void ActualizarMontoLimite_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedItem == null)
            {
                textBox1.Text = "";
            }
            else
            {
                textBox1.Text = "" + comboBox1.SelectedItem;
            }
        }


        private void button3_Click(object sender, EventArgs e)
        {
            //Botón limpiar
            co.limpiarcampostextosactualizarmontos(textBox1, textBox2, textBox3);
            comboBox1.SelectedIndex = -1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
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
                    MessageBox.Show("SE ECONTRÓ LA CUENTA, SE MOSTRARÁ EL MONTO LÍMITE DE CRÉDITO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.desbloquearobjetosactualizarmontocuentas(textBox1, textBox2, textBox3, comboBox1, button1, button2);
                    md.mostrarmontolimite(Convert.ToString(textBox1.Text), textBox2);
                    montolimite = Convert.ToDecimal(textBox2.Text);
                }
                else
                {
                    MessageBox.Show(
                        "CUENTA NO ESTÁ REGISTRADA", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.bloquearobjetosactualizarmontocuentas(textBox1, textBox2, textBox3, comboBox1, button1, button2);
                    co.limpiarcampostextosactualizarmontos(textBox1, textBox2, textBox3);
                    textBox1.Focus();
                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            ActualizarMontoLimite r = new ActualizarMontoLimite();
            //Botón modificar
            if ((textBox1.Text == "") || (textBox2.Text == "") || (textBox3.Text == ""))
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox3.Focus();
            }
            else
            {
                Decimal montolimitenuevo = Convert.ToDecimal(textBox3.Text);

                if (montolimitenuevo <= montolimite)
                {
                    MessageBox.Show("Nuevo Monto Límite no aceptable, es menor al anterior",
                   "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Text = "";
                    textBox3.Focus();
                }
                else
                {
                    //Aquí llama al procedimiento modificarcliente del modelo datos
                    md.modificarmontolimite(this.textBox1.Text, Decimal.Parse(this.textBox3.Text));
                    //Aquí le especificamos a cada uno de los parámetros el campo
                    //texto del formulario de donde va a obtener el dato para el
                    //parámetro
                    md.oDataAdapter.UpdateCommand.Parameters["@montolimite"].Value =
                        this.textBox2.Text;

                    //Aquí llamamos al insertar en bitácora para que inserte 
                    //un nuevo movimiento en la tabla bitácora para que quede
                    //registrado los datos del usuario que inicia la sesión

                    //Obtiene la fecha de actual                    
                    DateTime fecha = DateTime.Now;
                    mb.ingresarbitacora(Convert.ToDateTime(fecha), "" + textBox2.Text, " ");

                    //Especifica los tipos de datos de los parámetros para la bitácora
                    mb.oDataAdapter.InsertCommand.Parameters["@f_mov"].Value =
                        fecha;
                    mb.oDataAdapter.InsertCommand.Parameters["@loginUS"].Value =
                        this.textBox2.Text;
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
                    co.limpiarcampostextosactualizarmontos(textBox1, textBox2, textBox3);
                    co.bloquearobjetosactualizarmontocuentas(textBox1, textBox2, textBox3, comboBox1, button1, button2);
                    textBox1.Focus();
                    comboBox1.SelectedIndex = -1;
                }
            }
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        //boto limpiar
        private void button3_Click_1(object sender, EventArgs e)
        {
            //Aquí llama al formulario 
            //para que vuelva el form como al principio para que
            //se registre una nueva cuenta 
            ActualizarMontoLimite r = new ActualizarMontoLimite();
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