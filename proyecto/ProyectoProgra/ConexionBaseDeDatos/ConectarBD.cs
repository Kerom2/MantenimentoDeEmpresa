using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
//Biblioteca que permite hacer conexión con motor SQL
using System.Data.SqlClient;
//Biblioteca para poder ejecutar comandos en tablas BD
using System.Data;
namespace ProyectoCreditos.ConexionBaseDeDatos
{
    class ConectarBD
    {
        //Define y construye una variable de tipo objeto que
        //permite hacer conexión con la BD de SQLServer
        //En el paréntesis lo que iría es la cadena de conexión
        //a la BD
        public SqlConnection oConexion =
            new SqlConnection(//colegioKarla
                              //"Data Source=LAPTOP-2IURRRLU;Initial Catalog=creditos;Integrated Security=True");
                              //casa
                              // "Data Source=lapt_jero;Initial Catalog=Creditos;Integrated Security=True");
                              //colegioMArio
                              //"Data Source=LAPTOP-L53GD9SR;Initial Catalog=Creditos;Integrated Security=True");
                              //colegioCompuMario
                              "Data Source=SOPORTE-E3QEC22;Initial Catalog=Creditos;Integrated Security=True");

        public void conectarbase()
        {
            try
            {
                oConexion.Open();
                Console.WriteLine("Conectado..");
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
    }
}
