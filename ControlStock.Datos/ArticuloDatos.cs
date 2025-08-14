using System.Collections.Generic;
using System.Data.SqlClient;
using ControlStock.Dominio;

namespace ControlStock.Datos
{
    public class ArticuloDatos
    {
        private string connectionString = "server=localhost\\SQLEXPRESS01; database=CATALOGO_DB; integrated security=true;";

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
    }
}
