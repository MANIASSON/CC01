using CC01.BLL;
using CC01.BO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CC01.WinForms
{
    public partial class FrmEcoleEdit : Form
    {
        private EtudiantBLO etudiantsBLO;
        private EcoleBLO ecoleBLO;
        public FrmEcoleEdit()
        {
            InitializeComponent();
            etudiantsBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);
            ecoleBLO = new EcoleBLO(ConfigurationManager.AppSettings["DbFolder"]);
        }

        private void loadData()
        {
            string value = txtSearch.Text.ToLower();
            var ecole = ecoleBLO.GetBy
            (
                x =>
                x.BoitePostale.ToLower().Contains(value) ||
                x.NomEcole.ToLower().Contains(value)
            ).OrderBy(x => x.BoitePostale).ToArray();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = ecole;
            lblRows.Text = $"{dataGridView1.RowCount} rows";
            dataGridView1.ClearSelection();
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            Form f = new FrmCreateEcole(loadData);

            f.Show();
        }

        private void FrmEcoleEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                loadData();
            else
                txtSearch.Clear();
        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                if (
                    MessageBox.Show
                    (
                        "Do you really want to delete this product(s)?",
                        "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question
                    ) == DialogResult.Yes
                )
                {
                    for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                    {
                        ecoleBLO.DeleteEcole(dataGridView1.SelectedRows[i].DataBoundItem as Ecole);
                    }
                    loadData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Choose a picture";
            ofd.Filter = "Image files|*.jpg;*.jpeg;*.png;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                pictureBox1.ImageLocation = ofd.FileName;
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    Form f = new CreateSchool
                    (
                        dataGridView1.SelectedRows[i].DataBoundItem as Ecole,
                        loadData
                    );
                    f.ShowDialog();
                }
            }
        }

        private void FrmEcoleEdit_Load_1(object sender, EventArgs e)
        {

        }
    }
}

