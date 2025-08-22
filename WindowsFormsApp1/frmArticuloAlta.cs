using ControlStock.Dominio;
using ControlStock.Negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmArticuloAlta : Form
    {
        private Articulo articulo = null;
        public frmArticuloAlta()
        {
            InitializeComponent();
            
            // this.articulo = articulo; // esto hace que el código no precargue?
        }

        public frmArticuloAlta(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
        }

        private void CargarCombos()
        {
            var marcaNeg = new MarcaNegocio();
            var categoriaNeg = new CategoriaNegocio();

            var marcas = marcaNeg.Listar();
            var categorias = categoriaNeg.Listar();

            // Marca
            cmbMarca.DataSource = null;
            cmbMarca.DisplayMember = nameof(Marca.Descripcion);
            cmbMarca.ValueMember = nameof(Marca.Id);
            cmbMarca.DataSource = marcas;
            cmbMarca.SelectedIndex = -1;

            // Categoría
            cmbCategoria.DataSource = null;
            cmbCategoria.DisplayMember = nameof(Categoria.Descripcion);
            cmbCategoria.ValueMember = nameof(Categoria.Id);
            cmbCategoria.DataSource = categorias;
            cmbCategoria.SelectedIndex = -1;
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                // --- Validaciones de campos obligatorios ---
                string codigo = txbCodigo.Text?.Trim();
                string nombre = txbNombre.Text?.Trim();
                string descripcion = txbDescripcion.Text?.Trim();
                string precioTexto = txbPrecio.Text?.Trim();

                if (string.IsNullOrWhiteSpace(codigo))
                {
                    MessageBox.Show("El Código es obligatorio.");
                    txbCodigo.Focus();
                    return;
                }

                if (string.IsNullOrWhiteSpace(nombre))
                {
                    MessageBox.Show("El Nombre es obligatorio.");
                    txbNombre.Focus();
                    return;
                }

                // Validar selección de Marca
                if (!(cmbMarca.SelectedItem is Marca marca))
                {
                    MessageBox.Show("Seleccioná una Marca.");
                    cmbMarca.DroppedDown = true;
                    return;
                }

                // Validar selección de Categoría
                if (!(cmbCategoria.SelectedItem is Categoria categoria))
                {
                    MessageBox.Show("Seleccioná una Categoría.");
                    cmbCategoria.DroppedDown = true;
                    return;
                }

                // --- Precio ---
                decimal precio;
                if (!decimal.TryParse(precioTexto, NumberStyles.Number, new CultureInfo("es-AR"), out precio) &&
                    !decimal.TryParse(precioTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out precio))
                {
                    MessageBox.Show("Precio inválido. Usá un número válido (ej: 12345,67).");
                    txbPrecio.Focus();
                    return;
                }

                if (precio <= 0)
                {
                    MessageBox.Show("El Precio debe ser mayor que 0.");
                    txbPrecio.Focus();
                    return;
                }

                
                var nuevoArticulo = new Articulo
                {
                    Codigo = codigo,
                    Nombre = nombre,
                    Descripcion = descripcion,
                    Marca = marca,
                    Categoria = categoria,
                    ImagenUrl = txtImagenUrl.Text?.Trim(),
                    Precio = precio
                };

             
                var negocio = new ArticuloNegocio();
                negocio.Agregar(nuevoArticulo);

                MessageBox.Show("Artículo guardado con éxito!");
                this.DialogResult = DialogResult.OK; 
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo guardar el artículo.\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmArticuloAlta_Load(object sender, EventArgs e)
        {
            try
            {

                CargarCombos();



                // --- Precargar de datos para modificar
                if (articulo != null)
                {
                    txbCodigo.Text = articulo.Codigo;
                    txbNombre.Text = articulo.Nombre;
                    txbDescripcion.Text = articulo.Descripcion;
                    txbPrecio.Text = articulo.Precio.ToString("F2");

                    // Recién ahora es seguro usar SelectedValue
                    if (articulo.Marca != null)
                        cmbMarca.SelectedValue = articulo.Marca.Id;

                    if (articulo.Categoria != null)
                        cmbCategoria.SelectedValue = articulo.Categoria.Id;
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los combos.\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

