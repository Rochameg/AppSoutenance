using AppSoutenance.Helpers;
using AppSoutenance.Models;
using AppSoutenance.Services;
using System;
using System.Windows.Forms;

namespace AppSoutenance.Views.Parametre
{
    public partial class frmDepartement : Form
    {
        private readonly DepartementService _service;
        private int? _selectedId = null;

        public frmDepartement()
        {
            InitializeComponent();
            _service = new DepartementService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            UITheme.ApplyToDataGridView(dgvDepartement);
            UITheme.ApplyPrimaryButton(btnAdd);
            UITheme.ApplySuccessButton(btnEdit);
            UITheme.ApplyDangerButton(btnDelete);
            UITheme.ApplySecondaryButton(btnClear);
        }

        private void frmDepartement_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvDepartement.DataSource = _service.GetAll();
            dgvDepartement.Columns["IdDepartement"].Visible = false;
            dgvDepartement.Columns["LibelleDepartement"].HeaderText = "Département";
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtLibelle.Text))
            {
                MessageHelper.ShowWarning("Le libellé est requis.");
                return;
            }

            var dept = new Departement { LibelleDepartement = txtLibelle.Text.Trim() };
            var result = _service.Add(dept);

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
                MessageHelper.ShowWarning("Sélectionnez un département.");
                return;
            }

            var dept = _service.GetById(_selectedId.Value);
            dept.LibelleDepartement = txtLibelle.Text.Trim();
            var result = _service.Update(dept);

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
                MessageHelper.ShowWarning("Sélectionnez un département.");
                return;
            }

            if (MessageHelper.ConfirmDelete("ce département"))
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

        private void dgvDepartement_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                _selectedId = (int)dgvDepartement.Rows[e.RowIndex].Cells["IdDepartement"].Value;
                txtLibelle.Text = dgvDepartement.Rows[e.RowIndex].Cells["LibelleDepartement"].Value?.ToString();
            }
        }

        private void ClearForm()
        {
            _selectedId = null;
            txtLibelle.Clear();
            txtLibelle.Focus();
        }
    }
}
