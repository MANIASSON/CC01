using System;
using System.Collections.Generic;
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
        public FrmParent()
        {
            InitializeComponent();
        }

        private void etudiantsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Etudiants();
            f.Show();
        }

        private void etudiantsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Form f = new Ecole();
            f.Show();
        }

        private void FrmParent_Load(object sender, EventArgs e)
        {

        }
    }
}
