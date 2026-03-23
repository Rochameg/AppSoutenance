namespace AppSoutenance.Views.Utilisateurs
{
    partial class frmCandidat
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
            txtPassword = new TextBox();
            lblPassword = new Label();
            txtTel = new TextBox();
            lblTel = new Label();
            txtEmail = new TextBox();
            lblEmail = new Label();
            txtPrenom = new TextBox();
            lblPrenom = new Label();
            txtNom = new TextBox();
            lblNom = new Label();
            txtMatricule = new TextBox();
            lblMatricule = new Label();
            lblTitle = new Label();
            dgvCandidat = new DataGridView();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCandidat).BeginInit();
            SuspendLayout();

            pnlForm.BackColor = Color.White;
            pnlForm.Controls.Add(btnClear);
            pnlForm.Controls.Add(btnDelete);
            pnlForm.Controls.Add(btnEdit);
            pnlForm.Controls.Add(btnAdd);
            pnlForm.Controls.Add(txtPassword);
            pnlForm.Controls.Add(lblPassword);
            pnlForm.Controls.Add(txtTel);
            pnlForm.Controls.Add(lblTel);
            pnlForm.Controls.Add(txtEmail);
            pnlForm.Controls.Add(lblEmail);
            pnlForm.Controls.Add(txtPrenom);
            pnlForm.Controls.Add(lblPrenom);
            pnlForm.Controls.Add(txtNom);
            pnlForm.Controls.Add(lblNom);
            pnlForm.Controls.Add(txtMatricule);
            pnlForm.Controls.Add(lblMatricule);
            pnlForm.Controls.Add(lblTitle);
            pnlForm.Dock = DockStyle.Left;
            pnlForm.Size = new Size(350, 600);

            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 58, 95);
            lblTitle.Location = new Point(20, 20);
            lblTitle.Size = new Size(310, 35);
            lblTitle.Text = "Gestion des Candidats";

            lblMatricule.Location = new Point(20, 70);
            lblMatricule.Size = new Size(100, 20);
            lblMatricule.Text = "Matricule";
            txtMatricule.Location = new Point(20, 93);
            txtMatricule.Size = new Size(310, 27);

            lblNom.Location = new Point(20, 125);
            lblNom.Size = new Size(100, 20);
            lblNom.Text = "Nom";
            txtNom.Location = new Point(20, 148);
            txtNom.Size = new Size(310, 27);

            lblPrenom.Location = new Point(20, 180);
            lblPrenom.Size = new Size(100, 20);
            lblPrenom.Text = "Prénom";
            txtPrenom.Location = new Point(20, 203);
            txtPrenom.Size = new Size(310, 27);

            lblEmail.Location = new Point(20, 235);
            lblEmail.Size = new Size(100, 20);
            lblEmail.Text = "Email";
            txtEmail.Location = new Point(20, 258);
            txtEmail.Size = new Size(310, 27);

            lblTel.Location = new Point(20, 290);
            lblTel.Size = new Size(100, 20);
            lblTel.Text = "Téléphone";
            txtTel.Location = new Point(20, 313);
            txtTel.Size = new Size(310, 27);

            lblPassword.Location = new Point(20, 345);
            lblPassword.Size = new Size(150, 20);
            lblPassword.Text = "Mot de passe";
            txtPassword.Location = new Point(20, 368);
            txtPassword.Size = new Size(310, 27);
            txtPassword.UseSystemPasswordChar = true;

            btnAdd.Location = new Point(20, 420);
            btnAdd.Size = new Size(150, 40);
            btnAdd.Text = "Ajouter";
            btnAdd.Click += btnAdd_Click;

            btnEdit.Location = new Point(180, 420);
            btnEdit.Size = new Size(150, 40);
            btnEdit.Text = "Modifier";
            btnEdit.Click += btnEdit_Click;

            btnDelete.Location = new Point(20, 470);
            btnDelete.Size = new Size(150, 40);
            btnDelete.Text = "Supprimer";
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(180, 470);
            btnClear.Size = new Size(150, 40);
            btnClear.Text = "Effacer";
            btnClear.Click += btnClear_Click;

            dgvCandidat.Dock = DockStyle.Fill;
            dgvCandidat.CellClick += dgvCandidat_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1000, 600);
            Controls.Add(dgvCandidat);
            Controls.Add(pnlForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmCandidat";
            Load += frmCandidat_Load;
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCandidat).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlForm;
        private Label lblTitle;
        private Label lblMatricule;
        private TextBox txtMatricule;
        private Label lblNom;
        private TextBox txtNom;
        private Label lblPrenom;
        private TextBox txtPrenom;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblTel;
        private TextBox txtTel;
        private Label lblPassword;
        private TextBox txtPassword;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvCandidat;
    }
}
