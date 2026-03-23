namespace AppSoutenance.Views.Dashboard
{
    partial class frmDashboard
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            pnlStats = new FlowLayoutPanel();
            pnlCardProfesseurs = new Panel();
            lblStatProfesseurs = new Label();
            lblTitleProfesseurs = new Label();
            pnlCardCandidats = new Panel();
            lblStatCandidats = new Label();
            lblTitleCandidats = new Label();
            pnlCardMemoires = new Panel();
            lblStatMemoires = new Label();
            lblTitleMemoires = new Label();
            pnlCardSoutenances = new Panel();
            lblStatSoutenances = new Label();
            lblTitleSoutenances = new Label();
            pnlLists = new Panel();
            pnlDernieresSoutenances = new Panel();
            dgvDernieresSoutenances = new DataGridView();
            lblTitleDernieres = new Label();
            pnlProchainesSoutenances = new Panel();
            dgvProchainesSoutenances = new DataGridView();
            lblTitleProchaines = new Label();
            pnlHeader = new Panel();
            btnRefresh = new Button();
            lblAnneeActuelle = new Label();
            lblStatAnnee = new Label();
            pnlStats.SuspendLayout();
            pnlCardProfesseurs.SuspendLayout();
            pnlCardCandidats.SuspendLayout();
            pnlCardMemoires.SuspendLayout();
            pnlCardSoutenances.SuspendLayout();
            pnlLists.SuspendLayout();
            pnlDernieresSoutenances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDernieresSoutenances).BeginInit();
            pnlProchainesSoutenances.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProchainesSoutenances).BeginInit();
            pnlHeader.SuspendLayout();
            SuspendLayout();
            //
            // lblTitle
            //
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(30, 58, 95);
            lblTitle.Location = new Point(10, 10);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(263, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "Tableau de Bord";
            //
            // pnlStats
            //
            pnlStats.Controls.Add(pnlCardProfesseurs);
            pnlStats.Controls.Add(pnlCardCandidats);
            pnlStats.Controls.Add(pnlCardMemoires);
            pnlStats.Controls.Add(pnlCardSoutenances);
            pnlStats.Dock = DockStyle.Top;
            pnlStats.Location = new Point(0, 80);
            pnlStats.Name = "pnlStats";
            pnlStats.Padding = new Padding(5);
            pnlStats.Size = new Size(1020, 150);
            pnlStats.TabIndex = 1;
            //
            // pnlCardProfesseurs
            //
            pnlCardProfesseurs.BackColor = Color.FromArgb(30, 58, 95);
            pnlCardProfesseurs.Controls.Add(lblStatProfesseurs);
            pnlCardProfesseurs.Controls.Add(lblTitleProfesseurs);
            pnlCardProfesseurs.Location = new Point(8, 8);
            pnlCardProfesseurs.Margin = new Padding(3);
            pnlCardProfesseurs.Name = "pnlCardProfesseurs";
            pnlCardProfesseurs.Padding = new Padding(15);
            pnlCardProfesseurs.Size = new Size(230, 130);
            pnlCardProfesseurs.TabIndex = 0;
            //
            // lblStatProfesseurs
            //
            lblStatProfesseurs.Dock = DockStyle.Fill;
            lblStatProfesseurs.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblStatProfesseurs.ForeColor = Color.White;
            lblStatProfesseurs.Location = new Point(15, 15);
            lblStatProfesseurs.Name = "lblStatProfesseurs";
            lblStatProfesseurs.Size = new Size(200, 70);
            lblStatProfesseurs.TabIndex = 0;
            lblStatProfesseurs.Text = "0";
            lblStatProfesseurs.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTitleProfesseurs
            //
            lblTitleProfesseurs.Dock = DockStyle.Bottom;
            lblTitleProfesseurs.Font = new Font("Segoe UI", 10F);
            lblTitleProfesseurs.ForeColor = Color.FromArgb(220, 220, 220);
            lblTitleProfesseurs.Location = new Point(15, 85);
            lblTitleProfesseurs.Name = "lblTitleProfesseurs";
            lblTitleProfesseurs.Size = new Size(200, 30);
            lblTitleProfesseurs.TabIndex = 1;
            lblTitleProfesseurs.Text = "Professeurs";
            lblTitleProfesseurs.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlCardCandidats
            //
            pnlCardCandidats.BackColor = Color.FromArgb(41, 128, 185);
            pnlCardCandidats.Controls.Add(lblStatCandidats);
            pnlCardCandidats.Controls.Add(lblTitleCandidats);
            pnlCardCandidats.Location = new Point(244, 8);
            pnlCardCandidats.Margin = new Padding(3);
            pnlCardCandidats.Name = "pnlCardCandidats";
            pnlCardCandidats.Padding = new Padding(15);
            pnlCardCandidats.Size = new Size(230, 130);
            pnlCardCandidats.TabIndex = 1;
            //
            // lblStatCandidats
            //
            lblStatCandidats.Dock = DockStyle.Fill;
            lblStatCandidats.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblStatCandidats.ForeColor = Color.White;
            lblStatCandidats.Location = new Point(15, 15);
            lblStatCandidats.Name = "lblStatCandidats";
            lblStatCandidats.Size = new Size(200, 70);
            lblStatCandidats.TabIndex = 0;
            lblStatCandidats.Text = "0";
            lblStatCandidats.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTitleCandidats
            //
            lblTitleCandidats.Dock = DockStyle.Bottom;
            lblTitleCandidats.Font = new Font("Segoe UI", 10F);
            lblTitleCandidats.ForeColor = Color.FromArgb(220, 220, 220);
            lblTitleCandidats.Location = new Point(15, 85);
            lblTitleCandidats.Name = "lblTitleCandidats";
            lblTitleCandidats.Size = new Size(200, 30);
            lblTitleCandidats.TabIndex = 1;
            lblTitleCandidats.Text = "Candidats";
            lblTitleCandidats.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlCardMemoires
            //
            pnlCardMemoires.BackColor = Color.FromArgb(40, 167, 69);
            pnlCardMemoires.Controls.Add(lblStatMemoires);
            pnlCardMemoires.Controls.Add(lblTitleMemoires);
            pnlCardMemoires.Location = new Point(480, 8);
            pnlCardMemoires.Margin = new Padding(3);
            pnlCardMemoires.Name = "pnlCardMemoires";
            pnlCardMemoires.Padding = new Padding(15);
            pnlCardMemoires.Size = new Size(230, 130);
            pnlCardMemoires.TabIndex = 2;
            //
            // lblStatMemoires
            //
            lblStatMemoires.Dock = DockStyle.Fill;
            lblStatMemoires.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblStatMemoires.ForeColor = Color.White;
            lblStatMemoires.Location = new Point(15, 15);
            lblStatMemoires.Name = "lblStatMemoires";
            lblStatMemoires.Size = new Size(200, 70);
            lblStatMemoires.TabIndex = 0;
            lblStatMemoires.Text = "0";
            lblStatMemoires.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTitleMemoires
            //
            lblTitleMemoires.Dock = DockStyle.Bottom;
            lblTitleMemoires.Font = new Font("Segoe UI", 10F);
            lblTitleMemoires.ForeColor = Color.FromArgb(220, 220, 220);
            lblTitleMemoires.Location = new Point(15, 85);
            lblTitleMemoires.Name = "lblTitleMemoires";
            lblTitleMemoires.Size = new Size(200, 30);
            lblTitleMemoires.TabIndex = 1;
            lblTitleMemoires.Text = "Mémoires";
            lblTitleMemoires.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlCardSoutenances
            //
            pnlCardSoutenances.BackColor = Color.FromArgb(230, 126, 34);
            pnlCardSoutenances.Controls.Add(lblStatSoutenances);
            pnlCardSoutenances.Controls.Add(lblTitleSoutenances);
            pnlCardSoutenances.Location = new Point(716, 8);
            pnlCardSoutenances.Margin = new Padding(3);
            pnlCardSoutenances.Name = "pnlCardSoutenances";
            pnlCardSoutenances.Padding = new Padding(15);
            pnlCardSoutenances.Size = new Size(230, 130);
            pnlCardSoutenances.TabIndex = 3;
            //
            // lblStatSoutenances
            //
            lblStatSoutenances.Dock = DockStyle.Fill;
            lblStatSoutenances.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblStatSoutenances.ForeColor = Color.White;
            lblStatSoutenances.Location = new Point(15, 15);
            lblStatSoutenances.Name = "lblStatSoutenances";
            lblStatSoutenances.Size = new Size(200, 70);
            lblStatSoutenances.TabIndex = 0;
            lblStatSoutenances.Text = "0";
            lblStatSoutenances.TextAlign = ContentAlignment.MiddleCenter;
            //
            // lblTitleSoutenances
            //
            lblTitleSoutenances.Dock = DockStyle.Bottom;
            lblTitleSoutenances.Font = new Font("Segoe UI", 10F);
            lblTitleSoutenances.ForeColor = Color.FromArgb(220, 220, 220);
            lblTitleSoutenances.Location = new Point(15, 85);
            lblTitleSoutenances.Name = "lblTitleSoutenances";
            lblTitleSoutenances.Size = new Size(200, 30);
            lblTitleSoutenances.TabIndex = 1;
            lblTitleSoutenances.Text = "Soutenances";
            lblTitleSoutenances.TextAlign = ContentAlignment.MiddleCenter;
            //
            // pnlLists
            //
            pnlLists.Controls.Add(pnlDernieresSoutenances);
            pnlLists.Controls.Add(pnlProchainesSoutenances);
            pnlLists.Dock = DockStyle.Fill;
            pnlLists.Location = new Point(0, 230);
            pnlLists.Name = "pnlLists";
            pnlLists.Padding = new Padding(5);
            pnlLists.Size = new Size(1020, 420);
            pnlLists.TabIndex = 2;
            //
            // pnlDernieresSoutenances
            //
            pnlDernieresSoutenances.BackColor = Color.White;
            pnlDernieresSoutenances.Controls.Add(dgvDernieresSoutenances);
            pnlDernieresSoutenances.Controls.Add(lblTitleDernieres);
            pnlDernieresSoutenances.Dock = DockStyle.Fill;
            pnlDernieresSoutenances.Location = new Point(505, 5);
            pnlDernieresSoutenances.Name = "pnlDernieresSoutenances";
            pnlDernieresSoutenances.Padding = new Padding(15);
            pnlDernieresSoutenances.Size = new Size(510, 410);
            pnlDernieresSoutenances.TabIndex = 1;
            //
            // dgvDernieresSoutenances
            //
            dgvDernieresSoutenances.BackgroundColor = Color.White;
            dgvDernieresSoutenances.BorderStyle = BorderStyle.None;
            dgvDernieresSoutenances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDernieresSoutenances.Dock = DockStyle.Fill;
            dgvDernieresSoutenances.Location = new Point(15, 55);
            dgvDernieresSoutenances.Name = "dgvDernieresSoutenances";
            dgvDernieresSoutenances.RowHeadersWidth = 51;
            dgvDernieresSoutenances.Size = new Size(480, 340);
            dgvDernieresSoutenances.TabIndex = 1;
            //
            // lblTitleDernieres
            //
            lblTitleDernieres.Dock = DockStyle.Top;
            lblTitleDernieres.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleDernieres.ForeColor = Color.FromArgb(30, 58, 95);
            lblTitleDernieres.Location = new Point(15, 15);
            lblTitleDernieres.Name = "lblTitleDernieres";
            lblTitleDernieres.Size = new Size(480, 40);
            lblTitleDernieres.TabIndex = 0;
            lblTitleDernieres.Text = "Dernières Soutenances";
            //
            // pnlProchainesSoutenances
            //
            pnlProchainesSoutenances.BackColor = Color.White;
            pnlProchainesSoutenances.Controls.Add(dgvProchainesSoutenances);
            pnlProchainesSoutenances.Controls.Add(lblTitleProchaines);
            pnlProchainesSoutenances.Dock = DockStyle.Left;
            pnlProchainesSoutenances.Location = new Point(5, 5);
            pnlProchainesSoutenances.Name = "pnlProchainesSoutenances";
            pnlProchainesSoutenances.Padding = new Padding(15);
            pnlProchainesSoutenances.Size = new Size(500, 410);
            pnlProchainesSoutenances.TabIndex = 0;
            //
            // dgvProchainesSoutenances
            //
            dgvProchainesSoutenances.BackgroundColor = Color.White;
            dgvProchainesSoutenances.BorderStyle = BorderStyle.None;
            dgvProchainesSoutenances.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProchainesSoutenances.Dock = DockStyle.Fill;
            dgvProchainesSoutenances.Location = new Point(15, 55);
            dgvProchainesSoutenances.Name = "dgvProchainesSoutenances";
            dgvProchainesSoutenances.RowHeadersWidth = 51;
            dgvProchainesSoutenances.Size = new Size(470, 340);
            dgvProchainesSoutenances.TabIndex = 1;
            //
            // lblTitleProchaines
            //
            lblTitleProchaines.Dock = DockStyle.Top;
            lblTitleProchaines.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTitleProchaines.ForeColor = Color.FromArgb(30, 58, 95);
            lblTitleProchaines.Location = new Point(15, 15);
            lblTitleProchaines.Name = "lblTitleProchaines";
            lblTitleProchaines.Size = new Size(470, 40);
            lblTitleProchaines.TabIndex = 0;
            lblTitleProchaines.Text = "Prochaines Soutenances";
            //
            // pnlHeader
            //
            pnlHeader.Controls.Add(lblStatAnnee);
            pnlHeader.Controls.Add(lblAnneeActuelle);
            pnlHeader.Controls.Add(btnRefresh);
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1020, 80);
            pnlHeader.TabIndex = 3;
            //
            // btnRefresh
            //
            btnRefresh.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnRefresh.BackColor = Color.FromArgb(30, 58, 95);
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.ForeColor = Color.White;
            btnRefresh.Location = new Point(890, 20);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(120, 35);
            btnRefresh.TabIndex = 1;
            btnRefresh.Text = "Actualiser";
            btnRefresh.UseVisualStyleBackColor = false;
            btnRefresh.Click += btnRefresh_Click;
            //
            // lblAnneeActuelle
            //
            lblAnneeActuelle.AutoSize = true;
            lblAnneeActuelle.Font = new Font("Segoe UI", 10F);
            lblAnneeActuelle.ForeColor = Color.FromArgb(108, 117, 125);
            lblAnneeActuelle.Location = new Point(285, 15);
            lblAnneeActuelle.Name = "lblAnneeActuelle";
            lblAnneeActuelle.Size = new Size(170, 23);
            lblAnneeActuelle.TabIndex = 2;
            lblAnneeActuelle.Text = "Année académique : -";
            //
            // lblStatAnnee
            //
            lblStatAnnee.AutoSize = true;
            lblStatAnnee.Font = new Font("Segoe UI", 9F);
            lblStatAnnee.ForeColor = Color.FromArgb(108, 117, 125);
            lblStatAnnee.Location = new Point(285, 42);
            lblStatAnnee.Name = "lblStatAnnee";
            lblStatAnnee.Size = new Size(15, 20);
            lblStatAnnee.TabIndex = 3;
            lblStatAnnee.Text = "-";
            //
            // frmDashboard
            //
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(245, 247, 250);
            ClientSize = new Size(1020, 650);
            Controls.Add(pnlLists);
            Controls.Add(pnlStats);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDashboard";
            Text = "Tableau de Bord";
            Load += frmDashboard_Load;
            pnlStats.ResumeLayout(false);
            pnlCardProfesseurs.ResumeLayout(false);
            pnlCardCandidats.ResumeLayout(false);
            pnlCardMemoires.ResumeLayout(false);
            pnlCardSoutenances.ResumeLayout(false);
            pnlLists.ResumeLayout(false);
            pnlDernieresSoutenances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvDernieresSoutenances).EndInit();
            pnlProchainesSoutenances.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvProchainesSoutenances).EndInit();
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitle;
        private FlowLayoutPanel pnlStats;
        private Panel pnlCardProfesseurs;
        private Label lblStatProfesseurs;
        private Label lblTitleProfesseurs;
        private Panel pnlCardCandidats;
        private Label lblStatCandidats;
        private Label lblTitleCandidats;
        private Panel pnlCardMemoires;
        private Label lblStatMemoires;
        private Label lblTitleMemoires;
        private Panel pnlCardSoutenances;
        private Label lblStatSoutenances;
        private Label lblTitleSoutenances;
        private Panel pnlLists;
        private Panel pnlProchainesSoutenances;
        private Label lblTitleProchaines;
        private DataGridView dgvProchainesSoutenances;
        private Panel pnlDernieresSoutenances;
        private Label lblTitleDernieres;
        private DataGridView dgvDernieresSoutenances;
        private Panel pnlHeader;
        private Button btnRefresh;
        private Label lblAnneeActuelle;
        private Label lblStatAnnee;
    }
}
