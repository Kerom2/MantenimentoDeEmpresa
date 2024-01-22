using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProyectoCreditos.MantenimientoClientes;
using ProyectoCreditos.MantenimientoCuentas;
using ProyectoCreditos.MantenimientoReportes;
using ProyectoCreditos.Mantenimiento_Movimientos;
using ProyectoCreditos.MantenimientoFunciones;
using ProyectoCreditos.MantenimientoNiveles;
using ProyectoCreditos.MenuPrincipal;
using ProyectoCreditos.MantenimientoUsuarios;





namespace ProyectoCreditos
{
    static class Program
    {
        /// <summary>
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new InicioSesion ());
        }
    }
}
