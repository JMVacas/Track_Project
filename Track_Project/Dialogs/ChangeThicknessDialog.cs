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
    public partial class ChangeThicknessDialog : Form
    {
        public double _Thickness { get; set;}
        public ChangeThicknessDialog()
        {
            InitializeComponent();
        }
        public ChangeThicknessDialog(double Thickness)
        {
            InitializeComponent();
            _Thickness = Thickness;
            trackBar1.Value = (int)(Thickness * 5);
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Hide();
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            _Thickness = ((double)trackBar1.Value / (double)5);
        }
    }
}
