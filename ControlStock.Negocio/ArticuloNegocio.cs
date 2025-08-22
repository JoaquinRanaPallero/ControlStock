using ControlStock.Datos;
using ControlStock.Dominio;
using System;
using System.Collections.Generic;

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



    }
}
