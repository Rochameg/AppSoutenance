using AppSoutenance.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AppSoutenance.Views.Parametre
{
    public partial class frmSession : Form
    {
        public frmSession()
        {
            InitializeComponent();
        }

        BdSenSoutenanceContext db = new BdSenSoutenanceContext();

        private void frmSession_Load(object sender, EventArgs e)
        {
            dgSession.DataSource = db.sessions.ToList();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSession_TextChanged(object sender, EventArgs e)
        {

        }

        

    }
}
