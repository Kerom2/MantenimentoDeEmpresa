using ProyectoCreditos.ConexionBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//Biblioteca que permite hacer conexión con motor SQL
using System.Data.SqlClient;
//Biblioteca para poder ejecutar comandos en tablas BD
using System.Data;
using ProyectoCreditos.ConexionBaseDeDatos;
using System.Net.NetworkInformation;

namespace ProyectoCreditos.ModeloUsuarios
{
    class ModeloDatos
    {
        public static string ploginusuario;
        public static string pnivelusuario;
        //Instancia la clase ConectarBaseDatos
        ConectarBD cn = new ConectarBD();

        public SqlConnection oConexion =
             new SqlConnection(//colegioKarla
                               //"Data Source=LAPTOP-2IURRRLU;Initial Catalog=creditos;Integrated Security=True");
                               //casa
                               // "Data Source=lapt_jero;Initial Catalog=Creditos;Integrated Security=True");
                               //colegioMArio
                               //"Data Source=LAPTOP-L53GD9SR;Initial Catalog=Creditos;Integrated Security=True");
                               //colegioCompuMario
                               "Data Source=SOPORTE-E3QEC22\\SQLEXPRESS;Initial Catalog=Creditos;Integrated Security=True");

        //Define e instancia la variable objeto oDataSet del
        //tipo de objeto DataSet que funciona similar al 
        //ResultSet en Java
        public DataSet oDataSet = new DataSet();

        //Define e instancia la variable objeto oDataAdapter del
        //tipo de objeto SqlDataAdapter, este comando permite utilizar
        //y ejecutar las sentencias de SQL en la tabla de BD
        //Similar al Statement de Java
        public SqlDataAdapter oDataAdapter = new SqlDataAdapter();



