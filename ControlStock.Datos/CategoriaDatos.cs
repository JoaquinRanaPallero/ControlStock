using ControlStock.Dominio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStock.Datos
{
    public class CategoriaDatos
    {
        // Cadena de conexión tomada del App.config
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CatalogoDb"].ConnectionString;

        // Método para listar todas las categorías
        public List<Categoria> Listar()
        {
            var lista = new List<Categoria>();
            const string sql = "SELECT Id, Descripcion FROM CATEGORIAS ORDER BY Descripcion";

            using (var conexion = new SqlConnection(connectionString))
            using (var comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                using (var lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Categoria
                        {
                            Id = (int)lector["Id"],
                            Descripcion = lector["Descripcion"] as string
                        });
                    }
                }
            }
            return lista;
        }
    }
}