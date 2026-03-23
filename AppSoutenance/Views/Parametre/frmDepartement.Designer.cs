namespace AppSoutenance.Views.Parametre
{
    partial class frmDepartement
    {
        private System.ComponentModel.IContainer components = null;
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            pnlForm = new Panel();
            btnClear = new Button();
            btnDelete = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            txtLibelle = new TextBox();
            lblLibelle = new Label();
            lblTitle = new Label();
            dgvDepartement = new DataGridView();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartement).BeginInit();
            SuspendLayout();

            // pnlForm
            pnlForm.BackColor = Color.White;
            pnlForm.Controls.Add(btnClear);
            pnlForm.Controls.Add(btnDelete);
            pnlForm.Controls.Add(btnEdit);
            pnlForm.Controls.Add(btnAdd);
            pnlForm.Controls.Add(txtLibelle);
            pnlForm.Controls.Add(lblLibelle);
            pnlForm.Controls.Add(lblTitle);
            pnlForm.Dock = DockStyle.Left;
            pnlForm.Location = new Point(0, 0);
            pnlForm.Padding = new Padding(20);
            pnlForm.Size = new Size(350, 600);

            // lblTitle
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 58, 95);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(310, 35);
            lblTitle.Text = "Gestion des Départements";

            // lblLibelle
            lblLibelle.Location = new Point(20, 80);
            lblLibelle.Size = new Size(100, 25);
            lblLibelle.Text = "Libellé";

            // txtLibelle
            txtLibelle.Location = new Point(20, 108);
            txtLibelle.Size = new Size(310, 30);

            // btnAdd
            btnAdd.Location = new Point(20, 160);
            btnAdd.Size = new Size(150, 40);
            btnAdd.Text = "Ajouter";
            btnAdd.Click += btnAdd_Click;

            // btnEdit
            btnEdit.Location = new Point(180, 160);
            btnEdit.Size = new Size(150, 40);
            btnEdit.Text = "Modifier";
            btnEdit.Click += btnEdit_Click;

            // btnDelete
            btnDelete.Location = new Point(20, 210);
            btnDelete.Size = new Size(150, 40);
            btnDelete.Text = "Supprimer";
            btnDelete.Click += btnDelete_Click;

            // btnClear
            btnClear.Location = new Point(180, 210);
            btnClear.Size = new Size(150, 40);
            btnClear.Text = "Effacer";
            btnClear.Click += btnClear_Click;

            // dgvDepartement
            dgvDepartement.Dock = DockStyle.Fill;
            dgvDepartement.Location = new Point(350, 0);
            dgvDepartement.CellClick += dgvDepartement_CellClick;

            // frmDepartement
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(900, 600);
            Controls.Add(dgvDepartement);
            Controls.Add(pnlForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDepartement";
            Load += frmDepartement_Load;
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDepartement).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlForm;
        private Label lblTitle;
        private Label lblLibelle;
        private TextBox txtLibelle;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvDepartement;
    }
}
