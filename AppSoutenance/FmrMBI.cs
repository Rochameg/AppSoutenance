using AppSoutenance.Helpers;
using AppSoutenance.Services;
using AppSoutenance.Views.Dashboard;
using AppSoutenance.Views.Parametre;
using AppSoutenance.Views.Utilisateurs;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AppSoutenance
{
    public partial class FmrMBI : Form
    {
        private Button _activeMenuButton = null;
        private Panel _activeSubMenu = null;
        private Timer _dateTimeTimer;

        // Couleurs du theme moderne
        private readonly Color _sidebarBg = Color.FromArgb(15, 23, 42);
        private readonly Color _sidebarHover = Color.FromArgb(30, 41, 59);
        private readonly Color _sidebarActive = Color.FromArgb(51, 65, 85);
        private readonly Color _textInactive = Color.FromArgb(148, 163, 184);
        private readonly Color _textActive = Color.White;
        private readonly Color _accentColor = Color.FromArgb(99, 102, 241);

        public FmrMBI()
        {
            InitializeComponent();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Double buffering pour des animations fluides
            this.DoubleBuffered = true;
            this.BackColor = UITheme.BackgroundColor;

            // Header moderne blanc
            pnlHeader.BackColor = Color.White;
            pnlHeader.Paint += PnlHeader_Paint;

            // Configuration du titre
            lblAppTitle.ForeColor = UITheme.TextPrimaryColor;
            lblAppTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);

            // Date et heure
            UpdateDateTime();
            _dateTimeTimer = new Timer { Interval = 60000 };
            _dateTimeTimer.Tick += (s, e) => UpdateDateTime();
            _dateTimeTimer.Start();

            // Informations utilisateur
            if (AuthentificationService.CurrentUser != null)
            {
                lblUserName.Text = $"{AuthentificationService.CurrentUser.PrenomUtilisateur} {AuthentificationService.CurrentUser.NomUtilisateur}";
                lblUserRole.Text = AuthentificationService.CurrentUser.EmailUtilisateur;
            }
            lblUserName.ForeColor = UITheme.TextPrimaryColor;
            lblUserRole.ForeColor = UITheme.TextSecondaryColor;

            // Sidebar moderne
            pnlSidebar.BackColor = _sidebarBg;

            // Logo avec coins arrondis
            lblLogoIcon.Paint += LblLogoIcon_Paint;

            // Styliser tous les boutons du menu
            StyleMenuButton(btnDashboard, true);
            StyleMenuButton(btnParametres, false);
            StyleMenuButton(btnMemoires, false);
            StyleMenuButton(btnSoutenances, false);
            StyleMenuButton(btnUtilisateurs, false);
            StyleDeconnexionButton(btnDeconnexion);

            // Styliser les sous-menus
            StyleSubMenuButton(btnAnneeAcademique);
            StyleSubMenuButton(btnSession);
            StyleSubMenuButton(btnDepartement);
            StyleSubMenuButton(btnProfesseur);
            StyleSubMenuButton(btnCandidat);

            // Cacher les sous-menus initialement
            pnlSubParametres.Visible = false;
            pnlSubUtilisateurs.Visible = false;

            // Charger le Dashboard par defaut
            OpenChildForm(new frmDashboard());
            SetActiveButton(btnDashboard);
            UpdateHeaderTitle("Tableau de Bord");
        }

        private void LblLogoIcon_Paint(object sender, PaintEventArgs e)
        {
            Label lbl = (Label)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, lbl.Width - 1, lbl.Height - 1);
            using (GraphicsPath path = UITheme.RoundedRect(rect, 8))
            {
                using (SolidBrush brush = new SolidBrush(_accentColor))
                {
                    e.Graphics.FillPath(brush, path);
                }
            }

            TextRenderer.DrawText(e.Graphics, "SS", lbl.Font, rect, Color.White,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void PnlHeader_Paint(object sender, PaintEventArgs e)
        {
            // Ligne de bordure subtile en bas du header
            using (Pen pen = new Pen(UITheme.BorderColor, 1))
            {
                e.Graphics.DrawLine(pen, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);
            }
        }

        private void UpdateDateTime()
        {
            var culture = new System.Globalization.CultureInfo("fr-FR");
            lblDateTime.Text = DateTime.Now.ToString("dddd, d MMMM yyyy", culture);
            lblDateTime.Text = char.ToUpper(lblDateTime.Text[0]) + lblDateTime.Text.Substring(1);
        }

        private void UpdateHeaderTitle(string title)
        {
            lblAppTitle.Text = title;
        }

        private void StyleMenuButton(Button btn, bool isFirst)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = _sidebarBg;
            btn.ForeColor = _textInactive;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(28, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
            btn.Height = 48;

            btn.Paint += (s, e) =>
            {
                if (btn == _activeMenuButton)
                {
                    // Indicateur actif
                    using (SolidBrush brush = new SolidBrush(_accentColor))
                    {
                        e.Graphics.FillRectangle(brush, 0, 8, 4, btn.Height - 16);
                    }
                }
            };

            btn.MouseEnter += (s, e) =>
            {
                if (btn != _activeMenuButton)
                    btn.BackColor = _sidebarHover;
            };
            btn.MouseLeave += (s, e) =>
            {
                if (btn != _activeMenuButton)
                    btn.BackColor = _sidebarBg;
            };
        }

        private void StyleSubMenuButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = Color.FromArgb(22, 33, 51);
            btn.ForeColor = Color.FromArgb(125, 140, 160);
            btn.Font = new Font("Segoe UI", 9F, FontStyle.Regular);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(48, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
            btn.Height = 42;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = _sidebarHover;
                btn.ForeColor = Color.FromArgb(180, 190, 200);
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = Color.FromArgb(22, 33, 51);
                btn.ForeColor = Color.FromArgb(125, 140, 160);
            };
        }

        private void StyleDeconnexionButton(Button btn)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = _sidebarBg;
            btn.ForeColor = UITheme.DangerColor;
            btn.Font = new Font("Segoe UI", 10F, FontStyle.Regular);
            btn.TextAlign = ContentAlignment.MiddleLeft;
            btn.Padding = new Padding(28, 0, 0, 0);
            btn.Cursor = Cursors.Hand;
            btn.Height = 48;

            btn.MouseEnter += (s, e) =>
            {
                btn.BackColor = UITheme.DangerColor;
                btn.ForeColor = Color.White;
            };
            btn.MouseLeave += (s, e) =>
            {
                btn.BackColor = _sidebarBg;
                btn.ForeColor = UITheme.DangerColor;
            };
        }

        private void SetActiveButton(Button btn)
        {
            // Reinitialiser l'ancien bouton actif
            if (_activeMenuButton != null)
            {
                _activeMenuButton.BackColor = _sidebarBg;
                _activeMenuButton.ForeColor = _textInactive;
                _activeMenuButton.Invalidate();
            }

            // Activer le nouveau bouton
            _activeMenuButton = btn;
            btn.BackColor = _sidebarActive;
            btn.ForeColor = _textActive;
            btn.Invalidate();
        }

        private void ToggleSubMenu(Panel subMenu, Button parentButton)
        {
            // Fermer l'autre sous-menu si ouvert
            if (_activeSubMenu != null && _activeSubMenu != subMenu)
            {
                _activeSubMenu.Visible = false;
            }

            // Animation de toggle
            subMenu.Visible = !subMenu.Visible;
            _activeSubMenu = subMenu.Visible ? subMenu : null;
        }

        private void CloseAllSubMenus()
        {
            pnlSubParametres.Visible = false;
            pnlSubUtilisateurs.Visible = false;
            _activeSubMenu = null;
        }

        private void OpenChildForm(Form childForm)
        {
            CloseAllChildForms();
            childForm.TopLevel = false;
            childForm.Dock = DockStyle.Fill;
            childForm.FormBorderStyle = FormBorderStyle.None;
            pnlMain.Controls.Add(childForm);
            childForm.BringToFront();
            childForm.Show();
        }

        private void CloseAllChildForms()
        {
            foreach (Control ctrl in pnlMain.Controls)
            {
                if (ctrl is Form form)
                {
                    form.Close();
                }
            }
            pnlMain.Controls.Clear();
        }

        // Event Handlers pour les boutons du menu

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            CloseAllSubMenus();
            SetActiveButton(btnDashboard);
            UpdateHeaderTitle("Tableau de Bord");
            OpenChildForm(new frmDashboard());
        }

        private void btnParametres_Click(object sender, EventArgs e)
        {
            ToggleSubMenu(pnlSubParametres, btnParametres);
        }

        private void btnUtilisateurs_Click(object sender, EventArgs e)
        {
            ToggleSubMenu(pnlSubUtilisateurs, btnUtilisateurs);
        }

        private void btnAnneeAcademique_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnParametres);
            UpdateHeaderTitle("Annees Academiques");
            OpenChildForm(new frmAnneeAcademique());
        }

        private void btnSession_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnParametres);
            UpdateHeaderTitle("Sessions");
            OpenChildForm(new frmSession());
        }

        private void btnDepartement_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnParametres);
            UpdateHeaderTitle("Departements");
            OpenChildForm(new frmDepartement());
        }

        private void btnProfesseur_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnUtilisateurs);
            UpdateHeaderTitle("Professeurs");
            OpenChildForm(new frmProfesseur());
        }

        private void btnCandidat_Click(object sender, EventArgs e)
        {
            SetActiveButton(btnUtilisateurs);
            UpdateHeaderTitle("Candidats");
            OpenChildForm(new frmCandidat());
        }

        private void btnMemoires_Click(object sender, EventArgs e)
        {
            CloseAllSubMenus();
            SetActiveButton(btnMemoires);
            UpdateHeaderTitle("Memoires");
            OpenChildForm(new frmMemoire());
        }

        private void btnSoutenances_Click(object sender, EventArgs e)
        {
            CloseAllSubMenus();
            SetActiveButton(btnSoutenances);
            UpdateHeaderTitle("Soutenances");
            OpenChildForm(new frmSoutenance());
        }

        private void btnDeconnexion_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmLogout())
            {
                _dateTimeTimer?.Stop();

                var authService = new AuthentificationService();
                authService.Deconnecter();

                var loginForm = new fmrConnection();
                loginForm.Show();
                this.Close();
            }
        }

        private void FmrMBI_Load(object sender, EventArgs e)
        {
            // Animation fade-in
            this.Opacity = 0;
            var fadeTimer = new Timer { Interval = 20 };
            fadeTimer.Tick += (s, args) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.1;
                else
                {
                    this.Opacity = 1;
                    fadeTimer.Stop();
                }
            };
            fadeTimer.Start();
        }

        private void FmrMBI_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                if (!MessageHelper.ConfirmExit())
                {
                    e.Cancel = true;
                }
            }

            _dateTimeTimer?.Stop();
        }
    }
}
