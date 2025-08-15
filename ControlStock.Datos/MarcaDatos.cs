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
    public class MarcaDatos
    {
        private readonly string connectionString =
            ConfigurationManager.ConnectionStrings["CatalogoDb"].ConnectionString;

        public List<Marca> Listar()
        {
            List<Marca> lista = new List<Marca>();
            const string sql = "SELECT Id, Descripcion FROM MARCAS ORDER BY Descripcion";

            using (SqlConnection conexion = new SqlConnection(connectionString))
            using (SqlCommand comando = new SqlCommand(sql, conexion))
            {
                conexion.Open();
                using (SqlDataReader lector = comando.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Marca
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