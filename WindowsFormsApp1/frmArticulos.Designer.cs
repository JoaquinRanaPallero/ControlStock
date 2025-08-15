namespace WindowsFormsApp1
{
    partial class frmArticulos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvArticulos = new System.Windows.Forms.DataGridView();
            this.TextBox1 = new System.Windows.Forms.TextBox();
            this.btnBusqueda = new System.Windows.Forms.Button();
            this.cboMarca = new System.Windows.Forms.ComboBox();
            this.cboCategoria = new System.Windows.Forms.ComboBox();
            this.btnABM = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvArticulos
            // 
            this.dgvArticulos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvArticulos.Location = new System.Drawing.Point(58, 36);
            this.dgvArticulos.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvArticulos.Name = "dgvArticulos";
            this.dgvArticulos.RowHeadersWidth = 51;
            this.dgvArticulos.RowTemplate.Height = 24;
            this.dgvArticulos.Size = new System.Drawing.Size(700, 194);
            this.dgvArticulos.TabIndex = 0;
            // 
            // TextBox1
            // 
            this.TextBox1.Location = new System.Drawing.Point(360, 253);
            this.TextBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.TextBox1.Name = "TextBox1";
            this.TextBox1.Size = new System.Drawing.Size(177, 20);
            this.TextBox1.TabIndex = 6;
            // 
            // btnBusqueda
            // 
            this.btnBusqueda.Location = new System.Drawing.Point(541, 253);
            this.btnBusqueda.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnBusqueda.Name = "btnBusqueda";
            this.btnBusqueda.Size = new System.Drawing.Size(64, 19);
            this.btnBusqueda.TabIndex = 7;
            this.btnBusqueda.Text = "Busqueda";
            this.btnBusqueda.UseVisualStyleBackColor = true;
            // 
            // cboMarca
            // 
            this.cboMarca.FormattingEnabled = true;
            this.cboMarca.Location = new System.Drawing.Point(58, 253);
            this.cboMarca.Name = "cboMarca";
            this.cboMarca.Size = new System.Drawing.Size(121, 21);
            this.cboMarca.TabIndex = 8;
            // 
            // cboCategoria
            // 
            this.cboCategoria.FormattingEnabled = true;
            this.cboCategoria.Location = new System.Drawing.Point(200, 253);
            this.cboCategoria.Name = "cboCategoria";
            this.cboCategoria.Size = new System.Drawing.Size(121, 21);
            this.cboCategoria.TabIndex = 9;
            // 
            // btnABM
            // 
            this.btnABM.Location = new System.Drawing.Point(58, 305);
            this.btnABM.Name = "btnABM";
            this.btnABM.Size = new System.Drawing.Size(184, 23);
            this.btnABM.TabIndex = 10;
            this.btnABM.Text = "Alta / Baja / Modificación";
            this.btnABM.UseVisualStyleBackColor = true;
            this.btnABM.Click += new System.EventHandler(this.btnABM_Click);
            // 
            // frmArticulos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(863, 366);
            this.Controls.Add(this.btnABM);
            this.Controls.Add(this.cboCategoria);
            this.Controls.Add(this.cboMarca);
            this.Controls.Add(this.btnBusqueda);
            this.Controls.Add(this.TextBox1);
            this.Controls.Add(this.dgvArticulos);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "frmArticulos";
            this.Text = "Control de stock";
            this.Load += new System.EventHandler(this.frmArticulos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvArticulos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvArticulos;
        private System.Windows.Forms.TextBox TextBox1;
        private System.Windows.Forms.Button btnBusqueda;
        private System.Windows.Forms.ComboBox cboMarca;
        private System.Windows.Forms.ComboBox cboCategoria;
        private System.Windows.Forms.Button btnABM;
    }
}

