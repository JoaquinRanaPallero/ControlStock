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
        public frmArticulos()
        {
            InitializeComponent();
        }

        private void frmArticulos_Load(object sender, EventArgs e)
        {
            CargarGrid();
            CargarCombos();
        }

        private void CargarGrid()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            dgvArticulos.DataSource = negocio.Listar();

            // Ocular columnas
            dgvArticulos.Columns["Id"].Visible = false;
            dgvArticulos.Columns["ImagenUrl"].Visible = false;
        }


        private void CargarCombos()
        {
            // Cargar Marcas
            var marcaNeg = new MarcaNegocio();
            cboMarca.DataSource = marcaNeg.Listar();
            cboMarca.DisplayMember = "Descripcion"; 
            cboMarca.ValueMember = "Id";            

            // Cargar Categorías
            var catNeg = new CategoriaNegocio();
            cboCategoria.DataSource = catNeg.Listar();
            cboCategoria.DisplayMember = "Descripcion";
            cboCategoria.ValueMember = "Id";
        }




    }




}

