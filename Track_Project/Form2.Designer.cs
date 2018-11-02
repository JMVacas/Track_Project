using System;

namespace Track_Project
{
    partial class Form2
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
        public  string Lines_Name = "Line_Points";
        public  string Curves_Name = "Curve_Points";
        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.Curve_Points = new System.Windows.Forms.TabPage();
            this.Curve_Data = new System.Windows.Forms.DataGridView();
            this.Curve = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.X_Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Y_Position = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Line_Points = new System.Windows.Forms.TabPage();
            this.Line_Data = new System.Windows.Forms.DataGridView();
            this.Lineas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posicion_X = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Posicion_Y = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Add_Row = new System.Windows.Forms.Button();
            this.Delete_Row = new System.Windows.Forms.Button();
            this.Track_Select_Box = new System.Windows.Forms.ComboBox();
            this.form2BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Curve_Points.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Curve_Data)).BeginInit();
            this.Line_Points.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Line_Data)).BeginInit();
            this.tabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.form2BindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // Curve_Points
            // 
            this.Curve_Points.Controls.Add(this.Curve_Data);
            this.Curve_Points.Location = new System.Drawing.Point(4, 22);
            this.Curve_Points.Name = "Curve_Points";
            this.Curve_Points.Padding = new System.Windows.Forms.Padding(3);
            this.Curve_Points.Size = new System.Drawing.Size(550, 425);
            this.Curve_Points.TabIndex = 1;
            this.Curve_Points.Text = "Curve Points";
            this.Curve_Points.UseVisualStyleBackColor = true;
            // 
            // Curve_Data
            // 
            this.Curve_Data.AllowUserToAddRows = false;
            this.Curve_Data.AllowUserToDeleteRows = false;
            this.Curve_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Curve_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Curve,
            this.X_Position,
            this.Y_Position});
            this.Curve_Data.Location = new System.Drawing.Point(6, 6);
            this.Curve_Data.Name = "Curve_Data";
            this.Curve_Data.Size = new System.Drawing.Size(541, 423);
            this.Curve_Data.TabIndex = 0;
            this.Curve_Data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Curve_Data_CellEndEdit);
            // 
            // Curve
            // 
            this.Curve.HeaderText = "Curves";
            this.Curve.Name = "Curve";
            this.Curve.ReadOnly = true;
            // 
            // X_Position
            // 
            this.X_Position.HeaderText = "X_Position";
            this.X_Position.Name = "X_Position";
            // 
            // Y_Position
            // 
            this.Y_Position.HeaderText = "Y_Position";
            this.Y_Position.Name = "Y_Position";
            // 
            // Line_Points
            // 
            this.Line_Points.Controls.Add(this.Line_Data);
            this.Line_Points.Location = new System.Drawing.Point(4, 22);
            this.Line_Points.Name = "Line_Points";
            this.Line_Points.Padding = new System.Windows.Forms.Padding(3);
            this.Line_Points.Size = new System.Drawing.Size(550, 425);
            this.Line_Points.TabIndex = 0;
            this.Line_Points.Text = "Line Points";
            this.Line_Points.UseVisualStyleBackColor = true;
            // 
            // Line_Data
            // 
            this.Line_Data.AllowUserToAddRows = false;
            this.Line_Data.AllowUserToDeleteRows = false;
            this.Line_Data.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Line_Data.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Lineas,
            this.Posicion_X,
            this.Posicion_Y});
            this.Line_Data.Location = new System.Drawing.Point(6, 6);
            this.Line_Data.Name = "Line_Data";
            this.Line_Data.Size = new System.Drawing.Size(541, 416);
            this.Line_Data.TabIndex = 0;
            this.Line_Data.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.Line_Data_CellEndEdit);
            // 
            // Lineas
            // 
            this.Lineas.HeaderText = "Linea";
            this.Lineas.Name = "Lineas";
            this.Lineas.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Posicion_X
            // 
            this.Posicion_X.HeaderText = "Posicion X";
            this.Posicion_X.Name = "Posicion_X";
            this.Posicion_X.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // Posicion_Y
            // 
            this.Posicion_Y.HeaderText = "Posicion_Y";
            this.Posicion_Y.Name = "Posicion_Y";
            this.Posicion_Y.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Line_Points);
            this.tabControl1.Controls.Add(this.Curve_Points);
            this.tabControl1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(558, 451);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.Selected += new System.Windows.Forms.TabControlEventHandler(this.tabControl1_Selected);
            // 
            // Add_Row
            // 
            this.Add_Row.Location = new System.Drawing.Point(605, 40);
            this.Add_Row.Name = "Add_Row";
            this.Add_Row.Size = new System.Drawing.Size(152, 23);
            this.Add_Row.TabIndex = 2;
            this.Add_Row.Text = "Add Row";
            this.Add_Row.UseVisualStyleBackColor = true;
            this.Add_Row.Click += new System.EventHandler(this.Add_Row_Click);
            // 
            // Delete_Row
            // 
            this.Delete_Row.Location = new System.Drawing.Point(605, 69);
            this.Delete_Row.Name = "Delete_Row";
            this.Delete_Row.Size = new System.Drawing.Size(152, 23);
            this.Delete_Row.TabIndex = 3;
            this.Delete_Row.Text = "Delete Row";
            this.Delete_Row.UseVisualStyleBackColor = true;
            this.Delete_Row.Click += new System.EventHandler(this.Delete_Row_Click);
            // 
            // Track_Select_Box
            // 
            this.Track_Select_Box.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Track_Select_Box.FormattingEnabled = true;
            this.Track_Select_Box.Location = new System.Drawing.Point(605, 98);
            this.Track_Select_Box.Name = "Track_Select_Box";
            this.Track_Select_Box.Size = new System.Drawing.Size(152, 21);
            this.Track_Select_Box.TabIndex = 4;
            this.Track_Select_Box.SelectedIndexChanged += new System.EventHandler(this.Track_Select_Box_SelectedIndexChanged);
            this.Track_Select_Box.SelectedValueChanged += new System.EventHandler(this.Track_Select_Box_SelectedValueChanged);
            // 
            // form2BindingSource
            // 
            this.form2BindingSource.DataSource = typeof(Track_Project.Form2);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 535);
            this.Controls.Add(this.Track_Select_Box);
            this.Controls.Add(this.Delete_Row);
            this.Controls.Add(this.Add_Row);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.Curve_Points.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Curve_Data)).EndInit();
            this.Line_Points.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.Line_Data)).EndInit();
            this.tabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.form2BindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource form2BindingSource;
        private System.Windows.Forms.TabPage Curve_Points;
        private System.Windows.Forms.DataGridView Curve_Data;
        private System.Windows.Forms.TabPage Line_Points;
        private System.Windows.Forms.DataGridView Line_Data;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lineas;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posicion_X;
        private System.Windows.Forms.DataGridViewTextBoxColumn Posicion_Y;
        private System.Windows.Forms.Button Add_Row;
        private System.Windows.Forms.Button Delete_Row;
        private System.Windows.Forms.DataGridViewTextBoxColumn Curve;
        private System.Windows.Forms.DataGridViewTextBoxColumn X_Position;
        private System.Windows.Forms.DataGridViewTextBoxColumn Y_Position;
        private System.Windows.Forms.ComboBox Track_Select_Box;
    }
}