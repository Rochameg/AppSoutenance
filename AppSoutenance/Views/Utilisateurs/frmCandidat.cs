using AppSoutenance.Helpers;
using AppSoutenance.Models;
using AppSoutenance.Services;
using System;
using System.Windows.Forms;

namespace AppSoutenance.Views.Utilisateurs
{
    public partial class frmCandidat : Form
    {
        private readonly CandidatService _service;
        private int? _selectedId = null;

        public frmCandidat()
        {
            InitializeComponent();
            _service = new CandidatService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            UITheme.ApplyToDataGridView(dgvCandidat);
            UITheme.ApplyPrimaryButton(btnAdd);
            UITheme.ApplySuccessButton(btnEdit);
            UITheme.ApplyDangerButton(btnDelete);
            UITheme.ApplySecondaryButton(btnClear);
        }

        private void frmCandidat_Load(object sender, EventArgs e) => LoadData();

        private void LoadData()
        {
            dgvCandidat.DataSource = _service.GetAll();
            if (dgvCandidat.Columns.Count > 0)
            {
                dgvCandidat.Columns["IdUtilisateur"].Visible = false;
                dgvCandidat.Columns["MotDeUtilisateur"].Visible = false;
                dgvCandidat.Columns["MatriculeCandidat"].HeaderText = "Matricule";
                dgvCandidat.Columns["NomUtilisateur"].HeaderText = "Nom";
                dgvCandidat.Columns["PrenomUtilisateur"].HeaderText = "Prénom";
                dgvCandidat.Columns["EmailUtilisateur"].HeaderText = "Email";
                dgvCandidat.Columns["TelUtilisateur"].HeaderText = "Téléphone";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            var candidat = new Candidat
            {
                MatriculeCandidat = txtMatricule.Text.Trim(),
                NomUtilisateur = txtNom.Text.Trim(),
                PrenomUtilisateur = txtPrenom.Text.Trim(),
                EmailUtilisateur = txtEmail.Text.Trim(),
                TelUtilisateur = txtTel.Text.Trim(),
                MotDeUtilisateur = txtPassword.Text
            };
            var result = _service.Add(candidat);
            if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
            else MessageHelper.ShowError(result.Message);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue) { MessageHelper.ShowWarning("Sélectionnez un candidat."); return; }
            if (!ValidateForm()) return;
            var candidat = _service.GetById(_selectedId.Value);
            candidat.MatriculeCandidat = txtMatricule.Text.Trim();
            candidat.NomUtilisateur = txtNom.Text.Trim();
            candidat.PrenomUtilisateur = txtPrenom.Text.Trim();
            candidat.EmailUtilisateur = txtEmail.Text.Trim();
            candidat.TelUtilisateur = txtTel.Text.Trim();
            if (!string.IsNullOrEmpty(txtPassword.Text)) candidat.MotDeUtilisateur = txtPassword.Text;
            var result = _service.Update(candidat);
            if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
            else MessageHelper.ShowError(result.Message);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue) { MessageHelper.ShowWarning("Sélectionnez un candidat."); return; }
            if (MessageHelper.ConfirmDelete("ce candidat"))
            {
                var result = _service.Delete(_selectedId.Value);
                if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
                else MessageHelper.ShowError(result.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void dgvCandidat_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvCandidat.Rows[e.RowIndex];
                _selectedId = (int)row.Cells["IdUtilisateur"].Value;
                txtMatricule.Text = row.Cells["MatriculeCandidat"].Value?.ToString();
                txtNom.Text = row.Cells["NomUtilisateur"].Value?.ToString();
                txtPrenom.Text = row.Cells["PrenomUtilisateur"].Value?.ToString();
                txtEmail.Text = row.Cells["EmailUtilisateur"].Value?.ToString();
                txtTel.Text = row.Cells["TelUtilisateur"].Value?.ToString();
                txtPassword.Text = "";
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtMatricule.Text)) { MessageHelper.ShowWarning("Le matricule est requis."); return false; }
            if (string.IsNullOrWhiteSpace(txtNom.Text)) { MessageHelper.ShowWarning("Le nom est requis."); return false; }
            if (string.IsNullOrWhiteSpace(txtEmail.Text)) { MessageHelper.ShowWarning("L'email est requis."); return false; }
            if (!_selectedId.HasValue && string.IsNullOrWhiteSpace(txtPassword.Text)) { MessageHelper.ShowWarning("Le mot de passe est requis."); return false; }
            return true;
        }

        private void ClearForm()
        {
            _selectedId = null;
            txtMatricule.Clear(); txtNom.Clear(); txtPrenom.Clear();
            txtEmail.Clear(); txtTel.Clear(); txtPassword.Clear();
            txtMatricule.Focus();
        }
    }
}
