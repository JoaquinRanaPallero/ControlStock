using ControlStock.Datos;
using ControlStock.Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;


namespace ControlStock.Negocio
{
    public class ArticuloNegocio
    {
        
       
        public List<Articulo> Listar()
        {
            ArticuloDatos datos = new ArticuloDatos();
            return datos.Listar();
        }

        public void Agregar(Articulo art)
        {
            ArticuloDatos datos = new ArticuloDatos();
            datos.Agregar(art);
        }

        public void Eliminar(int id)
        {
            var datos = new ArticuloDatos();
            datos.Eliminar(id);
        }

        public void  Modificar(Articulo articulo)
        {
            // validar
            if (articulo == null) throw new Exception("Artículo no puede ser nulo");
            if (articulo.Id <= 0) throw new Exception("ID inválido");

            var datos = new ArticuloDatos();
            datos.Modificar(articulo);
        }
        public Articulo ObtenerPorId(int id)
        {
            var datos = new ArticuloDatos();
            return datos.ObtenerPorId(id);
        }

        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
                      
            try
            {
                string consulta = @"SELECT A.Id, Codigo, Nombre, A.Descripcion,                                       M.Descripcion AS Marca, 
                                        C.Descripcion AS Categoria, 
                                        ImagenUrl, Precio,
                                        A.IdMarca, A.IdCategoria
                                 FROM ARTICULOS A
                                 JOIN MARCAS M ON A.IdMarca = M.Id
                                 JOIN CATEGORIAS C ON A.IdCategoria = C.Id ";
                if (campo == "Precio")
                {
                    switch (criterio)
                    {
                        case "Mayor a":
                            consulta += " AND A.Precio > @precio";
                            break;
                        case "Menor a":
                            consulta += " AND A.Precio < @precio";
                            break;
                        default: // "Igual a" o cualquier otro
                            consulta += " AND A.Precio = @precio";
                            break;
                    }
                }
                else if (campo == "Nombre")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "AND Nombre like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "AND Nombre like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "AND Nombre like '%" + filtro + "%'";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "AND A.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "AND A.Descripcion like '%" + filtro + "'";
                            break;
                        default:
                            consulta += "AND A.Descripcion like '%" + filtro + "%'";
                            break;
                    }
                }

                datos.SetearConsulta(consulta);

                if (campo == "Precio")
                {
                    if (decimal.TryParse(filtro, out decimal precio))
                    {
                        datos.AgregarParametro("@precio", precio);
                    }
                    else
                    {
                        throw new ArgumentException("El filtro de precio debe ser un número válido");
                    }
                }



                datos.EjecutarLectura();
                var dr = datos.Lector;
                while (dr.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)dr["Id"];
                    art.Codigo = dr["Codigo"].ToString();
                    art.Nombre = dr["Nombre"].ToString();
                    art.Descripcion = dr["Descripcion"].ToString();
                    art.ImagenUrl = dr["ImagenUrl"].ToString();
                    art.Precio = (decimal)dr["Precio"];

                    art.Marca = new Marca
                    {
                        // Id = (int)lector["IdMarca"],
                        // Descripcion = lector["Marca"].ToString()
                        Id = dr["IdMarca"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdMarca"]),
                        Descripcion = dr["Marca"] == DBNull.Value ? null : dr["Marca"].ToString()
                    };

                    art.Categoria = new Categoria
                    {
                        Id = dr["IdCategoria"] == DBNull.Value ? 0 : Convert.ToInt32(dr["IdCategoria"]),
                        Descripcion = dr["Categoria"] == DBNull.Value ? null : dr["Categoria"].ToString()


                        // Id = (int)lector["IdCategoria"],
                        //Descripcion = lector["Categoria"].ToString()
                    };

                    lista.Add(art);
                }




            }
            catch (Exception ex)
            {
                throw ex;
            }

            return lista;
        }
    }
}
