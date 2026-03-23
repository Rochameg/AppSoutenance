using AppSoutenance.Helpers;
using AppSoutenance.Models;
using AppSoutenance.Services;
using System;
using System.Windows.Forms;

namespace AppSoutenance.Views.Parametre
{
    public partial class frmProfesseur : Form
    {
        private readonly ProfesseurService _service;
        private int? _selectedId = null;

        public frmProfesseur()
        {
            InitializeComponent();
            _service = new ProfesseurService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            UITheme.ApplyToDataGridView(dgvProfesseur);
            UITheme.ApplyPrimaryButton(btnAdd);
            UITheme.ApplySuccessButton(btnEdit);
            UITheme.ApplyDangerButton(btnDelete);
            UITheme.ApplySecondaryButton(btnClear);
        }

        private void frmProfesseur_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvProfesseur.DataSource = _service.GetAll();
            ConfigureGrid();
        }

        private void ConfigureGrid()
        {
            if (dgvProfesseur.Columns.Count > 0)
            {
                dgvProfesseur.Columns["IdUtilisateur"].Visible = false;
                dgvProfesseur.Columns["MotDeUtilisateur"].Visible = false;
                dgvProfesseur.Columns["NomUtilisateur"].HeaderText = "Nom";
                dgvProfesseur.Columns["PrenomUtilisateur"].HeaderText = "Prénom";
                dgvProfesseur.Columns["EmailUtilisateur"].HeaderText = "Email";
                dgvProfesseur.Columns["TelUtilisateur"].HeaderText = "Téléphone";
                dgvProfesseur.Columns["SpecialiteProfesseur"].HeaderText = "Spécialité";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var prof = new Professeur
            {
                NomUtilisateur = txtNom.Text.Trim(),
                PrenomUtilisateur = txtPrenom.Text.Trim(),
                EmailUtilisateur = txtEmail.Text.Trim(),
                TelUtilisateur = txtTel.Text.Trim(),
                SpecialiteProfesseur = txtSpecialite.Text.Trim(),
                MotDeUtilisateur = txtPassword.Text
            };

            var result = _service.Add(prof);
            if (result.IsSuccess)
            {
                MessageHelper.ShowSuccess(result.Message);
                ClearForm();
                LoadData();
            }
            else
            {
                MessageHelper.ShowError(result.Message);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageHelper.ShowWarning("Sélectionnez un professeur.");
                return;
            }
            if (!ValidateForm()) return;

            var prof = _service.GetById(_selectedId.Value);
            prof.NomUtilisateur = txtNom.Text.Trim();
            prof.PrenomUtilisateur = txtPrenom.Text.Trim();
            prof.EmailUtilisateur = txtEmail.Text.Trim();
            prof.TelUtilisateur = txtTel.Text.Trim();
            prof.SpecialiteProfesseur = txtSpecialite.Text.Trim();
            if (!string.IsNullOrEmpty(txtPassword.Text))
                prof.MotDeUtilisateur = txtPassword.Text;

            var result = _service.Update(prof);
            if (result.IsSuccess)
            {
                MessageHelper.ShowSuccess(result.Message);
                ClearForm();
                LoadData();
            }
            else
            {
                MessageHelper.ShowError(result.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageHelper.ShowWarning("Sélectionnez un professeur.");
                return;
            }

            if (MessageHelper.ConfirmDelete("ce professeur"))
            {
                var result = _service.Delete(_selectedId.Value);
                if (result.IsSuccess)
                {
                    MessageHelper.ShowSuccess(result.Message);
                    ClearForm();
                    LoadData();
                }
                else
                {
                    MessageHelper.ShowError(result.Message);
                }
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void dgvProfesseur_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvProfesseur.Rows[e.RowIndex];
                _selectedId = (int)row.Cells["IdUtilisateur"].Value;
                txtNom.Text = row.Cells["NomUtilisateur"].Value?.ToString();
                txtPrenom.Text = row.Cells["PrenomUtilisateur"].Value?.ToString();
                txtEmail.Text = row.Cells["EmailUtilisateur"].Value?.ToString();
                txtTel.Text = row.Cells["TelUtilisateur"].Value?.ToString();
                txtSpecialite.Text = row.Cells["SpecialiteProfesseur"].Value?.ToString();
                txtPassword.Text = "";
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtNom.Text))
            {
                MessageHelper.ShowWarning("Le nom est requis.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtPrenom.Text))
            {
                MessageHelper.ShowWarning("Le prénom est requis.");
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                MessageHelper.ShowWarning("L'email est requis.");
                return false;
            }
            if (!_selectedId.HasValue && string.IsNullOrWhiteSpace(txtPassword.Text))
            {
                MessageHelper.ShowWarning("Le mot de passe est requis.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            _selectedId = null;
            txtNom.Clear();
            txtPrenom.Clear();
            txtEmail.Clear();
            txtTel.Clear();
            txtSpecialite.Clear();
            txtPassword.Clear();
            txtNom.Focus();
        }
    }
}
