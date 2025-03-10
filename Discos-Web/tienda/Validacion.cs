using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace tienda
{
    public static class Validacion
    {
        public static bool textoVacio(object control)
        {
            if (control is TextBox textBox)
            {
                if (string.IsNullOrEmpty(textBox.Text))
                    return true;
                else
                    return false;
            }



            return false;
        }
    }
}