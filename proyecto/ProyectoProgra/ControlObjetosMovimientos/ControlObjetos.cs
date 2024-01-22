using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProyectoCreditos.ControlObjetosMovimientos
{
    class ControlObjetos
    {
        //Procedimiento que permite cargar las direcciones del formulario
        public void cargarcombotipomovimiento(ComboBox combo)
        {
            combo.Items.Add("Compra");
            combo.Items.Add("Abono");
        }

        public void limpiarcampostextosregistrar(TextBox texto1,
            TextBox texto2, TextBox texto3, TextBox texto4)
        {
            texto1.Text = ""; texto2.Text = "Monto Movimiento";
            texto3.Text = "Nombre del Responsable"; texto4.Text = "Detalle Movimiento";
            texto1.Focus();
        }
        public void bloquearobjetosregistrarmovimientos(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, ComboBox combo1, DateTimePicker fecha,
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            combo1.Enabled = false;
            fecha.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }

        public void desbloquearobjetosregistrarmovimientos(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, ComboBox combo1, ComboBox combo2, DateTimePicker fecha,
            Button boton1, Button boton2)
        {
            texto1.Enabled = false;
            texto2.Enabled = true;
            texto3.Enabled = true;
            texto4.Enabled = true;
            combo1.Enabled = true;
            combo2.Enabled = false;
            fecha.Enabled =  true;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }
        public void bloquearobjetosconsultarmovimientos(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7, ComboBox combo1,
            Button boton1)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            texto6.Enabled = false;
            texto7.Enabled = false;
            combo1.Enabled = true;
            boton1.Enabled = true;
        }
        public void bloquearobjetoseliminarmovimientos(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7, ComboBox combo1,
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            texto6.Enabled = false;
            texto7.Enabled = false;
            combo1.Enabled = true;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }
        public void desbloquearobjetoseliminarmovimientos(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7, ComboBox combo1,
            Button boton1, Button boton2)
        {
            texto1.Enabled = false;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            texto6.Enabled = false;
            texto7.Enabled = false;
            combo1.Enabled = false;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }
        public void limpiarcampostextosconsultar(TextBox texto1,
            TextBox texto2, TextBox texto3, TextBox texto4,
            TextBox texto5, TextBox texto6, TextBox texto7)
        {
            texto1.Text = ""; texto2.Text = "";
            texto3.Text = ""; texto4.Text = "";
            texto5.Text = ""; texto6.Text = "";
            texto7.Text = "";
            texto1.Focus();
        }
    }
}
