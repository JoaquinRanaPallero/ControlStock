using ControlStock.Datos;
using ControlStock.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlStock.Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> Listar()
        {
            var datos = new MarcaDatos();
            return datos.Listar();
        }
    }
}
