namespace WindowsFormsApp1
{
    partial class frmArticuloAlta
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txbNombre = new System.Windows.Forms.TextBox();
            this.txbCodigo = new System.Windows.Forms.TextBox();
            this.txbDescripcion = new System.Windows.Forms.TextBox();
            this.txbPrecio = new System.Windows.Forms.TextBox();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.cmbMarca = new System.Windows.Forms.ComboBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Agregar artículo";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(72, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Código";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Nombre";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(72, 131);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Descripcion";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(72, 163);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(46, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Precio";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(72, 199);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Marca";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(74, 241);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(66, 16);
            this.label7.TabIndex = 6;
            this.label7.Text = "Categoría";
            // 
            // txbNombre
            // 
            this.txbNombre.Location = new System.Drawing.Point(182, 60);
            this.txbNombre.Name = "txbNombre";
            this.txbNombre.Size = new System.Drawing.Size(100, 22);
            this.txbNombre.TabIndex = 7;
            // 
            // txbCodigo
            // 
            this.txbCodigo.Location = new System.Drawing.Point(182, 97);
            this.txbCodigo.Name = "txbCodigo";
            this.txbCodigo.Size = new System.Drawing.Size(100, 22);
            this.txbCodigo.TabIndex = 8;
            // 
            // txbDescripcion
            // 
            this.txbDescripcion.Location = new System.Drawing.Point(182, 131);
            this.txbDescripcion.Name = "txbDescripcion";
            this.txbDescripcion.Size = new System.Drawing.Size(100, 22);
            this.txbDescripcion.TabIndex = 9;
            // 
            // txbPrecio
            // 
            this.txbPrecio.Location = new System.Drawing.Point(182, 163);
            this.txbPrecio.Name = "txbPrecio";
            this.txbPrecio.Size = new System.Drawing.Size(100, 22);
            this.txbPrecio.TabIndex = 10;
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(182, 238);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(121, 24);
            this.cmbCategoria.TabIndex = 11;
            // 
            // cmbMarca
            // 
            this.cmbMarca.FormattingEnabled = true;
            this.cmbMarca.Location = new System.Drawing.Point(182, 199);
            this.cmbMarca.Name = "cmbMarca";
            this.cmbMarca.Size = new System.Drawing.Size(121, 24);
            this.cmbMarca.TabIndex = 12;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(428, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(299, 202);
            this.pictureBox1.TabIndex = 13;
            this.pictureBox1.TabStop = false;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Location = new System.Drawing.Point(143, 307);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 14;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // frmArticuloAlta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
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
            this.Name = "frmArticuloAlta";
            this.Text = "frmArticuloAlta";
            this.Load += new System.EventHandler(this.frmArticuloAlta_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txbNombre;
        private System.Windows.Forms.TextBox txbCodigo;
        private System.Windows.Forms.TextBox txbDescripcion;
        private System.Windows.Forms.TextBox txbPrecio;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.ComboBox cmbMarca;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button btnGuardar;
    }
}