using AppSoutenance.Helpers;
using AppSoutenance.Models;
using AppSoutenance.Services;
using System;
using System.Windows.Forms;

namespace AppSoutenance.Views.Parametre
{
    public partial class frmSession : Form
    {
        private readonly SessionService _service;
        private readonly AnneeAcademiqueService _anneeService;
        private int? _selectedId = null;

        public frmSession()
        {
            InitializeComponent();
            _service = new SessionService();
            _anneeService = new AnneeAcademiqueService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            UITheme.ApplyToDataGridView(dgSession);
            UITheme.ApplyPrimaryButton(btnAjouter);
            UITheme.ApplySuccessButton(btnModifier);
            UITheme.ApplyDangerButton(btnSupprimer);
            UITheme.ApplySecondaryButton(btnSelectionner);
            UITheme.ApplySecondaryButton(btnSearch);
        }

        private void frmSession_Load(object sender, EventArgs e)
        {
            LoadComboBox();
            LoadData();
        }

        private void LoadComboBox()
        {
            cbbAnneeAcademique.DataSource = _anneeService.GetListItems();
            cbbAnneeAcademique.DisplayMember = "Text";
            cbbAnneeAcademique.ValueMember = "Value";
        }

        private void LoadData()
        {
            dgSession.DataSource = _service.GetAll();
            if (dgSession.Columns.Count > 0)
            {
                dgSession.Columns["IdSession"].Visible = false;
                dgSession.Columns["IdAnneeAcademique"].Visible = false;
                if (dgSession.Columns.Contains("AnneeAcademique"))
                    dgSession.Columns["AnneeAcademique"].Visible = false;
                dgSession.Columns["LibelleSession"].HeaderText = "Session";
            }
        }

        private void btnAjouter_Click_1(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;

            var session = new Session
            {
                LibelleSession = txtSession.Text.Trim(),
                IdAnneeAcademique = int.TryParse(cbbAnneeAcademique.SelectedValue?.ToString(), out int id) ? id : (int?)null
            };

            var result = _service.Add(session);
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

        private void btnModifier_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageHelper.ShowWarning("Sélectionnez une session.");
                return;
            }
            if (!ValidateForm()) return;

            var session = _service.GetById(_selectedId.Value);
            session.LibelleSession = txtSession.Text.Trim();
            session.IdAnneeAcademique = int.TryParse(cbbAnneeAcademique.SelectedValue?.ToString(), out int id) ? id : (int?)null;

            var result = _service.Update(session);
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

        private void btnSupprimer_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue)
            {
                MessageHelper.ShowWarning("Sélectionnez une session.");
                return;
            }

            if (MessageHelper.ConfirmDelete("cette session"))
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

        private void btnSelectionner_Click(object sender, EventArgs e)
        {
            if (dgSession.CurrentRow == null) return;

            _selectedId = (int)dgSession.CurrentRow.Cells["IdSession"].Value;
            txtSession.Text = dgSession.CurrentRow.Cells["LibelleSession"].Value?.ToString();
            var idAnnee = dgSession.CurrentRow.Cells["IdAnneeAcademique"].Value;
            if (idAnnee != null)
                cbbAnneeAcademique.SelectedValue = idAnnee.ToString();
        }

        private void dgSession_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                btnSelectionner_Click(sender, e);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var sessions = _service.Rechercher(txtRSession.Text, txtRAnneeAcademique.Text);
            dgSession.DataSource = sessions;
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtSession.Text))
            {
                MessageHelper.ShowWarning("Le libellé de la session est requis.");
                return false;
            }
            if (cbbAnneeAcademique.SelectedIndex <= 0)
            {
                MessageHelper.ShowWarning("L'année académique est requise.");
                return false;
            }
            return true;
        }

        private void ClearForm()
        {
            _selectedId = null;
            txtSession.Clear();
            cbbAnneeAcademique.SelectedIndex = 0;
            txtSession.Focus();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void txtSession_TextChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
    }
}
