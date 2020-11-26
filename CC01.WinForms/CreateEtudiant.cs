using CC01.BO;
using System;
using CC01.BLO;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Security.Cryptography.X509Certificates;

namespace CC01.WinForms
{
    public partial class FrmCreateEtudiant : Form
    {
        private Action callBack;
        private Etudiants oldEtudiant;

        public FrmCreateEtudiant()
        {
            InitializeComponent();
        }

        public FrmCreateEtudiant(Action callBack) : this()
        {
            this.callBack = callBack;
        }

        public FrmCreateEtudiant(Etudiants etudiants, Action callBack) : this(callBack)
        {
            this.oldEtudiant = etudiants;
            txtNom.Text = etudiants.Nom;
            txtPrenom.Text = etudiants.Prenom.ToString();
            txtSexe.Text = etudiants.Sexe;
            txtContact.Text = etudiants.Contact.ToString();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            try
            {
                checkForm();

                Etudiants newProduct = new Etudiants
                (
                    txtNom.Text,
                    txtPrenom.Text,
                    txtContact.Text,
                    txtSexe.Text,
                    txtEmail.Text,
                    txtLieuxNaissance.Text,
                    txtDatedeNaissance.Text,
                    txtIdentifiant.Text


                );

                EtudiantBLO productBLO = new EtudiantBLO(ConfigurationManager.AppSettings["DbFolder"]);

                if (this.oldEtudiant == null)
                    productBLO.CreateEtudiant(newProduct);
                else
                    productBLO.EditEtudiants(oldEtudiant, newProduct);

                MessageBox.Show
                (
                    "Save done !",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                if (callBack != null)
                    callBack();

                if (oldEtudiant != null)
                    Close();

                txtNom.Clear();
                txtPrenom.Clear();
                txtEmail.Clear();
                txtDatedeNaissance.Clear();
                txtNom.Focus();
                txtLieuxNaissance.Clear();
                txtIdentifiant.Clear();
                txtSexe.Clear();

            }
            catch (TypingException ex)
            {
                MessageBox.Show
               (
                   ex.Message,
                   "Typing error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            catch (DuplicateNameException ex)
            {
                MessageBox.Show
               (
                   ex.Message,
                   "Duplicate error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            catch (KeyNotFoundException ex)
            {
                MessageBox.Show
               (
                   ex.Message,
                   "Not found error",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Warning
               );
            }
            /* catch (Exception ex)
             {
                 ex.WriteToFile();
                 MessageBox.Show
                (
                    "An error occurred! Please try again later.",
                    "Erreur",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
             }*/

        }

        private void checkForm()
        {
            string text = string.Empty;
            txtIdentifiant.BackColor = Color.White;
            txtNom.BackColor = Color.White;
            if (string.IsNullOrWhiteSpace(txtIdentifiant.Text))
            {
                text += "- Please enter the Identifiant ! \n";
                txtIdentifiant.BackColor = Color.Pink;
            }
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                text += "- Please enter the name ! \n";
                txtNom.BackColor = Color.Pink;
            }

            if (!string.IsNullOrEmpty(text))
                throw new TypingException(text);
        }

        private void FrmCreateEtudiant_Load(object sender, EventArgs e)
        {

        }
    }
}