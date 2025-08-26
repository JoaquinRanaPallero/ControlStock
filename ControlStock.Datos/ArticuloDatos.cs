using ControlStock.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;

namespace ControlStock.Datos
{
    public class ArticuloDatos
    {
        // private string connectionString = "server=localhost\\SQLEXPRESS; database=CATALOGO_DB; integrated security=true;"; esto no va más, entra por app.config
        private readonly string connectionString = ConfigurationManager.ConnectionStrings["CatalogoDb"].ConnectionString;
        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos(); // 1.Se crea el objeto de acceso

            //using (SqlConnection conexion = new SqlConnection(connectionString)) // 2. se reemplaza por la clase AccesoDatos
            try
            {
                // se define query
                string query = @"SELECT A.Id, Codigo, Nombre, A.Descripcion, 
                                        M.Descripcion AS Marca, 
                                        C.Descripcion AS Categoria, 
                                        ImagenUrl, Precio,
                                        A.IdMarca, A.IdCategoria
                                 FROM ARTICULOS A
                                 LEFT JOIN MARCAS M ON A.IdMarca = M.Id
                                 LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id";

                // SqlCommand comando = new SqlCommand(query, conexion);
                // conexion.Open();
                //SqlDataReader lector = comando.ExecuteReader();

                datos.SetearConsulta(query); //se ejecuta consulta desde accesodatos
                datos.EjecutarLectura();

                // leer resultados
                while (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Codigo = datos.Lector["Codigo"].ToString();
                    art.Nombre = datos.Lector["Nombre"].ToString();
                    art.Descripcion = datos.Lector["Descripcion"].ToString();
                    art.ImagenUrl = datos.Lector["ImagenUrl"].ToString();
                    art.Precio = (decimal)datos.Lector["Precio"];
                    art.Id = (int)datos.Lector["Id"];

                    art.Marca = new Marca
                    {
                        Id = datos.Lector["IdMarca"] == DBNull.Value ? 0 : Convert.ToInt32(datos.Lector["IdMarca"]),
                        Descripcion = datos.Lector["Marca"] == DBNull.Value ? null : datos.Lector["Marca"].ToString()
                    };

                    art.Categoria = new Categoria
                    {
                        Id = datos.Lector["IdCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(datos.Lector["IdCategoria"]),
                        Descripcion = datos.Lector["Categoria"] == DBNull.Value ? null : datos.Lector["Categoria"].ToString()

                    };
                    lista.Add(art);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }   
            return lista;
    }


        public void Agregar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                const string sql = @"
                    INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)
                    VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio);";

                datos.SetearConsulta(sql);

                datos.AgregarParametro("@Codigo", art.Codigo);
                datos.AgregarParametro("@Nombre", art.Nombre);
                datos.AgregarParametro("@Descripcion", (object)art.Descripcion ?? DBNull.Value);
                datos.AgregarParametro("@IdMarca", art.Marca?.Id ?? (object)DBNull.Value);
                datos.AgregarParametro("@IdCategoria", art.Categoria?.Id ?? (object)DBNull.Value);
                datos.AgregarParametro("@ImagenUrl", (object)art.ImagenUrl ?? DBNull.Value);
                datos.AgregarParametro("@Precio", art.Precio);

                datos.EjecutarAccion();
            
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public void Eliminar(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string sql = @"DELETE FROM ARTICULOS WHERE Id = @Id";
                datos.SetearConsulta(sql);
                datos.AgregarParametro("@Id", id);
                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public void Modificar(Articulo art)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string sql = @"UPDATE ARTICULOS 
                       SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, 
                           IdMarca = @IdMarca, IdCategoria = @IdCategoria, 
                           ImagenUrl = @ImagenUrl, Precio = @Precio 
                       WHERE Id = @Id";

                datos.SetearConsulta(sql);

                datos.AgregarParametro("@Id", art.Id);
                datos.AgregarParametro("@Codigo", art.Codigo);
                datos.AgregarParametro("@Nombre", art.Nombre);
                datos.AgregarParametro("@Descripcion", (object)art.Descripcion ?? DBNull.Value);
                datos.AgregarParametro("@IdMarca", art.Marca?.Id ?? (object)DBNull.Value);
                datos.AgregarParametro("@IdCategoria", art.Categoria?.Id ?? (object)DBNull.Value);
                datos.AgregarParametro("@ImagenUrl", (object)art.ImagenUrl ?? DBNull.Value);
                datos.AgregarParametro("@Precio", art.Precio);

                datos.EjecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }


        public Articulo ObtenerPorId(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string sql = @"
        SELECT A.*, M.Id as MarcaId, M.Descripcion as MarcaDesc, 
               C.Id as CategoriaId, C.Descripcion as CategoriaDesc 
        FROM ARTICULOS A
        LEFT JOIN MARCAS M ON A.IdMarca = M.Id
        LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
        WHERE A.Id = @Id";

                datos.SetearConsulta(sql);
                datos.AgregarParametro("@Id", id);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Lector["Id"];
                    art.Codigo = datos.Lector["Codigo"].ToString();
                    art.Nombre = datos.Lector["Nombre"].ToString();

                    // ... (el resto del código para leer los datos igual que antes, usando datos.Lector)

                    art.Marca = new Marca
                    {
                        Id = datos.Lector["MarcaId"] != DBNull.Value ? (int)datos.Lector["MarcaId"] : 0,
                        Descripcion = datos.Lector["MarcaDesc"] != DBNull.Value ? datos.Lector["MarcaDesc"].ToString() : ""
                    };
                    art.Categoria = new Categoria
                    {
                        Id = datos.Lector["CategoriaId"] != DBNull.Value ? (int)datos.Lector["CategoriaId"] : 0,
                        Descripcion = datos.Lector["CategoriaDesc"] != DBNull.Value ? datos.Lector["CategoriaDesc"].ToString() : ""
                    };

                    return art;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

    }

}

