namespace AppSoutenance
{
    partial class fmrConnection
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
            pnlMain = new Panel();
            pnlRight = new Panel();
            pnlLogin = new Panel();
            lblError = new Label();
            btnCancel = new Button();
            btnLogin = new Button();
            pnlPassword = new Panel();
            txtPassword = new TextBox();
            lblPasswordIcon = new Label();
            lblPassword = new Label();
            pnlEmail = new Panel();
            txtEmail = new TextBox();
            lblEmailIcon = new Label();
            lblEmail = new Label();
            lblSubtitle = new Label();
            lblTitle = new Label();
            lblWelcome = new Label();
            pnlLeft = new Panel();
            pnlBrandContent = new Panel();
            lblFeature3 = new Label();
            lblFeature2 = new Label();
            lblFeature1 = new Label();
            lblBrandSubtitle = new Label();
            lblBrandTitle = new Label();
            pnlLogo = new Panel();
            lblAppName = new Label();
            lblCopyright = new Label();
            pnlMain.SuspendLayout();
            pnlRight.SuspendLayout();
            pnlLogin.SuspendLayout();
            pnlPassword.SuspendLayout();
            pnlEmail.SuspendLayout();
            pnlLeft.SuspendLayout();
            pnlBrandContent.SuspendLayout();
            pnlLogo.SuspendLayout();
            SuspendLayout();

            // pnlMain
            pnlMain.Anchor = AnchorStyles.None;
            pnlMain.BackColor = Color.White;
            pnlMain.Controls.Add(pnlRight);
            pnlMain.Controls.Add(pnlLeft);
            pnlMain.Location = new Point(90, 60);
            pnlMain.Name = "pnlMain";
            pnlMain.Size = new Size(1000, 600);
            pnlMain.TabIndex = 0;

            // pnlRight - Zone de connexion
            pnlRight.BackColor = Color.White;
            pnlRight.Controls.Add(pnlLogin);
            pnlRight.Dock = DockStyle.Fill;
            pnlRight.Location = new Point(440, 0);
            pnlRight.Name = "pnlRight";
            pnlRight.Padding = new Padding(60, 40, 60, 40);
            pnlRight.Size = new Size(560, 600);
            pnlRight.TabIndex = 1;

            // pnlLogin
            pnlLogin.BackColor = Color.White;
            pnlLogin.Controls.Add(lblError);
            pnlLogin.Controls.Add(btnCancel);
            pnlLogin.Controls.Add(btnLogin);
            pnlLogin.Controls.Add(pnlPassword);
            pnlLogin.Controls.Add(lblPassword);
            pnlLogin.Controls.Add(pnlEmail);
            pnlLogin.Controls.Add(lblEmail);
            pnlLogin.Controls.Add(lblSubtitle);
            pnlLogin.Controls.Add(lblTitle);
            pnlLogin.Controls.Add(lblWelcome);
            pnlLogin.Dock = DockStyle.Fill;
            pnlLogin.Location = new Point(60, 40);
            pnlLogin.Name = "pnlLogin";
            pnlLogin.Size = new Size(440, 520);
            pnlLogin.TabIndex = 0;

