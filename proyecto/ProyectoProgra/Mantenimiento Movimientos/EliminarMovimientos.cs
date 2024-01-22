using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.ControlObjetosMovimientos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoCreditos.Mantenimiento_Movimientos
{
    public partial class EliminarMovimientos : Form
    {
        ControlObjetos co = new ControlObjetos();
        ProyectoCreditos.ModeloMovimientos.ModeloDatos mdm = new ProyectoCreditos.ModeloMovimientos.ModeloDatos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public EliminarMovimientos()
        {
            InitializeComponent();
            mdm.cargarcombomovimiento(comboBox1);
            co.bloquearobjetoseliminarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, 
                textBox3, textBox6, comboBox1, button1, button2);
            textBox8.Focus();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Botón buscar
            if (textBox8.Text == "")
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                textBox8.Focus();
            }
            else
            {
                //Aquí llama a la función buscaridentificacion
                if (mdm.buscarmovimiento(textBox8.Text) == 1)
                {
                    MessageBox.Show("MOVIMIENTO ESTÁ REGISTRADO, SE MOSTRARÁN SUS DATOS..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mdm.mostrarmovimiento(Convert.ToString(textBox8.Text), textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
                    co.desbloquearobjetoseliminarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1, button2);
                }
                else
                {
                    MessageBox.Show(
                        "MOVIMIENTO NO ESTÁ REGISTRADO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.bloquearobjetoseliminarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1, button2);
                    co.limpiarcampostextosconsultar(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
                    textBox8.Focus();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox8.Text = Convert.ToString(comboBox1.SelectedItem);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            EliminarMovimientos r = new EliminarMovimientos();
            //Botón Eliminar
            if (MessageBox.Show("¿Desea Eliminar el Movimiento?", "Eliminar", MessageBoxButtons.YesNoCancel,
                MessageBoxIcon.Question) == DialogResult.Yes)
            {                
                decimal monto = (decimal)Convert.ToSingle(textBox7.Text);
                if (textBox5.Text == "Abono")
                {
                    mdm.modificarCompra(this.textBox1.Text, monto);
                    mdm.eliminarmovimientos(textBox8.Text);
                    mdm.oDataAdapter.UpdateCommand.Parameters["@mondispo"].Value = monto;

                    mdm.oConexion.Open(); //Abre la conexión
                    mdm.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                    //Aquí ejecuta el InsertCommand para que se inserte un
                    //nuevo registro en la tablaclientes
                    mdm.oConexion.Close(); //Cierra la conexión
                }
                else
                {                   
                    
                    mdm.modificarAbono(this.textBox1.Text, monto);
                    mdm.eliminarmovimientos(textBox8.Text);
                    mdm.oDataAdapter.UpdateCommand.Parameters["@mondispo"].Value = monto;
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
                    mdm.oConexion.Open(); //Abre la conexión
                    mdm.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                    //Aquí ejecuta el InsertCommand para que se inserte un
                    //nuevo registro en la tablaclientes
                    mdm.oConexion.Close(); //Cierra la conexión
                }
                MessageBox.Show("Movimiento ha sido Eliminado Correctamente...", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                co.bloquearobjetoseliminarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1, button2);
                co.limpiarcampostextosconsultar(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
                comboBox1.Items.Clear();
                mdm.cargarcombomovimiento(comboBox1);
                //comboBox1.Text = "";
                textBox8.Focus();
            }
            else
            {
                MessageBox.Show("Movimiento NO ha sido Eliminado Correctamente...", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                co.bloquearobjetoseliminarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1, button2);
                co.limpiarcampostextosconsultar(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
                textBox8.Focus();
                comboBox1.Items.Clear();
                mdm.cargarcombomovimiento(comboBox1);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Botón Limpiar
            co.bloquearobjetoseliminarmovimientos(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6, comboBox1, button1, button2);
            co.limpiarcampostextosconsultar(textBox8, textBox1, textBox4, textBox5, textBox7, textBox3, textBox6);
            textBox8.Focus();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }
    }
}
