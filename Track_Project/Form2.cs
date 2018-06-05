using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

namespace Track_Project
{
    public partial class Form2 : Form
    {

        private Tracks track_;
        private List<Tracks> tracks= new List<Tracks>();
        private Point Origin;
        private PictureBox Paleta;
        const short PointsOfaCurve = 4;
        const short PointsOfaLine = 2;
        enum GeometryTypes { Line, Curve};
        public Form2()
        {
            InitializeComponent();
        }
        public Form2(ref Tracks _track, ref List<Tracks> _tracks, Point _Origin, ref PictureBox _Paleta)
        {
            track_ = _track;
            track_.SetName("Track actual");
            tracks.AddRange(_tracks);
            Origin = _Origin;
            Paleta = _Paleta;
            InitializeComponent();
            Load += new EventHandler(Form2_Load);
        }
        private void Form2_Load(System.Object sender, System.EventArgs e)
        {
            Track_Select_Box.BeginUpdate();
            try
            {
                if(track_.GetName()!="Track_Actual")
                    track_.SetName("Track actual");
                Track_Select_Box.Items.Add(track_.GetName());
            }
            catch(ArgumentNullException)
            {
                track_.SetName("Track actual");
                Track_Select_Box.Items.Add(track_.GetName());
            }
            finally
            {
                Track_Select_Box.SelectedItem = Track_Select_Box.Items[0];

            }
            foreach (Tracks _track in tracks)
            {
                Track_Select_Box.Items.Add(_track.GetName());
            }
            PopulateDataGridView(track_);
            Track_Select_Box.EndUpdate();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
        }
        private void PopulateDataGridView(Tracks track)
        {
                for (int i = 0; i < track.GetLineCount(); i++)
                {
                    for (int j = 0; j < track.GetLines()[i].Count; j++)
                    {
                        string[] rows = { i.ToString(), (track.GetLines()[i][j].X - Origin.X).ToString(), (-track.GetLines()[i][j].Y + Origin.Y).ToString() };
                        Line_Data.Rows.Add(rows);
                    }
                }
                for (int i = 0; i < track.GetCurves().Count; i++)
                {
                    for (int j = 0; j < track.GetCurves()[i].Count; j++)
                    {
                        string[] rows = { i.ToString(), (track.GetCurves()[i][j].X - Origin.X).ToString(), (-track.GetCurves()[i][j].Y + Origin.Y).ToString() };
                        Curve_Data.Rows.Add(rows);
                    }
                }
        }

        private void Line_Data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (Track_Select_Box.SelectedItem == null)
                Track_Select_Box.SelectedItem = Track_Select_Box.Items[0];
            if (Track_Select_Box.SelectedItem.ToString() == track_.GetName())
                Line_Data_CellEndEdit_Function(track_, e);
            else
                Line_Data_CellEndEdit_Function(tracks[Track_Select_Box.SelectedIndex - 1], e);
        }

        private void Add_Row_Click(object sender, EventArgs e)
        {
            if (Track_Select_Box.SelectedItem.ToString()==track_.GetName())
            {
                Add_Row_Function(track_);
            }
            else
            {
                Add_Row_Function(tracks[Track_Select_Box.SelectedIndex - 1]);
            }
        }

        private void Delete_Row_Click(object sender, EventArgs e)
        {
            if (Track_Select_Box.SelectedItem.ToString() == track_.GetName())
                Delete_Row_Click_Function(track_);
            else
                Delete_Row_Click_Function(tracks[Track_Select_Box.SelectedIndex - 1]);

        }

