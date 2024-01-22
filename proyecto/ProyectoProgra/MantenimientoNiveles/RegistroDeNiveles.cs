using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCreditos.MantenimientoNiveles
{
    public partial class RegistroDeNiveles : Form
    {
        ModeloNiveles.ModeloDatos mn = new ModeloNiveles.ModeloDatos();
        ControlObjetosNivelesYFunciones.ControlObjetos mo = new ControlObjetosNivelesYFunciones.ControlObjetos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();


        public RegistroDeNiveles()
        {
            InitializeComponent();
            mn.cargarcomboniveles(comboBox1);
            mo.bloquearobjetosniveles(textBox1, textBox2, button1, button2);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Botón Regresar
            ProyectoCreditos.MenuPrincipal.Menu m = new ProyectoCreditos.MenuPrincipal.Menu();
            m.Show(); this.Hide();
        }

        //boton buscar
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
                //Aquí busca el código de nivel en la tabla de la BD
                if (mn.buscarcodigonivel(textBox1.Text) == 1)
                {
                    MessageBox.Show("NIVEL YA ESTÁ REGISTRADO..", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox1.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "NIVEL NO ESTÁ REGISTRADO.., Puede Registrarlo..",
                        "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    mo.desbloquearobjetosniveles(textBox1, textBox2, button1, button2);

                }
            }
        }

        //boton registrar
        private void button2_Click(object sender, EventArgs e)
        {

            RegistroDeNiveles r = new RegistroDeNiveles();
            if ((textBox1.Text == "") || (textBox2.Text == ""))
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                RegistroDeNiveles m = new RegistroDeNiveles();
                m.Show(); this.Hide();
            }
            else
            {
                //Aquí invoca el método insertarnivel del Modelo Niveles
                //con cada uno de los nombres de los objetos del formulario
                mn.insertarnivel(this.textBox1.Text, this.textBox2.Text);

                //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el 
                //modelo de datos y los que son double y dateTimePicker se convierten al tipo de dato
                mn.oDataAdapter.InsertCommand.Parameters["@codNiv"].Value =
                    this.textBox1.Text;
                mn.oDataAdapter.InsertCommand.Parameters["@nomNiv"].Value =
                    this.textBox2.Text;
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
                mn.oConexion.Open();

                //Aquí ejecuta la inserción del cliente
                mn.oDataAdapter.InsertCommand.ExecuteNonQuery();

                MessageBox.Show("Datos Almacenados Correctamente..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                mn.oConexion.Close(); //Cierra la conexión

                mo.limpiarcampostextosniveles(textBox1, textBox2);
                mo.bloquearobjetosniveles(textBox1, textBox2, button1, button2);
                textBox1.Focus();
            }
        }

        //limpiar
        private void button3_Click(object sender, EventArgs e)
        {
            RegistroDeNiveles m = new RegistroDeNiveles();
            m.Show(); this.Hide();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text =
                mn.devuelvecodigonivel(Convert.ToString(comboBox1.SelectedItem));
        }

        private void RegistroDeNiveles_Load(object sender, EventArgs e)
        {

        }
    }//final
}
