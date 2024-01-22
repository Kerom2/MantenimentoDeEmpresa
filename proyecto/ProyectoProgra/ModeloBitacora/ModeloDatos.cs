using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace ProyectoCreditos.ModeloBitacora
{
    internal class ModeloDatos
    {
        public ConexionBaseDeDatos.ConectarBD cn = 
            new ConexionBaseDeDatos.ConectarBD();

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

        //Procedimiento que permite ingresar un cliente en la tablaclientes
        public void ingresarbitacora(DateTime f_mov,
            string loginUS, string detalle)
        {
            try
            {
                cn.conectarbase();
                //Aquí construye el objeto oCmdInsercion con la instrucción en SQL de insertar
                SqlCommand oCmdInsercion = new SqlCommand("INSERT INTO bitacora (f_mov,loginUS,detalle) VALUES (@f_mov,@loginUS,@detalle)", oConexion);

                oDataAdapter.InsertCommand = oCmdInsercion;
                //Aquí ejecuta la instrucción SQL que está en oCmdInsercion

                //Aquí se especifican los tipos de datos de cada uno de los parámetros que van en los values
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@f_mov", SqlDbType.DateTime));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@loginUS", SqlDbType.VarChar));
                oDataAdapter.InsertCommand.Parameters.Add(
                    new SqlParameter("@detalle", SqlDbType.VarChar));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

    }//final
}
