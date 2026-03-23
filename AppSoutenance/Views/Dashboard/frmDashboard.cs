using AppSoutenance.Helpers;
using AppSoutenance.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AppSoutenance.Views.Dashboard
{
    public partial class frmDashboard : Form
    {
        private readonly DashboardService _dashboardService;

        // Couleurs des cartes statistiques
        private readonly Color[] _cardColors = new Color[]
        {
            Color.FromArgb(99, 102, 241),   // Indigo - Professeurs
            Color.FromArgb(14, 165, 233),   // Sky Blue - Candidats
            Color.FromArgb(34, 197, 94),    // Green - Memoires
            Color.FromArgb(245, 158, 11)    // Amber - Soutenances
        };

        private readonly Color[] _cardLightColors = new Color[]
        {
            Color.FromArgb(129, 140, 248),  // Indigo Light
            Color.FromArgb(56, 189, 248),   // Sky Blue Light
            Color.FromArgb(74, 222, 128),   // Green Light
            Color.FromArgb(251, 191, 36)    // Amber Light
        };

        public frmDashboard()
        {
            InitializeComponent();
            _dashboardService = new DashboardService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            this.BackColor = UITheme.BackgroundColor;
            this.DoubleBuffered = true;

            // Cacher le titre car il est dans le header principal
            lblTitle.Visible = false;

            // Header du dashboard
            pnlHeader.BackColor = UITheme.BackgroundColor;
            lblAnneeActuelle.ForeColor = UITheme.TextPrimaryColor;
            lblAnneeActuelle.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblStatAnnee.ForeColor = UITheme.TextSecondaryColor;

            // Bouton actualiser moderne
            StyleRefreshButton();

            // Style moderne des cartes statistiques avec gradient
            StyleStatCard(pnlCardProfesseurs, lblStatProfesseurs, lblTitleProfesseurs, 0);
            StyleStatCard(pnlCardCandidats, lblStatCandidats, lblTitleCandidats, 1);
            StyleStatCard(pnlCardMemoires, lblStatMemoires, lblTitleMemoires, 2);
            StyleStatCard(pnlCardSoutenances, lblStatSoutenances, lblTitleSoutenances, 3);

            // Panel des stats avec espacement
            pnlStats.BackColor = UITheme.BackgroundColor;
            pnlStats.Padding = new Padding(0, 10, 0, 10);

            // Style des panels de listes
            StyleListPanel(pnlProchainesSoutenances, lblTitleProchaines, "Prochaines Soutenances");
            StyleListPanel(pnlDernieresSoutenances, lblTitleDernieres, "Dernieres Soutenances");

            // Style moderne des DataGridView
            StyleDataGridView(dgvProchainesSoutenances);
            StyleDataGridView(dgvDernieresSoutenances);
        }

        private void StyleRefreshButton()
        {
            btnRefresh.BackColor = UITheme.PrimaryColor;
            btnRefresh.ForeColor = Color.White;
            btnRefresh.FlatStyle = FlatStyle.Flat;
            btnRefresh.FlatAppearance.BorderSize = 0;
            btnRefresh.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRefresh.Cursor = Cursors.Hand;
            btnRefresh.Size = new Size(130, 40);

            btnRefresh.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, btnRefresh.Width - 1, btnRefresh.Height - 1);
                using (GraphicsPath path = UITheme.RoundedRect(rect, 10))
                {
                    btnRefresh.Region = new Region(path);
                }
            };

            btnRefresh.MouseEnter += (s, e) => btnRefresh.BackColor = UITheme.PrimaryDarkColor;
            btnRefresh.MouseLeave += (s, e) => btnRefresh.BackColor = UITheme.PrimaryColor;
        }

        private void StyleStatCard(Panel panel, Label statLabel, Label titleLabel, int colorIndex)
        {
            panel.BackColor = Color.Transparent;
            panel.Padding = new Padding(0);
            panel.Margin = new Padding(10);
            panel.Size = new Size(230, 140);

            // Peinture personnalisee avec gradient et coins arrondis
            panel.Paint += (s, e) =>
            {
                Panel pnl = (Panel)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

                using (GraphicsPath path = UITheme.RoundedRect(rect, 16))
                {
                    // Gradient de fond
                    using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                        rect, _cardColors[colorIndex], _cardLightColors[colorIndex], 135f))
                    {
                        e.Graphics.FillPath(gradientBrush, path);
                    }

                    // Cercles decoratifs
                    using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
                    {
                        e.Graphics.FillEllipse(circleBrush, pnl.Width - 80, -30, 100, 100);
                        e.Graphics.FillEllipse(circleBrush, pnl.Width - 50, pnl.Height - 40, 80, 80);
                    }
                }
            };

            // Style des labels
            statLabel.BackColor = Color.Transparent;
            statLabel.Font = new Font("Segoe UI", 36F, FontStyle.Bold);
            statLabel.ForeColor = Color.White;
            statLabel.TextAlign = ContentAlignment.MiddleLeft;
            statLabel.Padding = new Padding(20, 15, 0, 0);

            titleLabel.BackColor = Color.Transparent;
            titleLabel.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            titleLabel.ForeColor = Color.FromArgb(230, 255, 255, 255);
            titleLabel.TextAlign = ContentAlignment.TopLeft;
            titleLabel.Padding = new Padding(20, 0, 0, 15);
        }

        private void StyleListPanel(Panel panel, Label titleLabel, string title)
        {
            panel.BackColor = Color.Transparent;
            panel.Padding = new Padding(0);

            panel.Paint += (s, e) =>
            {
                Panel pnl = (Panel)s;
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                Rectangle rect = new Rectangle(0, 0, pnl.Width - 1, pnl.Height - 1);

                using (GraphicsPath path = UITheme.RoundedRect(rect, 12))
                {
                    // Fond blanc
                    using (SolidBrush brush = new SolidBrush(Color.White))
                    {
                        e.Graphics.FillPath(brush, path);
                    }

                    // Bordure subtile
                    using (Pen pen = new Pen(UITheme.BorderLightColor, 1))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            titleLabel.BackColor = Color.Transparent;
            titleLabel.Text = title;
            titleLabel.Font = new Font("Segoe UI", 13F, FontStyle.Bold);
            titleLabel.ForeColor = UITheme.TextPrimaryColor;
            titleLabel.Padding = new Padding(10, 10, 0, 5);
        }

        private void StyleDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = UITheme.BorderLightColor;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = UITheme.TextSecondaryColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(12, 10, 12, 10);
            dgv.ColumnHeadersHeight = 45;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = UITheme.TextPrimaryColor;
            dgv.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            dgv.DefaultCellStyle.SelectionBackColor = UITheme.PrimaryLighterColor;
            dgv.DefaultCellStyle.SelectionForeColor = UITheme.PrimaryDarkColor;
            dgv.DefaultCellStyle.Padding = new Padding(12, 8, 12, 8);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);

            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowTemplate.Height = 48;
            dgv.ScrollBars = ScrollBars.Vertical;
        }

        private void frmDashboard_Load(object sender, EventArgs e)
        {
            LoadStatistiques();
            LoadProchainesSoutenances();
            LoadDernieresSoutenances();
        }

        private void LoadStatistiques()
        {
            try
            {
                var stats = _dashboardService.GetStatistiques();

                // Animation des compteurs
                AnimateCounter(lblStatProfesseurs, stats.NombreProfesseurs);
                AnimateCounter(lblStatCandidats, stats.NombreCandidats);
                AnimateCounter(lblStatMemoires, stats.NombreMemoires);
                AnimateCounter(lblStatSoutenances, stats.NombreSoutenances);

                if (!string.IsNullOrEmpty(stats.AnneeActuelle))
                {
                    lblAnneeActuelle.Text = $"Annee academique : {stats.AnneeActuelle}";
                    lblStatAnnee.Text = $"{stats.NombreMemoiresAnneeActuelle} memoires | {stats.NombreSoutenancesAnneeActuelle} soutenances";
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur chargement stats: {ex.Message}");
            }
        }

        private void AnimateCounter(Label label, int targetValue)
        {
            int currentValue = 0;
            int increment = Math.Max(1, targetValue / 20);

            var timer = new Timer { Interval = 30 };
            timer.Tick += (s, e) =>
            {
                currentValue += increment;
                if (currentValue >= targetValue)
                {
                    currentValue = targetValue;
                    timer.Stop();
                }
                label.Text = currentValue.ToString();
            };

            if (targetValue > 0)
                timer.Start();
            else
                label.Text = "0";
        }

        private void LoadProchainesSoutenances()
        {
            try
            {
                var soutenances = _dashboardService.GetProchainesSoutenances(5);
                dgvProchainesSoutenances.DataSource = soutenances;

                if (dgvProchainesSoutenances.Columns.Count > 0)
                {
                    dgvProchainesSoutenances.Columns["IdSoutenance"].Visible = false;
                    dgvProchainesSoutenances.Columns["Resultat"].Visible = false;
                    dgvProchainesSoutenances.Columns["Mention"].Visible = false;

                    dgvProchainesSoutenances.Columns["SujetMemoire"].HeaderText = "Sujet du Memoire";
                    dgvProchainesSoutenances.Columns["DateSoutenance"].HeaderText = "Date";
                    dgvProchainesSoutenances.Columns["LieuSoutenance"].HeaderText = "Lieu";

                    dgvProchainesSoutenances.Columns["DateSoutenance"].DefaultCellStyle.Format = "dd/MM/yyyy HH:mm";
                    dgvProchainesSoutenances.Columns["SujetMemoire"].FillWeight = 50;
                    dgvProchainesSoutenances.Columns["DateSoutenance"].FillWeight = 25;
                    dgvProchainesSoutenances.Columns["LieuSoutenance"].FillWeight = 25;
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur chargement prochaines soutenances: {ex.Message}");
            }
        }

        private void LoadDernieresSoutenances()
        {
            try
            {
                var soutenances = _dashboardService.GetDernieresSoutenances(5);
                dgvDernieresSoutenances.DataSource = soutenances;

                if (dgvDernieresSoutenances.Columns.Count > 0)
                {
                    dgvDernieresSoutenances.Columns["IdSoutenance"].Visible = false;
                    dgvDernieresSoutenances.Columns["LieuSoutenance"].Visible = false;

                    dgvDernieresSoutenances.Columns["SujetMemoire"].HeaderText = "Sujet du Memoire";
                    dgvDernieresSoutenances.Columns["DateSoutenance"].HeaderText = "Date";
                    dgvDernieresSoutenances.Columns["Resultat"].HeaderText = "Resultat";
                    dgvDernieresSoutenances.Columns["Mention"].HeaderText = "Mention";

                    dgvDernieresSoutenances.Columns["DateSoutenance"].DefaultCellStyle.Format = "dd/MM/yyyy";
                    dgvDernieresSoutenances.Columns["SujetMemoire"].FillWeight = 45;
                    dgvDernieresSoutenances.Columns["DateSoutenance"].FillWeight = 20;
                    dgvDernieresSoutenances.Columns["Resultat"].FillWeight = 17;
                    dgvDernieresSoutenances.Columns["Mention"].FillWeight = 18;

                    // Coloration conditionnelle pour le resultat
                    dgvDernieresSoutenances.CellFormatting += (s, e) =>
                    {
                        if (e.ColumnIndex == dgvDernieresSoutenances.Columns["Resultat"].Index && e.Value != null)
                        {
                            string resultat = e.Value.ToString().ToLower();
                            if (resultat.Contains("admis"))
                            {
                                e.CellStyle.ForeColor = UITheme.SuccessColor;
                                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                            else if (resultat.Contains("ajourn"))
                            {
                                e.CellStyle.ForeColor = UITheme.DangerColor;
                                e.CellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
                            }
                        }
                    };
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Erreur chargement dernieres soutenances: {ex.Message}");
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Animation de rotation du bouton
            btnRefresh.Text = "Chargement...";
            btnRefresh.Enabled = false;

            var timer = new Timer { Interval = 500 };
            timer.Tick += (s, args) =>
            {
                LoadStatistiques();
                LoadProchainesSoutenances();
                LoadDernieresSoutenances();

                btnRefresh.Text = "Actualiser";
                btnRefresh.Enabled = true;
                timer.Stop();

                MessageHelper.ShowSuccess("Donnees actualisees avec succes.");
            };
            timer.Start();
        }
    }
}
