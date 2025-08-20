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
        public frmArticuloAlta()
        {
            InitializeComponent();
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
                    // ImagenUrl = txtImagenUrl.Text?.Trim(),
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
                var marcaNeg = new MarcaNegocio();
                var categoriaNeg = new CategoriaNegocio();

                // --- Combo Marca ---
                cmbMarca.DataSource = marcaNeg.Listar();
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "Id";            
                cmbMarca.SelectedIndex = -1;            // para que arranque vacío

                // --- Combo Categoría ---
                cmbCategoria.DataSource = categoriaNeg.Listar();
                cmbCategoria.DisplayMember = "Descripcion";
                cmbCategoria.ValueMember = "Id";
                cmbCategoria.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los combos.\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}

