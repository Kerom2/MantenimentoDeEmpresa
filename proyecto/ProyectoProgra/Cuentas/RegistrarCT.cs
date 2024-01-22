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

namespace Proyecto.Cuentas
{
    public partial class RegistrarCT : Form
    {
        //Instancia la clase ConectarBaseDatos
        ConectarBD cn = new ConectarBD();
        ModelodeDatos m = new ModelodeDatos();
        COCuentas co = new COCuentas();
        public RegistrarCT()
        {
            InitializeComponent();
            co.bloquearobjetosregistrarcuentas(textBox1,textBox2,textBox3,
                textBox4,textBox5, textBox6, comboBox1,comboBox2,button1,button2, button5);
            comboBox2.Items.Add("Activa");
            comboBox2.Items.Add("Desactiva");
            m.cargarcomboidentificacion(comboBox1);

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
                //Aquí llama a la función buscaridentificacion
                if (m.buscaridentificacion(textBox1.Text) == 1)
                {
                    MessageBox.Show("CLIENTE ESTÁ REGISTRADO\n PUEDE REGISTRAR UNA CUENTA" +
                        "\n PRESIONE EL BOTON DE 'CUENTA' PARA VALIDAR \n EL NUMERO DE CUENTA", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.desbloquearobjetosregistrarcuentas(textBox1, textBox2, textBox3,
                textBox4, textBox5, comboBox1, comboBox2, button1, button2, button5);
                    

                }
                else
                {
                    MessageBox.Show(
                        "CLIENTE NO ESTÁ REGISTRADO.. Necesita Registrarlo..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information); 
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox1.Text = Convert.ToString(comboBox1.SelectedItem);

        }

        //registrar
        private void button2_Click(object sender, EventArgs e)
        {

            if ((textBox1.Text == "") || (textBox2.Text == "") ||
               (textBox3.Text == "") || (textBox4.Text == "") ||
               (textBox5.Text == "") || (textBox6.Text == ""))
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
            }
            else
            {
                //Aquí llama al procedimiento insertarcliente del modelo datos
                m.ingresarCuenta(this.textBox1.Text, this.textBox2.Text,
                    Decimal.Parse(this.textBox3.Text), Decimal.Parse(this.textBox4.Text), 
                    Decimal.Parse(this.textBox5.Text), this.textBox6.Text,
                    Convert.ToDateTime(this.dateTimePicker1.Text));

                //Aquí le especificamos a cada uno de los parámetros el campo
                //texto del formulario de donde va a obtener el dato para el
                //parámetro
                m.oDataAdapter.InsertCommand.Parameters["@id"].Value =
                    this.textBox1.Text;
                m.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value =
                    this.textBox2.Text;
                m.oDataAdapter.InsertCommand.Parameters["@saldoApagar"].Value =
                    this.textBox3.Text;
                m.oDataAdapter.InsertCommand.Parameters["@monLimit"].Value =
                    this.textBox4.Text;
                m.oDataAdapter.InsertCommand.Parameters["@mondispo"].Value =
                   this.textBox5.Text;
                m.oDataAdapter.InsertCommand.Parameters["@condiCuen"].Value =
                  this.textBox6.Text;
                m.oDataAdapter.InsertCommand.Parameters["@f_ap"].Value =
                    Convert.ToDateTime(this.dateTimePicker1.Text);

                if (m.buscarNumC(textBox2.Text) == 1)
                {
                    MessageBox.Show("Cuenta ya existe\n Intentelo de nuevo", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show(
                        "La cuenta está disponble.. Puede Registrar..", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    m.oConexion.Open(); //Abre la conexión
                                        //Aquí ejecuta el InsertCommand para que se inserte un
                                        //nuevo registro en la tablaclientes
                    m.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    m.oConexion.Close(); //Cierra la conexión

                    MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                    "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //Aquí llama al formulario 
                    //para que vuelva el form como al principio para que
                    //se registre una nueva cuenta 
                    RegistrarCT r = new RegistrarCT();
                    r.Show();
                    this.Hide();
                    textBox1.Focus();

                }
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            
        }

        //boton cuentas
        private void button5_Click(object sender, EventArgs e)
        {
            //crea un numero random entre el 100 y el 1000
            Random r = new Random();
            textBox2.Text = Convert.ToString(r.Next(100, 1000));
            textBox4.Focus();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            //asigna al espacio 5 los datos del espacio 4
            textBox5.Text = textBox4.Text;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBox6.Text = Convert.ToString(comboBox2.SelectedItem);
        }

        private void button3_Click(object sender, EventArgs e)
        {

            //Aquí llama al formulario 
            //para que vuelva el form como al principio para que
            //se registre una nueva cuenta 
            RegistrarCT r = new RegistrarCT();
            r.Show();
            this.Hide();
            textBox1.Focus();
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
