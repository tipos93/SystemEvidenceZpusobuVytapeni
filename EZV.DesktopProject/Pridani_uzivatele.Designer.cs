namespace EZV.DesktopProject
{
    partial class Pridani_uzivatele
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
            this.PostaveniList = new System.Windows.Forms.ComboBox();
            this.HesloText1 = new System.Windows.Forms.TextBox();
            this.LoginText = new System.Windows.Forms.TextBox();
            this.VlastniciList = new System.Windows.Forms.ComboBox();
            this.VlozeniButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.AktualnostList = new System.Windows.Forms.ComboBox();
            this.UspesnostPridani = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PostaveniList
            // 
            this.PostaveniList.FormattingEnabled = true;
            this.PostaveniList.Location = new System.Drawing.Point(156, 109);
            this.PostaveniList.Name = "PostaveniList";
            this.PostaveniList.Size = new System.Drawing.Size(253, 24);
            this.PostaveniList.TabIndex = 9;
            // 
            // HesloText1
            // 
            this.HesloText1.Location = new System.Drawing.Point(156, 199);
            this.HesloText1.Name = "HesloText1";
            this.HesloText1.Size = new System.Drawing.Size(100, 22);
            this.HesloText1.TabIndex = 8;
            // 
            // LoginText
            // 
            this.LoginText.Location = new System.Drawing.Point(156, 152);
            this.LoginText.Name = "LoginText";
            this.LoginText.Size = new System.Drawing.Size(100, 22);
            this.LoginText.TabIndex = 7;
            // 
            // VlastniciList
            // 
            this.VlastniciList.FormattingEnabled = true;
            this.VlastniciList.Location = new System.Drawing.Point(156, 66);
            this.VlastniciList.Name = "VlastniciList";
            this.VlastniciList.Size = new System.Drawing.Size(253, 24);
            this.VlastniciList.TabIndex = 6;
            // 
            // VlozeniButton
            // 
            this.VlozeniButton.Location = new System.Drawing.Point(334, 276);
            this.VlozeniButton.Name = "VlozeniButton";
            this.VlozeniButton.Size = new System.Drawing.Size(75, 23);
            this.VlozeniButton.TabIndex = 5;
            this.VlozeniButton.Text = "Vložit";
            this.VlozeniButton.UseVisualStyleBackColor = true;
            this.VlozeniButton.Click += new System.EventHandler(this.VlozeniButton_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(67, 112);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(74, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Postavení:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(67, 202);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "Heslo:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(67, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Login:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(67, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(62, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Uživatel:";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Location = new System.Drawing.Point(67, 250);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(78, 17);
            this.Label5.TabIndex = 10;
            this.Label5.Text = "Aktuálnost:";
            // 
            // AktualnostList
            // 
            this.AktualnostList.FormattingEnabled = true;
            this.AktualnostList.Location = new System.Drawing.Point(156, 250);
            this.AktualnostList.Name = "AktualnostList";
            this.AktualnostList.Size = new System.Drawing.Size(100, 24);
            this.AktualnostList.TabIndex = 11;
            // 
            // UspesnostPridani
            // 
            this.UspesnostPridani.AutoSize = true;
            this.UspesnostPridani.Location = new System.Drawing.Point(67, 325);
            this.UspesnostPridani.Name = "UspesnostPridani";
            this.UspesnostPridani.Size = new System.Drawing.Size(46, 17);
            this.UspesnostPridani.TabIndex = 12;
            this.UspesnostPridani.Text = "label6";
            // 
            // Pridani_uzivatele
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 366);
            this.Controls.Add(this.UspesnostPridani);
            this.Controls.Add(this.AktualnostList);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.PostaveniList);
            this.Controls.Add(this.HesloText1);
            this.Controls.Add(this.LoginText);
            this.Controls.Add(this.VlastniciList);
            this.Controls.Add(this.VlozeniButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Pridani_uzivatele";
            this.Text = "Pridani_uzivatele";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button VlozeniButton;
        private System.Windows.Forms.ComboBox VlastniciList;
        private System.Windows.Forms.TextBox LoginText;
        private System.Windows.Forms.TextBox HesloText1;
        private System.Windows.Forms.ComboBox PostaveniList;
        private System.Windows.Forms.Label Label5;
        private System.Windows.Forms.ComboBox AktualnostList;
        private System.Windows.Forms.Label UspesnostPridani;
    }
}