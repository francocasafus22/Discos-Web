using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    public class TipoTienda
    {

        public List<Tipo> listarTipos()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Tipo> list = new List<Tipo>();

            try
            {

                datos.setConsulta("Select Id, Descripcion from TIPOSEDICION");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Tipo aux = new Tipo();
                    aux.Id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.Descripcion = datos.Lector["descripcion"].ToString();
                    list.Add(aux);
                }

                return list;
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
