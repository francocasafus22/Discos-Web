using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tienda
{
    public class EstiloTienda
    {

        public List<Estilo> listarEstilo()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Estilo> list = new List<Estilo>();

            try
            {

                datos.setConsulta("Select Id, Descripcion from ESTILOS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Estilo aux = new Estilo();
                    aux.Id = Convert.ToInt32(datos.Lector["Id"]);
                    aux.Descripcion = datos.Lector["Descripcion"].ToString();
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
