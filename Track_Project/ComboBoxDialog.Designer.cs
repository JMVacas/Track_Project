namespace Track_Project
{
    partial class ComboBoxDialog
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
            this.Msg = new System.Windows.Forms.Label();
            this.Track_Selection_ComboBox = new System.Windows.Forms.ComboBox();
            this.OK_Button = new System.Windows.Forms.Button();
            this.Cancel_Button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Msg
            // 
            this.Msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Msg.Location = new System.Drawing.Point(12, 9);
            this.Msg.Name = "Msg";
            this.Msg.Size = new System.Drawing.Size(254, 37);
            this.Msg.TabIndex = 0;
            this.Msg.Text = "Select a Track";
            // 
            // Track_Selection_ComboBox
            // 
            this.Track_Selection_ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Track_Selection_ComboBox.FormattingEnabled = true;
            this.Track_Selection_ComboBox.Location = new System.Drawing.Point(15, 38);
            this.Track_Selection_ComboBox.Name = "Track_Selection_ComboBox";
            this.Track_Selection_ComboBox.Size = new System.Drawing.Size(251, 21);
            this.Track_Selection_ComboBox.TabIndex = 1;
            this.Track_Selection_ComboBox.SelectionChangeCommitted += new System.EventHandler(this.Track_Selection_ComboBox_SelectionChangeCommitted);
            // 
            // OK_Button
            // 
            this.OK_Button.Location = new System.Drawing.Point(15, 62);
            this.OK_Button.Name = "OK_Button";
            this.OK_Button.Size = new System.Drawing.Size(88, 23);
            this.OK_Button.TabIndex = 2;
            this.OK_Button.Text = "OK";
            this.OK_Button.UseVisualStyleBackColor = true;
            this.OK_Button.Click += new System.EventHandler(this.OK_Button_Click);
            // 
            // Cancel_Button
            // 
            this.Cancel_Button.Location = new System.Drawing.Point(178, 62);
            this.Cancel_Button.Name = "Cancel_Button";
            this.Cancel_Button.Size = new System.Drawing.Size(88, 23);
            this.Cancel_Button.TabIndex = 3;
            this.Cancel_Button.Text = "Cancel";
            this.Cancel_Button.UseVisualStyleBackColor = true;
            this.Cancel_Button.Click += new System.EventHandler(this.Cancel_Button_Click);
            // 
            // ComboBoxDialog
            // 
            this.AcceptButton = this.OK_Button;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.CancelButton = this.Cancel_Button;
            this.ClientSize = new System.Drawing.Size(284, 101);
            this.Controls.Add(this.Cancel_Button);
            this.Controls.Add(this.OK_Button);
            this.Controls.Add(this.Track_Selection_ComboBox);
            this.Controls.Add(this.Msg);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Location = new System.Drawing.Point(200, 200);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComboBoxDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Export";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label Msg;
        private System.Windows.Forms.ComboBox Track_Selection_ComboBox;
        private System.Windows.Forms.Button OK_Button;
        private System.Windows.Forms.Button Cancel_Button;
    }
}