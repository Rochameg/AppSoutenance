using AppSoutenance.Helpers;
using AppSoutenance.Services;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace AppSoutenance
{
    public partial class fmrConnection : Form
    {
        private readonly AuthentificationService _authService;
        private FormValidator _validator = null!;
        private bool _isLoading = false;
        private Color _emailBorderColor = UITheme.BorderColor;
        private Color _passwordBorderColor = UITheme.BorderColor;

        public fmrConnection()
        {
            InitializeComponent();
            _authService = new AuthentificationService();
            InitializeUI();
        }

        private void InitializeUI()
        {
            // Configuration du formulaire
            this.DoubleBuffered = true;
            this.BackColor = UITheme.BackgroundColor;

            // Style des zones de saisie avec bordures
            StyleInputPanel(pnlEmail, txtEmail);
            StyleInputPanel(pnlPassword, txtPassword);

            // Style du bouton de connexion
            ApplyModernButtonStyle(btnLogin, UITheme.PrimaryColor, UITheme.PrimaryDarkColor);

            // Style du bouton Quitter
            ApplyOutlineButtonStyle(btnCancel);

            // Effet de focus sur les TextBox
            txtEmail.GotFocus += (s, e) => SetInputFocus(pnlEmail, true);
            txtEmail.LostFocus += (s, e) => SetInputFocus(pnlEmail, false);
            txtPassword.GotFocus += (s, e) => SetInputFocus(pnlPassword, true);
            txtPassword.LostFocus += (s, e) => SetInputFocus(pnlPassword, false);

            // Validation
            _validator = new FormValidator(this);

            // Label d'erreur
            lblError.ForeColor = UITheme.DangerColor;
            lblError.Visible = false;

            // Focus initial
            txtEmail.Focus();

            // Peinture personnalisee des panels
            pnlEmail.Paint += InputPanel_Paint;
            pnlPassword.Paint += InputPanel_Paint;
            pnlLeft.Paint += BrandPanel_Paint;
            pnlMain.Paint += MainPanel_Paint;
        }

        private void MainPanel_Paint(object sender, PaintEventArgs e)
        {
            // Coins arrondis pour le panel principal
            Panel panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (GraphicsPath path = UITheme.RoundedRect(new Rectangle(0, 0, panel.Width - 1, panel.Height - 1), 20))
            {
                panel.Region = new Region(path);
            }
        }

        private void BrandPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle rect = new Rectangle(0, 0, panel.Width, panel.Height);

            // Gradient de fond
            using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                rect,
                UITheme.PrimaryColor,
                UITheme.PrimaryDarkColor,
                45f))
            {
                e.Graphics.FillRectangle(gradientBrush, rect);
            }

            // Cercles decoratifs
            using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(20, 255, 255, 255)))
            {
                e.Graphics.FillEllipse(circleBrush, -50, -50, 200, 200);
                e.Graphics.FillEllipse(circleBrush, panel.Width - 100, panel.Height - 150, 250, 250);
                e.Graphics.FillEllipse(circleBrush, panel.Width - 200, 100, 150, 150);
            }

            // Coins arrondis gauche
            using (GraphicsPath path = CreateLeftRoundedRect(new Rectangle(0, 0, panel.Width, panel.Height - 1), 20))
            {
                panel.Region = new Region(path);
            }
        }

        private GraphicsPath CreateLeftRoundedRect(Rectangle bounds, int radius)
        {
            GraphicsPath path = new GraphicsPath();
            int diameter = radius * 2;

            // Coin superieur gauche arrondi
            path.AddArc(bounds.Left, bounds.Top, diameter, diameter, 180, 90);
            // Ligne superieure
            path.AddLine(bounds.Left + radius, bounds.Top, bounds.Right, bounds.Top);
            // Cote droit (pas arrondi)
            path.AddLine(bounds.Right, bounds.Top, bounds.Right, bounds.Bottom);
            // Ligne inferieure
            path.AddLine(bounds.Right, bounds.Bottom, bounds.Left + radius, bounds.Bottom);
            // Coin inferieur gauche arrondi
            path.AddArc(bounds.Left, bounds.Bottom - diameter, diameter, diameter, 90, 90);
            path.CloseFigure();

            return path;
        }

        private void InputPanel_Paint(object sender, PaintEventArgs e)
        {
            Panel panel = (Panel)sender;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Color borderColor = panel == pnlEmail ? _emailBorderColor : _passwordBorderColor;

            Rectangle rect = new Rectangle(0, 0, panel.Width - 1, panel.Height - 1);

            using (GraphicsPath path = UITheme.RoundedRect(rect, 10))
            {
                // Fond
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, path);
                }

                // Bordure
                using (Pen pen = new Pen(borderColor, borderColor == UITheme.PrimaryColor ? 2 : 1))
                {
                    e.Graphics.DrawPath(pen, path);
                }
            }
        }

        private void StyleInputPanel(Panel panel, TextBox textBox)
        {
            panel.BackColor = Color.Transparent;
            textBox.BackColor = Color.White;
        }

        private void SetInputFocus(Panel panel, bool focused)
        {
            if (panel == pnlEmail)
                _emailBorderColor = focused ? UITheme.PrimaryColor : UITheme.BorderColor;
            else
                _passwordBorderColor = focused ? UITheme.PrimaryColor : UITheme.BorderColor;

            panel.Invalidate();
        }

        private void ApplyModernButtonStyle(Button button, Color normalColor, Color hoverColor)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = normalColor;
            button.ForeColor = Color.White;
            button.Cursor = Cursors.Hand;

            button.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, button.Width - 1, button.Height - 1);

                using (GraphicsPath path = UITheme.RoundedRect(rect, 10))
                {
                    button.Region = new Region(path);
                }
            };

            button.MouseEnter += (s, e) =>
            {
                button.BackColor = hoverColor;
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = normalColor;
            };
        }

        private void ApplyOutlineButtonStyle(Button button)
        {
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.BackColor = Color.White;
            button.ForeColor = UITheme.TextSecondaryColor;
            button.Cursor = Cursors.Hand;

            button.Paint += (s, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle rect = new Rectangle(0, 0, button.Width - 1, button.Height - 1);

                using (GraphicsPath path = UITheme.RoundedRect(rect, 10))
                {
                    button.Region = new Region(path);

                    using (Pen pen = new Pen(UITheme.BorderColor, 2))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            };

            button.MouseEnter += (s, e) =>
            {
                button.BackColor = UITheme.BackgroundDarkColor;
                button.ForeColor = UITheme.TextPrimaryColor;
            };

            button.MouseLeave += (s, e) =>
            {
                button.BackColor = Color.White;
                button.ForeColor = UITheme.TextSecondaryColor;
            };
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (_isLoading) return;

            // Validation
            _validator.ClearErrors();

            bool isValid = true;
            isValid &= _validator.RequiredField(txtEmail, "Email");
            isValid &= _validator.RequiredField(txtPassword, "Mot de passe");

            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
            {
                isValid &= _validator.ValidEmail(txtEmail);
            }

            if (!isValid)
            {
                ShowError(_validator.GetFirstError());
                return;
            }

            // Authentification
            SetLoading(true);

            try
            {
                var result = _authService.Authentifier(txtEmail.Text.Trim(), txtPassword.Text);

                if (result.IsSuccess)
                {
                    HideError();
                    var mainForm = new FmrMBI();
                    mainForm.Show();
                    this.Hide();
                }
                else
                {
                    ShowError(result.Message);
                    txtPassword.SelectAll();
                    txtPassword.Focus();
                }
            }
            catch (Exception ex)
            {
                var innerMsg = ex.InnerException?.Message ?? "Aucun detail";
                ShowError("Erreur de connexion. Verifiez votre connexion a la base de donnees.");
                System.Diagnostics.Debug.WriteLine($"Erreur: {ex.Message}\nDetails: {innerMsg}");
            }
            finally
            {
                SetLoading(false);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageHelper.ConfirmExit())
            {
                Application.Exit();
            }
        }

        private void SetLoading(bool loading)
        {
            _isLoading = loading;
            btnLogin.Enabled = !loading;
            btnLogin.Text = loading ? "Connexion en cours..." : "Se connecter";
            txtEmail.Enabled = !loading;
            txtPassword.Enabled = !loading;
            this.Cursor = loading ? Cursors.WaitCursor : Cursors.Default;
        }

        private void ShowError(string message)
        {
            lblError.Text = message;
            lblError.Visible = true;

            // Animation de secousse subtile
            var originalLocation = pnlEmail.Location;
            var timer = new Timer { Interval = 50 };
            int count = 0;

            timer.Tick += (s, e) =>
            {
                count++;
                int offset = count % 2 == 0 ? 3 : -3;

                if (count <= 4)
                {
                    pnlEmail.Location = new Point(originalLocation.X + offset, originalLocation.Y);
                    pnlPassword.Location = new Point(pnlPassword.Location.X + offset, pnlPassword.Location.Y);
                }
                else
                {
                    pnlEmail.Location = originalLocation;
                    pnlPassword.Location = new Point(0, 290);
                    timer.Stop();
                }
            };
            timer.Start();
        }

        private void HideError()
        {
            lblError.Visible = false;
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(sender, e);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtPassword.Focus();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void fmrConnection_Load(object sender, EventArgs e)
        {
            // Animation fade-in
            this.Opacity = 0;
            var timer = new Timer { Interval = 15 };
            timer.Tick += (s, args) =>
            {
                if (this.Opacity < 1)
                    this.Opacity += 0.08;
                else
                {
                    this.Opacity = 1;
                    timer.Stop();
                }
            };
            timer.Start();

            // Centrer le panel principal
            CenterMainPanel();
        }

        private void CenterMainPanel()
        {
            pnlMain.Location = new Point(
                (this.ClientSize.Width - pnlMain.Width) / 2,
                (this.ClientSize.Height - pnlMain.Height - 40) / 2
            );
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            CenterMainPanel();
        }
    }
}
