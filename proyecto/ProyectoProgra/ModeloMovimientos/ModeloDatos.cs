using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProyectoCreditos.ConexionBaseDeDatos;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
namespace ProyectoCreditos.ModeloMovimientos
{
    class ModeloDatos
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

        //Variables Globales
        public decimal montDisponibleActual = 0, saldoActual = 0;

        ////////////////////////////////////////////////////////////////MOVIMIENTOS////////////////////////////////////////////////////


        //Busca una identificación en la tablaclientes
        public int buscarnumcuenta(String ide)
        {
            int enco = 0;
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM cuentas WHERE numCuenta = '" + ide + "' AND condiCuen = 'Activa'", oConexion);
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
        public void insertarmovimiento(String numCuenta,
            DateTime f_mov,
            String tipoMov,
            Decimal montoMov,
            String nomRespon,
            String detalle)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdInsercion = new SqlCommand(
                    "INSERT INTO movimiento(numCuenta,f_mov,tipoMov,montoMov,nomRespon, detalle) " +
                    "VALUES (@numCuenta,@f_mov,@tipoMov,@montoMov,@nomRespon,@detalle)", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.InsertCommand = oCmdInsercion;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@numCuenta", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@f_mov", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@tipoMov", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@montoMov", SqlDbType.Decimal));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@nomRespon", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@detalle", SqlDbType.VarChar));

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

        public void modificarCompra(String numCuenta, Decimal mondispo)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand(
                    "UPDATE cuentas set mondispo = mondispo - @mondispo, saldoApagar = saldoApagar " +
                    "+ @mondispo where numCuenta = '" + numCuenta + "'", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@mondispo", SqlDbType.Decimal));
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
        public void modificarAbono(String numerocuenta,
            Decimal montodispo)
        {
            try
            {
                cn.conectarbase(); //Aquí conecta con la BD
                //Aquí guarda la instrucción QUERY en el comando oCmdInsercion
                SqlCommand oCmdModificar = new SqlCommand(
                    "UPDATE cuentas SET mondispo = mondispo + @mondispo, saldoApagar = saldoApagar - @mondispo WHERE numCuenta = '" + numerocuenta + "'", oConexion);
                //Ejecuta el Insert con la instruccón QUERY que está en el comando oCmdInsercion
                oDataAdapter.UpdateCommand = oCmdModificar;

                //Aquí especificamos el tipo de dato de cada uno de los parámetros que se
                //van a guardar en los campos de la tabla
                oDataAdapter.UpdateCommand.Parameters.Add(
                    new SqlParameter("@mondispo", SqlDbType.Decimal));
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
        public int buscarmovimiento(String num)
        {
            int enco = 0;
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM movimiento WHERE numMov = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
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

        //Busca una identificación en la tablaclientes
        public int buscardetalle(String num)
        {
            int enco = 0;
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM movimiento WHERE detalle = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
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
        public void cargarcombomovimiento(ComboBox combo)
        {
            //El data reader es como de el dataaparter con la diferencia que los datos los cargar o guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand cmd = new SqlCommand("Select * from  movimiento", oConexion);
            dr = cmd.ExecuteReader();//Aquí ejecuta la instrucción sql

            //Este if permite controlar si el dr tiene datos si el verdadero, es porque tiene datos
            if (dr.Read() == true)
            {
                //Ciclo que permite cargar los datos del dr en el combo
                do
                {
                    //Aqui agrega al combo el campo dr a identificación convertido a string porque el campo identificacion era varchar
                    combo.Items.Add(dr["numMov"].ToString());
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }

         public void cargarcombodetalle(ComboBox combo)
        {
            //El data reader es como de el dataaparter con la diferencia que los datos los cargar o guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand cmd = new SqlCommand("Select detalle from  movimiento", oConexion);
            dr = cmd.ExecuteReader();//Aquí ejecuta la instrucción sql
            
            //Este if permite controlar si el dr tiene datos si el verdadero, es porque tiene datos
            if (dr.Read() == true)
            {
                //Ciclo que permite cargar los datos del dr en el combo
                do
                {
                    //Aqui agrega al combo el campo dr a identificación convertido a string porque el campo identificacion era varchar
                    combo.Items.Add(dr["detalle"].ToString());
                } while (dr.Read() == true);
            }
            oConexion.Close();
        }
        //Busca una identificación en la tablaclientes
        public void mostrarmovimiento(String nummov, TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM movimiento WHERE numMov = '" + nummov + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "movimiento.numCuenta");
                    texto3.DataBindings.Add("text", oDataSet, "movimiento.f_mov");
                    texto4.DataBindings.Add("text", oDataSet, "movimiento.tipoMov");
                    texto5.DataBindings.Add("text", oDataSet, "movimiento.montoMov");
                    texto6.DataBindings.Add("text", oDataSet, "movimiento.nomRespon");
                    texto7.DataBindings.Add("text", oDataSet, "movimiento.detalle");

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
        //Procedimiento que permite eliminar un cliente de tablaclientes
        public void eliminarmovimientos(string num)
        {

            try
            {
                cn.conectarbase();
                SqlCommand oCmdElimina =
                    new SqlCommand("DELETE FROM movimiento WHERE numMov = '" + num + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdElimina;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
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

        //Procedimiento para obtener el Monro Disponible y el Saldo a Pagar
        public void ObtenerValores(string cnta) {
            //El data reader es como de el dataAdapter con la diferencia que los datos los cargar o guarda como un conjunto de datos
            SqlDataReader dataReader = null;

            oConexion.Open();
            SqlCommand cmd = new SqlCommand("Select mondispo, saldoApagar from cuentas where numCuenta = '" + cnta + "'", oConexion);
            dataReader = cmd.ExecuteReader();//Aquí ejecuta la instrucción sql

            if (dataReader.Read() == true)
            {
                montDisponibleActual = dataReader.GetDecimal(0);
                saldoActual = dataReader.GetDecimal(1);
            }

            oConexion.Close();
        }

        //Busca una identificación en la tablaclientes
        public void mostrarregistrarmovimiento(String numCuenta, TextBox texto2)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM cuentas WHERE numCuenta = '" + numCuenta + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "cuentas");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "cuentas.mondispo");
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

    }//final
}
