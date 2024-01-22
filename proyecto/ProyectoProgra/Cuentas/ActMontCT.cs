using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Proyecto.ConexionBd;
using Proyecto.ModeloDatos;
using Proyecto.ControlObjetos;
using Proyecto.Cuentas;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Proyecto.Cuentas
{
    public partial class ActMontCT : Form
    {
        //Instancia la clase ConectarBaseDatos
        ConectarBD cn = new ConectarBD();
        ModelodeDatos m = new ModelodeDatos();
        COCuentas co = new COCuentas();
        public ActMontCT()
        {
            InitializeComponent();
            m.cargarcombocuentas(comboBox1);
            co.bloquearobjetosADCT(textBox1, textBox2, textBox3, button2, button1);
        }

        private void ActMontCT_Load(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //permite que el dato seleccionado de un combo se imprima en un campo texto
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);
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
                //Aquí llama a la función buscarnumcuenta
                if (m.buscarNumC(textBox1.Text) == 1)
                {
                    MessageBox.Show("CLIENTE ESTÁ REGISTRADO., se Mostrará el dato solicitado", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    m.mostrarMontoCuenta(Convert.ToString(textBox1.Text),
                    textBox2);
                    button2.Enabled = true;
                    button1.Enabled = false;
                    textBox4.Focus();
                }
                else
                {
                    MessageBox.Show(
                        "CLIENTE NO ESTÁ REGISTRADO.., Debe Registrarlo..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //llamamos a la calse para reiniciarla de 0
                    ActMontCT r = new ActMontCT();
                    r.Show();
                    this.Hide();
                    textBox1.Focus();

                }
            }
        }

        //boton limpiar
        private void button3_Click(object sender, EventArgs e)
        {
            //llamamos a la calse para reiniciarla de 0
            ActMontCT r = new ActMontCT();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }

        //boton actualizar
        private void button2_Click(object sender, EventArgs e)
        {

            {
                if (textBox3.Text == "")
                {
                    MessageBox.Show("FALTAN DATOS POR COMPLETAR..", "ERROR",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox3.Focus();
                }
                else
                {

                    {
                        //Aquí llama al procedimiento insertarcliente del modelo datos
                        m.ActualizarMontoCTA(this.textBox1.Text, this.textBox2.Text, this.textBox3.Text);

                        //Aquí le especificamos a cada uno de los parámetros el campo
                        //texto del formulario de donde va a obtener el dato para el
                        //parámetro
                        m.oDataAdapter.UpdateCommand.Parameters["@monLimit"].Value =
                            this.textBox2.Text;
                        m.oDataAdapter.UpdateCommand.Parameters["@mondispo"].Value =
                            this.textBox3.Text;


                        m.oConexion.Open(); //Abre la conexión
                        m.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                        //Aquí ejecuta el InsertCommand para que se inserte un
                        //nuevo registro en la tablaclientes
                        m.oConexion.Close(); //Cierra la conexión

                        MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                        "Información",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                        //llamamos a la calse para reiniciarla de 0
                        ActDesCT r = new ActDesCT();
                        r.Show();
                        this.Hide();
                        textBox1.Focus();

                    }
                }
            }
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //asigna al espacio 2 y 3 los datos del espacio 4
            textBox2.Text = textBox4.Text;
            textBox3.Text = textBox4.Text;
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
