namespace WindowsFormsApp1
{
    partial class frmArticuloModificacion
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
            this.btnGuardar = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.txbCodigo = new System.Windows.Forms.TextBox();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCancelar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(230, 333);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(61, 19);
            this.btnGuardar.TabIndex = 29;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(444, 133);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(224, 164);
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(259, 246);
            this.cmbMarca.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(92, 21);
            this.cmbMarca.TabIndex = 27;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(259, 277);
            this.cmbCategoria.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(92, 21);
            this.cmbCategoria.TabIndex = 26;
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(259, 216);
            this.txbPrecio.Margin = new System.Windows.Forms.Padding(2);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(76, 20);
            this.txbPrecio.TabIndex = 25;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(259, 190);
            this.txbDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(76, 20);
            this.txbDescripcion.TabIndex = 24;
            // 
            // txbCodigo
            // 
            this.txbCodigo.Location = new System.Drawing.Point(259, 163);
            this.txbCodigo.Margin = new System.Windows.Forms.Padding(2);
            this.txbCodigo.Name = "txbCodigo";
            this.txbCodigo.Size = new System.Drawing.Size(76, 20);
            this.txbCodigo.TabIndex = 23;
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(259, 133);
            this.txbNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(76, 20);
            this.txbNombre.TabIndex = 22;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(179, 280);
            this.label7.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Categoría";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(177, 246);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Marca";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(177, 216);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Precio";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(177, 190);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Descripcion";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(177, 133);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Nombre";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(177, 165);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Código";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(132, 99);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = " Modificar artículo";
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(341, 333);
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(63, 19);
            this.btnCancelar.TabIndex = 30;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            // 
            // frmArticuloModificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.cmbMarca);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.txbPrecio);
            this.Controls.Add(this.txbDescripcion);
            this.Controls.Add(this.txbCodigo);
            this.Controls.Add(this.txbNombre);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "frmArticuloModificacion";
            this.Text = "frmArticuloModificacion";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.TextBox txbCodigo;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCancelar;
    }
}