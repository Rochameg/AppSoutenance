namespace AppSoutenance
{
    partial class fmrConnection
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            btnQuitter = new Button();
            btnSeConnecter = new Button();
            label1 = new Label();
            txtIdentifiant = new TextBox();
            txtMotdePasse = new TextBox();
            label2 = new Label();
            SuspendLayout();
            // 
            // btnQuitter
            // 
            btnQuitter.Location = new Point(106, 436);
            btnQuitter.Name = "btnQuitter";
            btnQuitter.Size = new Size(112, 34);
            btnQuitter.TabIndex = 4;
            btnQuitter.Text = "Quitter";
            btnQuitter.UseVisualStyleBackColor = true;
            btnQuitter.Click += btnQuitter_Click;
            // 
            // btnSeConnecter
            // 
            btnSeConnecter.Location = new Point(306, 436);
            btnSeConnecter.Name = "btnSeConnecter";
            btnSeConnecter.Size = new Size(176, 34);
            btnSeConnecter.TabIndex = 3;
            btnSeConnecter.Text = "Se connecter";
            btnSeConnecter.UseVisualStyleBackColor = true;
            btnSeConnecter.Click += button2_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(29, 52);
            label1.Name = "label1";
            label1.Size = new Size(92, 25);
            label1.TabIndex = 2;
            label1.Text = "Identifiant";
            // 
            // txtIdentifiant
            // 
            txtIdentifiant.Location = new Point(33, 99);
            txtIdentifiant.Name = "txtIdentifiant";
            txtIdentifiant.Size = new Size(505, 31);
            txtIdentifiant.TabIndex = 1;
            // 
            // txtMotdePasse
            // 
            txtMotdePasse.Location = new Point(33, 214);
            txtMotdePasse.Name = "txtMotdePasse";
            txtMotdePasse.Size = new Size(505, 31);
            txtMotdePasse.TabIndex = 2;
            txtMotdePasse.UseSystemPasswordChar = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 167);
            label2.Name = "label2";
            label2.Size = new Size(120, 25);
            label2.TabIndex = 4;
            label2.Text = "Mot de passe";
            // 
            // fmrConnection
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(599, 665);
            ControlBox = false;
            Controls.Add(txtMotdePasse);
            Controls.Add(label2);
            Controls.Add(txtIdentifiant);
            Controls.Add(label1);
            Controls.Add(btnSeConnecter);
            Controls.Add(btnQuitter);
            Name = "fmrConnection";
            Text = "Sen Soutenance :: Connection";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnQuitter;
        private Button btnSeConnecter;
        private Label label1;
        private TextBox txtIdentifiant;
        private TextBox txtMotdePasse;
        private Label label2;
    }
}
