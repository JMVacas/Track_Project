namespace Track_Project
{
    partial class Form3
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
            this.Importar = new System.Windows.Forms.Button();
            this.Mapa = new System.Windows.Forms.PictureBox();
            this.Giro_Mapa_90 = new System.Windows.Forms.Button();
            this.Giro_Mapa_180 = new System.Windows.Forms.Button();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.Actualizar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.Mapa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            this.SuspendLayout();
            // 
            // Importar
            // 
            this.Importar.Location = new System.Drawing.Point(1123, 30);
            this.Importar.Name = "Importar";
            this.Importar.Size = new System.Drawing.Size(75, 23);
            this.Importar.TabIndex = 1;
            this.Importar.Text = "Importar";
            this.Importar.UseVisualStyleBackColor = true;
            this.Importar.Click += new System.EventHandler(this.Importar_Click);
            // 
            // Mapa
            // 
            this.Mapa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Mapa.Location = new System.Drawing.Point(12, 12);
            this.Mapa.Name = "Mapa";
            this.Mapa.Size = new System.Drawing.Size(1105, 571);
            this.Mapa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Mapa.TabIndex = 0;
            this.Mapa.TabStop = false;
            this.Mapa.Paint += new System.Windows.Forms.PaintEventHandler(this.Mapa_Paint);
            // 
            // Giro_Mapa_90
            // 
            this.Giro_Mapa_90.Location = new System.Drawing.Point(1123, 59);
            this.Giro_Mapa_90.Name = "Giro_Mapa_90";
            this.Giro_Mapa_90.Size = new System.Drawing.Size(75, 23);
            this.Giro_Mapa_90.TabIndex = 2;
            this.Giro_Mapa_90.Text = "Girar 90";
            this.Giro_Mapa_90.UseVisualStyleBackColor = true;
            this.Giro_Mapa_90.Click += new System.EventHandler(this.Giro_Mapa_90_Click);
            // 
            // Giro_Mapa_180
            // 
            this.Giro_Mapa_180.Location = new System.Drawing.Point(1123, 88);
            this.Giro_Mapa_180.Name = "Giro_Mapa_180";
            this.Giro_Mapa_180.Size = new System.Drawing.Size(75, 23);
            this.Giro_Mapa_180.TabIndex = 3;
            this.Giro_Mapa_180.Text = "Girar 180";
            this.Giro_Mapa_180.UseVisualStyleBackColor = true;
            this.Giro_Mapa_180.Click += new System.EventHandler(this.Giro_Mapa_180_Click);
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(1124, 134);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(120, 20);
            this.numericUpDown1.TabIndex = 4;
            this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // Actualizar
            // 
            this.Actualizar.Location = new System.Drawing.Point(1123, 173);
            this.Actualizar.Name = "Actualizar";
            this.Actualizar.Size = new System.Drawing.Size(75, 23);
            this.Actualizar.TabIndex = 5;
            this.Actualizar.Text = "Actualizar";
            this.Actualizar.UseVisualStyleBackColor = true;
            this.Actualizar.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 586);
            this.Controls.Add(this.Actualizar);
            this.Controls.Add(this.numericUpDown1);
            this.Controls.Add(this.Giro_Mapa_180);
            this.Controls.Add(this.Giro_Mapa_90);
            this.Controls.Add(this.Importar);
            this.Controls.Add(this.Mapa);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.Mapa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Mapa;
        private System.Windows.Forms.Button Importar;
        private System.Windows.Forms.Button Giro_Mapa_90;
        private System.Windows.Forms.Button Giro_Mapa_180;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.Button Actualizar;
    }
}