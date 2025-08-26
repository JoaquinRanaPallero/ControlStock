using ControlStock.Dominio;
using ControlStock.Negocio;
using System;
using System.Globalization;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmArticuloAlta : Form
    {
        private Articulo articulo = null;
        public frmArticuloAlta()
        {
            InitializeComponent();
                        
        }

        public frmArticuloAlta(Articulo articulo)
        {
            InitializeComponent();
            this.articulo = articulo;
            Text = "Modificar Artículo";
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
            
            // Categoría
            cmbCategoria.DataSource = null;
            cmbCategoria.DisplayMember = nameof(Categoria.Descripcion);
            cmbCategoria.ValueMember = nameof(Categoria.Id);
            cmbCategoria.DataSource = categorias;
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
                { MessageBox.Show("El Código es obligatorio."); txbCodigo.Focus(); return; }

                if (string.IsNullOrWhiteSpace(nombre))
                { MessageBox.Show("El Nombre es obligatorio."); txbNombre.Focus(); return; }

                if (!(cmbMarca.SelectedItem is Marca marca))
                { MessageBox.Show("Seleccioná una Marca."); cmbMarca.DroppedDown = true; return; }

                if (!(cmbCategoria.SelectedItem is Categoria categoria))
                { MessageBox.Show("Seleccioná una Categoría."); cmbCategoria.DroppedDown = true; return; }

                if (!decimal.TryParse(precioTexto, NumberStyles.Number, new CultureInfo("es-AR"), out decimal precio) &&
                    !decimal.TryParse(precioTexto, NumberStyles.Number, CultureInfo.InvariantCulture, out precio))
                { MessageBox.Show("Precio inválido. Usá un número válido (ej: 12345,67)."); txbPrecio.Focus(); return; }

                if (precio <= 0)
                { MessageBox.Show("El Precio debe ser mayor que 0."); txbPrecio.Focus(); return; }

                //  Alta o Modificación 
                var negocio = new ArticuloNegocio();

                if (articulo == null)
                {
                    // Alta
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

                    negocio.Agregar(nuevoArticulo);
                    MessageBox.Show("Artículo agregado con éxito!");
                }
                else
                {
                    // Modificación (usar el mismo objeto existente)
                    articulo.Codigo = codigo;
                    articulo.Nombre = nombre;
                    articulo.Descripcion = descripcion;
                    articulo.Marca = marca;
                    articulo.Categoria = categoria;
                    articulo.ImagenUrl = txtImagenUrl.Text?.Trim();
                    articulo.Precio = precio;

                    negocio.Modificar(articulo);  
                    MessageBox.Show("Artículo modificado con éxito!");
                }

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

                //  Precarga de datos para modificar
                if (articulo != null)
                {
                    txbCodigo.Text = articulo.Codigo;
                    txbNombre.Text = articulo.Nombre;
                    txbDescripcion.Text = articulo.Descripcion;
                    txbPrecio.Text = articulo.Precio.ToString("F2");
                    txtImagenUrl.Text = articulo.ImagenUrl;
                    CargarImagen(articulo.ImagenUrl);


                    
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

        private void CargarImagen(string url)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(url))
                {
                    pbxImagenUrl.Image = null; // poner imagen por defecto?
                    return;
                }

                pbxImagenUrl.Visible = true;
                pbxImagenUrl.BorderStyle = BorderStyle.FixedSingle;
                pbxImagenUrl.SizeMode = PictureBoxSizeMode.Zoom;

                pbxImagenUrl.Load(url); 
            }
            catch
            {
                pbxImagenUrl.Image = null; 
            }
        }

        private void txtImagenUrl_TextChanged_1(object sender, EventArgs e)
        {
            // Llama al método que para cargar la imagen pasándole el texto actual del TextBox.
            CargarImagen(txtImagenUrl.Text);
        }
    }
}

