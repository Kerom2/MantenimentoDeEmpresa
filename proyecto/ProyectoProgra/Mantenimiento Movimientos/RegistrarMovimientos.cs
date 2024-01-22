using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.ControlObjetosMovimientos;
using ProyectoCreditos.ControlObjetosMovimientos;
using ProyectoCreditos.ModeloMovimientos;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ProyectoCreditos.Mantenimiento_Movimientos
{
    public partial class RegistrarMovimientos : Form
    {
        ControlObjetos co = new ControlObjetos();
        ProyectoCreditos.ModeloMovimientos.ModeloDatos mdm = new ProyectoCreditos.ModeloMovimientos.ModeloDatos();
        ProyectoCreditos.ModeloDatos.ModeloDato md = new ProyectoCreditos.ModeloDatos.ModeloDato();
        ModeloBitacora.ModeloDatos mb = new ModeloBitacora.ModeloDatos();
        public RegistrarMovimientos()
        {
            InitializeComponent();
            co.cargarcombotipomovimiento(comboBox1);
            co.limpiarcampostextosregistrar(textBox1, textBox2, textBox3, textBox6);
            md.cargarcombocuentas(comboBox2);
            textBox5.Enabled = false;
        }

        private void RegistrarMovimientos_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            //Evento
            if(textBox1.Enabled==true)
            {
                if(textBox1.Text== "Número Cuenta")
                {
                    textBox1.Text = "";
                    label4.ForeColor = Color.FromArgb(255, 250, 205);
                }
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            //Evento
            if (textBox1.Enabled == true)
            {
                if (textBox1.Text == "")
                {
                    textBox1.Text = "Número Cuenta";
                    label4.ForeColor = Color.DarkKhaki;
                }
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            //Evento
            if (textBox2.Enabled == true)
            {
                if (textBox2.Text == "Monto Movimiento")
                {
                    textBox2.Text = "";
                    label6.ForeColor = Color.FromArgb(255, 250, 205);
                }
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            //Evento
            if (textBox2.Enabled == true)
            {
                if (textBox2.Text == "")
                {
                    textBox2.Text = "Monto Movimiento";
                    label6.ForeColor = Color.DarkKhaki;
                }
            }
        }
        private void textBox3_Enter(object sender, EventArgs e)
        {
            //Evento
            if (textBox3.Enabled == true)
            {
                if (textBox3.Text == "Nombre del Responsable")
                {
                    textBox3.Text = "";
                    label5.ForeColor = Color.FromArgb(255, 250, 205);
                }
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            //Evento
            if (textBox3.Enabled == true)
            {
                if (textBox3.Text == "")
                {
                    textBox3.Text = "Nombre del Responsable";
                    label5.ForeColor = Color.DarkKhaki;
                }
            }
        }
        private void textBox6_Enter(object sender, EventArgs e)
        {
            //Evento
            if (textBox6.Enabled == true)
            {
                if (textBox6.Text == "Detalle Movimiento")
                {
                    textBox6.Text = "";
                    label7.ForeColor = Color.FromArgb(255, 250, 205);
                }
            }
        }

        private void textBox6_Leave(object sender, EventArgs e)
        {
            //Evento
            if (textBox6.Enabled == true)
            {
                if (textBox6.Text == "")
                {
                    textBox6.Text = "Detalle Movimiento";
                    label7.ForeColor = Color.DarkKhaki;
                }
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
                if (mdm.buscarnumcuenta(textBox1.Text) == 1)
                {
                    MessageBox.Show("CUENTA ESTÁ REGISTRADA, PUEDE REGISTRARLE UN MOVIMIENTO", "INFORMACIÓN",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    co.desbloquearobjetosregistrarmovimientos(textBox1, textBox2, textBox3, textBox6,
                        comboBox1, comboBox2, dateTimePicker1, button1, button2);
                    mdm.mostrarregistrarmovimiento(this.textBox1.Text, textBox5);
                }
                else
                {
                    MessageBox.Show(
                        "CUENTA NO ESTÁ REGISTRADA / ESTÁ DESACTIVA,  NO PUEDE REGISTRARLE UN MOVIMIENTO", "Información",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //llamamos al mismo formulario para reiniciarlo
                    RegistrarMovimientos m = new RegistrarMovimientos();
                    m.Show(); this.Hide();

                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            RegistrarMovimientos r = new RegistrarMovimientos();

            string TipoMov = "";
            TipoMov = comboBox1.Text;

            decimal dispo = Convert.ToDecimal(textBox5.Text);

            decimal monto = Convert.ToDecimal(textBox2.Text);

            Console.WriteLine(monto);

            //Botón Agregar
            if ((textBox1.Text == "") || (textBox2.Text == "") || 
                (textBox3.Text == "") || (textBox6.Text == "") || 
                comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Faltan Datos por Completar..",
                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                mdm.ObtenerValores(textBox1.Text);

                if (TipoMov == "Compra" && monto > 0 && monto <= dispo)
                {
                    //Aquí llama al procedimiento insertarcliente del modelo datos
                    mdm.insertarmovimiento(this.textBox1.Text,
                    Convert.ToDateTime(dateTimePicker1.Text), TipoMov, Decimal.Parse(this.textBox2.Text),
                        this.textBox3.Text, this.textBox6.Text);

                    //Aquí le especificamos a cad uno de los parámetros el campo
                    //texto del formu lario de donde va a obtener el dato para el
                    //parámetro
                    mdm.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value =
                        this.textBox1.Text;
                    mdm.oDataAdapter.InsertCommand.Parameters["@f_mov"].Value =
                        Convert.ToDateTime(this.dateTimePicker1.Text);
                    mdm.oDataAdapter.InsertCommand.Parameters["@TipoMov"].Value =
                        TipoMov;
                    mdm.oDataAdapter.InsertCommand.Parameters["@montoMov"].Value =
                        Decimal.Parse(this.textBox2.Text);
                    mdm.oDataAdapter.InsertCommand.Parameters["@nomRespon"].Value =
                        this.textBox3.Text; ;
                    mdm.oDataAdapter.InsertCommand.Parameters["@detalle"].Value = 
                        this.textBox6.Text; ;

                    //Aquí se modifican los datos para una compra en las cuentas
                    mdm.modificarCompra(this.textBox1.Text, Decimal.Parse(this.textBox2.Text));
                    mdm.oDataAdapter.UpdateCommand.Parameters["@mondispo"].Value =
                    Decimal.Parse(this.textBox2.Text);

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
                    mdm.oDataAdapter.InsertCommand.ExecuteNonQuery();
                    //Aquí ejecuta el InsertCommand para que se inserte un
                    //nuevo registro en la tablaclientes
                    mdm.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                    //Aquí ejecuta el UpdateCommand para que se modifique los 
                    //Datos en cuentas
                    mdm.oConexion.Close(); //Cierra la conexión

                    MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                            "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                    //llamamos al mismo formulario para reiniciarlo
                    RegistrarMovimientos m = new RegistrarMovimientos();
                    m.Show(); this.Hide();

                }
                else
                {

                    if (TipoMov == "Compra" && monto >= dispo)
                    {
                        MessageBox.Show("¡NO SE PUEDE REALIZAR EL MOVIMIENTO!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //llamamos al mismo formulario para reiniciarlo
                        RegistrarMovimientos m = new RegistrarMovimientos();
                        m.Show(); this.Hide();
                    
                }
                    else
                    {
                        if (TipoMov == "Abono" && monto > 0 && monto <= dispo)
                        {
                            //Aquí llama al procedimiento insertarcliente del modelo datos
                            mdm.insertarmovimiento(this.textBox1.Text,
                    Convert.ToDateTime(dateTimePicker1.Text), TipoMov, Decimal.Parse(this.textBox2.Text),
                                this.textBox3.Text, this.textBox6.Text);

                            //Aquí le especificamos a cad uno de los parámetros el campo
                            //texto del formulario de donde va a obtener el dato para el
                            //parámetro
                            mdm.oDataAdapter.InsertCommand.Parameters["@numCuenta"].Value =
                                this.textBox1.Text;
                            mdm.oDataAdapter.InsertCommand.Parameters["@f_mov"].Value =
                                Convert.ToDateTime(this.dateTimePicker1.Text);
                            mdm.oDataAdapter.InsertCommand.Parameters["@tipoMov"].Value =
                                TipoMov;
                            mdm.oDataAdapter.InsertCommand.Parameters["@montoMov"].Value =
                                Decimal.Parse(this.textBox2.Text);
                            mdm.oDataAdapter.InsertCommand.Parameters["@nomRespon"].Value =
                                this.textBox3.Text; ;
                            mdm.oDataAdapter.InsertCommand.Parameters["@detalle"].Value =
                                this.textBox6.Text; ;

                            //Aquí se modifican los datos para una compra en las cuentas
                            mdm.modificarAbono(this.textBox1.Text, Decimal.Parse(this.textBox2.Text));
                            mdm.oDataAdapter.UpdateCommand.Parameters["@mondispo"].Value =
                            Decimal.Parse(this.textBox2.Text);
                            mdm.oConexion.Open(); //Abre la conexión
                            mdm.oDataAdapter.InsertCommand.ExecuteNonQuery();
                            //Aquí ejecuta el InsertCommand para que se inserte un
                            //nuevo registro en la tablaclientes
                            mdm.oDataAdapter.UpdateCommand.ExecuteNonQuery();
                            //Aquí ejecuta el UpdateCommand para que se modifique los 
                            //Datos en cuentas
                            mdm.oConexion.Close(); //Cierra la conexión


                            MessageBox.Show("DATOS ALMACENADOS CORRECTAMENTE..",
                            "Información",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);

                            //llamamos al mismo formulario para reiniciarlo
                            RegistrarMovimientos m = new RegistrarMovimientos();
                            m.Show(); this.Hide();

                        }
                        else 
                        {
                            MessageBox.Show("¡NO SE PUEDE REALIZAR EL MOVIMIENTO!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //llamamos al mismo formulario para reiniciarlo
                            RegistrarMovimientos m = new RegistrarMovimientos();
                            m.Show(); this.Hide();
                        }
                    }
                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Cuando se hace click en el combo se asigna al campo texto el elemento seleccionado
            //Asigna al campo texto el elemento seleccionado del combo convertido a string
            textBox1.Text = Convert.ToString(comboBox2.SelectedItem);
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
            co.limpiarcampostextosregistrar(textBox1, textBox2, textBox3, textBox6);
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }
}
