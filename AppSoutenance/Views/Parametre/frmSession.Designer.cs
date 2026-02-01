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
            btnSelectionner = new Button();
            btnModifier = new Button();
            btnSupprimer = new Button();
            btnAjouter = new Button();
            txtRSession = new TextBox();
            label3 = new Label();
            txtRAnneeAcademique = new TextBox();
            label = new Label();
            btnSearch = new Button();
            ((System.ComponentModel.ISupportInitialize)dgSession).BeginInit();
            SuspendLayout();
            // 
            // dgSession
            // 
            dgSession.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgSession.Location = new Point(420, 95);
            dgSession.Name = "dgSession";
            dgSession.RowHeadersWidth = 62;
            dgSession.Size = new Size(777, 587);
            dgSession.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 67);
            label1.Name = "label1";
            label1.Size = new Size(72, 25);
            label1.TabIndex = 1;
            label1.Text = "Session";
            label1.Click += label1_Click;
            // 
            // txtSession
            // 
            txtSession.Location = new Point(25, 95);
            txtSession.Name = "txtSession";
            txtSession.Size = new Size(270, 31);
            txtSession.TabIndex = 2;
            txtSession.TextChanged += txtSession_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 174);
            label2.Name = "label2";
            label2.Size = new Size(166, 25);
            label2.TabIndex = 3;
            label2.Text = "Année Academique";
            // 
            // cbbAnneeAcademique
            // 
            cbbAnneeAcademique.FormattingEnabled = true;
            cbbAnneeAcademique.Location = new Point(25, 219);
            cbbAnneeAcademique.Name = "cbbAnneeAcademique";
            cbbAnneeAcademique.Size = new Size(282, 33);
            cbbAnneeAcademique.TabIndex = 4;
            // 
            // btnSelectionner
            // 
            btnSelectionner.Location = new Point(254, 27);
            btnSelectionner.Name = "btnSelectionner";
            btnSelectionner.Size = new Size(222, 34);
            btnSelectionner.TabIndex = 7;
            btnSelectionner.Text = "Selectionner";
            btnSelectionner.UseVisualStyleBackColor = true;
            btnSelectionner.Click += btnSelectionner_Click;
            // 
            // btnModifier
            // 
            btnModifier.Location = new Point(293, 460);
            btnModifier.Name = "btnModifier";
            btnModifier.Size = new Size(112, 34);
            btnModifier.TabIndex = 8;
            btnModifier.Text = "Modifier";
            btnModifier.UseVisualStyleBackColor = true;
            btnModifier.Click += btnModifier_Click;
            // 
            // btnSupprimer
            // 
            btnSupprimer.Location = new Point(293, 550);
            btnSupprimer.Name = "btnSupprimer";
            btnSupprimer.Size = new Size(112, 34);
            btnSupprimer.TabIndex = 9;
            btnSupprimer.Text = "Supprimer";
            btnSupprimer.UseVisualStyleBackColor = true;
            btnSupprimer.Click += btnSupprimer_Click;
            // 
            // btnAjouter
            // 
            btnAjouter.Location = new Point(293, 362);
            btnAjouter.Name = "btnAjouter";
            btnAjouter.Size = new Size(112, 34);
            btnAjouter.TabIndex = 10;
            btnAjouter.Text = "Ajouter";
            btnAjouter.UseVisualStyleBackColor = true;
            btnAjouter.Click += btnAjouter_Click_1;
            // 
            // txtRSession
            // 
            txtRSession.Location = new Point(510, 60);
            txtRSession.Name = "txtRSession";
            txtRSession.Size = new Size(292, 31);
            txtRSession.TabIndex = 12;
            txtRSession.TextChanged += textBox1_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(510, 32);
            label3.Name = "label3";
            label3.Size = new Size(72, 25);
            label3.TabIndex = 11;
            label3.Text = "Session";
            // 
            // txtRAnneeAcademique
            // 
            txtRAnneeAcademique.Location = new Point(808, 61);
            txtRAnneeAcademique.Name = "txtRAnneeAcademique";
            txtRAnneeAcademique.Size = new Size(365, 31);
            txtRAnneeAcademique.TabIndex = 14;
            // 
            // label
            // 
            label.AutoSize = true;
            label.Location = new Point(808, 33);
            label.Name = "label";
            label.Size = new Size(163, 25);
            label.TabIndex = 13;
            label.Text = "Année academique";
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(1008, 12);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(189, 34);
            btnSearch.TabIndex = 15;
            btnSearch.Text = "Rechercher";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // frmSession
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1209, 694);
            Controls.Add(btnSearch);
            Controls.Add(txtRAnneeAcademique);
            Controls.Add(label);
            Controls.Add(txtRSession);
            Controls.Add(label3);
            Controls.Add(btnAjouter);
            Controls.Add(btnSupprimer);
            Controls.Add(btnModifier);
            Controls.Add(btnSelectionner);
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
        private Button btnSelectionner;
        private Button btnModifier;
        private Button btnSupprimer;
        private Button btnAjouter;
        private TextBox txtRSession;
        private Label label3;
        private TextBox txtRAnneeAcademique;
        private Label label;
        private Button btnSearch;
    }
}