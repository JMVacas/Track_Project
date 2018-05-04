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
    public partial class ChangeOriginDiaog : Form
    {
        public Point Origin = new Point();
        private Point Origin_Memento = new Point();
        public ChangeOriginDiaog()
        {
            InitializeComponent();
        }
        public ChangeOriginDiaog(Point _Origin)
        {
            InitializeComponent();
            Origin = _Origin;
            Origin_Memento = _Origin;
            string[] rows = {(Origin.X - Origin.X).ToString(), (Origin.Y - Origin.Y).ToString() };
            Origin_DataGrid.Rows.Add(rows);
        }

        private void Origin_DataGrid_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Origin.X=Convert.ToInt32(Origin_DataGrid.Rows[e.RowIndex].Cells[0].Value.ToString())+Origin_Memento.X;
                Origin.Y=Convert.ToInt32(Origin_DataGrid.Rows[e.RowIndex].Cells[1].Value.ToString())+Origin_Memento.Y;
            }
            catch (FormatException ex)
            {
                Origin_DataGrid.Rows[e.RowIndex].Cells[0].Value = Origin.X;
                Origin_DataGrid.Rows[e.RowIndex].Cells[1].Value = Origin.Y;
                MessageBox.Show(this, "Por favor, introduzca un valor\ncorrecto en la celda\n" + ex.Message, "Error al introducir un valor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            Origin = Origin_Memento;
            Hide();
        }
    }
}
