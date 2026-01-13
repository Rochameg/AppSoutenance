namespace AppSoutenance.Views.Parametre
{
    partial class frmAnneeAcademique
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
            dgAnneAcademique = new DataGridView();
            txtAnneeAcademiqueText = new TextBox();
            label1 = new Label();
            label2 = new Label();
            txtAnneeAcademiqueVal = new TextBox();
            btnRemove = new Button();
            btnEdit = new Button();
            btnAdd = new Button();
            btnSelect = new Button();
            ((System.ComponentModel.ISupportInitialize)dgAnneAcademique).BeginInit();
            SuspendLayout();
            // 
            // dgAnneAcademique
            // 
            dgAnneAcademique.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgAnneAcademique.Location = new Point(574, 12);
            dgAnneAcademique.Name = "dgAnneAcademique";
            dgAnneAcademique.RowHeadersWidth = 62;
            dgAnneAcademique.Size = new Size(635, 586);
            dgAnneAcademique.TabIndex = 1;
            // 
            // txtAnneeAcademiqueText
            // 
            txtAnneeAcademiqueText.Location = new Point(12, 92);
            txtAnneeAcademiqueText.Name = "txtAnneeAcademiqueText";
            txtAnneeAcademiqueText.Size = new Size(270, 31);
            txtAnneeAcademiqueText.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 55);
            label1.Name = "label1";
            label1.Size = new Size(42, 25);
            label1.TabIndex = 4;
            label1.Text = "Text";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 181);
            label2.Name = "label2";
            label2.Size = new Size(60, 25);
            label2.TabIndex = 5;
            label2.Text = "Valeur";
            // 
            // txtAnneeAcademiqueVal
            // 
            txtAnneeAcademiqueVal.Location = new Point(12, 223);
            txtAnneeAcademiqueVal.Name = "txtAnneeAcademiqueVal";
            txtAnneeAcademiqueVal.Size = new Size(270, 31);
            txtAnneeAcademiqueVal.TabIndex = 2;
            txtAnneeAcademiqueVal.TextChanged += textBox1_TextChanged;
            // 
            // btnRemove
            // 
            btnRemove.Location = new Point(391, 529);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(112, 34);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "Supprimer";
            btnRemove.UseVisualStyleBackColor = true;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnEdit
            // 
            btnEdit.Location = new Point(391, 439);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(112, 34);
            btnEdit.TabIndex = 5;
            btnEdit.Text = "Modifier";
            btnEdit.UseVisualStyleBackColor = true;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnAdd
            // 
            btnAdd.Location = new Point(391, 350);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(112, 34);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Ajouter";
            btnAdd.UseVisualStyleBackColor = true;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnSelect
            // 
            btnSelect.Location = new Point(247, 12);
            btnSelect.Name = "btnSelect";
            btnSelect.Size = new Size(296, 34);
            btnSelect.TabIndex = 3;
            btnSelect.Text = "Selectionner";
            btnSelect.UseVisualStyleBackColor = true;
            btnSelect.Click += btnSelect_Click;
            // 
            // frmAnneeAcademique
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1221, 600);
            Controls.Add(btnSelect);
            Controls.Add(btnRemove);
            Controls.Add(btnEdit);
            Controls.Add(btnAdd);
            Controls.Add(txtAnneeAcademiqueVal);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtAnneeAcademiqueText);
            Controls.Add(dgAnneAcademique);
            Name = "frmAnneeAcademique";
            Text = "frmAnneeAcademique";
            Load += frmAnneeAcademique_Load;
            ((System.ComponentModel.ISupportInitialize)dgAnneAcademique).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgAnneAcademique;
        private TextBox txtAnneeAcademiqueText;
        private Label label1;
        private Label label2;
        private TextBox txtAnneeAcademiqueVal;
        private Button btnRemove;
        private Button btnEdit;
        private Button btnAdd;
        private Button btnSelect;
    }
}