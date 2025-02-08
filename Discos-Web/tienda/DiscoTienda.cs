using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;

namespace tienda
{
    public class DiscoTienda
    {
        
        public List<Disco> listar()         //Funcion que devuelve en una lista todos los discos de la BBDD
        {
            List<Disco> list = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();      //Para hacer la consulta SQL
            SqlDataReader lector;


            try
            {
                //cadena de conexion
                conexion.ConnectionString = "server=DESKTOP-GHSCFC0; database=DISCOS_DB; integrated security=false; user=sa; password=2005";
                comando.CommandType = System.Data.CommandType.Text;    //Consulta SQL
                comando.CommandText = "Select DISCOS.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa, ESTILOS.Descripcion as Estilo, TIPOSEDICION.Descripcion as Tipo from DISCOS " +
                    "INNER JOIN ESTILOS " +
                    "ON DISCOS.IdEstilo = ESTILOS.Id " +
                    "INNER JOIN TIPOSEDICION " +
                    "ON DISCOS.IdTipoEdicion = TIPOSEDICION.Id";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read()) //Lee los datos de la tabla, si hay un valor siguiente da true, sino false.
                {

                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.Titulo = (string)lector["Titulo"];
                    aux.Fecha = (DateTime)lector["FechaLanzamiento"];
                    aux.Cant_Canciones = (int)lector["CantidadCanciones"];
                    aux.Url_Imagen = (string)lector["UrlImagenTapa"];
                    aux.Estilo_Disco = new Estilo();
                    aux.Estilo_Disco.Descripcion = (string)lector["Estilo"];
                    aux.Tipo_Disco = new Tipo();
                    aux.Tipo_Disco.Descripcion = (string)lector["Tipo"];

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
                conexion.Close();
            }
        }

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("insert into DISCOS values (@Titulo, @Fecha, @cant_canciones, @Imagen, 1, 1);");

                datos.agregarParametro("@Titulo", nuevo.Titulo);
                datos.agregarParametro("@Fecha", nuevo.Fecha);
                datos.agregarParametro("@cant_canciones", nuevo.Cant_Canciones);
                datos.agregarParametro("@Imagen", nuevo.Url_Imagen);

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

        public void borrar(Disco borrar)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("DELETE FROM DISCOS WHERE Id = @Id;");
                datos.agregarParametro("@Id", borrar.Id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { datos.cerrarConexion(); }
        }

        public void modificar(Disco disco)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("UPDATE DISCOS SET Titulo=@Titulo, FechaLanzamiento=@Fecha, CantidadCanciones=@Canciones, UrlImagenTapa=@Imagen where Id = @ID;");
                
                datos.agregarParametro("@Titulo", disco.Titulo);
                datos.agregarParametro("@Fecha", disco.Fecha);
                datos.agregarParametro("@Canciones", disco.Cant_Canciones);
                datos.agregarParametro("@Imagen", disco.Url_Imagen);
                datos.agregarParametro("@ID", disco.Id);
                

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

    }
}
