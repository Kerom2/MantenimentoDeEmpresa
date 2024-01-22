using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace ProyectoCreditos.ControlObjetosCuentas
{
    class ControlObjetos
    {
        public void bloquearobjetosregistrarcuentas(
            TextBox texto1, TextBox texto2,
   TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, ComboBox combo1, ComboBox combo2,
   Button boton1, Button boton2, Button boton3)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            texto6.Enabled = false;
            combo1.Enabled = true;
            combo2.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
            boton3.Enabled = false;
        }

        public void desbloquearobjetosregistrarcuentas(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, ComboBox combo1, ComboBox combo2,
            Button boton1, Button boton2, Button boton3)
        {
            texto1.Enabled = false;
            texto2.Enabled = false;
            texto3.Enabled = true;
            texto4.Enabled = false;
            texto5.Enabled = true;
            texto6.Enabled = false;
            combo1.Enabled = true;
            combo2.Enabled = true;
            boton1.Enabled = true;
            boton2.Enabled = true;
            boton3.Enabled = true;
        }
        public void limpiarcampostextos(TextBox texto1,
            TextBox texto2, TextBox texto3)
        {
            texto1.Text = ""; texto2.Text = "";
            texto3.Text = "";
            texto1.Focus();
        }
        //Procedimiento que permite cargar las direcciones del formulario
        public void cargarcombocondicion(ComboBox combo)
        {
            combo.Items.Add("Activa");
            combo.Items.Add("Desactiva");
        }
        public void bloquearobjetosconsultarcuentas(
            TextBox texto1, TextBox texto2,
            TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7,
            Button boton1)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            texto4.Enabled = false;
            texto5.Enabled = false;
            texto6.Enabled = false;
            texto7.Enabled = false;
            boton1.Enabled = true;
        }
        public void limpiarcampostextosconsultar(TextBox texto1,
            TextBox texto2, TextBox texto3, TextBox texto4, TextBox texto5, TextBox texto6, TextBox texto7)
        {
            texto1.Text = ""; texto2.Text = "";
            texto3.Text = ""; texto4.Text = "";
            texto5.Text = ""; texto6.Text = "";
            texto7.Text = "";
            texto1.Focus();
        }
        public void bloquearobjetosactivardesactivarcuentas(
            TextBox texto1, TextBox texto2, ComboBox combo1, ComboBox combo2,
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            combo1.Enabled = true;
            combo2.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }
        public void desbloquearobjetosactivardesactivarcuentas(
            TextBox texto1, TextBox texto2, ComboBox combo1, ComboBox combo2,
            Button boton1, Button boton2)
        {
            texto1.Enabled = false;
            texto2.Enabled = false;
            combo1.Enabled = false;
            combo2.Enabled = true;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }
        public void limpiarcampostextosactydesac(TextBox texto1,
            TextBox texto2)
        {
            texto1.Text = ""; texto2.Text = "";
            texto1.Focus();
        }
        public void bloquearobjetosactualizarmontocuentas(
            TextBox texto1, TextBox texto2, TextBox texto3, ComboBox combo1,
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            combo1.Enabled = true;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }
        public void desbloquearobjetosactualizarmontocuentas(
            TextBox texto1, TextBox texto2, TextBox texto3, ComboBox combo1,
            Button boton1, Button boton2)
        {
            texto1.Enabled = false;
            texto2.Enabled = false;
            texto3.Enabled = true;
            combo1.Enabled = false;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }
        public void limpiarcampostextosactualizarmontos(TextBox texto1,
            TextBox texto2, TextBox texto3)
        {
            texto1.Text = ""; texto2.Text = ""; texto3.Text = "";
            texto1.Focus();
        }
        public void bloquearobjetosActDesactcuentas(
            TextBox texto1, TextBox texto2, TextBox texto3, ComboBox combo1, ComboBox combo2, 
            Button boton1, Button boton2)
        {
            texto1.Enabled = true;
            texto2.Enabled = false;
            texto3.Enabled = false;
            combo1.Enabled = true;
            combo2.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }

        public void desbloquearobjetosActDesactcuentas(
           TextBox texto1, TextBox texto2, TextBox texto3, ComboBox combo1, ComboBox combo2,
           Button boton1, Button boton2)
        {
            texto1.Enabled = false;
            texto2.Enabled = false;
            texto3.Enabled = false;
            combo1.Enabled = false;
            combo2.Enabled = true;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }

    }//final
}
