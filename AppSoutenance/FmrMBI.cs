using AppSoutenance.Views;
using AppSoutenance.Views.Parametre;
using Microsoft.VisualBasic.Devices;
using Org.BouncyCastle.Asn1.X509;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppSoutenance
{
    public partial class FmrMBI : Form
    {
        public FmrMBI()
        {
            InitializeComponent();
        }
        //Methode pour fermer tout les formulaires
        private void fermer()
        {
            Form[] charr = this.MdiChildren;

            // For each child form set the window state
            foreach (Form chform in charr)
            {
                // chform.WindowState = FormWindowState.Minimized;
                chform.Close();
            }
        }


        private void seConnecterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fmrConnection f = new fmrConnection();
            f.Show();
            this.Close();
        }

        private void quitterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void annéeAcedemiqueToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmAnneeAcademique f = new frmAnneeAcademique();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void sessionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmSession f = new frmSession();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;
        }

        private void professeurToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fermer();
            frmProfesseur f = new frmProfesseur();
            f.MdiParent = this;
            f.Show();
            f.WindowState = FormWindowState.Maximized;

        }

        private void FmrMBI_Load(object sender, EventArgs e)
        {
            Computer myComputer = new Computer();
            this.Width = myComputer.Screen.Bounds.Width;
            this.Height = myComputer.Screen.Bounds.Height;
            this.Location = new Point(0, 0);
        }
    }
}
