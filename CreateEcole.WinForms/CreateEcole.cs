using CC01.BO;
using CC01.BLL;
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
    public partial class FrmCreateEcole : Form
    {
        private Action callBack;
        private EcoleBLO ecoleBLO;
        private Ecole oldEcole;
        private Action loadData;

        public FrmCreateEcole(object loadData)
        {
            InitializeComponent();

        }

        public FrmCreateEcole(Action callBack, Action loadData) : this()
        {
            this.callBack = callBack;
            this.loadData = loadData;
        }



        public FrmCreateEcole(Action loadData)
        {
            this.loadData = loadData;
        }

        public FrmCreateEcole(Ecole ecole, Action callBack) : this(callBack)
        {
            this.oldEcole = ecole;
            txtNomEcole.Text = ecole.NomEcole;
            txtContact.Text = ecole.Contact.ToString();
            txtBoitePostale.Text = ecole.BoitePostale;
            txtEmail.Text = ecole.Email.ToString();
        }
        public FrmCreateEcole()
        {
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmCreateEcole_Load(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                checkForm();

                Ecole newEcole = new Ecole
                (
                    txtNomEcole.Text.ToUpper(),
                    txtLocalisation.Text,
                    txtContact.Text,
                    txtEmail.Text,
                    txtBoitePostale.Text,
                    pictureBox1.ImageLocation
                );

                ecoleBLO.CreateEcole(oldEcole, newEcole);

                MessageBox.Show
                (
                    "Save done !",
                    "Confirmation",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );

                Close();


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
            catch (Exception ex)
            {
                ex.WriteToFile();
                MessageBox.Show
               (
                   "An error occurred! Please try again later.",
                   "Erreur",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error
               );
            }
        }

        private void checkForm()
        {
            string text = string.Empty;
            txtNomEcole.BackColor = Color.White;
            txtEmail.BackColor = Color.White;
            if (!long.TryParse(txtContact.Text, out _))
            {
                text += "- Please enter a good phone number ! \n";
                txtNomEcole.BackColor = Color.Pink;
            }
            if (string.IsNullOrWhiteSpace(txtNomEcole.Text))
            {
                text += "- Please enter the name ! \n";
                txtEmail.BackColor = Color.Pink;
            }

            if (!string.IsNullOrEmpty(text))
                throw new TypingException(text);
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            pictureBox1.ImageLocation = null;
        }

        private void FrmCreateEcole_Load_1(object sender, EventArgs e)
        {

        }
    }
}
