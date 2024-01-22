using System;
using System.Collections.Generic;
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

namespace ProyectoCreditos.ModeloDatos
{
    class ModeloDato
    {
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



        ////////////////////////////////////////////////////////////////CLIENTES//////////////////////////////////////////////////////////////////////////////
    


        //Busca una identificación en la tablaclientes
        public int buscaridentificacion(String ide)
        {
            int enco = 0;
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM clientes WHERE id = '" + ide + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "clientes");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                    enco = 1;
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
            return enco;
        }
        //Método que nos permite insertar un cliente en la tablaclientes
        //de la BD
        public void insertarcliente(String identificacion,
            String nombre,
            String telefono, string direccion, string correo, DateTime fecha)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdInsercion = new SqlCommand(
                     "INSERT INTO clientes (id,nombre,tel,dir,correo,f_regi) VALUES " +
                    "(@id,@nombre,@tel,@dir,@correo,@f_regi)", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.InsertCommand = oCmdInsercion;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@id", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@nombre", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@tel", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@dir", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@correo", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@f_regi", SqlDbType.DateTime));
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
        //Busca una identificación en la tablaclientes
        public void mostrarcliente(String ide, TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM clientes WHERE id = '" + ide + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "clientes");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "clientes.nombre");
                    texto3.DataBindings.Add("text", oDataSet, "clientes.tel");
                    texto4.DataBindings.Add("text", oDataSet, "clientes.dir");
                    texto5.DataBindings.Add("text", oDataSet, "clientes.correo");
                    texto6.DataBindings.Add("text", oDataSet, "clientes.f_regi");
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

        public void cargarcomboidentificacion(ComboBox combo)
        {
            //El data reader es como de el dataaparter con la diferencia que los datos los cargar o guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand cmd = new SqlCommand("Select * from  clientes", oConexion);
            dr = cmd.ExecuteReader();//Aquí ejecuta la instrucción sql

            //Este if permite controlar si el dr tiene datos si el verdadero, es porque tiene datos
            if (dr.Read() == true)
            {
                //Ciclo que permite cargar los datos del dr en el combo
                do
                {
                    //Aqui agrega al combo el campo dr a identificación convertido a string porque el campo identificacion era varchar
                    combo.Items.Add(dr["id"].ToString());
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Busca una identificación en la tablaclientes
        public void mostrarclienteModificar(String ide, TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5, DateTimePicker date)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM clientes WHERE id = '" + ide + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "clientes");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "clientes.nombre");
                    texto3.DataBindings.Add("text", oDataSet, "clientes.tel");
                    texto4.DataBindings.Add("text", oDataSet, "clientes.dir");
                    texto5.DataBindings.Add("text", oDataSet, "clientes.correo");
                    date.DataBindings.Add("text", oDataSet, "clientes.f_regi");
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
        public void Modificar(String ide,
            String nombre,
            String tel, String dir, String correo)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand("UPDATE clientes set nombre = @nombre, tel = @tel, dir = @dir, correo = @correo " +
                    "where id = '" + ide + "'", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@id", SqlDbType.VarChar));
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@nombre", SqlDbType.VarChar));
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@tel", SqlDbType.VarChar));
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@dir", SqlDbType.VarChar));
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@correo", SqlDbType.VarChar));
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




        ////////////////////////////////////////////////////////////////CUENTAS//////////////////////////////////////////////////////////////////////////////




        //Busca una identificación en la tablaclientes
        public int buscarNumC(String ide)
        {
            int enco = 0;
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM cuentas WHERE numCuenta = '" + ide + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "cuentas");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                    enco = 1;
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
            return enco;
        }

        //Método que nos permite insertar un cliente en la tablaclientes
        //de la BD
        public void ingresarCuenta(String id, String numCuenta,
            Decimal saldo, Decimal monLimite, Decimal mondispo, String condi, DateTime f_ap)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO cuentas (id,numCuenta,saldoApagar,monLimit,mondispo,condiCuen,f_ap) " +
                    "VALUES (@id,@numCuenta,@saldoApagar,@monLimit,@mondispo,@condiCuen,@f_ap)", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.InsertCommand = oCmdInsercion;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@id", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@numCuenta", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@saldoApagar", SqlDbType.Decimal));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@monLimit", SqlDbType.Decimal));
                oDataAdapter.InsertCommand.Parameters.Add(
                   new SqlParameter("@mondispo", SqlDbType.Decimal));
                oDataAdapter.InsertCommand.Parameters.Add(
                  new SqlParameter("@condiCuen", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@f_ap", SqlDbType.DateTime));

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
        //Busca una identificación en la tablaclientes
        public void mostrarcuenta(String cuen, TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM cuentas WHERE numCuenta = '" + cuen + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "CUENTAS");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "cuentas.f_ap");
                    texto3.DataBindings.Add("text", oDataSet, "cuentas.condiCuen");
                    texto4.DataBindings.Add("text", oDataSet, "cuentas.saldoApagar");
                    texto5.DataBindings.Add("text", oDataSet, "cuentas.monLimit");
                    texto6.DataBindings.Add("text", oDataSet, "cuentas.mondispo");
                    texto7.DataBindings.Add("text", oDataSet, "cuentas.id");

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
        public void cargarcombocuentas(ComboBox combo)
        {
            //El data reader es como de el dataaparter con la diferencia que los datos los cargar o guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand cmd = new SqlCommand("Select * from  cuentas", oConexion);
            dr = cmd.ExecuteReader();//Aquí ejecuta la instrucción sql

            //Este if permite controlar si el dr tiene datos si el verdadero, es porque tiene datos
            if (dr.Read() == true)
            {
                //Ciclo que permite cargar los datos del dr en el combo
                do
                {
                    //Aqui agrega al combo el campo dr a identificación convertido a string porque el campo identificacion era varchar
                    combo.Items.Add(dr["numCuenta"].ToString());
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Busca una identificación en la tablaclientes
        public void mostrarcondicuenta(String numcuen, TextBox texto2)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM cuentas WHERE numCuenta = '" + numcuen+"'",oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "cuentas");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "cuentas.condiCuen");

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
        public void modificarcuenta(String numerocuenta,
            String condicion)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand(
                    "UPDATE cuentas SET condiCuen = '" + condicion + "' WHERE numCuenta = '" + numerocuenta+"'", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@condicion", SqlDbType.VarChar));
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
        public void modificarmontolimite(String numerocuenta,
            decimal montolimite)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand(
                    "UPDATE cuentas SET monLimit = " + montolimite + ", mondispo = " + montolimite + " WHERE numCuenta = '" + numerocuenta + "'", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@montolimite", SqlDbType.VarChar));
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
        //Busca una identificación en la tablaclientes
        public void mostrarmontolimite(String numcuen, TextBox texto2)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM cuentas WHERE numCuenta = '" + numcuen + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "cuentas");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "cuentas.monLimit");

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


        public void mostrarestadodecuenta(String numcuen, TextBox texto2)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM cuentas WHERE numCuenta = '" + numcuen + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "cuentas");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "cuentas.condiCuen");

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
        public void modificarActDesact(String numCuenta,
            String condiCuen)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand("UPDATE cuentas set condiCuen = @condiCuen where numCuenta = '" + numCuenta + "'", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(new SqlParameter("@condiCuen", SqlDbType.VarChar));
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
    }//final
}