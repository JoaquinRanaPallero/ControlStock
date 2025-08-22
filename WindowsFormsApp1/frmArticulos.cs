using ControlStock.Dominio;
using ControlStock.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmArticulos : Form
    {





        // todos los articulos cargados
        private List<Articulo> articulostodos = new List<Articulo>();
        

        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            CargarGrid();
            //CargarCombos();
        }

        private void CargarGrid()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            articulostodos = negocio.Listar();
            dgvArticulos.DataSource = articulostodos;
            pictureBox1.Load(articulostodos[0].ImagenUrl); // Cargar imagen del primer artículo

            // Ocular columnas
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }


        //////private void CargarCombos()
        //////{
        //////    // Cargar Marcas
        //////    var marcaNeg = new MarcaNegocio();
        //////    cboMarca.DataSource = marcaNeg.Listar();
        //////    cboMarca.DisplayMember = "Descripcion"; 
        //////    cboMarca.ValueMember = "Id";            

        //////    // Cargar Categorías
        //////    var catNeg = new CategoriaNegocio();
        //////    cboCategoria.DataSource = catNeg.Listar();
        //////    cboCategoria.DisplayMember = "Descripcion";
        //////    cboCategoria.ValueMember = "Id";
        //////}


        /// prueba
        /// 









        // botón ABM - hoy funciona solo para ALTA
        private void btnABM_Click(object sender, EventArgs e)
        {
            using (var frm = new frmArticuloAlta())
            {
                frm.ShowDialog();
                CargarGrid(); // Actualiza el grid después de cualquier operación 
            }
        }


        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para eliminar");
                return;
            }

            try
            {
                // Obtener el código de la fila seleccionada 
                int id = (int)dgvArticulos.CurrentRow.Cells["Id"].Value;
                string nombre = dgvArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
                string codigo = dgvArticulos.CurrentRow.Cells["Codigo"].Value.ToString();

                // CONFIRMACIÓN 
                DialogResult respuesta = MessageBox.Show(
                    $"¿Está seguro que desea eliminar el artículo?\n\n" +
                    $"Código: {codigo}\n" +
                    $"Nombre: {nombre}",
                    "Confirmar Eliminación",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning);

                if (respuesta == DialogResult.Yes)
                {
                    var negocio = new ArticuloNegocio();
                    negocio.Eliminar(id);

                    MessageBox.Show("Artículo eliminado correctamente");
                    CargarGrid(); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar: {ex.Message}");
            }
        }

        //la idea es dejar de usar esta forma de modificacion
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null)
            {
                MessageBox.Show("Seleccione un artículo para modificar");
                return;
            }

            try
            {
                // Obtener datos de la fila seleccionada 
                int id = (int)dgvArticulos.CurrentRow.Cells["Id"].Value;
                string nombre = dgvArticulos.CurrentRow.Cells["Nombre"].Value.ToString();
                string codigo = dgvArticulos.CurrentRow.Cells["Codigo"].Value.ToString();

                // Buscar el artículo completo por ID
                var negocio = new ArticuloNegocio();
                Articulo articulo = negocio.ObtenerPorId(id);

                if (articulo == null)
                {
                    MessageBox.Show("No se encontró el artículo seleccionado");
                    return;
                }

                // Abrir formulario de modificación PASANDO el artículo
                using (var frm = new frmArticuloModificacion(articulo))
                {
                    if (frm.ShowDialog() == DialogResult.OK)
                    {
                        MessageBox.Show("Artículo modificado correctamente");
                        CargarGrid(); // Refrescar el grid
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al modificar: {ex.Message}");
            }
        }

        //filtro
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            List<Articulo> listaFiltrada;
            listaFiltrada = articulostodos.FindAll(x =>
                x.Nombre.ToLower().Contains(txtFiltro.Text.ToLower()) ||
                x.Codigo.ToLower().Contains(txtFiltro.Text.ToLower()) ||
                (x.Marca != null && x.Marca.Descripcion.ToLower().Contains(txtFiltro.Text.ToLower())) ||
                (x.Categoria != null && x.Categoria.Descripcion.ToLower().Contains(txtFiltro.Text.ToLower())));
            dgvArticulos.DataSource = null;
            dgvArticulos.DataSource = listaFiltrada;
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }



        //aca hay un problema con el acceso a imagenes de otros articulos que no sean el primero, da error 403 forbidden. 
        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            Articulo seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            cargarImagen(seleccionado.ImagenUrl);
        }

        private void cargarImagen(string imagen)
        {
            try
            {
                pictureBox1.Load(imagen);
            }
            catch (Exception ex)
            {
                pictureBox1.Load("https://efectocolibri.com/wp-content/uploads/2021/01/placeholder.png");

            }
        }




        // boton modificar 2 - pruebas

        private void btnModificar2_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            using (var frm = new frmArticuloAlta(seleccionado))
            {
                 
                frm.ShowDialog();
                CargarGrid(); // Actualiza el grid después de cualquier operación 
            }
        }
    }
}











