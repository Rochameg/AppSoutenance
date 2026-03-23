using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;
using AppSoutenance.Helpers;

namespace AppSoutenance.Controls
{
    #region ModernButton - Bouton avec coins arrondis et animations

    public class ModernButton : Button
    {
        private Color _normalColor = UITheme.PrimaryColor;
        private Color _hoverColor = UITheme.PrimaryDarkColor;
        private Color _pressColor = Color.FromArgb(67, 56, 202);
        private int _borderRadius = 10;
        private bool _isHovered = false;
        private bool _isPressed = false;
        private ButtonStyle _buttonStyle = ButtonStyle.Primary;

        public enum ButtonStyle { Primary, Secondary, Success, Danger, Ghost, Outline }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public ButtonStyle Style
        {
            get => _buttonStyle;
            set
            {
                _buttonStyle = value;
                ApplyStyle();
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        public ModernButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = Color.White;
            Font = UITheme.ButtonFont;
            Cursor = Cursors.Hand;
            Size = new Size(140, UITheme.ButtonHeight);

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);

            ApplyStyle();
        }

        private void ApplyStyle()
        {
            switch (_buttonStyle)
            {
                case ButtonStyle.Primary:
                    _normalColor = UITheme.PrimaryColor;
                    _hoverColor = UITheme.PrimaryDarkColor;
                    _pressColor = Color.FromArgb(67, 56, 202);
                    ForeColor = Color.White;
                    break;
                case ButtonStyle.Secondary:
                    _normalColor = UITheme.SecondaryColor;
                    _hoverColor = UITheme.SecondaryDarkColor;
                    _pressColor = Color.FromArgb(3, 105, 161);
                    ForeColor = Color.White;
                    break;
                case ButtonStyle.Success:
                    _normalColor = UITheme.SuccessColor;
                    _hoverColor = UITheme.SuccessDarkColor;
                    _pressColor = Color.FromArgb(21, 128, 61);
                    ForeColor = Color.White;
                    break;
                case ButtonStyle.Danger:
                    _normalColor = UITheme.DangerColor;
                    _hoverColor = UITheme.DangerDarkColor;
                    _pressColor = Color.FromArgb(185, 28, 28);
                    ForeColor = Color.White;
                    break;
                case ButtonStyle.Ghost:
                    _normalColor = Color.Transparent;
                    _hoverColor = UITheme.BackgroundDarkColor;
                    _pressColor = UITheme.BorderColor;
                    ForeColor = UITheme.TextSecondaryColor;
                    break;
                case ButtonStyle.Outline:
                    _normalColor = Color.White;
                    _hoverColor = UITheme.PrimaryLighterColor;
                    _pressColor = UITheme.PrimaryLightColor;
                    ForeColor = UITheme.PrimaryColor;
                    break;
            }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? Color.White);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);
            Color bgColor = _isPressed ? _pressColor : (_isHovered ? _hoverColor : _normalColor);

            using (GraphicsPath path = UITheme.RoundedRect(rect, _borderRadius))
            {
                using (SolidBrush brush = new SolidBrush(bgColor))
                {
                    e.Graphics.FillPath(brush, path);
                }

                if (_buttonStyle == ButtonStyle.Outline)
                {
                    using (Pen pen = new Pen(_isHovered ? UITheme.PrimaryColor : UITheme.BorderColor, 2))
                    {
                        e.Graphics.DrawPath(pen, path);
                    }
                }
            }

            Color textColor = _buttonStyle == ButtonStyle.Outline ? UITheme.PrimaryColor :
                              _buttonStyle == ButtonStyle.Ghost ? (_isHovered ? UITheme.TextPrimaryColor : UITheme.TextSecondaryColor) :
                              Color.White;

            TextRenderer.DrawText(e.Graphics, Text, Font, rect, textColor,
                TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            _isPressed = false;
            Invalidate();
            base.OnMouseLeave(e);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            _isPressed = true;
            Invalidate();
            base.OnMouseDown(e);
        }

