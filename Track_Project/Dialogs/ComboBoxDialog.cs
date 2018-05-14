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
    public partial class ComboBoxDialog : Form
    {
        public Tracks Selected_track = new Tracks();
        private List<Tracks> tracks = new List<Tracks>();
        public bool Cancel = false;
        public ComboBoxDialog()
        {
            InitializeComponent();
        }
        public ComboBoxDialog(ref List<Tracks> _tracks)
        {
            InitializeComponent();
            tracks.AddRange(_tracks);
            Load += new EventHandler(Form4_Load);
        }
        public void Form4_Load(System.Object sender, EventArgs e)
        {
            foreach (Tracks track in tracks)
            {
                Track_Selection_ComboBox.Items.Add(track.GetName());
            }
        }

        private void Track_Selection_ComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            Selected_track = tracks.Find(t => t.GetName() == Track_Selection_ComboBox.SelectedItem.ToString());
        }

        private void OK_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Hide();
        }

        private void Cancel_Button_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Selected_track = null;
            Hide();
        }
    }
}