            // lblWelcome
            lblWelcome.AutoSize = true;
            lblWelcome.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            lblWelcome.ForeColor = Color.FromArgb(99, 102, 241);
            lblWelcome.Location = new Point(0, 20);
            lblWelcome.Name = "lblWelcome";
            lblWelcome.Size = new Size(120, 25);
            lblWelcome.TabIndex = 0;
            lblWelcome.Text = "Bienvenue !";

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 28F, FontStyle.Bold);
            lblTitle.ForeColor = Color.FromArgb(15, 23, 42);
            lblTitle.Location = new Point(-5, 50);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(280, 62);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "Connexion";

            // lblSubtitle
            lblSubtitle.AutoSize = true;
            lblSubtitle.Font = new Font("Segoe UI", 10F);
            lblSubtitle.ForeColor = Color.FromArgb(100, 116, 139);
            lblSubtitle.Location = new Point(0, 115);
            lblSubtitle.Name = "lblSubtitle";
            lblSubtitle.Size = new Size(340, 23);
            lblSubtitle.TabIndex = 2;
            lblSubtitle.Text = "Entrez vos identifiants pour acceder au systeme";

            // lblEmail
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblEmail.ForeColor = Color.FromArgb(71, 85, 105);
            lblEmail.Location = new Point(0, 170);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(110, 20);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Adresse email";

            // pnlEmail
            pnlEmail.BackColor = Color.White;
            pnlEmail.Controls.Add(txtEmail);
            pnlEmail.Controls.Add(lblEmailIcon);
            pnlEmail.Location = new Point(0, 195);
            pnlEmail.Name = "pnlEmail";
            pnlEmail.Size = new Size(440, 50);
            pnlEmail.TabIndex = 1;

            // lblEmailIcon
            lblEmailIcon.BackColor = Color.FromArgb(248, 250, 252);
            lblEmailIcon.Font = new Font("Segoe UI", 12F);
            lblEmailIcon.ForeColor = Color.FromArgb(148, 163, 184);
            lblEmailIcon.Location = new Point(0, 0);
            lblEmailIcon.Name = "lblEmailIcon";
            lblEmailIcon.Size = new Size(50, 50);
            lblEmailIcon.TabIndex = 0;
            lblEmailIcon.Text = "@";
            lblEmailIcon.TextAlign = ContentAlignment.MiddleCenter;

            // txtEmail
            txtEmail.BackColor = Color.White;
            txtEmail.BorderStyle = BorderStyle.None;
            txtEmail.Font = new Font("Segoe UI", 11F);
            txtEmail.ForeColor = Color.FromArgb(15, 23, 42);
            txtEmail.Location = new Point(55, 13);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(375, 25);
            txtEmail.TabIndex = 1;
            txtEmail.KeyDown += txtEmail_KeyDown;

            // lblPassword
            lblPassword.AutoSize = true;
            lblPassword.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblPassword.ForeColor = Color.FromArgb(71, 85, 105);
            lblPassword.Location = new Point(0, 265);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(104, 20);
            lblPassword.TabIndex = 4;
            lblPassword.Text = "Mot de passe";

            // pnlPassword
            pnlPassword.BackColor = Color.White;
            pnlPassword.Controls.Add(txtPassword);
            pnlPassword.Controls.Add(lblPasswordIcon);
            pnlPassword.Location = new Point(0, 290);
            pnlPassword.Name = "pnlPassword";
            pnlPassword.Size = new Size(440, 50);
            pnlPassword.TabIndex = 2;

            // lblPasswordIcon
            lblPasswordIcon.BackColor = Color.FromArgb(248, 250, 252);
            lblPasswordIcon.Font = new Font("Segoe UI", 14F);
            lblPasswordIcon.ForeColor = Color.FromArgb(148, 163, 184);
            lblPasswordIcon.Location = new Point(0, 0);
            lblPasswordIcon.Name = "lblPasswordIcon";
            lblPasswordIcon.Size = new Size(50, 50);
            lblPasswordIcon.TabIndex = 0;
            lblPasswordIcon.Text = "*";
            lblPasswordIcon.TextAlign = ContentAlignment.MiddleCenter;

            // txtPassword
            txtPassword.BackColor = Color.White;
            txtPassword.BorderStyle = BorderStyle.None;
            txtPassword.Font = new Font("Segoe UI", 11F);
            txtPassword.ForeColor = Color.FromArgb(15, 23, 42);
            txtPassword.Location = new Point(55, 13);
            txtPassword.Name = "txtPassword";
            txtPassword.Size = new Size(375, 25);
            txtPassword.TabIndex = 1;
            txtPassword.UseSystemPasswordChar = true;
            txtPassword.KeyDown += txtPassword_KeyDown;

            // lblError
            lblError.Font = new Font("Segoe UI", 9F);
            lblError.ForeColor = Color.FromArgb(239, 68, 68);
            lblError.Location = new Point(0, 355);
            lblError.Name = "lblError";
            lblError.Size = new Size(440, 25);
            lblError.TabIndex = 8;
            lblError.Text = "";
            lblError.TextAlign = ContentAlignment.MiddleLeft;
            lblError.Visible = false;

            // btnLogin
            btnLogin.BackColor = Color.FromArgb(99, 102, 241);
            btnLogin.Cursor = Cursors.Hand;
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.FlatStyle = FlatStyle.Flat;
            btnLogin.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            btnLogin.ForeColor = Color.White;
            btnLogin.Location = new Point(0, 395);
            btnLogin.Name = "btnLogin";
            btnLogin.Size = new Size(440, 52);
            btnLogin.TabIndex = 3;
            btnLogin.Text = "Se connecter";
            btnLogin.UseVisualStyleBackColor = false;
            btnLogin.Click += btnLogin_Click;

            // btnCancel
            btnCancel.BackColor = Color.White;
            btnCancel.Cursor = Cursors.Hand;
            btnCancel.FlatAppearance.BorderColor = Color.FromArgb(226, 232, 240);
            btnCancel.FlatAppearance.BorderSize = 2;
            btnCancel.FlatStyle = FlatStyle.Flat;
            btnCancel.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            btnCancel.ForeColor = Color.FromArgb(100, 116, 139);
            btnCancel.Location = new Point(0, 460);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(440, 48);
            btnCancel.TabIndex = 4;
            btnCancel.Text = "Quitter l'application";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;

            // pnlLeft - Zone de branding
            pnlLeft.BackColor = Color.FromArgb(99, 102, 241);
            pnlLeft.Controls.Add(pnlBrandContent);
            pnlLeft.Controls.Add(pnlLogo);
            pnlLeft.Dock = DockStyle.Left;
            pnlLeft.Location = new Point(0, 0);
            pnlLeft.Name = "pnlLeft";
            pnlLeft.Size = new Size(440, 600);
            pnlLeft.TabIndex = 0;

            // pnlLogo
            pnlLogo.BackColor = Color.Transparent;
            pnlLogo.Controls.Add(lblAppName);
            pnlLogo.Dock = DockStyle.Top;
            pnlLogo.Location = new Point(0, 0);
            pnlLogo.Name = "pnlLogo";
            pnlLogo.Padding = new Padding(40, 40, 40, 20);
            pnlLogo.Size = new Size(440, 120);
            pnlLogo.TabIndex = 0;

            // lblAppName
            lblAppName.Dock = DockStyle.Fill;
            lblAppName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblAppName.ForeColor = Color.White;
            lblAppName.Location = new Point(40, 40);
            lblAppName.Name = "lblAppName";
            lblAppName.Size = new Size(360, 60);
            lblAppName.TabIndex = 0;
            lblAppName.Text = "SEN SOUTENANCE";
            lblAppName.TextAlign = ContentAlignment.MiddleLeft;

            // pnlBrandContent
            pnlBrandContent.BackColor = Color.Transparent;
            pnlBrandContent.Controls.Add(lblFeature3);
            pnlBrandContent.Controls.Add(lblFeature2);
            pnlBrandContent.Controls.Add(lblFeature1);
            pnlBrandContent.Controls.Add(lblBrandSubtitle);
            pnlBrandContent.Controls.Add(lblBrandTitle);
            pnlBrandContent.Dock = DockStyle.Fill;
            pnlBrandContent.Location = new Point(0, 120);
            pnlBrandContent.Name = "pnlBrandContent";
            pnlBrandContent.Padding = new Padding(40, 40, 40, 60);
            pnlBrandContent.Size = new Size(440, 480);
            pnlBrandContent.TabIndex = 1;

            // lblBrandTitle
            lblBrandTitle.Dock = DockStyle.Top;
            lblBrandTitle.Font = new Font("Segoe UI", 26F, FontStyle.Bold);
            lblBrandTitle.ForeColor = Color.White;
            lblBrandTitle.Location = new Point(40, 40);
            lblBrandTitle.Name = "lblBrandTitle";
            lblBrandTitle.Size = new Size(360, 120);
            lblBrandTitle.TabIndex = 0;
            lblBrandTitle.Text = "Gerez vos soutenances efficacement";

            // lblBrandSubtitle
            lblBrandSubtitle.Dock = DockStyle.Top;
            lblBrandSubtitle.Font = new Font("Segoe UI", 11F);
            lblBrandSubtitle.ForeColor = Color.FromArgb(200, 220, 255);
            lblBrandSubtitle.Location = new Point(40, 160);
            lblBrandSubtitle.Name = "lblBrandSubtitle";
            lblBrandSubtitle.Size = new Size(360, 60);
            lblBrandSubtitle.TabIndex = 1;
            lblBrandSubtitle.Text = "Une plateforme complete pour la gestion des memoires et des soutenances academiques.";

            // lblFeature1
            lblFeature1.AutoSize = true;
            lblFeature1.Font = new Font("Segoe UI", 10F);
            lblFeature1.ForeColor = Color.FromArgb(220, 230, 255);
            lblFeature1.Location = new Point(40, 260);
            lblFeature1.Name = "lblFeature1";
            lblFeature1.Size = new Size(240, 23);
            lblFeature1.TabIndex = 2;
            lblFeature1.Text = "Gestion des annees academiques";

            // lblFeature2
            lblFeature2.AutoSize = true;
            lblFeature2.Font = new Font("Segoe UI", 10F);
            lblFeature2.ForeColor = Color.FromArgb(220, 230, 255);
            lblFeature2.Location = new Point(40, 295);
            lblFeature2.Name = "lblFeature2";
            lblFeature2.Size = new Size(260, 23);
            lblFeature2.TabIndex = 3;
            lblFeature2.Text = "Suivi des memoires et candidats";

            // lblFeature3
            lblFeature3.AutoSize = true;
            lblFeature3.Font = new Font("Segoe UI", 10F);
            lblFeature3.ForeColor = Color.FromArgb(220, 230, 255);
            lblFeature3.Location = new Point(40, 330);
            lblFeature3.Name = "lblFeature3";
            lblFeature3.Size = new Size(270, 23);
            lblFeature3.TabIndex = 4;
            lblFeature3.Text = "Planification des soutenances";

            // lblCopyright
            lblCopyright.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblCopyright.Font = new Font("Segoe UI", 9F);
            lblCopyright.ForeColor = Color.FromArgb(148, 163, 184);
            lblCopyright.Location = new Point(0, 685);
            lblCopyright.Name = "lblCopyright";
            lblCopyright.Size = new Size(1180, 25);
            lblCopyright.TabIndex = 1;
            lblCopyright.Text = "2025 Sen Soutenance - Systeme de Gestion des Soutenances";
            lblCopyright.TextAlign = ContentAlignment.MiddleCenter;

            // fmrConnection
            AcceptButton = btnLogin;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(248, 250, 252);
            ClientSize = new Size(1180, 720);
            ControlBox = false;
            Controls.Add(lblCopyright);
            Controls.Add(pnlMain);
            FormBorderStyle = FormBorderStyle.None;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "fmrConnection";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Sen Soutenance - Connexion";
            Load += fmrConnection_Load;
            pnlMain.ResumeLayout(false);
            pnlRight.ResumeLayout(false);
            pnlLogin.ResumeLayout(false);
            pnlLogin.PerformLayout();
            pnlPassword.ResumeLayout(false);
            pnlPassword.PerformLayout();
            pnlEmail.ResumeLayout(false);
            pnlEmail.PerformLayout();
            pnlLeft.ResumeLayout(false);
            pnlBrandContent.ResumeLayout(false);
            pnlBrandContent.PerformLayout();
            pnlLogo.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMain;
        private Panel pnlLeft;
        private Panel pnlRight;
        private Panel pnlLogin;
        private Panel pnlLogo;
        private Label lblAppName;
        private Panel pnlBrandContent;
        private Label lblBrandTitle;
        private Label lblBrandSubtitle;
        private Label lblFeature1;
        private Label lblFeature2;
        private Label lblFeature3;
        private Label lblWelcome;
        private Label lblTitle;
        private Label lblSubtitle;
        private Label lblEmail;
        private Panel pnlEmail;
        private Label lblEmailIcon;
        private TextBox txtEmail;
        private Label lblPassword;
        private Panel pnlPassword;
        private Label lblPasswordIcon;
        private TextBox txtPassword;
        private Label lblError;
        private Button btnLogin;
        private Button btnCancel;
        private Label lblCopyright;
    }
}
