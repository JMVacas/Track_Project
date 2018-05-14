using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Track_Project
{
    public partial class CodesysExportDialog : Form
    {
        public int Path_Number = new int();
        public string Orientation;
        public CodesysExportDialog()
        {
            InitializeComponent();
            Path_Number = 1;
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            if (Orientation!=null && Path_Number>0)
            {
                DialogResult = DialogResult.OK;
                Hide();
            }
            else
            {
                MessageBox.Show(this, "Please, select and set a valid value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Orientation = comboBox1.SelectedItem.ToString();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Path_Number = Convert.ToInt32(textBox1.Text);
            }
            catch (FormatException)
            {
                Path_Number = 1;
                textBox1.Text = "1";
                MessageBox.Show(this, "Plese, insert a valid number in the box [0, "+sizeof(int)+"].", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
    }
}
