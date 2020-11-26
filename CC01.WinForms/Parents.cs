using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.WinForms
{
    public partial class Parent : Form
    {
        public Parent()
        {
            InitializeComponent();
        }

        private void etudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new CreateEtudiant();
            f.Show();
        }

        private void etudiantsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new FrmCreateEcole();
            f.Show();
        }

        private void Parent_Load(object sender, EventArgs e)
        {

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Parent_Load_1(object sender, EventArgs e)
        {

        }
    }
}
