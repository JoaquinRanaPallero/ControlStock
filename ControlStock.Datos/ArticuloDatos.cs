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

            using (SqlConnection conexion = new SqlConnection(connectionString))
            {
                string query = @"SELECT A.Id, Codigo, Nombre, A.Descripcion, 
                                        M.Descripcion AS Marca, 
                                        C.Descripcion AS Categoria, 
                                        ImagenUrl, Precio,
                                        A.IdMarca, A.IdCategoria
                                 FROM ARTICULOS A
                                 JOIN MARCAS M ON A.IdMarca = M.Id
                                 JOIN CATEGORIAS C ON A.IdCategoria = C.Id";

                SqlCommand comando = new SqlCommand(query, conexion);
                conexion.Open();
                SqlDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)lector["Id"];
                    art.Codigo = lector["Codigo"].ToString();
                    art.Nombre = lector["Nombre"].ToString();
                    art.Descripcion = lector["Descripcion"].ToString();
                    art.ImagenUrl = lector["ImagenUrl"].ToString();
                    art.Precio = (decimal)lector["Precio"];

                    art.Marca = new Marca
                    {
                        Id = (int)lector["IdMarca"],
                        Descripcion = lector["Marca"].ToString()
                    };

                    art.Categoria = new Categoria
                    {
                        Id = (int)lector["IdCategoria"],
                        Descripcion = lector["Categoria"].ToString()
                    };

                    lista.Add(art);
                }
            }
            return lista;
        }

        public void Agregar(Articulo art)
        {
            const string sql = @"
                INSERT INTO ARTICULOS (Codigo, Nombre, Descripcion, IdMarca, IdCategoria, ImagenUrl, Precio)
                VALUES (@Codigo, @Nombre, @Descripcion, @IdMarca, @IdCategoria, @ImagenUrl, @Precio);";

            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@Codigo", art.Codigo);
                comando.Parameters.AddWithValue("@Nombre", art.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", (object)art.Descripcion ?? DBNull.Value);
                comando.Parameters.AddWithValue("@IdMarca", art.Marca?.Id ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@IdCategoria", art.Categoria?.Id ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@ImagenUrl", (object)art.ImagenUrl ?? DBNull.Value);
                comando.Parameters.AddWithValue("@Precio", art.Precio);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Eliminar(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser un número entero positivo.", nameof(id));

            const string sql = @"DELETE FROM ARTICULOS WHERE Id = @Id";

            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@Id", id);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public void Modificar(Articulo art)
        {
            const string sql = @"
        UPDATE ARTICULOS 
        SET Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, 
            IdMarca = @IdMarca, IdCategoria = @IdCategoria, 
            ImagenUrl = @ImagenUrl, Precio = @Precio 
        WHERE Id = @Id";

            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@Id", art.Id);
                comando.Parameters.AddWithValue("@Codigo", art.Codigo);
                comando.Parameters.AddWithValue("@Nombre", art.Nombre);
                comando.Parameters.AddWithValue("@Descripcion", (object)art.Descripcion ?? DBNull.Value);
                comando.Parameters.AddWithValue("@IdMarca", art.Marca?.Id ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@IdCategoria", art.Categoria?.Id ?? (object)DBNull.Value);
                comando.Parameters.AddWithValue("@ImagenUrl", (object)art.ImagenUrl ?? DBNull.Value);
                comando.Parameters.AddWithValue("@Precio", art.Precio);

                conexion.Open();
                comando.ExecuteNonQuery();
            }
        }

        public Articulo ObtenerPorId(int id)
        {
            const string sql = @"
        SELECT A.*, M.Id as MarcaId, M.Descripcion as MarcaDesc, 
               C.Id as CategoriaId, C.Descripcion as CategoriaDesc 
        FROM ARTICULOS A
        LEFT JOIN MARCAS M ON A.IdMarca = M.Id
        LEFT JOIN CATEGORIAS C ON A.IdCategoria = C.Id
        WHERE A.Id = @Id";

            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand(sql, conexion))
            {
                comando.Parameters.AddWithValue("@Id", id);
                conexion.Open();

                using (var reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Articulo
                        {
                            Id = (int)reader["Id"],
                            Codigo = reader["Codigo"].ToString(),
                            Nombre = reader["Nombre"].ToString(),
                            Descripcion = reader["Descripcion"] != DBNull.Value ?
                                         reader["Descripcion"].ToString() : null,
                            Precio = (decimal)reader["Precio"],
                            ImagenUrl = reader["ImagenUrl"] != DBNull.Value ?
                                       reader["ImagenUrl"].ToString() : null,

                            // Marca
                            Marca = new Marca
                            {
                                Id = reader["MarcaId"] != DBNull.Value ?
                                    (int)reader["MarcaId"] : 0,
                                Descripcion = reader["MarcaDesc"] != DBNull.Value ?
                                            reader["MarcaDesc"].ToString() : string.Empty
                            },

                            // Categoría
                            Categoria = new Categoria
                            {
                                Id = reader["CategoriaId"] != DBNull.Value ?
                                    (int)reader["CategoriaId"] : 0,
                                Descripcion = reader["CategoriaDesc"] != DBNull.Value ?
                                            reader["CategoriaDesc"].ToString() : string.Empty
                            }
                        };
                    }
                }
            }
            return null; 
        }


    }

}