        protected override void OnMouseUp(MouseEventArgs e)
        {
            _isPressed = false;
            Invalidate();
            base.OnMouseUp(e);
        }
    }

    #endregion

    #region ModernCard - Panel carte avec ombre et coins arrondis

    public class ModernCard : Panel
    {
        private int _borderRadius = 12;
        private bool _showShadow = true;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int BorderRadius
        {
            get => _borderRadius;
            set { _borderRadius = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowShadow
        {
            get => _showShadow;
            set { _showShadow = value; Invalidate(); }
        }

        public ModernCard()
        {
            BackColor = Color.Transparent;
            Padding = new Padding(20);

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? UITheme.BackgroundColor);

            int shadowDepth = _showShadow ? 3 : 0;
            Rectangle shadowRect = new Rectangle(shadowDepth, shadowDepth, Width - shadowDepth - 1, Height - shadowDepth - 1);
            Rectangle cardRect = new Rectangle(0, 0, Width - shadowDepth - 1, Height - shadowDepth - 1);

            if (_showShadow)
            {
                using (GraphicsPath shadowPath = UITheme.RoundedRect(shadowRect, _borderRadius))
                using (SolidBrush shadowBrush = new SolidBrush(Color.FromArgb(20, 0, 0, 0)))
                {
                    e.Graphics.FillPath(shadowBrush, shadowPath);
                }
            }

            using (GraphicsPath cardPath = UITheme.RoundedRect(cardRect, _borderRadius))
            {
                using (SolidBrush brush = new SolidBrush(Color.White))
                {
                    e.Graphics.FillPath(brush, cardPath);
                }

                using (Pen pen = new Pen(UITheme.BorderLightColor, 1))
                {
                    e.Graphics.DrawPath(pen, cardPath);
                }
            }
        }
    }

    #endregion

    #region ModernStatCard - Carte statistique avec gradient

    public class ModernStatCard : UserControl
    {
        private string _title = "Titre";
        private string _value = "0";
        private string _subtitle = "";
        private Color _accentColor = UITheme.PrimaryColor;
        private Color _accentColorLight = UITheme.PrimaryLightColor;
        private int _borderRadius = 16;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get => _title;
            set { _title = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Value
        {
            get => _value;
            set { _value = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Subtitle
        {
            get => _subtitle;
            set { _subtitle = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color AccentColor
        {
            get => _accentColor;
            set { _accentColor = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color AccentColorLight
        {
            get => _accentColorLight;
            set { _accentColorLight = value; Invalidate(); }
        }

        public ModernStatCard()
        {
            Size = new Size(260, 140);
            BackColor = Color.Transparent;

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? UITheme.BackgroundColor);

            Rectangle rect = new Rectangle(0, 0, Width - 1, Height - 1);

            using (GraphicsPath path = UITheme.RoundedRect(rect, _borderRadius))
            {
                using (LinearGradientBrush gradientBrush = new LinearGradientBrush(
                    rect, _accentColor, _accentColorLight, 135f))
                {
                    e.Graphics.FillPath(gradientBrush, path);
                }

                int circleSize = 100;
                using (SolidBrush circleBrush = new SolidBrush(Color.FromArgb(30, 255, 255, 255)))
                {
                    e.Graphics.FillEllipse(circleBrush, Width - circleSize + 20, -30, circleSize, circleSize);
                    e.Graphics.FillEllipse(circleBrush, Width - 60, Height - 40, 80, 80);
                }
            }

            using (Font valueFont = new Font("Segoe UI", 32, FontStyle.Bold))
            {
                TextRenderer.DrawText(e.Graphics, _value, valueFont,
                    new Rectangle(24, 20, Width - 48, 50), Color.White,
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

            using (Font titleFont = UITheme.SubHeaderFont)
            {
                TextRenderer.DrawText(e.Graphics, _title, titleFont,
                    new Rectangle(24, 75, Width - 48, 25), Color.FromArgb(230, 255, 255, 255),
                    TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
            }

            if (!string.IsNullOrEmpty(_subtitle))
            {
                using (Font subtitleFont = UITheme.SmallFont)
                {
                    TextRenderer.DrawText(e.Graphics, _subtitle, subtitleFont,
                        new Rectangle(24, 100, Width - 48, 20), Color.FromArgb(180, 255, 255, 255),
                        TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
                }
            }
        }
    }

    #endregion

    #region ModernSidebarButton - Bouton de menu latéral

    public class ModernSidebarButton : Button
    {
        private bool _isActive = false;
        private bool _isHovered = false;
        private Color _activeIndicatorColor = UITheme.PrimaryColor;
        private int _indicatorWidth = 4;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsActive
        {
            get => _isActive;
            set { _isActive = value; Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ActiveIndicatorColor
        {
            get => _activeIndicatorColor;
            set { _activeIndicatorColor = value; Invalidate(); }
        }

        public ModernSidebarButton()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderSize = 0;
            BackColor = Color.Transparent;
            ForeColor = UITheme.SidebarTextColor;
            Font = UITheme.MenuFont;
            TextAlign = ContentAlignment.MiddleLeft;
            Padding = new Padding(24, 0, 16, 0);
            Height = 48;
            Cursor = Cursors.Hand;

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            Color bgColor;

            if (_isActive)
            {
                bgColor = UITheme.SidebarActiveColor;
            }
            else if (_isHovered)
            {
                bgColor = UITheme.SidebarHoverColor;
            }
            else
            {
                bgColor = UITheme.SidebarBackgroundColor;
            }

            e.Graphics.Clear(bgColor);

            if (_isActive)
            {
                using (SolidBrush indicatorBrush = new SolidBrush(_activeIndicatorColor))
                {
                    e.Graphics.FillRectangle(indicatorBrush, 0, 0, _indicatorWidth, Height);
                }
            }

            Color textColor = _isActive ? UITheme.SidebarTextActiveColor :
                              _isHovered ? Color.FromArgb(200, 210, 220) : UITheme.SidebarTextColor;

            Rectangle textRect = new Rectangle(Padding.Left, 0, Width - Padding.Horizontal, Height);
            TextRenderer.DrawText(e.Graphics, Text, Font, textRect, textColor,
                TextFormatFlags.Left | TextFormatFlags.VerticalCenter);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            _isHovered = true;
            Invalidate();
            base.OnMouseEnter(e);
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            _isHovered = false;
            Invalidate();
            base.OnMouseLeave(e);
        }
    }

    #endregion

    #region ModernProgressBar - Barre de progression moderne

    public class ModernProgressBar : UserControl
    {
        private int _value = 0;
        private int _maximum = 100;
        private Color _progressColor = UITheme.PrimaryColor;
        private Color _trackColor = UITheme.BorderLightColor;
        private int _borderRadius = 8;

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Value
        {
            get => _value;
            set
            {
                _value = Math.Min(Math.Max(value, 0), _maximum);
                Invalidate();
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int Maximum
        {
            get => _maximum;
            set { _maximum = Math.Max(value, 1); Invalidate(); }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public Color ProgressColor
        {
            get => _progressColor;
            set { _progressColor = value; Invalidate(); }
        }

        public ModernProgressBar()
        {
            Size = new Size(200, 8);
            BackColor = Color.Transparent;

            SetStyle(ControlStyles.AllPaintingInWmPaint |
                     ControlStyles.UserPaint |
                     ControlStyles.ResizeRedraw |
                     ControlStyles.OptimizedDoubleBuffer, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(Parent?.BackColor ?? UITheme.BackgroundColor);

            Rectangle trackRect = new Rectangle(0, 0, Width - 1, Height - 1);
            int progressWidth = (int)((Width - 1) * ((float)_value / _maximum));
            Rectangle progressRect = new Rectangle(0, 0, progressWidth, Height - 1);

            using (GraphicsPath trackPath = UITheme.RoundedRect(trackRect, _borderRadius))
            using (SolidBrush trackBrush = new SolidBrush(_trackColor))
            {
                e.Graphics.FillPath(trackBrush, trackPath);
            }

            if (progressWidth > 0)
            {
                using (GraphicsPath progressPath = UITheme.RoundedRect(progressRect, _borderRadius))
                using (SolidBrush progressBrush = new SolidBrush(_progressColor))
                {
                    e.Graphics.FillPath(progressBrush, progressPath);
                }
            }
        }
    }

    #endregion
}
