using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProyectoCreditos.ControlOjetosUsuarios
{
    internal class ControlObjetos
    {
        public void bloquearobjetosusuarios(TextBox textbox1,
              TextBox textbox2, TextBox textbox3, TextBox textbox4,
              TextBox textBox5,
              DateTimePicker fecha,
              Button boton1, Button boton2)
        {
            textbox1.Enabled = true;
            textbox2.Enabled = false;
            textbox3.Enabled = false;
            textbox4.Enabled = false;
            textBox5.Enabled = false;
            fecha.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }

        //Desbloquear objetos de usuarios
        public void desbloquearobjetosusuarios(TextBox textbox1,
            TextBox textbox2, TextBox textbox3, TextBox textbox4,
              TextBox textBox5,
            DateTimePicker fecha,
            Button boton1, Button boton2)
        {
            textbox1.Enabled = false;
            textbox2.Enabled = true;
            textbox3.Enabled = true;
            textbox4.Enabled = true;
            textBox5.Enabled = true;
            fecha.Enabled = true;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }

        public void bloquearobjetosConsultarusuarios(TextBox textbox1,
              TextBox textbox2, TextBox textbox3, TextBox textbox4,
              TextBox textBox5, TextBox textBox6, TextBox textBox7, TextBox textBox8)
              
        {
            textbox1.Enabled = true;
            textbox2.Enabled = false;
            textbox3.Enabled = false;
            textbox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
        }

        public void bloquearobjetosElminarusuarios(TextBox textbox1,
              TextBox textbox2, TextBox textbox3, TextBox textbox4,
              TextBox textBox5, TextBox textBox6, TextBox textBox7, TextBox textBox8, Button boton1, Button boton2)

        {
            textbox1.Enabled = true;
            textbox2.Enabled = false;
            textbox3.Enabled = false;
            textbox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }

        public void desbloquearobjetosElminarusuarios(TextBox textbox1,
              TextBox textbox2, TextBox textbox3, TextBox textbox4,
              TextBox textBox5, TextBox textBox6, TextBox textBox7, TextBox textBox8, Button boton1, Button boton2)

        {
            textbox1.Enabled = false;
            textbox2.Enabled = false;
            textbox3.Enabled = false;
            textbox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            textBox8.Enabled = false;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }

        public void bloquearobjetosModificarusuarios(TextBox textbox1,
             TextBox textbox2, TextBox textbox3, TextBox textbox4,
             TextBox textBox5, TextBox textBox6,  Button boton1, Button boton2)

        {
            textbox1.Enabled = true;
            textbox2.Enabled = false;
            textbox3.Enabled = false;
            textbox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            boton1.Enabled = true;
            boton2.Enabled = false;
        }

        public void desbloquearobjetosModificarusuarios(TextBox textbox1,
              TextBox textbox2, TextBox textbox3, TextBox textbox4,
              TextBox textBox5, TextBox textBox6, Button boton1, Button boton2)

        {
            textbox1.Enabled = false;
            textbox2.Enabled = false;
            textbox3.Enabled = true;
            textbox4.Enabled = true;
            textBox5.Enabled = true;
            textBox6.Enabled = true;
            boton1.Enabled = false;
            boton2.Enabled = true;
        }

    }//final
}
