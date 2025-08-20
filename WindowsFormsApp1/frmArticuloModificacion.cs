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
    public partial class frmArticuloModificacion : Form
    {
        private Articulo articuloModificar;

        public frmArticuloModificacion(Articulo articulo)
        {
            InitializeComponent();
            articuloModificar = articulo;
            this.Load += frmArticuloModificacion_Load;

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                //  Validaciones  
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

                //  Precio 
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

                //  Actualizar el artículo existente 
                articuloModificar.Codigo = codigo;
                articuloModificar.Nombre = nombre;
                articuloModificar.Descripcion = descripcion;
                articuloModificar.Marca = marca;
                articuloModificar.Categoria = categoria;
                articuloModificar.Precio = precio;
                // articuloModificar.ImagenUrl = txtImagenUrl.Text?.Trim();

                var negocio = new ArticuloNegocio();
                negocio.Modificar(articuloModificar);

                MessageBox.Show("Artículo modificado con éxito!");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudo modificar el artículo.\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void frmArticuloModificacion_Load(object sender, EventArgs e)
        {
            try
            {
                // PRIMERO: Cargar los datos en los TextBox
                if (articuloModificar != null)
                {
                    txbCodigo.Text = articuloModificar.Codigo;
                    txbNombre.Text = articuloModificar.Nombre;
                    txbDescripcion.Text = articuloModificar.Descripcion;
                    txbPrecio.Text = articuloModificar.Precio.ToString("F2", CultureInfo.InvariantCulture);
                }

                // SEGUNDO: Cargar los combos
                var marcaNeg = new MarcaNegocio();
                var categoriaNeg = new CategoriaNegocio();

                cmbMarca.DataSource = marcaNeg.Listar();
                cmbMarca.DisplayMember = "Descripcion";
                cmbMarca.ValueMember = "Id";

                cmbCategoria.DataSource = categoriaNeg.Listar();
                cmbCategoria.DisplayMember = "Descripcion";
                cmbCategoria.ValueMember = "Id";

                // TERCERO: Seleccionar los items en los combos
                if (articuloModificar != null)
                {
                    SeleccionarItemCombo(cmbMarca, articuloModificar.Marca?.Id);
                    SeleccionarItemCombo(cmbCategoria, articuloModificar.Categoria?.Id);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"No se pudieron cargar los datos.\nDetalle: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método auxiliar para seleccionar items en los combos
        private void SeleccionarItemCombo(ComboBox combo, int? id)
        {
            if (id.HasValue)
            {
                foreach (var item in combo.Items)
                {
                    var objetoConId = item as dynamic;
                    if (objetoConId != null && objetoConId.Id == id.Value)
                    {
                        combo.SelectedItem = item;
                        return;
                    }
                }
            }
            combo.SelectedIndex = -1;
        }

        // Botón Cancelar 
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
