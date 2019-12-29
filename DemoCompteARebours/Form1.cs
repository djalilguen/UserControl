using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DemoCompteARebours
{
    public partial class mainForm : Form
    {
        public mainForm()
        {
            InitializeComponent();
            txtReponse.DataBindings.Add("Enabled", compteARebours1, "isNotTimeOut");
            panQuestion.Visible = true;
            compteARebours1.Visible = true;
           
           
        }

        private void btnQuitter_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            String message="";
            String caption= "";
            if (txtReponse.Text == "4")
            {
                message = "Bonne Réponse ! Bravo";
                caption = "Félicitation ";
            }
            else {
                message = "Mauvaise Réponse ! La bonne réponse c'est: 4 ";
                caption = "Information ";
            }
            MessageBox.Show(message, caption, MessageBoxButtons.OK,
                MessageBoxIcon.Asterisk);
            compteARebours1.stopChrono();
            txtReponse.Enabled = false;
            btnOk.Enabled = false;
        }

        private void compteARebours1_Load_1(object sender, EventArgs e)
        {
            compteARebours1.startChrono();
        }

        private void mainForm_Load(object sender, EventArgs e)
        {
            txtReponse.Focus();
        }
    }
}
