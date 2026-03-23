namespace AppSoutenance.Views.Parametre
{
    partial class frmMemoire
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
            cbbSession = new ComboBox();
            lblSession = new Label();
            cbbAnnee = new ComboBox();
            lblAnnee = new Label();
            txtSujet = new TextBox();
            lblSujet = new Label();
            lblTitle = new Label();
            dgvMemoire = new DataGridView();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMemoire).BeginInit();
            SuspendLayout();

            pnlForm.BackColor = Color.White;
            pnlForm.Controls.Add(btnClear);
            pnlForm.Controls.Add(btnDelete);
            pnlForm.Controls.Add(btnEdit);
            pnlForm.Controls.Add(btnAdd);
            pnlForm.Controls.Add(cbbSession);
            pnlForm.Controls.Add(lblSession);
            pnlForm.Controls.Add(cbbAnnee);
            pnlForm.Controls.Add(lblAnnee);
            pnlForm.Controls.Add(txtSujet);
            pnlForm.Controls.Add(lblSujet);
            pnlForm.Controls.Add(lblTitle);
            pnlForm.Dock = DockStyle.Left;
            pnlForm.Size = new Size(380, 600);

            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 58, 95);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(340, 35);
            lblTitle.Text = "Gestion des Mémoires";

            lblSujet.Location = new Point(20, 70);
            lblSujet.Size = new Size(100, 20);
            lblSujet.Text = "Sujet";
            txtSujet.Location = new Point(20, 93);
            txtSujet.Size = new Size(340, 60);
            txtSujet.Multiline = true;

            lblAnnee.Location = new Point(20, 165);
            lblAnnee.Size = new Size(150, 20);
            lblAnnee.Text = "Année Académique";
            cbbAnnee.Location = new Point(20, 188);
            cbbAnnee.Size = new Size(340, 28);
            cbbAnnee.DropDownStyle = ComboBoxStyle.DropDownList;

            lblSession.Location = new Point(20, 225);
            lblSession.Size = new Size(100, 20);
            lblSession.Text = "Session";
            cbbSession.Location = new Point(20, 248);
            cbbSession.Size = new Size(340, 28);
            cbbSession.DropDownStyle = ComboBoxStyle.DropDownList;

            btnAdd.Location = new Point(20, 310);
            btnAdd.Size = new Size(160, 40);
            btnAdd.Text = "Ajouter";
            btnAdd.Click += btnAdd_Click;

            btnEdit.Location = new Point(200, 310);
            btnEdit.Size = new Size(160, 40);
            btnEdit.Text = "Modifier";
            btnEdit.Click += btnEdit_Click;

            btnDelete.Location = new Point(20, 360);
            btnDelete.Size = new Size(160, 40);
            btnDelete.Text = "Supprimer";
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(200, 360);
            btnClear.Size = new Size(160, 40);
            btnClear.Text = "Effacer";
            btnClear.Click += btnClear_Click;

            dgvMemoire.Dock = DockStyle.Fill;
            dgvMemoire.CellClick += dgvMemoire_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvMemoire);
            Controls.Add(pnlForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmMemoire";
            Load += frmMemoire_Load;
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvMemoire).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlForm;
        private Label lblTitle;
        private Label lblSujet;
        private TextBox txtSujet;
        private Label lblAnnee;
        private ComboBox cbbAnnee;
        private Label lblSession;
        private ComboBox cbbSession;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvMemoire;
    }
}
