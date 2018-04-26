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
    public partial class Form2 : Form
    {
        private List<List<Point>> Lines;
        private List<List<Point>> Curves; 
        private Point Origin;
        private PictureBox Paleta;
        const short PointsOfaCurve = 4;
        const short PointsOfaLine = 2;
        enum GeometryTypes { Line, Curve};
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(ref List<List<Point>>_Lines, ref List<List<Point>> _Curves, Point _Origin, ref PictureBox _Paleta)
        {
            Lines = _Lines;
            Curves = _Curves;
            Origin = _Origin;
            Paleta = _Paleta;
            InitializeComponent();
            Load += new EventHandler(Form2_Load);
        }
        private void Form2_Load(System.Object sender, System.EventArgs e)
        {
            PopulateDataGridView();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void PopulateDataGridView()
        {
                for (int i = 0; i < Lines.Count; i++)
                {
                    for (int j = 0; j < Lines[i].Count; j++)
                    {
                        string[] rows = { i.ToString(), (Lines[i][j].X - Origin.X).ToString(), (Lines[i][j].Y - Origin.Y).ToString() };
                        Line_Data.Rows.Add(rows);
                    }
                }
                for (int i = 0; i < Curves.Count; i++)
                {
                    for (int j = 0; j < Curves[i].Count; j++)
                    {
                        string[] rows = { i.ToString(), (Curves[i][j].X - Origin.X).ToString(), (Curves[i][j].Y - Origin.Y).ToString() };
                        Curve_Data.Rows.Add(rows);
                    }
                }
        }

        private void Line_Data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[1].Value.ToString());
                Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            catch(FormatException ex)
            {
                Line_Data.Rows[e.RowIndex].Cells[1].Value = Lines[e.RowIndex / PointsOfaLine][e.RowIndex % 2].X-Origin.X;
                Line_Data.Rows[e.RowIndex].Cells[2].Value = Lines[e.RowIndex / PointsOfaLine][e.RowIndex % 2].Y-Origin.Y;
                MessageBox.Show(this, "Por favor, introduzca un valor\ncorrecto en la celda\n"+ex.Message , "Error al introducir un valor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Point point = new Point(Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[1].Value.ToString())+Origin.X, Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[2].Value.ToString())+Origin.Y);
            Lines[e.RowIndex / PointsOfaLine].RemoveAt(e.RowIndex % 2);
            Lines[e.RowIndex / PointsOfaLine].Insert(e.RowIndex%2, point);
            Paleta.Invalidate();
            Paleta.Update();
        }

        private void Add_Row_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == Lines_Name)
            {
                Point[] points = new Point[PointsOfaLine] { Origin, Origin };
                for (int i = 0; i < PointsOfaLine; i++)
                {
                    string[] rows = { Lines.Count.ToString(), (points[i].X - Origin.X).ToString(), (points[i].Y - Origin.Y).ToString() };
                    Line_Data.Rows.Add(rows);
                }
                Lines.Add(points.ToList());
                Paleta.Refresh();
            }
            else if(tabControl1.SelectedTab.Name == Curves_Name)
            {
                Point[] points = new Point[PointsOfaCurve];
                
                for (int i = 0; i < PointsOfaCurve; i++)
                {
                    points[i] = Origin;
                    string[] rows = { Curves.Count.ToString(), (points[i].X - Origin.X).ToString(), (points[i].Y - Origin.Y).ToString() };
                    Curve_Data.Rows.Add(rows);
                }
                Curves.Add(points.ToList());
                Paleta.Refresh();
            }
            else
            {

            }
        }

        private void Delete_Row_Click(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab.Name == Lines_Name)
            {
                if (Lines.Count > 0)
                {
                    Lines.RemoveAt(Lines.Count - 1);
                    for (int i = 0; i < PointsOfaLine; i++)
                    {
                        Line_Data.Rows.RemoveAt(Line_Data.Rows.Count - 1);
                    }
                    Paleta.Refresh();
                }
            }
            else if (tabControl1.SelectedTab.Name == Curves_Name)
            {
                if (Curves.Count > 0)
                {
                    Curves.RemoveAt(Curves.Count - 1);
                    for (int i = 0; i < PointsOfaCurve; i++)
                    {
                        Curve_Data.Rows.RemoveAt(Curve_Data.Rows.Count - 1);
                    }
                    Paleta.Invalidate();
                    Paleta.Update();
                }
            }
            else
            {
                MessageBox.Show("Error, The tab control name doesn`t exists");
            }


        }

        private void Curve_Data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt32(Curve_Data.Rows[e.RowIndex].Cells[1].Value.ToString());
                Convert.ToInt32(Curve_Data.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            catch (FormatException ex)
            {
                Curve_Data.Rows[e.RowIndex].Cells[1].Value = Curves[e.RowIndex / PointsOfaCurve][e.RowIndex % PointsOfaCurve].X - Origin.X;
                Curve_Data.Rows[e.RowIndex].Cells[2].Value = Curves[e.RowIndex / PointsOfaCurve][e.RowIndex % PointsOfaCurve].Y - Origin.Y;
                MessageBox.Show(this, "Por favor, introduzca un valor\ncorrecto en la celda\n" + ex.Message, "Error al introducir un valor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Point point = new Point(Convert.ToInt32(Curve_Data.Rows[e.RowIndex].Cells[1].Value.ToString()) + Origin.X, Convert.ToInt32(Curve_Data.Rows[e.RowIndex].Cells[2].Value.ToString()) + Origin.Y);
            Curves[e.RowIndex / PointsOfaCurve].RemoveAt(e.RowIndex % PointsOfaCurve);
            Curves[e.RowIndex / PointsOfaCurve].Insert(e.RowIndex % PointsOfaCurve, point);
            Paleta.Refresh();
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
        }
        private void DeleteRows(ref List<List<Point>> points, GeometryTypes geometry)
        {
            points.RemoveAt(points.Count - 1);
            for (int j = 0; j < points[points.Count - 1].Count; j++)
            {
                if(geometry==GeometryTypes.Line)
                Line_Data.Rows.RemoveAt(Line_Data.Rows.Count - 1);
                else if(geometry==GeometryTypes.Line)
                Curve_Data.Rows.RemoveAt(Curve_Data.Rows.Count - 1);
            }
            Paleta.Refresh();
        }   
    }
}
