using System.Collections.Generic;
using ControlStock.Datos;
using ControlStock.Dominio;

namespace ControlStock.Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> Listar()
        {
            ArticuloDatos datos = new ArticuloDatos();
            return datos.Listar();
        }
    }
}
