using AppSoutenance.Helpers;
using AppSoutenance.Models;
using AppSoutenance.Services;
using System;
using System.Windows.Forms;

namespace AppSoutenance.Views.Parametre
{
    public partial class frmMemoire : Form
    {
        private readonly MemoireService _service;
        private readonly AnneeAcademiqueService _anneeService;
        private readonly SessionService _sessionService;
        private int? _selectedId = null;

        public frmMemoire()
        {
            InitializeComponent();
            _service = new MemoireService();
            _anneeService = new AnneeAcademiqueService();
            _sessionService = new SessionService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            UITheme.ApplyToDataGridView(dgvMemoire);
            UITheme.ApplyPrimaryButton(btnAdd);
            UITheme.ApplySuccessButton(btnEdit);
            UITheme.ApplyDangerButton(btnDelete);
            UITheme.ApplySecondaryButton(btnClear);
        }

        private void frmMemoire_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            cbbAnnee.DataSource = _anneeService.GetListItems();
            cbbAnnee.DisplayMember = "Text";
            cbbAnnee.ValueMember = "Value";

            cbbSession.DataSource = _sessionService.GetListItems();
            cbbSession.DisplayMember = "Text";
            cbbSession.ValueMember = "Value";
        }

        private void LoadData()
        {
            dgvMemoire.DataSource = _service.GetAll();
            if (dgvMemoire.Columns.Count > 0)
            {
                dgvMemoire.Columns["IdMemoire"].Visible = false;
                dgvMemoire.Columns["IdAnneeAcademique"].Visible = false;
                dgvMemoire.Columns["IdSession"].Visible = false;
                dgvMemoire.Columns["DocumentMemoire"].Visible = false;
                dgvMemoire.Columns["SujetMemoire"].HeaderText = "Sujet";
                if (dgvMemoire.Columns.Contains("AnneeAcademique"))
                    dgvMemoire.Columns["AnneeAcademique"].Visible = false;
                if (dgvMemoire.Columns.Contains("Session"))
                    dgvMemoire.Columns["Session"].Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            var memoire = new Memoire
            {
                SujetMemoire = txtSujet.Text.Trim(),
                IdAnneeAcademique = int.TryParse(cbbAnnee.SelectedValue?.ToString(), out int idA) ? idA : (int?)null,
                IdSession = int.TryParse(cbbSession.SelectedValue?.ToString(), out int idS) ? idS : (int?)null
            };
            var result = _service.Add(memoire);
            if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
            else MessageHelper.ShowError(result.Message);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue) { MessageHelper.ShowWarning("Sélectionnez un mémoire."); return; }
            if (!ValidateForm()) return;
            var memoire = _service.GetById(_selectedId.Value);
            memoire.SujetMemoire = txtSujet.Text.Trim();
            memoire.IdAnneeAcademique = int.TryParse(cbbAnnee.SelectedValue?.ToString(), out int idA) ? idA : (int?)null;
            memoire.IdSession = int.TryParse(cbbSession.SelectedValue?.ToString(), out int idS) ? idS : (int?)null;
            var result = _service.Update(memoire);
            if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
            else MessageHelper.ShowError(result.Message);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue) { MessageHelper.ShowWarning("Sélectionnez un mémoire."); return; }
            if (MessageHelper.ConfirmDelete("ce mémoire"))
            {
                var result = _service.Delete(_selectedId.Value);
                if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
                else MessageHelper.ShowError(result.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void dgvMemoire_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvMemoire.Rows[e.RowIndex];
                _selectedId = (int)row.Cells["IdMemoire"].Value;
                txtSujet.Text = row.Cells["SujetMemoire"].Value?.ToString();
                cbbAnnee.SelectedValue = row.Cells["IdAnneeAcademique"].Value?.ToString();
                cbbSession.SelectedValue = row.Cells["IdSession"].Value?.ToString();
            }
        }

        private bool ValidateForm()
        {
            if (string.IsNullOrWhiteSpace(txtSujet.Text)) { MessageHelper.ShowWarning("Le sujet est requis."); return false; }
            if (cbbAnnee.SelectedIndex <= 0) { MessageHelper.ShowWarning("L'année académique est requise."); return false; }
            if (cbbSession.SelectedIndex <= 0) { MessageHelper.ShowWarning("La session est requise."); return false; }
            return true;
        }

        private void ClearForm()
        {
            _selectedId = null;
            txtSujet.Clear();
            cbbAnnee.SelectedIndex = 0;
            cbbSession.SelectedIndex = 0;
            txtSujet.Focus();
        }
    }
}
