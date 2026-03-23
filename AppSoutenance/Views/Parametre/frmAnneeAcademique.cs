using AppSoutenance.Helpers;
using AppSoutenance.Models;
using AppSoutenance.Services;
using System;
using System.Windows.Forms;

namespace AppSoutenance.Views.Parametre
{
    public partial class frmAnneeAcademique : Form
    {
        private readonly AnneeAcademiqueService _service;
        private int? _selectedId = null;

        public frmAnneeAcademique()
        {
            InitializeComponent();
            _service = new AnneeAcademiqueService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            UITheme.ApplyToDataGridView(dgAnneAcademique);
            UITheme.ApplyPrimaryButton(btnAdd);
            UITheme.ApplySuccessButton(btnEdit);
            UITheme.ApplyDangerButton(btnRemove);
            UITheme.ApplySecondaryButton(btnSelect);
        }

        private void frmAnneeAcademique_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgAnneAcademique.DataSource = _service.GetAll();
            if (dgAnneAcademique.Columns.Count > 0)
            {
                dgAnneAcademique.Columns["IdAnneeAcademique"].Visible = false;
                dgAnneAcademique.Columns["LibelleAnneeAcademique"].HeaderText = "Libellé";
                dgAnneAcademique.Columns["AnneeAcademiqueVal"].HeaderText = "Valeur";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var annee = new AnneeAcademique
            {
                LibelleAnneeAcademique = txtAnneeAcademiqueText.Text.Trim(),
                AnneeAcademiqueVal = int.Parse(txtAnneeAcademiqueVal.Text)
            };

            var result = _service.Add(annee);
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
                MessageHelper.ShowWarning("Sélectionnez une année académique.");
                return;
            }
            if (!ValidateForm()) return;

            var annee = _service.GetById(_selectedId.Value);
            annee.LibelleAnneeAcademique = txtAnneeAcademiqueText.Text.Trim();
            annee.AnneeAcademiqueVal = int.Parse(txtAnneeAcademiqueVal.Text);

            var result = _service.Update(annee);
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

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageHelper.ShowWarning("Sélectionnez une année académique.");
                return;
            }

            if (MessageHelper.ConfirmDelete("cette année académique"))
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            if (dgAnneAcademique.CurrentRow == null) return;

            _selectedId = (int)dgAnneAcademique.CurrentRow.Cells["IdAnneeAcademique"].Value;
            txtAnneeAcademiqueText.Text = dgAnneAcademique.CurrentRow.Cells["LibelleAnneeAcademique"].Value?.ToString();
            txtAnneeAcademiqueVal.Text = dgAnneAcademique.CurrentRow.Cells["AnneeAcademiqueVal"].Value?.ToString();
        }

        private void dgAnneAcademique_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSelect_Click(sender, e);
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtAnneeAcademiqueText.Text))
            {
                MessageHelper.ShowWarning("Le libellé est requis.");
                return false;
            }
            if (!int.TryParse(txtAnneeAcademiqueVal.Text, out int val) || val < 2000 || val > 2100)
            {
                MessageHelper.ShowWarning("La valeur doit être un nombre entre 2000 et 2100.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            _selectedId = null;
            txtAnneeAcademiqueText.Clear();
            txtAnneeAcademiqueVal.Clear();
            txtAnneeAcademiqueText.Focus();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            // Méthode requise par le Designer
            // Ajoutez votre logique de filtrage ici si nécessaire
        }
    }
}