namespace AppSoutenance.Views.Parametre
{
    partial class frmSession
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
            dgSession = new DataGridView();
            label1 = new Label();
            txtSession = new TextBox();
            label2 = new Label();
            cbbAnneeAcademique = new ComboBox();
            btnAjouter = new Button();
            btnSelectionner = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            ((System.ComponentModel.ISupportInitialize)dgSession).BeginInit();
            SuspendLayout();
            // 
            // dgSession
            // 
            dgSession.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSession.Location = new Point(554, 12);
            dgSession.Name = "dgSession";
            dgSession.RowHeadersWidth = 62;
            dgSession.Size = new Size(635, 654);
            dgSession.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(47, 54);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 1;
            label1.Text = "Session";
            label1.Click += label1_Click;
            // 
            // txtSession
            // 
            txtSession.Location = new Point(47, 82);
            txtSession.Name = "txtSession";
            txtSession.Size = new Size(270, 31);
            txtSession.TabIndex = 2;
            txtSession.TextChanged += txtSession_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(47, 167);
            label2.Name = "label2";
            label2.Size = new Size(166, 25);
            label2.TabIndex = 3;
            label2.Text = "Année Academique";
            // 
            // cbbAnneeAcademique
            // 
            cbbAnneeAcademique.FormattingEnabled = true;
            cbbAnneeAcademique.Location = new Point(47, 212);
            cbbAnneeAcademique.Name = "cbbAnneeAcademique";
            cbbAnneeAcademique.Size = new Size(282, 33);
            cbbAnneeAcademique.TabIndex = 4;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(375, 345);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(112, 34);
            btnAjouter.TabIndex = 6;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            // 
            // btnSelectionner
            // 
            btnSelectionner.Location = new Point(305, 12);
            btnSelectionner.Name = "btnSelectionner";
            btnSelectionner.Size = new Size(222, 34);
            btnSelectionner.TabIndex = 7;
            btnSelectionner.Text = "Selectionner";
            btnSelectionner.UseVisualStyleBackColor = true;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(375, 434);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(112, 34);
            btnModifier.TabIndex = 8;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(375, 524);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(112, 34);
            btnSupprimer.TabIndex = 9;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            // 
            // frmSession
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1201, 678);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnSelectionner);
            Controls.Add(btnAjouter);
            Controls.Add(cbbAnneeAcademique);
            Controls.Add(label2);
            Controls.Add(txtSession);
            Controls.Add(label1);
            Controls.Add(dgSession);
            Name = "frmSession";
            Text = "frmSession";
            Load += frmSession_Load;
            ((System.ComponentModel.ISupportInitialize)dgSession).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgSession;
        private Label label1;
        private TextBox txtSession;
        private Label label2;
        private ComboBox cbbAnneeAcademique;
        private Button btnAjouter;
        private Button btnSelectionner;
        private Button btnModifier;
        private Button btnSupprimer;
    }
}