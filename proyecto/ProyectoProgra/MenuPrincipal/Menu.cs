using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.MantenimientoClientes;
using ProyectoCreditos.MantenimientoCuentas;
using ProyectoCreditos.Mantenimiento_Movimientos;
using ProyectoCreditos.MantenimientoReportes;
using ProyectoCreditos.MantenimientoUsuarios;
using ProyectoCreditos.MantenimientoNiveles;
using ProyectoCreditos.MantenimientoFunciones;

namespace ProyectoCreditos.MenuPrincipal
{
    public partial class Menu : Form
    {
        RegistrarClientes cli1 = new RegistrarClientes();
        ConsultarClientes cli2 = new ConsultarClientes();
        ModificarClientes cli3 = new ModificarClientes();
        RegistrarCuentas cuen1 = new RegistrarCuentas();
        ConsultarCuentas cuen2 = new ConsultarCuentas();
        ActualizarMontoLimite cuen4 = new ActualizarMontoLimite();
        ActivarDesactivarCuentas cuen5 = new ActivarDesactivarCuentas();
        RegistrarMovimientos mov1 = new RegistrarMovimientos();
        ConsultarMovimiento mov2 = new ConsultarMovimiento();
        EliminarMovimientos mov3 = new EliminarMovimientos();
        RegistrarUsuarios us1 = new RegistrarUsuarios();  
        ModificarUsusarios us2 = new ModificarUsusarios();      
        EliminarUsuario us3 = new EliminarUsuario();
        ConsultarUsuario us4 = new ConsultarUsuario();
        ActDesactUsuario us5 = new ActDesactUsuario();  
        RegistroDeNiveles niv1 = new RegistroDeNiveles();
        VisualizarNiveles niv2 = new VisualizarNiveles();   
        RegistroDeFunciones fun1 = new RegistroDeFunciones();
        ActualizarFuncionDeUnNivel fun2 = new ActualizarFuncionDeUnNivel();
        ReporteDeTodosLosClientes report1 = new ReporteDeTodosLosClientes();
        ReporteTodasLasCuentas report2 = new ReporteTodasLasCuentas();
        ReportarCuentasActivasYDesactivas report3 = new ReportarCuentasActivasYDesactivas();
        ReportarMovimientosDeCuenta report4 = new ReportarMovimientosDeCuenta();
        ReportarMovimientosPorFechas report5 = new ReportarMovimientosPorFechas();
        ReporteMovimientosPorTransaccion report6 = new ReporteMovimientosPorTransaccion();
        ReportarMovimientosPorDetalle report7 = new ReportarMovimientosPorDetalle();
        ReportarClientesPorCaracter report8 = new ReportarClientesPorCaracter();
        ReporteDeTodosLosUS report9 = new ReporteDeTodosLosUS();
        ReportarTodosLosUSPorNivel report10 = new ReportarTodosLosUSPorNivel();
        ReporteMovimientoDeBitacoraEntreFechas report11 = new ReporteMovimientoDeBitacoraEntreFechas();
        ReporteMovimientoDeBitacoraPorUsuario report12 = new ReporteMovimientoDeBitacoraPorUsuario();

       
        public Menu()
        {
            InitializeComponent();
        }

        private void moToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Modificar Clientes
            cli3.Show(); this.Hide();
        }

        private void actualizarMontoLímiteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Actualizar Monto Límite Cuentas
            cuen4.Show(); this.Hide();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void registrarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Registrar Clientes
            cli1.Show(); this.Hide();
        }

        private void consultarClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Consulatr Clientes
            cli2.Show(); this.Hide();
        }

        private void registrarCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Registrar Cuentas
            cuen1.Show(); this.Hide();
        }

        private void consultarCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Consultar Cuentas
            cuen2.Show(); this.Hide();
        }


        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //Botón Registrar Clientes
            cli1.Show(); this.Hide();
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Botón Registrar Cuentas
            cuen1.Show(); this.Hide();
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Salir
            Close();
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            //Botón Salir
            Close();
        }

        private void mantenimientoClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void registrarMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Registrar Movimientos
            mov1.Show(); this.Hide();
        }

        private void consultarMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Consultar Movimientos
            mov2.Show(); this.Hide();
        }

        private void eliminarMovimientosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Eliminar Movimientos
            mov3.Show(); this.Hide();
        }

        private void reportarTodosLosClientesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report1.Show(); this.Hide();
        }

        private void reportarTodosLasCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report2.Show(); this.Hide();
        }

        private void reportarTodasLasCuentasActivasDesactivasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report3.Show(); this.Hide();
        }

        private void reportarTodosLosMovimientosDeUnaCuentaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report4.Show(); this.Hide();
        }

        private void reportarMovimientosEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report5.Show(); this.Hide();
        }

        private void reportarMovimientosPorTipoDeTransacciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report6.Show(); this.Hide();
        }

        private void reportarElDetalleDeUnMovimientoDeCompraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report7.Show(); this.Hide();
        }

        private void reportarClientesPorCaracterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report8.Show(); this.Hide();
        }

        private void toolStripButton4_Click(object sender, EventArgs e)
        {
            //Botón Registrar Movimientos
            mov1.Show(); this.Hide();
        }

        private void activarDesactivarCuentasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //boton activar y desactivar cuentas
            //Botón Modificar Clientes
            cuen5.Show(); this.Hide();
        }

        private void reportarMovimientoDeBitácoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report12.Show(); this.Hide();
        }

        private void reportarTodosLosUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report9.Show(); this.Hide();
        }

        private void reportarTodosLosUsuariosPorNivelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report10.Show(); this.Hide();
        }

        private void reportarMovimientoDeBitacoraEntreFechasToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            report11.Show(); this.Hide();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {

        }

        private void registrarNivelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            niv1.Show(); this.Hide();
        }

        private void registrarFuncionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            fun1.Show(); this.Hide();
        }

        private void visualizarNivelesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            niv2.Show(); this.Hide();
        }

        private void actualizarFuncionDeUnNiveñToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            fun2.Show(); this.Hide();
        }

        private void registrarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            us1.Show(); this.Hide();
        }

        private void consultarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            us4.Show(); this.Hide();
        }

        private void modificarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            us2.Show(); this.Hide();
        }

        private void eliminarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            us3.Show(); this.Hide();
        }

        private void activarYDesactivarUsuariosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Botón Reporte
            us5.Show(); this.Hide();
        }
    }
}