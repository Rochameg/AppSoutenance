using AppSoutenance.Helpers;
using AppSoutenance.Models;
using AppSoutenance.Services;
using System;
using System.Windows.Forms;

namespace AppSoutenance.Views.Parametre
{
    public partial class frmSoutenance : Form
    {
        private readonly SoutenanceService _service;
        private readonly MemoireService _memoireService;
        private int? _selectedId = null;

        public frmSoutenance()
        {
            InitializeComponent();
            _service = new SoutenanceService();
            _memoireService = new MemoireService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            UITheme.ApplyToDataGridView(dgvSoutenance);
            UITheme.ApplyPrimaryButton(btnAdd);
            UITheme.ApplySuccessButton(btnEdit);
            UITheme.ApplyDangerButton(btnDelete);
            UITheme.ApplySecondaryButton(btnClear);
        }

        private void frmSoutenance_Load(object sender, EventArgs e)
        {
            LoadComboBoxes();
            LoadData();
        }

        private void LoadComboBoxes()
        {
            cbbMemoire.DataSource = _memoireService.GetListItems();
            cbbMemoire.DisplayMember = "Text";
            cbbMemoire.ValueMember = "Value";

            cbbResultat.Items.Clear();
            cbbResultat.Items.AddRange(new[] { "-- Sélectionner --", "Admis", "Ajourné" });
            cbbResultat.SelectedIndex = 0;

            cbbMention.Items.Clear();
            cbbMention.Items.AddRange(new[] { "-- Sélectionner --", "Passable", "Assez Bien", "Bien", "Très Bien", "Excellent" });
            cbbMention.SelectedIndex = 0;
        }

        private void LoadData()
        {
            dgvSoutenance.DataSource = _service.GetAll();
            if (dgvSoutenance.Columns.Count > 0)
            {
                dgvSoutenance.Columns["IdSoutenance"].Visible = false;
                dgvSoutenance.Columns["IdMemoire"].Visible = false;
                if (dgvSoutenance.Columns.Contains("Memoire")) dgvSoutenance.Columns["Memoire"].Visible = false;
                dgvSoutenance.Columns["DateSoutenance"].HeaderText = "Date";
                dgvSoutenance.Columns["LieuSoutenance"].HeaderText = "Lieu";
                dgvSoutenance.Columns["ResultatSoutenance"].HeaderText = "Résultat";
                dgvSoutenance.Columns["MentionSoutenance"].HeaderText = "Mention";
                dgvSoutenance.Columns["ObservationSoutenance"].HeaderText = "Observation";
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateForm()) return;
            var soutenance = new Soutenance
            {
                IdMemoire = int.TryParse(cbbMemoire.SelectedValue?.ToString(), out int id) ? id : (int?)null,
                DateSoutenance = dtpDate.Value,
                LieuSoutenance = txtLieu.Text.Trim(),
                ResultatSoutenance = cbbResultat.SelectedIndex > 0 ? cbbResultat.Text : null,
                MentionSoutenance = cbbMention.SelectedIndex > 0 ? cbbMention.Text : null,
                ObservationSoutenance = txtObservation.Text.Trim()
            };
            var result = _service.Add(soutenance);
            if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
            else MessageHelper.ShowError(result.Message);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue) { MessageHelper.ShowWarning("Sélectionnez une soutenance."); return; }
            if (!ValidateForm()) return;
            var soutenance = _service.GetById(_selectedId.Value);
            soutenance.IdMemoire = int.TryParse(cbbMemoire.SelectedValue?.ToString(), out int id) ? id : (int?)null;
            soutenance.DateSoutenance = dtpDate.Value;
            soutenance.LieuSoutenance = txtLieu.Text.Trim();
            soutenance.ResultatSoutenance = cbbResultat.SelectedIndex > 0 ? cbbResultat.Text : null;
            soutenance.MentionSoutenance = cbbMention.SelectedIndex > 0 ? cbbMention.Text : null;
            soutenance.ObservationSoutenance = txtObservation.Text.Trim();
            var result = _service.Update(soutenance);
            if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
            else MessageHelper.ShowError(result.Message);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!_selectedId.HasValue) { MessageHelper.ShowWarning("Sélectionnez une soutenance."); return; }
            if (MessageHelper.ConfirmDelete("cette soutenance"))
            {
                var result = _service.Delete(_selectedId.Value);
                if (result.IsSuccess) { MessageHelper.ShowSuccess(result.Message); ClearForm(); LoadData(); }
                else MessageHelper.ShowError(result.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e) => ClearForm();

        private void dgvSoutenance_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvSoutenance.Rows[e.RowIndex];
                _selectedId = (int)row.Cells["IdSoutenance"].Value;
                cbbMemoire.SelectedValue = row.Cells["IdMemoire"].Value?.ToString();
                dtpDate.Value = row.Cells["DateSoutenance"].Value != null ? (DateTime)row.Cells["DateSoutenance"].Value : DateTime.Now;
                txtLieu.Text = row.Cells["LieuSoutenance"].Value?.ToString();
                cbbResultat.Text = row.Cells["ResultatSoutenance"].Value?.ToString() ?? "";
                cbbMention.Text = row.Cells["MentionSoutenance"].Value?.ToString() ?? "";
                txtObservation.Text = row.Cells["ObservationSoutenance"].Value?.ToString();
            }
        }

        private bool ValidateForm()
        {
            if (cbbMemoire.SelectedIndex <= 0) { MessageHelper.ShowWarning("Le mémoire est requis."); return false; }
            if (string.IsNullOrWhiteSpace(txtLieu.Text)) { MessageHelper.ShowWarning("Le lieu est requis."); return false; }
            return true;
        }

        private void ClearForm()
        {
            _selectedId = null;
            cbbMemoire.SelectedIndex = 0;
            dtpDate.Value = DateTime.Now;
            txtLieu.Clear();
            cbbResultat.SelectedIndex = 0;
            cbbMention.SelectedIndex = 0;
            txtObservation.Clear();
        }
    }
}
