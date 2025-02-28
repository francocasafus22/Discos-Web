using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    public class UsuarioTienda
    {
        public void ActualizarImagen(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("UPDATE USUARIOS SET ImagenURL = @url WHERE Id = @id");
                datos.agregarParametro("@url", user.ImagenURL);
                datos.agregarParametro("@id", user.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public bool Login(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {

                datos.setConsulta("SELECT Id, TipoUser, Mail, ImagenURL FROM USUARIOS WHERE Usuario = @user AND Pass = @pass");
                datos.agregarParametro("@user", usuario.User);
                datos.agregarParametro("@pass", usuario.Pass);
               
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.TipoUsuario = (int)(datos.Lector["TipoUser"]) == 2 ? TipoUsuario.ADMIN : TipoUsuario.NORMAL;
                    usuario.Mail = (string)datos.Lector["Mail"];
                    if(!(datos.Lector["ImagenURL"] is DBNull))                    
                        usuario.ImagenURL = (string)datos.Lector["ImagenURL"];
                                        
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }


        public int Registrar(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO USUARIOS(Usuario, Pass, TipoUser, Mail) output inserted.Id VALUES (@User, @Pass, 1, @Mail)");
                datos.agregarParametro("@user", usuario.User);
                datos.agregarParametro("@pass", usuario.Pass);
                datos.agregarParametro("@mail", usuario.Mail);

                return datos.ejecutarScale();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }
   

    }
}
