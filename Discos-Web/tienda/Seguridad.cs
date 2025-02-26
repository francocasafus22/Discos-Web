using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    public static class Seguridad
    {

        public static bool SesionActiva(object User)
        {
            Usuario usuario = User != null ? (Usuario)User : null;

            if(usuario != null && usuario.Id != 0)            
                return true;            
            else            
                return false;
            
        }


        public static bool IsAdmin(Usuario usuario)
        {

            Usuario user = usuario != null ? (Usuario)usuario : null;

            if (user != null && user.Id != 0 && user.TipoUsuario == TipoUsuario.ADMIN) return true;
            else return false;

        }

    }
}
