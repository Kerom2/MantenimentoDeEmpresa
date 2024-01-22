using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProyectoCreditos.ControlObjetosClientes
{
    class ControlObjetos
    {
        public void bloquearobjetosregistrarclientes(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5,
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }

        public void desbloquearobjetosregistrarclientes(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5,
            Button boton1, Button boton2)
        {
            texto1.Enabled = false;
            texto2.Enabled = true;
            texto3.Enabled = true;
            texto4.Enabled = true;
            texto5.Enabled = true;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }

        public void limpiarcampostextos(TextBox texto1,
            TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5)
        {
            texto1.Text = ""; texto2.Text = "";
            texto3.Text = ""; texto4.Text = "";
            texto5.Text = "";
            texto1.Focus();
        }
        public void bloquearobjetosconsultarclientes(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5,
            Button boton1)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            boton1.Enabled = true;
        }
        public void limpiarcampostextosconsultar(TextBox texto1,
            TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6)
        {
            texto1.Text = ""; texto2.Text = "";
            texto3.Text = ""; texto4.Text = "";
            texto5.Text = ""; texto6.Text = "";
            texto1.Focus();
        }
        public void bloquearobjetosmodificarclientes(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5, DateTimePicker date,
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            date.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }
        public void desbloquearobjetosmodificarclientes(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5, DateTimePicker date,
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = true;
            texto3.Enabled = true;
            texto4.Enabled = true;
            texto5.Enabled = true;
            date.Enabled = true;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }
    }
}
