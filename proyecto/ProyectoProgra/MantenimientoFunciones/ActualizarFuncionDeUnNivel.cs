using ProyectoCreditos.MantenimientoCuentas;
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

namespace ProyectoCreditos.MantenimientoFunciones
{
    public partial class ActualizarFuncionDeUnNivel : Form
    {
        ModeloFunciones.ModeloDatos mn = new ModeloFunciones.ModeloDatos();
        ControlObjetosNivelesYFunciones.ControlObjetos mo = new ControlObjetosNivelesYFunciones.ControlObjetos();
        ModeloNiveles.ModeloDatos md = new ModeloNiveles.ModeloDatos();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public string nivelfuncion = "";
        public ActualizarFuncionDeUnNivel()
        {
            InitializeComponent();
            mo.bloquearobjetosfuncionnivel(textBox2, textBox3, textBox4, button2);
            md.cargarcombonivelesFUNNIV(comboBox1);
            mn.cargarcombofunciones(comboBox2);
            cargarcombocondicionfuncion();
        }
        //Método para cargar en el Combo las condiciones
        public void cargarcombocondicionfuncion()
        {
            comboBox3.Items.Add("ACTIVA");
            comboBox3.Items.Add("DESACTIVA");
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
            //se llama al mismo formulario para que se reinicien
            ActualizarFuncionDeUnNivel m = new ActualizarFuncionDeUnNivel();
            m.Show(); this.Hide();
        }

        //boton registrar
        private void button2_Click(object sender, EventArgs e)
        {

            ActualizarFuncionDeUnNivel r = new ActualizarFuncionDeUnNivel();
            if ((textBox2.Text == "") || (textBox3.Text == "") ||
                (textBox4.Text == ""))
            {
                MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                //se llama al mismo formulario para que se reinicien
                ActualizarFuncionDeUnNivel m = new ActualizarFuncionDeUnNivel();
                m.Show(); this.Hide();
            }
            else
            {
                //Aquí llama a la función para ver si la función nivel no se encuentra
                if (md.buscarfuncionnivel("" + textBox4.Text) == 0)
                {
                    //Aquí invoca el método insertarnivel del Modelo Niveles
                    //con cada uno de los nombres de los objetos del formulario
                    md.insertarfuncionnivel(this.textBox4.Text, this.textBox2.Text,
                        this.textBox3.Text, Convert.ToString(comboBox3.SelectedItem));

                    //Aquí le pasa cada uno de los campos textos a los parámetros del procedimiento ingresar en el 
                    //modelo de datos y los que son double y dateTimePicker se convierten al tipo de dato
                    md.oDataAdapter.InsertCommand.Parameters["@codFunNiv"].Value =
                        this.textBox4.Text;
                    md.oDataAdapter.InsertCommand.Parameters["@codNiv"].Value =
                        this.textBox2.Text;
                    md.oDataAdapter.InsertCommand.Parameters["@codFun"].Value =
                        this.textBox3.Text;
                    md.oDataAdapter.InsertCommand.Parameters["@estado"].Value =
                        this.comboBox3.SelectedItem;

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

                    //Abre la conexión
                    md.oConexion.Open();

                    //Aquí ejecuta la inserción del cliente
                    md.oDataAdapter.InsertCommand.ExecuteNonQuery();

                    MessageBox.Show("Datos Almacenados Correctamente..", "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    md.oConexion.Close(); //Cierra la conexión
                                          //se llama al mismo formulario para que se reinicien
                    ActualizarFuncionDeUnNivel m = new ActualizarFuncionDeUnNivel();
                    m.Show(); this.Hide();
                }
                else
                {
                    MessageBox.Show("Función Ya Existe en Nivel..", "Advertencia",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //se llama al mismo formulario para que se reinicien
                    ActualizarFuncionDeUnNivel m = new ActualizarFuncionDeUnNivel();
                    m.Show(); this.Hide();

                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
             nivelfuncion = "";
            //Aquí asigna al campo textBox2 el código de nivel, ya que en el combo
            //se selecciona el Nombre del Nivel
            textBox2.Text = ("" + md.devuelvecodigonivel("" + comboBox1.SelectedItem));
            //textBox2.Text = (""+comboBox1.SelectedItem);
            nivelfuncion += "" + textBox2.Text;
            comboBox1.Enabled = false;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Aquí asigna al campo textBox3 el código de nivel, ya que en el combo
            //se selecciona el Nombre de la Función
            textBox3.Text = ("" + mn.devuelvecodigofuncion("" + comboBox2.SelectedItem));
            //textBox3.Text = ("" + comboBox2.SelectedItem);
            nivelfuncion += "" + textBox3.Text;
            textBox4.Text = "" + nivelfuncion;
            //Asigna a textBox4 la variable string nivelfuncion con la concatenación
            //del código de nivel + código de función
            comboBox2.Enabled = false;
        }
    }
}
