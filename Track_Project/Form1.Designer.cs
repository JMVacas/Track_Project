using System.Drawing;

namespace Track_Project
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private  void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Posicion_Cursor = new System.Windows.Forms.LinkLabel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.Paleta = new System.Windows.Forms.PictureBox();
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Archivo_Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarMapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cargarTrayectoriaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Exportar_Trayectoria_Menu1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportarMapaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.codesysToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewAllTracsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteTrackToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.Mouse_Button = new System.Windows.Forms.ToolStripButton();
            this.ChangeThickness_Button = new System.Windows.Forms.ToolStripButton();
            this.Color_Select = new System.Windows.Forms.ToolStripButton();
            this.Select_Origin_Button = new System.Windows.Forms.ToolStripButton();
            this.ChangeOrigin_ToolStrip = new System.Windows.Forms.ToolStripButton();
            this.Mathematical_Edition = new System.Windows.Forms.ToolStripButton();
            this.Line_Button = new System.Windows.Forms.ToolStripButton();
            this.Curve_Button = new System.Windows.Forms.ToolStripButton();
            this.Borrar_Todo_Strip = new System.Windows.Forms.ToolStripButton();
            this.Delete_Last = new System.Windows.Forms.ToolStripButton();
            this.Add_Track = new System.Windows.Forms.ToolStripButton();
            this.Save_Changes = new System.Windows.Forms.ToolStripButton();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.Track_Edit_Select = new System.Windows.Forms.ComboBox();
            this.Track_Caption = new System.Windows.Forms.PictureBox();
            this.DTA = new System.Windows.Forms.PictureBox();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paleta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_Caption)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTA)).BeginInit();
            this.SuspendLayout();
            // 
            // Posicion_Cursor
            // 
            this.Posicion_Cursor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Posicion_Cursor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
            this.Posicion_Cursor.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Posicion_Cursor.Font = new System.Drawing.Font("Adobe Fangsong Std R", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.Posicion_Cursor.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.Posicion_Cursor.LinkColor = System.Drawing.Color.Red;
            this.Posicion_Cursor.Location = new System.Drawing.Point(263, 468);
            this.Posicion_Cursor.Name = "Posicion_Cursor";
            this.Posicion_Cursor.Size = new System.Drawing.Size(311, 47);
            this.Posicion_Cursor.TabIndex = 19;
            this.Posicion_Cursor.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.AutoScroll = true;
            this.panel3.Controls.Add(this.Paleta);
            this.panel3.Location = new System.Drawing.Point(27, 27);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(770, 427);
            this.panel3.TabIndex = 21;
            // 
            // Paleta
            // 
            this.Paleta.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Paleta.BackColor = System.Drawing.SystemColors.Control;
            this.Paleta.ImageLocation = "";
            this.Paleta.Location = new System.Drawing.Point(3, 0);
            this.Paleta.Name = "Paleta";
            this.Paleta.Size = new System.Drawing.Size(770, 416);
            this.Paleta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Paleta.TabIndex = 18;
            this.Paleta.TabStop = false;
            this.Paleta.Click += new System.EventHandler(this.Paleta_Click);
            this.Paleta.Paint += new System.Windows.Forms.PaintEventHandler(this.Paleta_Paint);
            this.Paleta.MouseLeave += new System.EventHandler(this.Paleta_MouseLeave);
            this.Paleta.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Paleta_MouseMove);
            this.Paleta.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Paleta_MouseUp);
            // 
            // trackBar1
            // 
            this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar1.AutoSize = false;
            this.trackBar1.LargeChange = 2;
            this.trackBar1.Location = new System.Drawing.Point(658, 478);
            this.trackBar1.Maximum = 12;
            this.trackBar1.Minimum = 2;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.RightToLeftLayout = true;
            this.trackBar1.Size = new System.Drawing.Size(149, 45);
            this.trackBar1.SmallChange = 2;
            this.trackBar1.TabIndex = 22;
            this.trackBar1.Value = 2;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // menuStrip1
            // 
            this.menuStrip1.AutoSize = false;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Archivo_Menu,
            this.optionsToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1000, 24);
            this.menuStrip1.TabIndex = 24;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Archivo_Menu
            // 
            this.Archivo_Menu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cargarMapaToolStripMenuItem,
            this.cargarTrayectoriaToolStripMenuItem,
            this.Exportar_Trayectoria_Menu1,
            this.exportarMapaToolStripMenuItem,
            this.codesysToolStripMenuItem});
            this.Archivo_Menu.Name = "Archivo_Menu";
            this.Archivo_Menu.Size = new System.Drawing.Size(60, 20);
            this.Archivo_Menu.Text = "Archivo";
            // 
            // cargarMapaToolStripMenuItem
            // 
            this.cargarMapaToolStripMenuItem.Name = "cargarMapaToolStripMenuItem";
            this.cargarMapaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cargarMapaToolStripMenuItem.Text = "Cargar Mapa";
            this.cargarMapaToolStripMenuItem.Click += new System.EventHandler(this.cargarMapaToolStripMenuItem_Click);
            // 
            // cargarTrayectoriaToolStripMenuItem
            // 
            this.cargarTrayectoriaToolStripMenuItem.Name = "cargarTrayectoriaToolStripMenuItem";
            this.cargarTrayectoriaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cargarTrayectoriaToolStripMenuItem.Text = "Cargar Trayectoria";
            this.cargarTrayectoriaToolStripMenuItem.Click += new System.EventHandler(this.cargarTrayectoriaToolStripMenuItem_Click);
            // 
            // Exportar_Trayectoria_Menu1
            // 
            this.Exportar_Trayectoria_Menu1.Name = "Exportar_Trayectoria_Menu1";
            this.Exportar_Trayectoria_Menu1.Size = new System.Drawing.Size(185, 22);
            this.Exportar_Trayectoria_Menu1.Text = "Exportar Trayectoria";
            this.Exportar_Trayectoria_Menu1.Click += new System.EventHandler(this.Exportar_Trayectoria_Menu1_Click);
            // 
            // exportarMapaToolStripMenuItem
            // 
            this.exportarMapaToolStripMenuItem.Name = "exportarMapaToolStripMenuItem";
            this.exportarMapaToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.exportarMapaToolStripMenuItem.Text = "Exportar Mapa";
            this.exportarMapaToolStripMenuItem.Click += new System.EventHandler(this.exportarMapaToolStripMenuItem_Click);
            // 
            // codesysToolStripMenuItem
            // 
            this.codesysToolStripMenuItem.Name = "codesysToolStripMenuItem";
            this.codesysToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.codesysToolStripMenuItem.Text = "Export Codesys Code";
            this.codesysToolStripMenuItem.Click += new System.EventHandler(this.codesysToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.viewAllTracsToolStripMenuItem,
            this.deleteTrackToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // viewAllTracsToolStripMenuItem
            // 
            this.viewAllTracsToolStripMenuItem.AutoToolTip = true;
            this.viewAllTracsToolStripMenuItem.CheckOnClick = true;
            this.viewAllTracsToolStripMenuItem.Name = "viewAllTracsToolStripMenuItem";
            this.viewAllTracsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.viewAllTracsToolStripMenuItem.Text = "View All Tracks";
            this.viewAllTracsToolStripMenuItem.ToolTipText = "Check for viewing all track simultanisusly";
            // 
            // deleteTrackToolStripMenuItem
            // 
            this.deleteTrackToolStripMenuItem.Name = "deleteTrackToolStripMenuItem";
            this.deleteTrackToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.deleteTrackToolStripMenuItem.Text = "Delete track";
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Right;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Mouse_Button,
            this.ChangeThickness_Button,
            this.Color_Select,
            this.Select_Origin_Button,
            this.ChangeOrigin_ToolStrip,
            this.Mathematical_Edition,
            this.Line_Button,
            this.Curve_Button,
            this.Borrar_Todo_Strip,
            this.Delete_Last,
            this.Add_Track,
            this.Save_Changes});
            this.toolStrip1.Location = new System.Drawing.Point(976, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.toolStrip1.Size = new System.Drawing.Size(24, 511);
            this.toolStrip1.TabIndex = 25;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // Mouse_Button
            // 
            this.Mouse_Button.CheckOnClick = true;
            this.Mouse_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Mouse_Button.Image = ((System.Drawing.Image)(resources.GetObject("Mouse_Button.Image")));
            this.Mouse_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Mouse_Button.Name = "Mouse_Button";
            this.Mouse_Button.Size = new System.Drawing.Size(21, 20);
            this.Mouse_Button.Text = "Mouse tool, click here for add a line";
            this.Mouse_Button.Click += new System.EventHandler(this.Mouse_Button_Click);
            // 
            // ChangeThickness_Button
            // 
            this.ChangeThickness_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChangeThickness_Button.Image = ((System.Drawing.Image)(resources.GetObject("ChangeThickness_Button.Image")));
            this.ChangeThickness_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChangeThickness_Button.Name = "ChangeThickness_Button";
            this.ChangeThickness_Button.Size = new System.Drawing.Size(21, 20);
            this.ChangeThickness_Button.Text = "toolStripButton1";
            this.ChangeThickness_Button.ToolTipText = "Change the thickness of the components";
            this.ChangeThickness_Button.Click += new System.EventHandler(this.ChangeThickness_Button_Click);
            // 
            // Color_Select
            // 
            this.Color_Select.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Color_Select.Image = ((System.Drawing.Image)(resources.GetObject("Color_Select.Image")));
            this.Color_Select.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Color_Select.Name = "Color_Select";
            this.Color_Select.Size = new System.Drawing.Size(21, 20);
            this.Color_Select.Text = "toolStripButton1";
            this.Color_Select.ToolTipText = "Select the color of the lines";
            this.Color_Select.Click += new System.EventHandler(this.Color_Select_Click);
            // 
            // Select_Origin_Button
            // 
            this.Select_Origin_Button.CheckOnClick = true;
            this.Select_Origin_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Select_Origin_Button.Image = ((System.Drawing.Image)(resources.GetObject("Select_Origin_Button.Image")));
            this.Select_Origin_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Select_Origin_Button.Name = "Select_Origin_Button";
            this.Select_Origin_Button.Size = new System.Drawing.Size(21, 20);
            this.Select_Origin_Button.Text = "Modify the origin of the coordenates";
            this.Select_Origin_Button.Click += new System.EventHandler(this.Select_Origin_Button_Click);
            // 
            // ChangeOrigin_ToolStrip
            // 
            this.ChangeOrigin_ToolStrip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ChangeOrigin_ToolStrip.Image = ((System.Drawing.Image)(resources.GetObject("ChangeOrigin_ToolStrip.Image")));
            this.ChangeOrigin_ToolStrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ChangeOrigin_ToolStrip.Name = "ChangeOrigin_ToolStrip";
            this.ChangeOrigin_ToolStrip.Size = new System.Drawing.Size(21, 20);
            this.ChangeOrigin_ToolStrip.ToolTipText = "Changes numerically the position of the origin";
            this.ChangeOrigin_ToolStrip.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Mathematical_Edition
            // 
            this.Mathematical_Edition.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Mathematical_Edition.Image = ((System.Drawing.Image)(resources.GetObject("Mathematical_Edition.Image")));
            this.Mathematical_Edition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Mathematical_Edition.Name = "Mathematical_Edition";
            this.Mathematical_Edition.Size = new System.Drawing.Size(21, 20);
            this.Mathematical_Edition.Text = "toolStripButton3";
            this.Mathematical_Edition.ToolTipText = "Edit mathematically ol the drawings";
            this.Mathematical_Edition.Click += new System.EventHandler(this.Mathematical_Edition_Click);
            // 
            // Line_Button
            // 
            this.Line_Button.CheckOnClick = true;
            this.Line_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Line_Button.Image = ((System.Drawing.Image)(resources.GetObject("Line_Button.Image")));
            this.Line_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Line_Button.Name = "Line_Button";
            this.Line_Button.Size = new System.Drawing.Size(21, 20);
            this.Line_Button.Text = "Draw a line with two points";
            this.Line_Button.Click += new System.EventHandler(this.Line_Button_Click);
            // 
            // Curve_Button
            // 
            this.Curve_Button.CheckOnClick = true;
            this.Curve_Button.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Curve_Button.Image = ((System.Drawing.Image)(resources.GetObject("Curve_Button.Image")));
            this.Curve_Button.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Curve_Button.Name = "Curve_Button";
            this.Curve_Button.Size = new System.Drawing.Size(21, 20);
            this.Curve_Button.Text = "Draw a Curve, you need to select two points, of the defining points of the lines";
            this.Curve_Button.Click += new System.EventHandler(this.Curve_Button_Click);
            // 
            // Borrar_Todo_Strip
            // 
            this.Borrar_Todo_Strip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Borrar_Todo_Strip.Image = ((System.Drawing.Image)(resources.GetObject("Borrar_Todo_Strip.Image")));
            this.Borrar_Todo_Strip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Borrar_Todo_Strip.Name = "Borrar_Todo_Strip";
            this.Borrar_Todo_Strip.Size = new System.Drawing.Size(21, 20);
            this.Borrar_Todo_Strip.Text = "toolStripButton1";
            this.Borrar_Todo_Strip.ToolTipText = "Delete every draw in the scrreen";
            this.Borrar_Todo_Strip.Click += new System.EventHandler(this.toolStripButton1_Click_1);
            // 
            // Delete_Last
            // 
            this.Delete_Last.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Delete_Last.Image = ((System.Drawing.Image)(resources.GetObject("Delete_Last.Image")));
            this.Delete_Last.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Delete_Last.Name = "Delete_Last";
            this.Delete_Last.Size = new System.Drawing.Size(21, 20);
            this.Delete_Last.Text = "toolStripButton2";
            this.Delete_Last.ToolTipText = "Delete last draw in the screen";
            this.Delete_Last.Click += new System.EventHandler(this.Delete_Last_Click);
            // 
            // Add_Track
            // 
            this.Add_Track.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Add_Track.Image = ((System.Drawing.Image)(resources.GetObject("Add_Track.Image")));
            this.Add_Track.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Add_Track.Name = "Add_Track";
            this.Add_Track.Size = new System.Drawing.Size(21, 20);
            this.Add_Track.Text = "Add a track";
            this.Add_Track.Click += new System.EventHandler(this.Add_Track_Click);
            // 
            // Save_Changes
            // 
            this.Save_Changes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save_Changes.Image = ((System.Drawing.Image)(resources.GetObject("Save_Changes.Image")));
            this.Save_Changes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save_Changes.Name = "Save_Changes";
            this.Save_Changes.Size = new System.Drawing.Size(21, 20);
            this.Save_Changes.Text = "toolStripButton1";
            this.Save_Changes.ToolTipText = "Save the changes to the track";
            this.Save_Changes.Click += new System.EventHandler(this.Save_Changes_Click);
            // 
            // colorDialog1
            // 
            this.colorDialog1.SolidColorOnly = true;
            // 
            // Track_Edit_Select
            // 
            this.Track_Edit_Select.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.Track_Edit_Select.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Track_Edit_Select.FormattingEnabled = true;
            this.Track_Edit_Select.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.Track_Edit_Select.Location = new System.Drawing.Point(814, 478);
            this.Track_Edit_Select.Name = "Track_Edit_Select";
            this.Track_Edit_Select.Size = new System.Drawing.Size(121, 21);
            this.Track_Edit_Select.TabIndex = 27;
            this.Track_Edit_Select.TabStop = false;
            this.Track_Edit_Select.SelectedIndexChanged += new System.EventHandler(this.Track_Edit_Select_SelectedIndexChanged);
            // 
            // Track_Caption
            // 
            this.Track_Caption.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Track_Caption.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Track_Caption.InitialImage = null;
            this.Track_Caption.Location = new System.Drawing.Point(806, 27);
            this.Track_Caption.Name = "Track_Caption";
            this.Track_Caption.Size = new System.Drawing.Size(129, 416);
            this.Track_Caption.TabIndex = 26;
            this.Track_Caption.TabStop = false;
            this.Track_Caption.Paint += new System.Windows.Forms.PaintEventHandler(this.Track_Caption_Paint);
            // 
            // DTA
            // 
            this.DTA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.DTA.ImageLocation = "C:\\Users\\Juan\\Documents\\Visual Studio 2017\\Projects\\Track_Project\\Track_Project\\R" +
    "esources\\DTA.jpg";
            this.DTA.Location = new System.Drawing.Point(13, 468);
            this.DTA.Name = "DTA";
            this.DTA.Size = new System.Drawing.Size(122, 57);
            this.DTA.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.DTA.TabIndex = 12;
            this.DTA.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 535);
            this.Controls.Add(this.Track_Edit_Select);
            this.Controls.Add(this.Track_Caption);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.Posicion_Cursor);
            this.Controls.Add(this.DTA);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.Text = "Form1";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Paleta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Track_Caption)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DTA)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox DTA;
        private System.Windows.Forms.LinkLabel Posicion_Cursor;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.PictureBox Paleta;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Archivo_Menu;
        private System.Windows.Forms.ToolStripMenuItem cargarMapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cargarTrayectoriaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Exportar_Trayectoria_Menu1;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton Select_Origin_Button;
        private System.Windows.Forms.ToolStripButton Line_Button;
        private System.Windows.Forms.ToolStripButton Curve_Button;
        private System.Windows.Forms.ToolStripButton Mouse_Button;
        private System.Windows.Forms.ToolStripButton Borrar_Todo_Strip;
        private System.Windows.Forms.ToolStripButton Delete_Last;
        private System.Windows.Forms.ToolStripButton Mathematical_Edition;
        private System.Windows.Forms.ToolStripMenuItem exportarMapaToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Color_Select;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewAllTracsToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton Add_Track;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteTrackToolStripMenuItem;
        private System.Windows.Forms.PictureBox Track_Caption;
        private System.Windows.Forms.ComboBox Track_Edit_Select;
        private System.Windows.Forms.ToolStripButton Save_Changes;
        private System.Windows.Forms.ToolStripButton ChangeOrigin_ToolStrip;
        private System.Windows.Forms.ToolStripMenuItem codesysToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton ChangeThickness_Button;
    }
}

