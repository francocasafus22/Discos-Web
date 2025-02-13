﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.ComponentModel;

namespace tienda
{
    public class DiscoTienda
    {
        
        public List<Disco> listar(string filtro)         //Funcion que devuelve en una lista todos los discos de la BBDD
        {
            List<Disco> list = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();


            try
            {
                
                if(filtro == "")
                {
                    datos.setearProcedimiento("storedListar");
                }
                else
                {
                    datos.setConsulta("Select DISCOS.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,ESTILOS.Descripcion as Estilo, ESTILOS.Id as ESTILO_ID, TIPOSEDICION.Id as TIPO_ID ,TIPOSEDICION.Descripcion as Tipo, DISCOS.Activo as Activo from DISCOS " +
                    "INNER JOIN ESTILOS ON DISCOS.IdEstilo = ESTILOS.Id INNER JOIN TIPOSEDICION ON DISCOS.IdTipoEdicion = TIPOSEDICION.Id WHERE DISCOS.Titulo like @filtro and Activo = 1;");
                    datos.agregarParametro("@filtro", "%" + filtro + "%");
                }

                datos.ejecutarLectura();

                while (datos.Lector.Read()) //Lee los datos de la tabla, si hay un valor siguiente da true, sino false.
                {

                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Fecha = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.Cant_Canciones = (int)datos.Lector["CantidadCanciones"];
                    aux.Url_Imagen = (string)datos.Lector["UrlImagenTapa"];
                    aux.Estilo_Disco = new Estilo();
                    aux.Estilo_Disco.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Estilo_Disco.Id = (int)datos.Lector["ESTILO_ID"];
                    aux.Tipo_Disco = new Tipo();
                    aux.Tipo_Disco.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Tipo_Disco.Id = (int)datos.Lector["TIPO_ID"];
                    aux.Estado = bool.Parse(datos.Lector["Activo"].ToString());
                    
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

        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setearProcedimiento("storedAltaDisco");

                datos.agregarParametro("@Titulo", nuevo.Titulo);
                datos.agregarParametro("@Fecha", nuevo.Fecha);
                datos.agregarParametro("@cant_canciones", nuevo.Cant_Canciones);
                datos.agregarParametro("@Imagen", nuevo.Url_Imagen);
                datos.agregarParametro("@Estilo",nuevo.Estilo_Disco.Id);
                datos.agregarParametro("@Tipo", nuevo.Tipo_Disco.Id);

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

        public void borrar(string id)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("DELETE FROM DISCOS WHERE Id = @Id;");
                datos.agregarParametro("@Id", id);
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
                datos.setearProcedimiento("storedModificarDisco");
                
                datos.agregarParametro("@Titulo", disco.Titulo);
                datos.agregarParametro("@Fecha", disco.Fecha);
                datos.agregarParametro("@Canciones", disco.Cant_Canciones);
                datos.agregarParametro("@Imagen", disco.Url_Imagen);
                datos.agregarParametro("@Estilo", disco.Estilo_Disco.Id);
                datos.agregarParametro("@Tipo", disco.Tipo_Disco.Id);
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

        public Disco listarConId(string id)
        {
            AccesoDatos datos = new AccesoDatos();
            Disco aux = new Disco();

            try
            {
                datos.setConsulta("Select DISCOS.Id, Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,ESTILOS.Descripcion as Estilo, ESTILOS.Id as ESTILO_ID, TIPOSEDICION.Id as TIPO_ID ,TIPOSEDICION.Descripcion as Tipo, DISCOS.Activo as Activo from DISCOS INNER JOIN ESTILOS ON DISCOS.IdEstilo = ESTILOS.Id INNER JOIN TIPOSEDICION ON DISCOS.IdTipoEdicion = TIPOSEDICION.Id WHERE DISCOS.Id LIKE @Id");
                datos.agregarParametro("@Id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Titulo = (string)datos.Lector["Titulo"];
                    aux.Fecha = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.Cant_Canciones = (int)datos.Lector["CantidadCanciones"];
                    aux.Url_Imagen = (string)datos.Lector["UrlImagenTapa"];
                    aux.Estilo_Disco = new Estilo();
                    aux.Estilo_Disco.Descripcion = (string)datos.Lector["Estilo"];
                    aux.Estilo_Disco.Id = (int)datos.Lector["ESTILO_ID"];
                    aux.Tipo_Disco = new Tipo();
                    aux.Tipo_Disco.Descripcion = (string)datos.Lector["Tipo"];
                    aux.Tipo_Disco.Id = (int)datos.Lector["TIPO_ID"];
                    aux.Estado = bool.Parse(datos.Lector["Activo"].ToString());
                }

                return aux;
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

        public void EstadoDisco(string id, bool Estado = false)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("update DISCOS set Activo = @Estado where Id = @Id;");
                datos.agregarParametro("@Estado", Estado);
                datos.agregarParametro("@Id", id);
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