        public void cargarcomboidentificacion(ComboBox combo)
        {
            //El data reader es como de el dataaparter con la diferencia que los datos los cargar o guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand cmd = new SqlCommand("Select * from  usuarios", oConexion);
            dr = cmd.ExecuteReader();//Aquí ejecuta la instrucción sql

            //Este if permite controlar si el dr tiene datos si el verdadero, es porque tiene datos
            if (dr.Read() == true)
            {
                //Ciclo que permite cargar los datos del dr en el combo
                do
                {
                    //Aqui agrega al combo el campo dr a identificación convertido a string porque el campo identificacion era varchar
                    combo.Items.Add(dr["loginUS"].ToString());
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }

        //Esta función permite buscar una identifcación en la tablaclientes de la BD
        public int buscarlogin(string login)
        {
            int enco = 0;
            try
            {
                cn.conectarbase(); //Conectar con la BD
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM usuarios WHERE loginUS = '" + login + "'", oConexion);
                //Plantear la instrucción en SQL que se va a ejecutar
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta por medio del oDataAdapter la instrucción que está almacenada
                //en oCmdConsulta
                oDataSet.Clear();
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "usuarios");
                //Rellena el DataSet con los datos que obtiene de la tablaclientes
                //cuando se hace el Select
                oConexion.Close();

                //Si el DataSet es mayor que 0 quiere decir que hubo datos encontrados
                //cuando realizó la consulta o select
                if (oDataAdapter.Fill(oDataSet) > 0)
                    enco = 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return enco;
        } //Cierra función


        //Procedimiento que permite ingresar un cliente en la tablaclientes
        public void ingresarusuario(String loginUS,
            String nombreUS, String apellidoUS, DateTime f_regiUS, String passworUS,
            String idUS, String codNivUS, String condiUS)
        {
            try
            {
                cn.conectarbase();
                //Aquí construye el objeto oCmdInsercion con la instrucción en SQL de insertar
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO usuarios (loginUS,nombreUS,apellidoUS,f_regiUS,passworUS,idUS,codNivUS,condiUS)" +
                    " VALUES (@loginUS,@nombreUS,@apellidoUS,@f_regiUS,@passworUS,@idUS,@codNivUS,@condiUS)", oConexion);
                oDataAdapter.InsertCommand = oCmdInsercion;
                //Aquí ejecuta la instrucción SQL que está en oCmdInsercion

                //Aquí se especifican los tipos de datos de cada uno de los parámetros que van en los values
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@loginUS", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@nombreUS", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@apellidoUS", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@f_regiUS", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@passworUS", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@idUS", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@codNivUS", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@condiUS", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //Busca una identificación en la tablaclientes
        public void mostrarusuario(String login, TextBox texto2, TextBox texto3,
            TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7, TextBox texto8)
        {
            try
            {

                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM usuarios WHERE loginUS = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "usuarios");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "usuarios.passworUS");
                    texto3.DataBindings.Add("text", oDataSet, "usuarios.idUS");
                    texto4.DataBindings.Add("text", oDataSet, "usuarios.nombreUS");
                    texto5.DataBindings.Add("text", oDataSet, "usuarios.apellidoUS");
                    texto6.DataBindings.Add("text", oDataSet, "usuarios.f_regiUS");
                    texto7.DataBindings.Add("text", oDataSet, "usuarios.codNivUS");
                    texto8.DataBindings.Add("text", oDataSet, "usuarios.condiUS");

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }


        public void mostrarusuarioModificar(String login, TextBox texto2, TextBox texto3,TextBox texto4, TextBox texto5, TextBox texto6)
        {
            try
            {

                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM usuarios WHERE loginUS = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "usuarios");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "usuarios.passworUS");
                    texto3.DataBindings.Add("text", oDataSet, "usuarios.nombreUS");
                    texto4.DataBindings.Add("text", oDataSet, "usuarios.apellidoUS");
                    texto5.DataBindings.Add("text", oDataSet, "usuarios.codNivUS");
                    texto6.DataBindings.Add("text", oDataSet, "usuarios.condiUS");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }



        //Método que nos permite insertar un cliente en la tablaclientes
        //de la BD
        public void ModificarUS(String loginUS,
             String nombreUS, String apellidoUS, String codNivUS, String condiUS)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand("UPDATE usuarios set nombreUS = @nombreUS, apellidoUS = @apellidoUS," +
                    " codNivUS = @codNivUS, condiUS = @condiUS where loginUS = '" + loginUS + "'", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@nombreUS", SqlDbType.VarChar));
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@apellidoUS", SqlDbType.VarChar));
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@codNivUS", SqlDbType.VarChar));
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@condiUS", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }

        public void mostrarusuarioActDes(String login, TextBox texto2, TextBox texto3)
        {
            try
            {

                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM usuarios WHERE loginUS = '" + login + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "usuarios");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "usuarios.codNivUS");
                    texto3.DataBindings.Add("text", oDataSet, "usuarios.condiUS");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }

        public void modificarActDesact(String loginUS,
            String condiUS)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand("UPDATE usuarios set condiUS = @condiUS where loginUS = '" + loginUS + "'", oConexion);
                
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@condiUS", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }
        }

        //Procedimiento que permite eliminar un cliente de tablaclientes
        public void eliminarUsuarios(string loginUS)
        {

            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina =
                    new SqlCommand("DELETE FROM usuarios WHERE loginUS = '" + loginUS + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdElimina;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "usuarios");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }

        }


        public void eliminarusuario(string loginUS)
        {

            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina =
                    new SqlCommand("DELETE FROM usuarios WHERE loginUS = '" + loginUS + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdElimina;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "usuarios");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            finally
            {
                if (oConexion.State == ConnectionState.Open)
                    oConexion.Close();
            }

        }

        //Este es el método que se utiliza cuando se busca el usuario y
        //el Password y también asigna a las variables globales del proyecto
        //el login y el codigo de nivel
        public int buscarloginpassword(string login, string pass)
        {
            int enco = 0;
            //El DataReader es como el DataAdapter con la diferencia que los datos
            //los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM usuarios WHERE loginUS = '" + login + "' AND passworUS = '" + pass + "' AND condiUS = 'ACTIVO' ", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                enco = 1;
                //Asigna a las variables globales del proyecto el login
                //y el codigo de nivel del usuario para que cuando llega al Menú
                //se bloqueen las opciones según el código de nivel
                ploginusuario = login;
                pnivelusuario = Convert.ToString((dr["codNivUS"]));
            }
            oConexion.Close();
            return enco;
        }

    }//final
}
