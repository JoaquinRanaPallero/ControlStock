using ControlStock.Dominio;
using ControlStock.Negocio;
using System;
using System.Collections.Generic;
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
            cboCampo.Items.Add("Precio");
            cboCampo.Items.Add("Nombre");
            cboCampo.Items.Add("Descripción");
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
            dgvArticulos.Columns["Precio"].DefaultCellStyle.Format = "N2";

        }

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

        private void btnModificar_Click(object sender, EventArgs e)
        {
            Articulo seleccionado;
            seleccionado = (Articulo)dgvArticulos.CurrentRow.DataBoundItem;
            using (var frm = new frmArticuloAlta(seleccionado))
            {

                frm.ShowDialog();
                CargarGrid(); // Actualiza el grid después de cualquier operación 
            }



        }

        
        private void btnBusqueda_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                // VERIFICAR SI HAY ITEM SELECCIONADO
                if (cboCampo.SelectedItem == null || cboCriterio.SelectedItem == null)
                {
                    MessageBox.Show("Por favor, selecciona ambos campos para filtrar");
                    return;
                }

                // VERIFICAR SI EL FILTRO ESTÁ VACÍO
                if (string.IsNullOrWhiteSpace(txtFiltroAvanzado.Text))
                {
                    MessageBox.Show("Por favor, ingresa un valor para filtrar");
                    return;
                }


                string campo = cboCampo.SelectedItem.ToString();
                string criterio = cboCriterio.SelectedItem.ToString();
                string filtro = txtFiltroAvanzado.Text;
                dgvArticulos.DataSource = negocio.filtrar(campo, criterio, filtro);

            }
            catch (Exception ex) 
            {
                MessageBox.Show($"Error en el filtro: {ex.Message}");
            }
            
            
        } 

        private void btnLimpiarFiltros_Click(object sender, EventArgs e)
        {
            CargarGrid();
        }

        private void dgvArticulos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvArticulos.CurrentRow == null || dgvArticulos.CurrentRow.DataBoundItem == null)
                return;
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


        private void txtFiltro_KeyPress(object sender, KeyPressEventArgs e)
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

        private void cboCampo_SelectedIndexChanged(object sender, EventArgs e)
        {
            string opcion = cboCampo.SelectedItem.ToString();
            if (opcion == "Precio")
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Mayor a");
                cboCriterio.Items.Add("Menor a");
                cboCriterio.Items.Add("Igual a");
            }
            else
            {
                cboCriterio.Items.Clear();
                cboCriterio.Items.Add("Comienza con");
                cboCriterio.Items.Add("Termina con");
                cboCriterio.Items.Add("Contiene");
            }
        }
    }
}









































