namespace AppSoutenance
{
    partial class FmrMBI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            actionToolStripMenuItem = new ToolStripMenuItem();
            seConnecterToolStripMenuItem = new ToolStripMenuItem();
            quitterToolStripMenuItem = new ToolStripMenuItem();
            parametreToolStripMenuItem = new ToolStripMenuItem();
            annéeAcedemiqueToolStripMenuItem = new ToolStripMenuItem();
            sessionToolStripMenuItem = new ToolStripMenuItem();
            professeurToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(24, 24);
            menuStrip1.Items.AddRange(new ToolStripItem[] { actionToolStripMenuItem, parametreToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1217, 33);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // actionToolStripMenuItem
            // 
            actionToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { seConnecterToolStripMenuItem, quitterToolStripMenuItem });
            actionToolStripMenuItem.Name = "actionToolStripMenuItem";
            actionToolStripMenuItem.Size = new Size(79, 29);
            actionToolStripMenuItem.Text = "&Action";
            // 
            // seConnecterToolStripMenuItem
            // 
            seConnecterToolStripMenuItem.Name = "seConnecterToolStripMenuItem";
            seConnecterToolStripMenuItem.Size = new Size(218, 34);
            seConnecterToolStripMenuItem.Text = "&Se Connecter";
            seConnecterToolStripMenuItem.Click += seConnecterToolStripMenuItem_Click;
            // 
            // quitterToolStripMenuItem
            // 
            quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            quitterToolStripMenuItem.Size = new Size(218, 34);
            quitterToolStripMenuItem.Text = "&Quitter";
            quitterToolStripMenuItem.Click += quitterToolStripMenuItem_Click;
            // 
            // parametreToolStripMenuItem
            // 
            parametreToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { annéeAcedemiqueToolStripMenuItem, sessionToolStripMenuItem, professeurToolStripMenuItem });
            parametreToolStripMenuItem.Name = "parametreToolStripMenuItem";
            parametreToolStripMenuItem.Size = new Size(107, 29);
            parametreToolStripMenuItem.Text = "&Parametre";
            // 
            // annéeAcedemiqueToolStripMenuItem
            // 
            annéeAcedemiqueToolStripMenuItem.Name = "annéeAcedemiqueToolStripMenuItem";
            annéeAcedemiqueToolStripMenuItem.Size = new Size(268, 34);
            annéeAcedemiqueToolStripMenuItem.Text = "&Année Acedemique";
            annéeAcedemiqueToolStripMenuItem.Click += annéeAcedemiqueToolStripMenuItem_Click;
            // 
            // sessionToolStripMenuItem
            // 
            sessionToolStripMenuItem.Name = "sessionToolStripMenuItem";
            sessionToolStripMenuItem.Size = new Size(268, 34);
            sessionToolStripMenuItem.Text = "&Session";
            sessionToolStripMenuItem.Click += sessionToolStripMenuItem_Click;
            // 
            // professeurToolStripMenuItem
            // 
            professeurToolStripMenuItem.Name = "professeurToolStripMenuItem";
            professeurToolStripMenuItem.Size = new Size(268, 34);
            professeurToolStripMenuItem.Text = "&Professeur";
            professeurToolStripMenuItem.Click += professeurToolStripMenuItem_Click;
            // 
            // FmrMBI
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 668);
            ControlBox = false;
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Name = "FmrMBI";
            Text = "Sen Soutenance ::";
            Load += FmrMBI_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem actionToolStripMenuItem;
        private ToolStripMenuItem seConnecterToolStripMenuItem;
        private ToolStripMenuItem quitterToolStripMenuItem;
        private ToolStripMenuItem parametreToolStripMenuItem;
        private ToolStripMenuItem annéeAcedemiqueToolStripMenuItem;
        private ToolStripMenuItem sessionToolStripMenuItem;
        private ToolStripMenuItem professeurToolStripMenuItem;
    }
}