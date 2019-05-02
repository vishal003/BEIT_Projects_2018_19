namespace ColorSubstitutionCryptography
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.createCryptographyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readCryptographyImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createWithTranslatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readWithTranslatorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Lavender;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(734, 29);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createCryptographyImageToolStripMenuItem,
            this.readCryptographyImageToolStripMenuItem,
            this.createWithTranslatorToolStripMenuItem,
            this.readWithTranslatorToolStripMenuItem});
            this.toolStripMenuItem1.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(46, 25);
            this.toolStripMenuItem1.Text = "File";
            // 
            // createCryptographyImageToolStripMenuItem
            // 
            this.createCryptographyImageToolStripMenuItem.Name = "createCryptographyImageToolStripMenuItem";
            this.createCryptographyImageToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.createCryptographyImageToolStripMenuItem.Text = "Create Cryptography Image";
            this.createCryptographyImageToolStripMenuItem.Click += new System.EventHandler(this.createCryptographyImageToolStripMenuItem_Click);
            // 
            // readCryptographyImageToolStripMenuItem
            // 
            this.readCryptographyImageToolStripMenuItem.Name = "readCryptographyImageToolStripMenuItem";
            this.readCryptographyImageToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.readCryptographyImageToolStripMenuItem.Text = "Read Cryptography Image";
            this.readCryptographyImageToolStripMenuItem.Click += new System.EventHandler(this.readCryptographyImageToolStripMenuItem_Click);
            // 
            // createWithTranslatorToolStripMenuItem
            // 
            this.createWithTranslatorToolStripMenuItem.Name = "createWithTranslatorToolStripMenuItem";
            this.createWithTranslatorToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.createWithTranslatorToolStripMenuItem.Text = "Create With Translator";
            this.createWithTranslatorToolStripMenuItem.Click += new System.EventHandler(this.createWithTranslatorToolStripMenuItem_Click);
            // 
            // readWithTranslatorToolStripMenuItem
            // 
            this.readWithTranslatorToolStripMenuItem.Name = "readWithTranslatorToolStripMenuItem";
            this.readWithTranslatorToolStripMenuItem.Size = new System.Drawing.Size(306, 26);
            this.readWithTranslatorToolStripMenuItem.Text = "Read with Translator";
            this.readWithTranslatorToolStripMenuItem.Click += new System.EventHandler(this.readWithTranslatorToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.exitToolStripMenuItem});
            this.helpToolStripMenuItem.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(57, 25);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::ColorSubstitutionCryptography.Properties.Resources.cryptography;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(734, 508);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Century Gothic", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.Black;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Advanced Mail";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem createCryptographyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readCryptographyImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createWithTranslatorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readWithTranslatorToolStripMenuItem;
    }
}