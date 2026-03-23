using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace AppSoutenance.Helpers
{
    /// <summary>
    /// Theme UI Premium pour Sen Soutenance
    /// Design System Moderne et Professionnel
    /// </summary>
    public static class UITheme
    {
        #region Palette de Couleurs Premium

        // === Couleurs Primaires ===
        public static Color PrimaryColor => Color.FromArgb(99, 102, 241);      // Indigo moderne
        public static Color PrimaryDarkColor => Color.FromArgb(79, 70, 229);    // Indigo foncé
        public static Color PrimaryLightColor => Color.FromArgb(129, 140, 248); // Indigo clair
        public static Color PrimaryLighterColor => Color.FromArgb(238, 242, 255); // Indigo très clair

        // === Couleurs Secondaires ===
        public static Color SecondaryColor => Color.FromArgb(14, 165, 233);    // Sky blue
        public static Color SecondaryDarkColor => Color.FromArgb(2, 132, 199);
        public static Color SecondaryLightColor => Color.FromArgb(56, 189, 248);

        // === Couleurs d'Accent ===
        public static Color AccentColor => Color.FromArgb(245, 158, 11);       // Amber
        public static Color AccentDarkColor => Color.FromArgb(217, 119, 6);
        public static Color AccentLightColor => Color.FromArgb(251, 191, 36);

        // === Couleurs Sémantiques ===
        public static Color SuccessColor => Color.FromArgb(34, 197, 94);       // Green
        public static Color SuccessDarkColor => Color.FromArgb(22, 163, 74);
        public static Color SuccessLightColor => Color.FromArgb(74, 222, 128);
        public static Color SuccessBgColor => Color.FromArgb(240, 253, 244);

        public static Color DangerColor => Color.FromArgb(239, 68, 68);        // Red
        public static Color DangerDarkColor => Color.FromArgb(220, 38, 38);
        public static Color DangerLightColor => Color.FromArgb(248, 113, 113);
        public static Color DangerBgColor => Color.FromArgb(254, 242, 242);

        public static Color WarningColor => Color.FromArgb(234, 179, 8);       // Yellow
        public static Color WarningDarkColor => Color.FromArgb(202, 138, 4);
        public static Color WarningLightColor => Color.FromArgb(250, 204, 21);
        public static Color WarningBgColor => Color.FromArgb(254, 252, 232);

        public static Color InfoColor => Color.FromArgb(59, 130, 246);         // Blue
        public static Color InfoDarkColor => Color.FromArgb(37, 99, 235);
        public static Color InfoLightColor => Color.FromArgb(96, 165, 250);
        public static Color InfoBgColor => Color.FromArgb(239, 246, 255);

        #endregion

        #region Couleurs de Surface

        // === Background ===
        public static Color BackgroundColor => Color.FromArgb(248, 250, 252);  // Slate 50
        public static Color BackgroundDarkColor => Color.FromArgb(241, 245, 249); // Slate 100
        public static Color SurfaceColor => Color.White;
        public static Color CardBackgroundColor => Color.White;
        public static Color PanelBackgroundColor => Color.White;

        // === Sidebar Premium ===
        public static Color SidebarBackgroundColor => Color.FromArgb(15, 23, 42);   // Slate 900
        public static Color SidebarHoverColor => Color.FromArgb(30, 41, 59);        // Slate 800
        public static Color SidebarActiveColor => Color.FromArgb(51, 65, 85);       // Slate 700
        public static Color SidebarTextColor => Color.FromArgb(148, 163, 184);      // Slate 400
        public static Color SidebarTextActiveColor => Color.White;

        // === Header Premium ===
        public static Color HeaderBackgroundColor => Color.White;
        public static Color HeaderBorderColor => Color.FromArgb(226, 232, 240);     // Slate 200

        #endregion

        #region Couleurs de Texte

        public static Color TextPrimaryColor => Color.FromArgb(15, 23, 42);         // Slate 900
        public static Color TextSecondaryColor => Color.FromArgb(100, 116, 139);    // Slate 500
        public static Color TextTertiaryColor => Color.FromArgb(148, 163, 184);     // Slate 400
        public static Color TextOnDarkColor => Color.White;
        public static Color TextOnPrimaryColor => Color.White;
        public static Color LabelColor => Color.FromArgb(71, 85, 105);              // Slate 600
        public static Color PlaceholderColor => Color.FromArgb(148, 163, 184);      // Slate 400

        #endregion

        #region Couleurs de Bordure

        public static Color BorderColor => Color.FromArgb(226, 232, 240);           // Slate 200
        public static Color BorderLightColor => Color.FromArgb(241, 245, 249);      // Slate 100
        public static Color BorderDarkColor => Color.FromArgb(203, 213, 225);       // Slate 300
        public static Color BorderFocusColor => PrimaryColor;
        public static Color BorderErrorColor => DangerColor;
        public static Color BorderSuccessColor => SuccessColor;

        #endregion

        #region Typographie Premium

        public static Font DisplayFont => new Font("Segoe UI", 32F, FontStyle.Bold);
        public static Font TitleFont => new Font("Segoe UI", 24F, FontStyle.Bold);
        public static Font SubtitleFont => new Font("Segoe UI", 18F, FontStyle.Bold);
        public static Font HeaderFont => new Font("Segoe UI", 14F, FontStyle.Bold);
        public static Font SubHeaderFont => new Font("Segoe UI", 12F, FontStyle.Bold);
        public static Font BodyFont => new Font("Segoe UI", 11F, FontStyle.Regular);
        public static Font NormalFont => new Font("Segoe UI", 10F, FontStyle.Regular);
        public static Font LabelFont => new Font("Segoe UI", 9F, FontStyle.Bold);
        public static Font SmallFont => new Font("Segoe UI", 8F, FontStyle.Regular);
        public static Font CaptionFont => new Font("Segoe UI", 8F, FontStyle.Regular);
        public static Font ButtonFont => new Font("Segoe UI", 10F, FontStyle.Bold);
        public static Font MenuFont => new Font("Segoe UI", 10F, FontStyle.Regular);

        #endregion

        #region Dimensions et Espacement

        public static int BorderRadiusSmall => 6;
        public static int BorderRadius => 10;
        public static int BorderRadiusLarge => 16;
        public static int BorderRadiusXL => 24;

        public static int SpacingXS => 4;
        public static int SpacingS => 8;
        public static int Spacing => 12;
        public static int SpacingM => 16;
        public static int SpacingL => 24;
        public static int SpacingXL => 32;
        public static int SpacingXXL => 48;

        public static Padding PaddingSmall => new Padding(8);
        public static Padding PaddingNormal => new Padding(12);
        public static Padding PaddingMedium => new Padding(16);
        public static Padding PaddingLarge => new Padding(24);
        public static Padding StandardPadding => new Padding(16);

        public static int ButtonHeight => 44;
        public static int ButtonHeightSmall => 36;
        public static int ButtonHeightLarge => 52;
        public static int TextBoxHeight => 44;
        public static int ComboBoxHeight => 44;
        public static int SidebarWidth => 260;
        public static int HeaderHeight => 70;

        #endregion

        #region Ombres (simulées par bordures)

        public static Color ShadowLight => Color.FromArgb(15, 0, 0, 0);
        public static Color ShadowMedium => Color.FromArgb(25, 0, 0, 0);
        public static Color ShadowDark => Color.FromArgb(40, 0, 0, 0);

        #endregion

        #region Application du Thème aux Contrôles

        /// <summary>
        /// Applique le style au bouton principal (Primary)
        /// </summary>
        public static void ApplyPrimaryButton(Button button)
        {
            button.BackColor = PrimaryColor;
            button.ForeColor = TextOnPrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = PrimaryDarkColor;
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(67, 56, 202);
            button.Font = ButtonFont;
            button.Height = ButtonHeight;
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(20, 0, 20, 0);

            // Animation hover
            button.MouseEnter += (s, e) => {
                button.BackColor = PrimaryDarkColor;
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = PrimaryColor;
            };
        }

        /// <summary>
        /// Applique le style au bouton secondaire (Outline)
        /// </summary>
        public static void ApplySecondaryButton(Button button)
        {
            button.BackColor = Color.White;
            button.ForeColor = PrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderColor = BorderColor;
            button.FlatAppearance.BorderSize = 2;
            button.FlatAppearance.MouseOverBackColor = PrimaryLighterColor;
            button.Font = ButtonFont;
            button.Height = ButtonHeight;
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(20, 0, 20, 0);

            button.MouseEnter += (s, e) => {
                button.BackColor = PrimaryLighterColor;
                button.FlatAppearance.BorderColor = PrimaryColor;
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = Color.White;
                button.FlatAppearance.BorderColor = BorderColor;
            };
        }

        /// <summary>
        /// Applique le style au bouton de succès
        /// </summary>
        public static void ApplySuccessButton(Button button)
        {
            button.BackColor = SuccessColor;
            button.ForeColor = TextOnPrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = SuccessDarkColor;
            button.Font = ButtonFont;
            button.Height = ButtonHeight;
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(20, 0, 20, 0);

            button.MouseEnter += (s, e) => button.BackColor = SuccessDarkColor;
            button.MouseLeave += (s, e) => button.BackColor = SuccessColor;
        }

        /// <summary>
        /// Applique le style au bouton de danger
        /// </summary>
        public static void ApplyDangerButton(Button button)
        {
            button.BackColor = DangerColor;
            button.ForeColor = TextOnPrimaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = DangerDarkColor;
            button.Font = ButtonFont;
            button.Height = ButtonHeight;
            button.Cursor = Cursors.Hand;
            button.Padding = new Padding(20, 0, 20, 0);

            button.MouseEnter += (s, e) => button.BackColor = DangerDarkColor;
            button.MouseLeave += (s, e) => button.BackColor = DangerColor;
        }

        /// <summary>
        /// Applique le style au bouton Ghost (transparent)
        /// </summary>
        public static void ApplyGhostButton(Button button)
        {
            button.BackColor = Color.Transparent;
            button.ForeColor = TextSecondaryColor;
            button.FlatStyle = FlatStyle.Flat;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = BackgroundDarkColor;
            button.Font = ButtonFont;
            button.Height = ButtonHeight;
            button.Cursor = Cursors.Hand;

            button.MouseEnter += (s, e) => {
                button.BackColor = BackgroundDarkColor;
                button.ForeColor = TextPrimaryColor;
            };
            button.MouseLeave += (s, e) => {
                button.BackColor = Color.Transparent;
                button.ForeColor = TextSecondaryColor;
            };
        }

        /// <summary>
        /// Applique le style moderne à un TextBox
        /// </summary>
        public static void ApplyToTextBox(TextBox textBox)
        {
            textBox.BorderStyle = BorderStyle.FixedSingle;
            textBox.Font = BodyFont;
            textBox.BackColor = Color.White;
            textBox.ForeColor = TextPrimaryColor;

            textBox.Enter += (s, e) => {
                textBox.BackColor = Color.FromArgb(248, 250, 255);
            };
            textBox.Leave += (s, e) => {
                textBox.BackColor = Color.White;
            };
        }

        /// <summary>
        /// Applique le style moderne à un ComboBox
        /// </summary>
        public static void ApplyToComboBox(ComboBox comboBox)
        {
            comboBox.FlatStyle = FlatStyle.Flat;
            comboBox.Font = BodyFont;
            comboBox.BackColor = Color.White;
            comboBox.ForeColor = TextPrimaryColor;
            comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Applique le style moderne à un DataGridView
        /// </summary>
        public static void ApplyToDataGridView(DataGridView dgv)
        {
            dgv.BackgroundColor = Color.White;
            dgv.BorderStyle = BorderStyle.None;
            dgv.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgv.GridColor = BorderLightColor;

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = BackgroundColor;
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = TextSecondaryColor;
            dgv.ColumnHeadersDefaultCellStyle.Font = LabelFont;
            dgv.ColumnHeadersDefaultCellStyle.Padding = new Padding(16, 12, 16, 12);
            dgv.ColumnHeadersHeight = 50;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;

            dgv.DefaultCellStyle.BackColor = Color.White;
            dgv.DefaultCellStyle.ForeColor = TextPrimaryColor;
            dgv.DefaultCellStyle.Font = NormalFont;
            dgv.DefaultCellStyle.SelectionBackColor = PrimaryLighterColor;
            dgv.DefaultCellStyle.SelectionForeColor = PrimaryDarkColor;
            dgv.DefaultCellStyle.Padding = new Padding(16, 12, 16, 12);

            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 250, 251);

            dgv.RowHeadersVisible = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.ReadOnly = true;
            dgv.RowTemplate.Height = 52;
        }

        /// <summary>
        /// Applique le style titre
        /// </summary>
        public static void ApplyTitleLabel(Label label)
        {
            label.Font = TitleFont;
            label.ForeColor = TextPrimaryColor;
        }

        /// <summary>
        /// Applique le style sous-titre
        /// </summary>
        public static void ApplySubtitleLabel(Label label)
        {
            label.Font = SubtitleFont;
            label.ForeColor = TextSecondaryColor;
        }

        /// <summary>
        /// Applique le style label normal
        /// </summary>
        public static void ApplyNormalLabel(Label label)
        {
            label.Font = LabelFont;
            label.ForeColor = LabelColor;
        }

        /// <summary>
        /// Applique le thème à un formulaire
        /// </summary>
        public static void ApplyToForm(Form form)
        {
            form.BackColor = BackgroundColor;
            form.Font = NormalFont;
        }

        /// <summary>
        /// Applique le thème à un Panel
        /// </summary>
        public static void ApplyToPanel(Panel panel, bool isCard = false)
        {
            panel.BackColor = isCard ? CardBackgroundColor : PanelBackgroundColor;
            panel.Padding = StandardPadding;
        }

        /// <summary>
        /// Applique le thème à un GroupBox
        /// </summary>
        public static void ApplyToGroupBox(GroupBox groupBox)
        {
            groupBox.BackColor = CardBackgroundColor;
            groupBox.ForeColor = TextPrimaryColor;
            groupBox.Font = SubHeaderFont;
            groupBox.Padding = StandardPadding;
        }

        /// <summary>
        /// Crée un panel avec effet carte
        /// </summary>
        public static Panel CreateCardPanel()
        {
            return new Panel
            {
                BackColor = CardBackgroundColor,
                Padding = PaddingLarge
            };
        }

        #endregion

        #region Utilitaires Graphiques

        /// <summary>
        /// Crée un chemin avec coins arrondis
        /// </summary>
        public static GraphicsPath RoundedRect(Rectangle bounds, int radius)
        {
            int diameter = radius * 2;
            Size size = new Size(diameter, diameter);
            Rectangle arc = new Rectangle(bounds.Location, size);
            GraphicsPath path = new GraphicsPath();

            if (radius == 0)
            {
                path.AddRectangle(bounds);
                return path;
            }

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();

            return path;
        }

        /// <summary>
        /// Crée un dégradé linéaire
        /// </summary>
        public static LinearGradientBrush CreateGradient(Rectangle rect, Color color1, Color color2, float angle = 135f)
        {
            return new LinearGradientBrush(rect, color1, color2, angle);
        }

        #endregion
    }
}
