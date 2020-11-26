using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CC01.WinForms;
using CC01.BO;
using CC01.BLL;
using CC01.DAL;
using System.Configuration;

namespace CC01.WinForms
{
    public partial class FrmEtudiantEdit : Form
    {

        private EtudiantBLO etudiantsBLO;
        private EcoleBLO ecoleBLO;

        public FrmEtudiantEdit()
        {
            InitializeComponent();
            etudiantsBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);
            ecoleBLO = new EcoleBLO(ConfigurationManager.AppSettings["DbFolder"]);
        }

        private void loadData()
        {
            string value = txtSearch.Text.ToLower();
            var etudiants = etudiantsBLO.GetBy
            (
                x =>
                x.Identifiant.ToLower().Contains(value) ||
                x.Prenom.ToLower().Contains(value)
            ).OrderBy(x => x.Identifiant).ToArray();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = etudiants;
            lblRows.Text = $"{dataGridView1.RowCount} rows";
            dataGridView1.ClearSelection();
        }


        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                for (int i = 0; i < dataGridView1.SelectedRows.Count; i++)
                {
                    Form f = new CreateEtudiant
                    (
                        dataGridView1.SelectedRows[i].DataBoundItem as Etudiants,
                        loadData
                    );
                    f.ShowDialog();
                }
            }
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            Form f = new CreateEtudiant(loadData);
            f.Show();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearch.Text))
                loadData();
            else
                txtSearch.Clear();
        }


        private void btnImprimer_Click(object sender, EventArgs e)
        {
            List<EtudiantsListPrint> items = new List<EtudiantsListPrint>();
            Etudiants etudiants = etudiantsBLO.GetEtudiant();
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                Etudiants p = dataGridView1.Rows[i].DataBoundItem as Etudiants;
                items.Add
                (
                   new EtudiantListPrint
                   (
                       p.Nom,
                       p.Prenom,
                       p.DateNaissance,
                       p.Contact,
                       p.Email,
                       p.Identifiant,
                       p.Sexe,
                       p.LieuxNaissance,

                       etudiants?.Nom,
                      etudiants?.Email,
                       etudiants?.Contact.ToString(),
                       etudiants?.LieuxNaissance,
                        etudiants?.Identifiant,
                         etudiants?.Prenom,
                         etudiants?.DateNaissance,
                         etudiants?.Sexe



                    )
                );
            }
            Form f = new Preview("CartePrintRpt.rdlc", items);
            f.Show();
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
                        etudiantsBLO.DeleteEtudiant(dataGridView1.SelectedRows[i].DataBoundItem as Etudiants);
                    }
                    loadData();
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            loadData();
        }

        private void FrmEtudiantEdit_Load(object sender, EventArgs e)
        {
            loadData();
        }
    }
}
