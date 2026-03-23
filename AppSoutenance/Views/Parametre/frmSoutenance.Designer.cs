namespace AppSoutenance.Views.Parametre
{
    partial class frmSoutenance
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
            txtObservation = new TextBox();
            lblObservation = new Label();
            cbbMention = new ComboBox();
            lblMention = new Label();
            cbbResultat = new ComboBox();
            lblResultat = new Label();
            txtLieu = new TextBox();
            lblLieu = new Label();
            dtpDate = new DateTimePicker();
            lblDate = new Label();
            cbbMemoire = new ComboBox();
            lblMemoire = new Label();
            lblTitle = new Label();
            dgvSoutenance = new DataGridView();
            pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSoutenance).BeginInit();
            SuspendLayout();

            pnlForm.BackColor = Color.White;
            pnlForm.Controls.Add(btnClear);
            pnlForm.Controls.Add(btnDelete);
            pnlForm.Controls.Add(btnEdit);
            pnlForm.Controls.Add(btnAdd);
            pnlForm.Controls.Add(txtObservation);
            pnlForm.Controls.Add(lblObservation);
            pnlForm.Controls.Add(cbbMention);
            pnlForm.Controls.Add(lblMention);
            pnlForm.Controls.Add(cbbResultat);
            pnlForm.Controls.Add(lblResultat);
            pnlForm.Controls.Add(txtLieu);
            pnlForm.Controls.Add(lblLieu);
            pnlForm.Controls.Add(dtpDate);
            pnlForm.Controls.Add(lblDate);
            pnlForm.Controls.Add(cbbMemoire);
            pnlForm.Controls.Add(lblMemoire);
            pnlForm.Controls.Add(lblTitle);
            pnlForm.Dock = DockStyle.Left;
            pnlForm.Size = new Size(380, 650);

            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 58, 95);
            lblTitle.Location = new Point(20, 15);
            lblTitle.Size = new Size(340, 35);
            lblTitle.Text = "Gestion des Soutenances";

            lblMemoire.Location = new Point(20, 55);
            lblMemoire.Size = new Size(100, 20);
            lblMemoire.Text = "Mémoire";
            cbbMemoire.Location = new Point(20, 78);
            cbbMemoire.Size = new Size(340, 28);
            cbbMemoire.DropDownStyle = ComboBoxStyle.DropDownList;

            lblDate.Location = new Point(20, 115);
            lblDate.Size = new Size(100, 20);
            lblDate.Text = "Date";
            dtpDate.Location = new Point(20, 138);
            dtpDate.Size = new Size(340, 27);
            dtpDate.Format = DateTimePickerFormat.Custom;
            dtpDate.CustomFormat = "dd/MM/yyyy HH:mm";

            lblLieu.Location = new Point(20, 175);
            lblLieu.Size = new Size(100, 20);
            lblLieu.Text = "Lieu";
            txtLieu.Location = new Point(20, 198);
            txtLieu.Size = new Size(340, 27);

            lblResultat.Location = new Point(20, 235);
            lblResultat.Size = new Size(100, 20);
            lblResultat.Text = "Résultat";
            cbbResultat.Location = new Point(20, 258);
            cbbResultat.Size = new Size(160, 28);
            cbbResultat.DropDownStyle = ComboBoxStyle.DropDownList;

            lblMention.Location = new Point(200, 235);
            lblMention.Size = new Size(100, 20);
            lblMention.Text = "Mention";
            cbbMention.Location = new Point(200, 258);
            cbbMention.Size = new Size(160, 28);
            cbbMention.DropDownStyle = ComboBoxStyle.DropDownList;

            lblObservation.Location = new Point(20, 295);
            lblObservation.Size = new Size(100, 20);
            lblObservation.Text = "Observation";
            txtObservation.Location = new Point(20, 318);
            txtObservation.Size = new Size(340, 80);
            txtObservation.Multiline = true;

            btnAdd.Location = new Point(20, 420);
            btnAdd.Size = new Size(160, 40);
            btnAdd.Text = "Ajouter";
            btnAdd.Click += btnAdd_Click;

            btnEdit.Location = new Point(200, 420);
            btnEdit.Size = new Size(160, 40);
            btnEdit.Text = "Modifier";
            btnEdit.Click += btnEdit_Click;

            btnDelete.Location = new Point(20, 470);
            btnDelete.Size = new Size(160, 40);
            btnDelete.Text = "Supprimer";
            btnDelete.Click += btnDelete_Click;

            btnClear.Location = new Point(200, 470);
            btnClear.Size = new Size(160, 40);
            btnClear.Text = "Effacer";
            btnClear.Click += btnClear_Click;

            dgvSoutenance.Dock = DockStyle.Fill;
            dgvSoutenance.CellClick += dgvSoutenance_CellClick;

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1100, 650);
            Controls.Add(dgvSoutenance);
            Controls.Add(pnlForm);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmSoutenance";
            Load += frmSoutenance_Load;
            pnlForm.ResumeLayout(false);
            pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSoutenance).EndInit();
            ResumeLayout(false);
        }

        private Panel pnlForm;
        private Label lblTitle;
        private Label lblMemoire;
        private ComboBox cbbMemoire;
        private Label lblDate;
        private DateTimePicker dtpDate;
        private Label lblLieu;
        private TextBox txtLieu;
        private Label lblResultat;
        private ComboBox cbbResultat;
        private Label lblMention;
        private ComboBox cbbMention;
        private Label lblObservation;
        private TextBox txtObservation;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnClear;
        private DataGridView dgvSoutenance;
    }
}
