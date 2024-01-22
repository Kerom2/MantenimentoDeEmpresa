using ProyectoCreditos.ConexionBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCreditos.ModeloNiveles
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
        //////////////////////////////////////////////////////////////////////////////////
        public void cargarcomboniveles(ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos
            //los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand(
                "SELECT * FROM niveles", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega al combo el campo (identificacion) 
                    combo.Items.Add(dr["codNiv"]).ToString();
                } while (dr.Read() == true);
                //Este ciclo se va a ejecutar mientras el dr tenga datos almacenados en él
                //ya que si es true es porque hay datos
            }
            oConexion.Close();
        }
        //////////////////////////////////////////////////////////////////////////////////////
        //Esta función permite buscar una identifcación en la tablaclientes de la BD
        public int buscarcodigonivel(string cod)
        {
            int enco = 0;
            try
            {
                cn.conectarbase(); //Conectar con la BD
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM niveles WHERE codNiv = '" + cod + "'", oConexion);
                //Plantear la instrucción en SQL que se va a ejecutar
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta por medio del oDataAdapter la instrucción que está almacenada
                //en oCmdConsulta
                oDataSet.Clear();
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "niveles");
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
          //////////////////////////////////////////////////////////////////////////////////////////////////
          //Procedimiento que permite ingresar un Nivel en la tablaniveles
        public void insertarnivel(String codNiv, String nomNiv)
        {
            try
            {
                cn.conectarbase();
                //Aquí construye el objeto oCmdInsercion con la instrucción en SQL de insertar
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO niveles (codNiv,nomNiv) VALUES (@codNiv,@nomNiv)", oConexion);
                oDataAdapter.InsertCommand = oCmdInsercion;
                //Aquí ejecuta la instrucción SQL que está en oCmdInsercion

                //Aquí se especifican los tipos de datos de cada uno de los parámetros que van en los values
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@codNiv", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@nomNiv", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Función que devuelve el código de nivel
        public string devuelvecodigonivel(string nombre)
        {
            string dato = "";
            string num = "";
            //El DataReader es como el DataAdapter con la diferencia que los datos
            //los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM niveles WHERE nomNiv = '" + nombre + "'", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                dato = (dr["nomNiv"]).ToString();
                //combo.Items.Add(dr["nombrenivel"]).ToString();
                if (dato.Equals(nombre))
                    num = (dr["codNiv"].ToString());
            }
            oConexion.Close();
            return num;
        } //Cierra función

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //FUNCION QUE MUSTRA LOS DATOS DE UN NIVEL PARA QUE EL USUARIO PUEDA MODIFICARLOS
        public void mostrarNiveles(String codNiv, TextBox texto2)
        {
            try
            {
                cn.conectarbase();
                SqlCommand oCmdConsulta =
                    new SqlCommand("SELECT * FROM niveles WHERE codNiv = '" + codNiv + "'", oConexion);
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta la instrrucción en SQL que está almacenada
                //en la variable oCmdConsulta
                oDataSet.Clear(); //Limpia el DataSet
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "niveles");
                //Rellena el DataSet con los datos de tablaclientes 
                //de acuerdo al SELECT especificado
                oConexion.Close();
                //Si el DataSet es > 0 es pq encontró datos
                if (oDataAdapter.Fill(oDataSet) > 0)
                {
                    //Enlaza o visualiza el campo que está en el dataset y la vincula  con el objeto texto donde se va mostrar
                    texto2.DataBindings.Add("text", oDataSet, "niveles.nomNiv");
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

        //Esta función permite buscar una identifcación en la tablaclientes de la BD
        public int buscarfuncionnivel(string codigo)
        {
            int enco = 0;
            try
            {
                cn.conectarbase(); //Conectar con la BD
                SqlCommand oCmdConsulta = new SqlCommand("SELECT * FROM funnivs WHERE codFunNiv = '" + codigo + "'", oConexion);
                //Plantear la instrucción en SQL que se va a ejecutar
                oDataAdapter.SelectCommand = oCmdConsulta;
                //Ejecuta por medio del oDataAdapter la instrucción que está almacenada
                //en oCmdConsulta
                oDataSet.Clear();
                oConexion.Open(); //Abre la conexión
                oDataAdapter.Fill(oDataSet, "funnivs");
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
        }

        //Procedimiento que permite ingresar un Nivel en la tablaniveles
        public void insertarfuncionnivel(String codFunNiv,
            String codNiv, String codFun, String estado)
        {
            try
            {
                cn.conectarbase();
                //Aquí construye el objeto oCmdInsercion con la instrucción en SQL de insertar
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO funnivs (codFunNiv,codNiv,codFun,estado) VALUES (@codFunNiv,@codNiv,@codFun,@estado)", oConexion);
                oDataAdapter.InsertCommand = oCmdInsercion;
                //Aquí ejecuta la instrucción SQL que está en oCmdInsercion

                //Aquí se especifican los tipos de datos de cada uno de los parámetros que van en los values
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@codFunNiv", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@codNiv", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@codFun", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@estado", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        //////////////////////////////////////////////////////////////////////////////////////////////////
        public void cargarcombonivelesFUNNIV(ComboBox combo)
        {
            //El DataReader es como el DataAdapter con la diferencia que los datos
            //los guarda como un conjunto de datos
            SqlDataReader dr = null;
            oConexion.Open();
            SqlCommand oCmdConsulta = new SqlCommand(
                "SELECT * FROM niveles", oConexion);
            dr = oCmdConsulta.ExecuteReader();
            if (dr.Read() == true) //Si es verdadero es pq hay datos en el dr
            {
                //Ciclo para recorrer el DataReader y cargar los datos en el combo
                do
                {
                    //Agrega al combo el campo (identificacion) 
                    combo.Items.Add(dr["nomNiv"]).ToString();
                } while (dr.Read() == true);
                //Este ciclo se va a ejecutar mientras el dr tenga datos almacenados en él
                //ya que si es true es porque hay datos
            }
            oConexion.Close();
        }
    }//final
}
