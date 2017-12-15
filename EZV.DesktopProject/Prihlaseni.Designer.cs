namespace EZV.DesktopProject
{
    partial class Prihlaseni
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
            this.PrihlaseniButton = new System.Windows.Forms.Button();
            this.JmenoText = new System.Windows.Forms.TextBox();
            this.jmeno = new System.Windows.Forms.Label();
            this.heslo = new System.Windows.Forms.Label();
            this.Neuspech = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.HesloText = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // PrihlaseniButton
            // 
            this.PrihlaseniButton.Location = new System.Drawing.Point(198, 198);
            this.PrihlaseniButton.Name = "PrihlaseniButton";
            this.PrihlaseniButton.Size = new System.Drawing.Size(75, 23);
            this.PrihlaseniButton.TabIndex = 0;
            this.PrihlaseniButton.Text = "Přihlásit se";
            this.PrihlaseniButton.UseVisualStyleBackColor = true;
            this.PrihlaseniButton.Click += new System.EventHandler(this.Prihlaseni_Click);
            // 
            // JmenoText
            // 
            this.JmenoText.Location = new System.Drawing.Point(173, 82);
            this.JmenoText.Name = "JmenoText";
            this.JmenoText.Size = new System.Drawing.Size(100, 22);
            this.JmenoText.TabIndex = 1;
            // 
            // jmeno
            // 
            this.jmeno.AutoSize = true;
            this.jmeno.Location = new System.Drawing.Point(113, 87);
            this.jmeno.Name = "jmeno";
            this.jmeno.Size = new System.Drawing.Size(54, 17);
            this.jmeno.TabIndex = 3;
            this.jmeno.Text = "Jméno:";
            // 
            // heslo
            // 
            this.heslo.AutoSize = true;
            this.heslo.Location = new System.Drawing.Point(119, 139);
            this.heslo.Name = "heslo";
            this.heslo.Size = new System.Drawing.Size(48, 17);
            this.heslo.TabIndex = 4;
            this.heslo.Text = "Heslo:";
            // 
            // Neuspech
            // 
            this.Neuspech.AutoSize = true;
            this.Neuspech.Location = new System.Drawing.Point(170, 178);
            this.Neuspech.Name = "Neuspech";
            this.Neuspech.Size = new System.Drawing.Size(46, 17);
            this.Neuspech.TabIndex = 5;
            this.Neuspech.Text = "label1";
            this.Neuspech.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(185, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Přihlášení";
            // 
            // HesloText
            // 
            this.HesloText.Location = new System.Drawing.Point(173, 136);
            this.HesloText.Name = "HesloText";
            this.HesloText.PasswordChar = '*';
            this.HesloText.Size = new System.Drawing.Size(100, 22);
            this.HesloText.TabIndex = 7;
            // 
            // Prihlaseni
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 465);
            this.Controls.Add(this.HesloText);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Neuspech);
            this.Controls.Add(this.heslo);
            this.Controls.Add(this.jmeno);
            this.Controls.Add(this.JmenoText);
            this.Controls.Add(this.PrihlaseniButton);
            this.Name = "Prihlaseni";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button PrihlaseniButton;
        private System.Windows.Forms.TextBox JmenoText;
        private System.Windows.Forms.Label jmeno;
        private System.Windows.Forms.Label heslo;
        private System.Windows.Forms.Label Neuspech;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.MaskedTextBox HesloText;
    }
}

