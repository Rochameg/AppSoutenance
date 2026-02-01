using AppSoutenance.Models;
using AppSoutenance.Shared;
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
        FilliereList filler = new FilliereList();

        private void frmSession_Load(object sender, EventArgs e)
        {
            Effacer();
        }

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {

            Session session = new Session();

            session.LibelleSession = txtSession.Text;
            session.IdAnneeAcademique = int.Parse(cbbAnneeAcademique.SelectedValue.ToString());
            db.sessions.Add(session);
            db.SaveChanges();
            Effacer();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void txtSession_TextChanged(object sender, EventArgs e)
        {

        }

        private void Effacer()
        {
            txtSession.Clear();
            cbbAnneeAcademique.SelectedValue = "";
            dgSession.DataSource = db.sessions.ToList();
            cbbAnneeAcademique.DataSource = filler.FillAnneeAcademique();
            cbbAnneeAcademique.DisplayMember = "Text";
            cbbAnneeAcademique.ValueMember = "Value";

        }

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgSession.CurrentRow.Cells[0].Value.ToString());
            Session session = db.sessions.Find(id);
            txtSession.Text = session.LibelleSession;
            cbbAnneeAcademique.SelectedValue = session.IdAnneeAcademique;

        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgSession.CurrentRow.Cells[0].Value.ToString());
            Session session = db.sessions.Find(id);
            session.LibelleSession = txtSession.Text;
            session.IdAnneeAcademique = (int?)cbbAnneeAcademique.SelectedValue;
            db.SaveChanges();
            Effacer();

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            int? id = int.Parse(dgSession.CurrentRow.Cells[0].Value.ToString());
            Session session = db.sessions.Find(id);
            db.sessions.Remove(session);
            db.SaveChanges();
            Effacer();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var liste = db.sessions.ToList();

            if (!string.IsNullOrEmpty(txtRSession.Text))
            {
                liste = liste.Where(s => s.LibelleSession.Contains(txtRSession.Text)).ToList();
            }

            if (txtRAnneeAcademique.Text != "")
            {
                liste = liste.Where(s => s.AnneeAcademique.LibelleAnneeAcademique.Contains(txtRAnneeAcademique.Text)).ToList();
            }

            dgSession.DataSource = liste;

        }
    }
}
