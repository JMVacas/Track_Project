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
            ((System.ComponentModel.ISupportInitialize)(this.Mapa)).BeginInit();
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
            this.Mapa.Location = new System.Drawing.Point(12, 12);
            this.Mapa.Name = "Mapa";
            this.Mapa.Size = new System.Drawing.Size(1105, 571);
            this.Mapa.TabIndex = 0;
            this.Mapa.TabStop = false;
            this.Mapa.Paint += new System.Windows.Forms.PaintEventHandler(this.Mapa_Paint);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1254, 586);
            this.Controls.Add(this.Importar);
            this.Controls.Add(this.Mapa);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.Mapa)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox Mapa;
        private System.Windows.Forms.Button Importar;
    }
}