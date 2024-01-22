using ProyectoCreditos.ConexionBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCreditos.ModeloReportes
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

        public void cargartodoslosdatosclientes()
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM clientes ", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "clientes");
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
        public void cargarcombosengriidclientes(DataGridView grid)
        {
            //Este procedimiento permitre visualizar los datos que están cargados en el dataset después de haber ejecutado
            //la instrucción en sql y los visualiza en el grid
            oDataSet.Clear();
            oConexion.Open();
            oDataAdapter.Fill(oDataSet, "clientes");
            //El origen de los datos los carga del dataset 
            grid.DataSource = oDataSet;
            grid.DataMember = "clientes";
        }
        public void cargartodoslosdatoscuentas()
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM cuentas ", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "cuentas");
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
        public void cargarcombosengriidcuentas(DataGridView grid)
        {
            //Este procedimiento permitre visualizar los datos que están cargados en el dataset después de haber ejecutado
            //la instrucción en sql y los visualiza en el grid
            oDataSet.Clear();
            oConexion.Open();
            oDataAdapter.Fill(oDataSet, "cuentas");
            //El origen de los datos los carga del dataset 
            grid.DataSource = oDataSet;
            grid.DataMember = "cuentas";
        }
        public void cargarcombosengriidmovimientos(DataGridView grid)
        {
            //Este procedimiento permitre visualizar los datos que están cargados en el dataset después de haber ejecutado
            //la instrucción en sql y los visualiza en el grid
            oDataSet.Clear();
            oConexion.Open();
            oDataAdapter.Fill(oDataSet, "movimiento");
            //El origen de los datos los carga del dataset 
            grid.DataSource = oDataSet;
            grid.DataMember = "movimiento";
        }

        public void cargarcombosengribitacora(DataGridView grid)
        {
            //Este procedimiento permitre visualizar los datos que están cargados en el dataset después de haber ejecutado
            //la instrucción en sql y los visualiza en el grid
            oDataSet.Clear();
            oConexion.Open();
            oDataAdapter.Fill(oDataSet, "bitacora");
            //El origen de los datos los carga del dataset 
            grid.DataSource = oDataSet;
            grid.DataMember = "bitacora";
        }
        public void cargartodoslosdatosporestadocuenta(string Condi)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM Cuentas WHERE condiCuen = '" + Condi + "'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "cuentas");
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
        public void cargartodoslosmovimientospornumerocuenta(string num)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM movimiento WHERE numCuenta = '" + num + "'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
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
        public void cargartodoslosmovimientosporfechas(string fecha1, string fecha2)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM movimiento WHERE f_mov BETWEEN '" + fecha1 + "' AND '"+fecha2+"'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
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
        public void cargartodoslosmovimientospordetalle(string num)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT detalle FROM movimiento WHERE numMov = '" + num + "'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
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

        public void cargartodoslosmovimientosportransaccion(string num)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM movimiento WHERE tipoMov  = '" + num + "'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "movimiento");
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



        public void cargartodoslosclientespornombre(string nombre)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM clientes WHERE nombre LIKE '" + nombre + "%'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "clientes");
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

        public void cargartodoslosdatosUS()
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM usuarios ", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "usuarios");
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

        public void cargarcombosengridUS(DataGridView grid)
        {
            //Este procedimiento permitre visualizar los datos que están cargados en el dataset después de haber ejecutado
            //la instrucción en sql y los visualiza en el grid
            oDataSet.Clear();
            oConexion.Open();
            oDataAdapter.Fill(oDataSet, "usuarios");
            //El origen de los datos los carga del dataset 
            grid.DataSource = oDataSet;
            grid.DataMember = "usuarios";
        }

        public void cargartodoslosUSporNivel(string codNivUS)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM usuarios WHERE codNivUS LIKE '" + codNivUS + "%'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "usuarios");
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


        public void cargartodoslosmovimientosdeBitacoraporfechas(string fecha1, string fecha2)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM bitacora WHERE f_mov BETWEEN '" + fecha1 + "' AND '" + fecha2 + "'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "bitacora");
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

        public void cargartodoslosmovimientosdeBitacoraporUS(string US)
        {
            try
            {
                cn.conectarbase();
                SqlCommand ocmdconsulta = new SqlCommand("SELECT * FROM bitacora WHERE liginUS'" + US + "'", oConexion);

                oDataAdapter.SelectCommand = ocmdconsulta;
                oDataSet.Clear();
                oConexion.Open();
                oDataAdapter.Fill(oDataSet, "bitacora");
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