        private void Curve_Data_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (Track_Select_Box.SelectedItem.ToString() == track_.GetName())
                    Curve_Data_CellEndEdit_Function(track_, e);
                else
                    Curve_Data_CellEndEdit_Function(tracks[Track_Select_Box.SelectedIndex - 1], e);
            }
            catch(NullReferenceException)
            {

            }
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
        void fileExitMenuItem_Click(object sender, RoutedEventArgs e)
        {
            
            Close();
        }
        private void Add_Row_Function(Tracks track)
        {
            if (tabControl1.SelectedTab.Name == Lines_Name)
            {
                Point[] points = new Point[PointsOfaLine] { Origin, Origin };
                for (int i = 0; i < PointsOfaLine; i++)
                {
                    string[] rows = { track.GetLines().Count.ToString(), (points[i].X - Origin.X).ToString(), (-points[i].Y + Origin.Y).ToString() };
                    Line_Data.Rows.Add(rows);
                }
                track.GetLines().Add(points.ToList());
                Paleta.Refresh();
            }
            else if (tabControl1.SelectedTab.Name == Curves_Name)
            {
                Point[] points = new Point[PointsOfaCurve];

                for (int i = 0; i < PointsOfaCurve; i++)
                {
                    points[i] = Origin;
                    string[] rows = { track.GetCurves().Count.ToString(), (points[i].X - Origin.X).ToString(), (-points[i].Y + Origin.Y).ToString() };
                    Curve_Data.Rows.Add(rows);
                }
                track.GetCurves().Add(points.ToList());
                Paleta.Refresh();
            }
            else
            {

            }
        }
        private void Line_Data_CellEndEdit_Function(Tracks track, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[1].Value.ToString());
                Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            catch (FormatException ex)
            {
                Line_Data.Rows[e.RowIndex].Cells[1].Value =  track.GetLines()[e.RowIndex / PointsOfaLine][e.RowIndex % 2].X - Origin.X;
                Line_Data.Rows[e.RowIndex].Cells[2].Value = -track.GetLines()[e.RowIndex / PointsOfaLine][e.RowIndex % 2].Y + Origin.Y;
                MessageBox.Show(this, "Por favor, introduzca un valor\ncorrecto en la celda\n" + ex.Message, "Error al introducir un valor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Point point = new Point(Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[1].Value.ToString()) + Origin.X, -Convert.ToInt32(Line_Data.Rows[e.RowIndex].Cells[2].Value.ToString()) + Origin.Y);
            track.GetLines()[e.RowIndex / PointsOfaLine].RemoveAt(e.RowIndex % PointsOfaLine);
            track.GetLines()[e.RowIndex / PointsOfaLine].Insert(e.RowIndex % PointsOfaLine, point);
            AddLine addLine = new AddLine();
            int i = new int();
            bool exit = false;
            for (int counter=0; i<track.GetOperations().GetOperations().Count && exit==false ; i++)
            {
                if(counter==e.RowIndex/PointsOfaLine)
                {
                    exit = true;
                }
                else if(track.GetOperations().GetOperations()[i].GetType()==addLine.GetType())
                {
                    counter++;
                }
            }
            try
            {
                track.GetOperations().GetOperations()[i - 1].SetOperationPoint(point, e.RowIndex % PointsOfaLine);
            }
            catch(ArgumentOutOfRangeException)
            {

            }
            Paleta.Invalidate();
            Paleta.Update();
        }
        private void Delete_Row_Click_Function(Tracks track)
        {
            if (tabControl1.SelectedTab.Name == Lines_Name)
            {
                if (track.GetLines().Count > 0)
                {
                    track.GetLines().RemoveAt(track.GetLines().Count - 1);
                    for (int i = 0; i < PointsOfaLine; i++)
                    {
                        Line_Data.Rows.RemoveAt(Line_Data.Rows.Count - 1);
                    }
                    Paleta.Refresh();
                }
            }
            else if (tabControl1.SelectedTab.Name == Curves_Name)
            {
                if (track.GetCurves().Count > 0)
                {
                    track.GetCurves().RemoveAt(track.GetCurves().Count - 1);
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
                MessageBox.Show(this, "Error, The tab control name doesn`t exists", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void Curve_Data_CellEndEdit_Function(Tracks track, DataGridViewCellEventArgs e)
        {
            try
            {
                Convert.ToInt32(Curve_Data.Rows[e.RowIndex].Cells[1].Value.ToString());
                Convert.ToInt32(Curve_Data.Rows[e.RowIndex].Cells[2].Value.ToString());
            }
            catch (FormatException ex)
            {
                Curve_Data.Rows[e.RowIndex].Cells[1].Value =  track.GetCurves()[e.RowIndex / PointsOfaCurve][e.RowIndex % PointsOfaCurve].X - Origin.X;
                Curve_Data.Rows[e.RowIndex].Cells[2].Value = -track.GetCurves()[e.RowIndex / PointsOfaCurve][e.RowIndex % PointsOfaCurve].Y + Origin.Y;
                MessageBox.Show(this, "Por favor, introduzca un valor\ncorrecto en la celda\n" + ex.Message, "Error al introducir un valor", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Point point = new Point(Convert.ToInt32(Curve_Data.Rows[e.RowIndex].Cells[1].Value.ToString()) + Origin.X, -Convert.ToInt32((Curve_Data.Rows[e.RowIndex].Cells[2].Value).ToString()) + Origin.Y);
            track.GetCurves()[e.RowIndex / PointsOfaCurve].RemoveAt(e.RowIndex % PointsOfaCurve);
            track.GetCurves()[e.RowIndex / PointsOfaCurve].Insert(e.RowIndex % PointsOfaCurve, point);
            int i = new int();
            AddBezier addBezier = new AddBezier();
            bool exit = false;
            for (int counter = 0; i < track.GetOperations().GetOperations().Count && exit == false; i++)
            {
                if (track.GetOperations().GetOperations()[i].GetType() == addBezier.GetType())
                {
                    counter++;
                }
                else if (counter == (e.RowIndex / PointsOfaCurve+1))
                {
                    exit = true;
                }
            }
            try
            {
                track.GetOperations().GetOperations()[i - 1].SetOperationPoint(point, e.RowIndex % PointsOfaCurve);
            }
            catch (ArgumentOutOfRangeException)
            {
            }
            Paleta.Refresh();
        }

        private void Track_Select_Box_SelectedValueChanged(object sender, EventArgs e)
        {
            Line_Data.Rows.Clear();
            Curve_Data.Rows.Clear();
            if (Track_Select_Box.SelectedItem.ToString() == track_.GetName())
            PopulateDataGridView(track_);
            else
                PopulateDataGridView(tracks[Track_Select_Box.SelectedIndex - 1]);
        }
    }
}
