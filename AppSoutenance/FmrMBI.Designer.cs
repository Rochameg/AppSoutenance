namespace AppSoutenance
{
    partial class FmrMBI
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
            pnlHeader = new Panel();
            pnlUserInfo = new Panel();
            lblUserRole = new Label();
            lblUserName = new Label();
            pnlHeaderLeft = new Panel();
            lblDateTime = new Label();
            lblAppTitle = new Label();
            pnlSidebar = new Panel();
            btnDeconnexion = new Button();
            pnlMenuSeparator = new Panel();
            pnlSubUtilisateurs = new Panel();
            btnCandidat = new Button();
            btnProfesseur = new Button();
            btnUtilisateurs = new Button();
            btnSoutenances = new Button();
            btnMemoires = new Button();
            pnlSubParametres = new Panel();
            btnDepartement = new Button();
            btnSession = new Button();
            btnAnneeAcademique = new Button();
            btnParametres = new Button();
            btnDashboard = new Button();
            pnlLogo = new Panel();
            lblLogoIcon = new Label();
            lblLogo = new Label();
            pnlMain = new Panel();
            pnlHeader.SuspendLayout();
            pnlUserInfo.SuspendLayout();
            pnlHeaderLeft.SuspendLayout();
            pnlSidebar.SuspendLayout();
            pnlSubUtilisateurs.SuspendLayout();
            pnlSubParametres.SuspendLayout();
            pnlLogo.SuspendLayout();
            SuspendLayout();

            // pnlHeader - Header moderne blanc
            pnlHeader.BackColor = Color.White;
            pnlHeader.Controls.Add(pnlUserInfo);
            pnlHeader.Controls.Add(pnlHeaderLeft);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(260, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Padding = new Padding(24, 0, 24, 0);
            pnlHeader.Size = new Size(1020, 70);
            pnlHeader.TabIndex = 0;

            // pnlHeaderLeft
            pnlHeaderLeft.Controls.Add(lblDateTime);
            pnlHeaderLeft.Controls.Add(lblAppTitle);
            pnlHeaderLeft.Dock = DockStyle.Left;
            pnlHeaderLeft.Location = new Point(24, 0);
            pnlHeaderLeft.Name = "pnlHeaderLeft";
            pnlHeaderLeft.Size = new Size(400, 70);
            pnlHeaderLeft.TabIndex = 2;

            // lblAppTitle
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblAppTitle.Location = new Point(0, 14);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(200, 37);
            lblAppTitle.TabIndex = 0;
            lblAppTitle.Text = "Tableau de Bord";

            // lblDateTime
            lblDateTime.AutoSize = true;
            lblDateTime.Font = new Font("Segoe UI", 9F);
            lblDateTime.ForeColor = Color.FromArgb(100, 116, 139);
            lblDateTime.Location = new Point(2, 48);
            lblDateTime.Name = "lblDateTime";
            lblDateTime.Size = new Size(150, 20);
            lblDateTime.TabIndex = 1;
            lblDateTime.Text = "Mercredi, 4 Fevrier 2025";

            // pnlUserInfo
            pnlUserInfo.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            pnlUserInfo.Controls.Add(lblUserRole);
            pnlUserInfo.Controls.Add(lblUserName);
            pnlUserInfo.Location = new Point(780, 12);
            pnlUserInfo.Name = "pnlUserInfo";
            pnlUserInfo.Size = new Size(220, 46);
            pnlUserInfo.TabIndex = 1;

            // lblUserName
            lblUserName.Dock = DockStyle.Top;
            lblUserName.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblUserName.ForeColor = Color.FromArgb(15, 23, 42);
            lblUserName.Location = new Point(0, 0);
            lblUserName.Name = "lblUserName";
            lblUserName.Size = new Size(220, 26);
            lblUserName.TabIndex = 0;
            lblUserName.Text = "Administrateur";
            lblUserName.TextAlign = ContentAlignment.BottomRight;

            // lblUserRole
            lblUserRole.Dock = DockStyle.Bottom;
            lblUserRole.Font = new Font("Segoe UI", 9F);
            lblUserRole.ForeColor = Color.FromArgb(100, 116, 139);
            lblUserRole.Location = new Point(0, 26);
            lblUserRole.Name = "lblUserRole";
            lblUserRole.Size = new Size(220, 20);
            lblUserRole.TabIndex = 1;
            lblUserRole.Text = "admin@soutenance.sn";
            lblUserRole.TextAlign = ContentAlignment.TopRight;

            // pnlSidebar - Sidebar moderne sombre
            pnlSidebar.BackColor = Color.FromArgb(15, 23, 42);
            pnlSidebar.Controls.Add(btnDeconnexion);
            pnlSidebar.Controls.Add(pnlMenuSeparator);
            pnlSidebar.Controls.Add(pnlSubUtilisateurs);
            pnlSidebar.Controls.Add(btnUtilisateurs);
            pnlSidebar.Controls.Add(btnSoutenances);
            pnlSidebar.Controls.Add(btnMemoires);
            pnlSidebar.Controls.Add(pnlSubParametres);
            pnlSidebar.Controls.Add(btnParametres);
            pnlSidebar.Controls.Add(btnDashboard);
            pnlSidebar.Controls.Add(pnlLogo);
            pnlSidebar.Dock = DockStyle.Left;
            pnlSidebar.Location = new Point(0, 0);
            pnlSidebar.Name = "pnlSidebar";
            pnlSidebar.Size = new Size(260, 750);
            pnlSidebar.TabIndex = 1;

            // pnlLogo - Zone logo moderne
            pnlLogo.BackColor = Color.Transparent;
            pnlLogo.Controls.Add(lblLogo);
            pnlLogo.Controls.Add(lblLogoIcon);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Padding = new Padding(20, 20, 20, 20);
            pnlLogo.Size = new Size(260, 80);
            pnlLogo.TabIndex = 0;

            // lblLogoIcon
            lblLogoIcon.BackColor = Color.FromArgb(99, 102, 241);
            lblLogoIcon.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblLogoIcon.ForeColor = Color.White;
            lblLogoIcon.Location = new Point(20, 20);
            lblLogoIcon.Name = "lblLogoIcon";
            lblLogoIcon.Size = new Size(44, 40);
            lblLogoIcon.TabIndex = 1;
            lblLogoIcon.Text = "SS";
            lblLogoIcon.TextAlign = ContentAlignment.MiddleCenter;

            // lblLogo
            lblLogo.AutoSize = true;
            lblLogo.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            lblLogo.ForeColor = Color.White;
            lblLogo.Location = new Point(72, 28);
            lblLogo.Name = "lblLogo";
            lblLogo.Size = new Size(166, 30);
            lblLogo.TabIndex = 0;
            lblLogo.Text = "Sen Soutenance";

            // btnDashboard
            btnDashboard.Dock = DockStyle.Top;
            btnDashboard.FlatAppearance.BorderSize = 0;
            btnDashboard.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnDashboard.FlatStyle = FlatStyle.Flat;
            btnDashboard.Font = new Font("Segoe UI", 10F);
            btnDashboard.ForeColor = Color.FromArgb(148, 163, 184);
            btnDashboard.Location = new Point(0, 80);
            btnDashboard.Name = "btnDashboard";
            btnDashboard.Padding = new Padding(28, 0, 0, 0);
            btnDashboard.Size = new Size(260, 48);
            btnDashboard.TabIndex = 1;
            btnDashboard.Text = "     Tableau de Bord";
            btnDashboard.TextAlign = ContentAlignment.MiddleLeft;
            btnDashboard.UseVisualStyleBackColor = true;
            btnDashboard.Click += btnDashboard_Click;

            // btnParametres
            btnParametres.Dock = DockStyle.Top;
            btnParametres.FlatAppearance.BorderSize = 0;
            btnParametres.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnParametres.FlatStyle = FlatStyle.Flat;
            btnParametres.Font = new Font("Segoe UI", 10F);
            btnParametres.ForeColor = Color.FromArgb(148, 163, 184);
            btnParametres.Location = new Point(0, 128);
            btnParametres.Name = "btnParametres";
            btnParametres.Padding = new Padding(28, 0, 0, 0);
            btnParametres.Size = new Size(260, 48);
            btnParametres.TabIndex = 2;
            btnParametres.Text = "     Parametres";
            btnParametres.TextAlign = ContentAlignment.MiddleLeft;
            btnParametres.UseVisualStyleBackColor = true;
            btnParametres.Click += btnParametres_Click;

            // pnlSubParametres
            pnlSubParametres.BackColor = Color.FromArgb(22, 33, 51);
            pnlSubParametres.Controls.Add(btnDepartement);
            pnlSubParametres.Controls.Add(btnSession);
            pnlSubParametres.Controls.Add(btnAnneeAcademique);
            pnlSubParametres.Dock = DockStyle.Top;
            pnlSubParametres.Location = new Point(0, 176);
            pnlSubParametres.Name = "pnlSubParametres";
            pnlSubParametres.Size = new Size(260, 126);
            pnlSubParametres.TabIndex = 3;
            pnlSubParametres.Visible = false;

            // btnAnneeAcademique
            btnAnneeAcademique.Dock = DockStyle.Top;
            btnAnneeAcademique.FlatAppearance.BorderSize = 0;
            btnAnneeAcademique.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnAnneeAcademique.FlatStyle = FlatStyle.Flat;
            btnAnneeAcademique.Font = new Font("Segoe UI", 9F);
            btnAnneeAcademique.ForeColor = Color.FromArgb(125, 140, 160);
            btnAnneeAcademique.Location = new Point(0, 0);
            btnAnneeAcademique.Name = "btnAnneeAcademique";
            btnAnneeAcademique.Padding = new Padding(48, 0, 0, 0);
            btnAnneeAcademique.Size = new Size(260, 42);
            btnAnneeAcademique.TabIndex = 0;
            btnAnneeAcademique.Text = "Annees Academiques";
            btnAnneeAcademique.TextAlign = ContentAlignment.MiddleLeft;
            btnAnneeAcademique.UseVisualStyleBackColor = true;
            btnAnneeAcademique.Click += btnAnneeAcademique_Click;

            // btnSession
            btnSession.Dock = DockStyle.Top;
            btnSession.FlatAppearance.BorderSize = 0;
            btnSession.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnSession.FlatStyle = FlatStyle.Flat;
            btnSession.Font = new Font("Segoe UI", 9F);
            btnSession.ForeColor = Color.FromArgb(125, 140, 160);
            btnSession.Location = new Point(0, 42);
            btnSession.Name = "btnSession";
            btnSession.Padding = new Padding(48, 0, 0, 0);
            btnSession.Size = new Size(260, 42);
            btnSession.TabIndex = 1;
            btnSession.Text = "Sessions";
            btnSession.TextAlign = ContentAlignment.MiddleLeft;
            btnSession.UseVisualStyleBackColor = true;
            btnSession.Click += btnSession_Click;

            // btnDepartement
            btnDepartement.Dock = DockStyle.Top;
            btnDepartement.FlatAppearance.BorderSize = 0;
            btnDepartement.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnDepartement.FlatStyle = FlatStyle.Flat;
            btnDepartement.Font = new Font("Segoe UI", 9F);
            btnDepartement.ForeColor = Color.FromArgb(125, 140, 160);
            btnDepartement.Location = new Point(0, 84);
            btnDepartement.Name = "btnDepartement";
            btnDepartement.Padding = new Padding(48, 0, 0, 0);
            btnDepartement.Size = new Size(260, 42);
            btnDepartement.TabIndex = 2;
            btnDepartement.Text = "Departements";
            btnDepartement.TextAlign = ContentAlignment.MiddleLeft;
            btnDepartement.UseVisualStyleBackColor = true;
            btnDepartement.Click += btnDepartement_Click;

            // btnMemoires
            btnMemoires.Dock = DockStyle.Top;
            btnMemoires.FlatAppearance.BorderSize = 0;
            btnMemoires.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnMemoires.FlatStyle = FlatStyle.Flat;
            btnMemoires.Font = new Font("Segoe UI", 10F);
            btnMemoires.ForeColor = Color.FromArgb(148, 163, 184);
            btnMemoires.Location = new Point(0, 302);
            btnMemoires.Name = "btnMemoires";
            btnMemoires.Padding = new Padding(28, 0, 0, 0);
            btnMemoires.Size = new Size(260, 48);
            btnMemoires.TabIndex = 4;
            btnMemoires.Text = "     Memoires";
            btnMemoires.TextAlign = ContentAlignment.MiddleLeft;
            btnMemoires.UseVisualStyleBackColor = true;
            btnMemoires.Click += btnMemoires_Click;

            // btnSoutenances
            btnSoutenances.Dock = DockStyle.Top;
            btnSoutenances.FlatAppearance.BorderSize = 0;
            btnSoutenances.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnSoutenances.FlatStyle = FlatStyle.Flat;
            btnSoutenances.Font = new Font("Segoe UI", 10F);
            btnSoutenances.ForeColor = Color.FromArgb(148, 163, 184);
            btnSoutenances.Location = new Point(0, 350);
            btnSoutenances.Name = "btnSoutenances";
            btnSoutenances.Padding = new Padding(28, 0, 0, 0);
            btnSoutenances.Size = new Size(260, 48);
            btnSoutenances.TabIndex = 5;
            btnSoutenances.Text = "     Soutenances";
            btnSoutenances.TextAlign = ContentAlignment.MiddleLeft;
            btnSoutenances.UseVisualStyleBackColor = true;
            btnSoutenances.Click += btnSoutenances_Click;

            // btnUtilisateurs
            btnUtilisateurs.Dock = DockStyle.Top;
            btnUtilisateurs.FlatAppearance.BorderSize = 0;
            btnUtilisateurs.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnUtilisateurs.FlatStyle = FlatStyle.Flat;
            btnUtilisateurs.Font = new Font("Segoe UI", 10F);
            btnUtilisateurs.ForeColor = Color.FromArgb(148, 163, 184);
            btnUtilisateurs.Location = new Point(0, 398);
            btnUtilisateurs.Name = "btnUtilisateurs";
            btnUtilisateurs.Padding = new Padding(28, 0, 0, 0);
            btnUtilisateurs.Size = new Size(260, 48);
            btnUtilisateurs.TabIndex = 6;
            btnUtilisateurs.Text = "     Utilisateurs";
            btnUtilisateurs.TextAlign = ContentAlignment.MiddleLeft;
            btnUtilisateurs.UseVisualStyleBackColor = true;
            btnUtilisateurs.Click += btnUtilisateurs_Click;

            // pnlSubUtilisateurs
            pnlSubUtilisateurs.BackColor = Color.FromArgb(22, 33, 51);
            pnlSubUtilisateurs.Controls.Add(btnCandidat);
            pnlSubUtilisateurs.Controls.Add(btnProfesseur);
            pnlSubUtilisateurs.Dock = DockStyle.Top;
            pnlSubUtilisateurs.Location = new Point(0, 446);
            pnlSubUtilisateurs.Name = "pnlSubUtilisateurs";
            pnlSubUtilisateurs.Size = new Size(260, 84);
            pnlSubUtilisateurs.TabIndex = 7;
            pnlSubUtilisateurs.Visible = false;

            // btnProfesseur
            btnProfesseur.Dock = DockStyle.Top;
            btnProfesseur.FlatAppearance.BorderSize = 0;
            btnProfesseur.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnProfesseur.FlatStyle = FlatStyle.Flat;
            btnProfesseur.Font = new Font("Segoe UI", 9F);
            btnProfesseur.ForeColor = Color.FromArgb(125, 140, 160);
            btnProfesseur.Location = new Point(0, 0);
            btnProfesseur.Name = "btnProfesseur";
            btnProfesseur.Padding = new Padding(48, 0, 0, 0);
            btnProfesseur.Size = new Size(260, 42);
            btnProfesseur.TabIndex = 0;
            btnProfesseur.Text = "Professeurs";
            btnProfesseur.TextAlign = ContentAlignment.MiddleLeft;
            btnProfesseur.UseVisualStyleBackColor = true;
            btnProfesseur.Click += btnProfesseur_Click;

            // btnCandidat
            btnCandidat.Dock = DockStyle.Top;
            btnCandidat.FlatAppearance.BorderSize = 0;
            btnCandidat.FlatAppearance.MouseOverBackColor = Color.FromArgb(30, 41, 59);
            btnCandidat.FlatStyle = FlatStyle.Flat;
            btnCandidat.Font = new Font("Segoe UI", 9F);
            btnCandidat.ForeColor = Color.FromArgb(125, 140, 160);
            btnCandidat.Location = new Point(0, 42);
            btnCandidat.Name = "btnCandidat";
            btnCandidat.Padding = new Padding(48, 0, 0, 0);
            btnCandidat.Size = new Size(260, 42);
            btnCandidat.TabIndex = 1;
            btnCandidat.Text = "Candidats";
            btnCandidat.TextAlign = ContentAlignment.MiddleLeft;
            btnCandidat.UseVisualStyleBackColor = true;
            btnCandidat.Click += btnCandidat_Click;

            // pnlMenuSeparator
            pnlMenuSeparator.BackColor = Color.FromArgb(30, 41, 59);
            pnlMenuSeparator.Dock = DockStyle.Top;
            pnlMenuSeparator.Location = new Point(0, 530);
            pnlMenuSeparator.Name = "pnlMenuSeparator";
            pnlMenuSeparator.Size = new Size(260, 1);
            pnlMenuSeparator.TabIndex = 9;

            // btnDeconnexion
            btnDeconnexion.Dock = DockStyle.Bottom;
            btnDeconnexion.FlatAppearance.BorderSize = 0;
            btnDeconnexion.FlatAppearance.MouseOverBackColor = Color.FromArgb(220, 38, 38);
            btnDeconnexion.FlatStyle = FlatStyle.Flat;
            btnDeconnexion.Font = new Font("Segoe UI", 10F);
            btnDeconnexion.ForeColor = Color.FromArgb(239, 68, 68);
            btnDeconnexion.Location = new Point(0, 702);
            btnDeconnexion.Name = "btnDeconnexion";
            btnDeconnexion.Padding = new Padding(28, 0, 0, 0);
            btnDeconnexion.Size = new Size(260, 48);
            btnDeconnexion.TabIndex = 8;
            btnDeconnexion.Text = "     Deconnexion";
            btnDeconnexion.TextAlign = ContentAlignment.MiddleLeft;
            btnDeconnexion.UseVisualStyleBackColor = true;
            btnDeconnexion.Click += btnDeconnexion_Click;

            // pnlMain - Zone de contenu principale
            pnlMain.BackColor = Color.FromArgb(248, 250, 252);
            pnlMain.Dock = DockStyle.Fill;
            pnlMain.Location = new Point(260, 70);
            pnlMain.Name = "pnlMain";
            pnlMain.Padding = new Padding(24);
            pnlMain.Size = new Size(1020, 680);
            pnlMain.TabIndex = 2;

            // FmrMBI
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1280, 750);
            Controls.Add(pnlMain);
            Controls.Add(pnlHeader);
            Controls.Add(pnlSidebar);
            MinimumSize = new Size(1100, 650);
            Name = "FmrMBI";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sen Soutenance - Systeme de Gestion";
            WindowState = FormWindowState.Maximized;
            FormClosing += FmrMBI_FormClosing;
            Load += FmrMBI_Load;
            pnlHeader.ResumeLayout(false);
            pnlUserInfo.ResumeLayout(false);
            pnlHeaderLeft.ResumeLayout(false);
            pnlHeaderLeft.PerformLayout();
            pnlSidebar.ResumeLayout(false);
            pnlSubUtilisateurs.ResumeLayout(false);
            pnlSubParametres.ResumeLayout(false);
            pnlLogo.ResumeLayout(false);
            pnlLogo.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblAppTitle;
        private Panel pnlSidebar;
        private Panel pnlLogo;
        private Label lblLogo;
        private Label lblLogoIcon;
        private Button btnDashboard;
        private Button btnParametres;
        private Panel pnlSubParametres;
        private Button btnAnneeAcademique;
        private Button btnSession;
        private Button btnDepartement;
        private Button btnMemoires;
        private Button btnSoutenances;
        private Button btnUtilisateurs;
        private Panel pnlSubUtilisateurs;
        private Button btnProfesseur;
        private Button btnCandidat;
        private Button btnDeconnexion;
        private Panel pnlMain;
        private Panel pnlUserInfo;
        private Label lblUserName;
        private Label lblUserRole;
        private Panel pnlHeaderLeft;
        private Label lblDateTime;
        private Panel pnlMenuSeparator;
    }
}
