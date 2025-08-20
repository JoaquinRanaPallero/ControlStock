namespace WindowsFormsApp1
{
    partial class frmArticuloABM
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
            this.btnAlta = new System.Windows.Forms.Button();
            this.btnBaja = new System.Windows.Forms.Button();
            this.btnModificacion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Seleccione una operación";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnAlta
            // 
            this.btnAlta.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlta.Location = new System.Drawing.Point(145, 85);
            this.btnAlta.Name = "btnAlta";
            this.btnAlta.Size = new System.Drawing.Size(97, 23);
            this.btnAlta.TabIndex = 1;
            this.btnAlta.Text = "Alta";
            this.btnAlta.UseVisualStyleBackColor = true;
            this.btnAlta.Click += new System.EventHandler(this.btnAlta_Click);
            // 
            // btnBaja
            // 
            this.btnBaja.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaja.Location = new System.Drawing.Point(145, 114);
            this.btnBaja.Name = "btnBaja";
            this.btnBaja.Size = new System.Drawing.Size(97, 23);
            this.btnBaja.TabIndex = 2;
            this.btnBaja.Text = "Baja";
            this.btnBaja.UseVisualStyleBackColor = true;
            // 
            // btnModificacion
            // 
            this.btnModificacion.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificacion.Location = new System.Drawing.Point(145, 143);
            this.btnModificacion.Name = "btnModificacion";
            this.btnModificacion.Size = new System.Drawing.Size(97, 23);
            this.btnModificacion.TabIndex = 3;
            this.btnModificacion.Text = "Modificación";
            this.btnModificacion.UseVisualStyleBackColor = true;
            // 
            // frmArticuloABM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 230);
            this.Controls.Add(this.btnModificacion);
            this.Controls.Add(this.btnBaja);
            this.Controls.Add(this.btnAlta);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "frmArticuloABM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccione opción";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnAlta;
        private System.Windows.Forms.Button btnBaja;
        private System.Windows.Forms.Button btnModificacion;
    }
}