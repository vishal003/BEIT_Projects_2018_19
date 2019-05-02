namespace PhishDetect.Forms
{
    partial class Training
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
            this.components = new System.ComponentModel.Container();
            BunifuAnimatorNS.Animation animation3 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation2 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation4 = new BunifuAnimatorNS.Animation();
            BunifuAnimatorNS.Animation animation1 = new BunifuAnimatorNS.Animation();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Training));
            this.SideMenu = new System.Windows.Forms.Panel();
            this.bunifuFlatButton5 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton3 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton2 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.bunifuFlatButton1 = new Bunifu.Framework.UI.BunifuFlatButton();
            this.MenuButton = new Bunifu.Framework.UI.BunifuImageButton();
            this.LogoBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.bunifuImageButton1 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton8 = new Bunifu.Framework.UI.BunifuImageButton();
            this.bunifuImageButton7 = new Bunifu.Framework.UI.BunifuImageButton();
            this.Logo_Animator = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.TabArea = new System.Windows.Forms.FlowLayoutPanel();
            this.upload1 = new PhishDetect.UserControls.Upload();
            this.ruleset1 = new PhishDetect.UserControls.Ruleset();
            this.ruleset2 = new PhishDetect.UserControls.Ruleset();
            this.extracted1 = new PhishDetect.UserControls.Extracted();
            this.train1 = new PhishDetect.UserControls.Train();
            this.tree1 = new PhishDetect.UserControls.Tree();
            this.Panel_Animation = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.Panel_shrink = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.Logo_Hide = new BunifuAnimatorNS.BunifuTransition(this.components);
            this.bunifuDragControl1 = new Bunifu.Framework.UI.BunifuDragControl(this.components);
            this.SideMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MenuButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton7)).BeginInit();
            this.TabArea.SuspendLayout();
            this.SuspendLayout();
            // 
            // SideMenu
            // 
            this.SideMenu.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.SideMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(25)))), ((int)(((byte)(31)))));
            this.SideMenu.Controls.Add(this.bunifuFlatButton5);
            this.SideMenu.Controls.Add(this.bunifuFlatButton3);
            this.SideMenu.Controls.Add(this.bunifuFlatButton2);
            this.SideMenu.Controls.Add(this.bunifuFlatButton1);
            this.SideMenu.Controls.Add(this.MenuButton);
            this.SideMenu.Controls.Add(this.LogoBox);
            this.Logo_Hide.SetDecoration(this.SideMenu, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.SideMenu, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.SideMenu, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.SideMenu, BunifuAnimatorNS.DecorationType.None);
            this.SideMenu.Location = new System.Drawing.Point(0, 32);
            this.SideMenu.Name = "SideMenu";
            this.SideMenu.Size = new System.Drawing.Size(285, 705);
            this.SideMenu.TabIndex = 16;
            // 
            // bunifuFlatButton5
            // 
            this.bunifuFlatButton5.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(21)))));
            this.bunifuFlatButton5.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton5.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton5.BorderRadius = 0;
            this.bunifuFlatButton5.ButtonText = "     View Extracted                Features File";
            this.bunifuFlatButton5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo_Hide.SetDecoration(this.bunifuFlatButton5, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.bunifuFlatButton5, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.bunifuFlatButton5, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.bunifuFlatButton5, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFlatButton5.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton5.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton5.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton5.Iconimage")));
            this.bunifuFlatButton5.Iconimage_right = null;
            this.bunifuFlatButton5.Iconimage_right_Selected = null;
            this.bunifuFlatButton5.Iconimage_Selected = null;
            this.bunifuFlatButton5.IconMarginLeft = 0;
            this.bunifuFlatButton5.IconMarginRight = 0;
            this.bunifuFlatButton5.IconRightVisible = true;
            this.bunifuFlatButton5.IconRightZoom = 0D;
            this.bunifuFlatButton5.IconVisible = true;
            this.bunifuFlatButton5.IconZoom = 90D;
            this.bunifuFlatButton5.IsTab = true;
            this.bunifuFlatButton5.Location = new System.Drawing.Point(0, 380);
            this.bunifuFlatButton5.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton5.Name = "bunifuFlatButton5";
            this.bunifuFlatButton5.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton5.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.bunifuFlatButton5.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.bunifuFlatButton5.selected = false;
            this.bunifuFlatButton5.Size = new System.Drawing.Size(285, 70);
            this.bunifuFlatButton5.TabIndex = 3;
            this.bunifuFlatButton5.Text = "     View Extracted                Features File";
            this.bunifuFlatButton5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton5.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(113)))), ((int)(((byte)(206)))));
            this.bunifuFlatButton5.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton5.Click += new System.EventHandler(this.bunifuFlatButton5_Click);
            // 
            // bunifuFlatButton3
            // 
            this.bunifuFlatButton3.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(21)))));
            this.bunifuFlatButton3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton3.BorderRadius = 0;
            this.bunifuFlatButton3.ButtonText = "     Upload Text File and      Generate Ruleset";
            this.bunifuFlatButton3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo_Hide.SetDecoration(this.bunifuFlatButton3, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.bunifuFlatButton3, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.bunifuFlatButton3, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.bunifuFlatButton3, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFlatButton3.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton3.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton3.Iconimage")));
            this.bunifuFlatButton3.Iconimage_right = null;
            this.bunifuFlatButton3.Iconimage_right_Selected = null;
            this.bunifuFlatButton3.Iconimage_Selected = null;
            this.bunifuFlatButton3.IconMarginLeft = 0;
            this.bunifuFlatButton3.IconMarginRight = 0;
            this.bunifuFlatButton3.IconRightVisible = true;
            this.bunifuFlatButton3.IconRightZoom = 0D;
            this.bunifuFlatButton3.IconVisible = true;
            this.bunifuFlatButton3.IconZoom = 90D;
            this.bunifuFlatButton3.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.bunifuFlatButton3.IsTab = true;
            this.bunifuFlatButton3.Location = new System.Drawing.Point(0, 460);
            this.bunifuFlatButton3.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton3.Name = "bunifuFlatButton3";
            this.bunifuFlatButton3.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton3.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.bunifuFlatButton3.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.bunifuFlatButton3.selected = false;
            this.bunifuFlatButton3.Size = new System.Drawing.Size(285, 70);
            this.bunifuFlatButton3.TabIndex = 4;
            this.bunifuFlatButton3.Text = "     Upload Text File and      Generate Ruleset";
            this.bunifuFlatButton3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton3.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(88)))), ((int)(((byte)(104)))));
            this.bunifuFlatButton3.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton3.Click += new System.EventHandler(this.bunifuFlatButton3_Click);
            // 
            // bunifuFlatButton2
            // 
            this.bunifuFlatButton2.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(21)))));
            this.bunifuFlatButton2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton2.BorderRadius = 0;
            this.bunifuFlatButton2.ButtonText = "     Extract Features";
            this.bunifuFlatButton2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo_Hide.SetDecoration(this.bunifuFlatButton2, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.bunifuFlatButton2, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.bunifuFlatButton2, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.bunifuFlatButton2, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFlatButton2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton2.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton2.Iconimage")));
            this.bunifuFlatButton2.Iconimage_right = null;
            this.bunifuFlatButton2.Iconimage_right_Selected = null;
            this.bunifuFlatButton2.Iconimage_Selected = null;
            this.bunifuFlatButton2.IconMarginLeft = 0;
            this.bunifuFlatButton2.IconMarginRight = 0;
            this.bunifuFlatButton2.IconRightVisible = true;
            this.bunifuFlatButton2.IconRightZoom = 0D;
            this.bunifuFlatButton2.IconVisible = true;
            this.bunifuFlatButton2.IconZoom = 90D;
            this.bunifuFlatButton2.IsTab = true;
            this.bunifuFlatButton2.Location = new System.Drawing.Point(0, 300);
            this.bunifuFlatButton2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton2.Name = "bunifuFlatButton2";
            this.bunifuFlatButton2.Normalcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton2.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.bunifuFlatButton2.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.bunifuFlatButton2.selected = false;
            this.bunifuFlatButton2.Size = new System.Drawing.Size(285, 70);
            this.bunifuFlatButton2.TabIndex = 2;
            this.bunifuFlatButton2.Text = "     Extract Features";
            this.bunifuFlatButton2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton2.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(101)))), ((int)(((byte)(235)))));
            this.bunifuFlatButton2.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton2.Click += new System.EventHandler(this.bunifuFlatButton2_Click);
            // 
            // bunifuFlatButton1
            // 
            this.bunifuFlatButton1.Activecolor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(21)))));
            this.bunifuFlatButton1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(15)))), ((int)(((byte)(21)))));
            this.bunifuFlatButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuFlatButton1.BorderRadius = 0;
            this.bunifuFlatButton1.ButtonText = "     Upload Dataset";
            this.bunifuFlatButton1.Cursor = System.Windows.Forms.Cursors.Default;
            this.Logo_Hide.SetDecoration(this.bunifuFlatButton1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.bunifuFlatButton1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.bunifuFlatButton1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.bunifuFlatButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuFlatButton1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuFlatButton1.Iconcolor = System.Drawing.Color.Transparent;
            this.bunifuFlatButton1.Iconimage = ((System.Drawing.Image)(resources.GetObject("bunifuFlatButton1.Iconimage")));
            this.bunifuFlatButton1.Iconimage_right = null;
            this.bunifuFlatButton1.Iconimage_right_Selected = null;
            this.bunifuFlatButton1.Iconimage_Selected = null;
            this.bunifuFlatButton1.IconMarginLeft = 0;
            this.bunifuFlatButton1.IconMarginRight = 0;
            this.bunifuFlatButton1.IconRightVisible = true;
            this.bunifuFlatButton1.IconRightZoom = 0D;
            this.bunifuFlatButton1.IconVisible = true;
            this.bunifuFlatButton1.IconZoom = 70D;
            this.bunifuFlatButton1.IsTab = true;
            this.bunifuFlatButton1.Location = new System.Drawing.Point(0, 220);
            this.bunifuFlatButton1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.bunifuFlatButton1.Name = "bunifuFlatButton1";
            this.bunifuFlatButton1.Normalcolor = System.Drawing.Color.FromArgb(((int)(((byte)(21)))), ((int)(((byte)(25)))), ((int)(((byte)(31)))));
            this.bunifuFlatButton1.OnHovercolor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.bunifuFlatButton1.OnHoverTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.bunifuFlatButton1.selected = true;
            this.bunifuFlatButton1.Size = new System.Drawing.Size(285, 70);
            this.bunifuFlatButton1.TabIndex = 1;
            this.bunifuFlatButton1.Text = "     Upload Dataset";
            this.bunifuFlatButton1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuFlatButton1.Textcolor = System.Drawing.Color.FromArgb(((int)(((byte)(106)))), ((int)(((byte)(95)))), ((int)(((byte)(235)))));
            this.bunifuFlatButton1.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuFlatButton1.Click += new System.EventHandler(this.bunifuFlatButton1_Click);
            // 
            // MenuButton
            // 
            this.MenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.MenuButton.BackColor = System.Drawing.Color.Transparent;
            this.Logo_Hide.SetDecoration(this.MenuButton, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.MenuButton, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.MenuButton, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.MenuButton, BunifuAnimatorNS.DecorationType.None);
            this.MenuButton.Image = ((System.Drawing.Image)(resources.GetObject("MenuButton.Image")));
            this.MenuButton.ImageActive = null;
            this.MenuButton.Location = new System.Drawing.Point(226, 19);
            this.MenuButton.Name = "MenuButton";
            this.MenuButton.Size = new System.Drawing.Size(46, 47);
            this.MenuButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.MenuButton.TabIndex = 1;
            this.MenuButton.TabStop = false;
            this.MenuButton.Zoom = 10;
            this.MenuButton.Click += new System.EventHandler(this.MenuButton_Click);
            // 
            // LogoBox
            // 
            this.Panel_shrink.SetDecoration(this.LogoBox, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.LogoBox, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.LogoBox, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.LogoBox, BunifuAnimatorNS.DecorationType.None);
            this.LogoBox.Image = ((System.Drawing.Image)(resources.GetObject("LogoBox.Image")));
            this.LogoBox.Location = new System.Drawing.Point(12, 10);
            this.LogoBox.Name = "LogoBox";
            this.LogoBox.Size = new System.Drawing.Size(208, 134);
            this.LogoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.LogoBox.TabIndex = 0;
            this.LogoBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(119)))), ((int)(((byte)(215)))));
            this.panel1.Controls.Add(this.bunifuImageButton1);
            this.panel1.Controls.Add(this.bunifuImageButton8);
            this.panel1.Controls.Add(this.bunifuImageButton7);
            this.Logo_Hide.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.panel1, BunifuAnimatorNS.DecorationType.None);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1225, 32);
            this.panel1.TabIndex = 15;
            // 
            // bunifuImageButton1
            // 
            this.bunifuImageButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton1.BackColor = System.Drawing.Color.Transparent;
            this.Logo_Hide.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.bunifuImageButton1, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton1.Image = global::PhishDetect.Properties.Resources.maximize;
            this.bunifuImageButton1.ImageActive = null;
            this.bunifuImageButton1.Location = new System.Drawing.Point(1158, 0);
            this.bunifuImageButton1.Name = "bunifuImageButton1";
            this.bunifuImageButton1.Size = new System.Drawing.Size(25, 32);
            this.bunifuImageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton1.TabIndex = 9;
            this.bunifuImageButton1.TabStop = false;
            this.bunifuImageButton1.Zoom = 10;
            this.bunifuImageButton1.Click += new System.EventHandler(this.bunifuImageButton1_Click);
            // 
            // bunifuImageButton8
            // 
            this.bunifuImageButton8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton8.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton8.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo_Hide.SetDecoration(this.bunifuImageButton8, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.bunifuImageButton8, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.bunifuImageButton8, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.bunifuImageButton8, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton8.Image = global::PhishDetect.Properties.Resources.bunifuImageButton8_Image;
            this.bunifuImageButton8.ImageActive = null;
            this.bunifuImageButton8.Location = new System.Drawing.Point(1125, 1);
            this.bunifuImageButton8.Name = "bunifuImageButton8";
            this.bunifuImageButton8.Size = new System.Drawing.Size(27, 32);
            this.bunifuImageButton8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton8.TabIndex = 8;
            this.bunifuImageButton8.TabStop = false;
            this.bunifuImageButton8.Zoom = 10;
            this.bunifuImageButton8.Click += new System.EventHandler(this.bunifuImageButton8_Click);
            // 
            // bunifuImageButton7
            // 
            this.bunifuImageButton7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bunifuImageButton7.BackColor = System.Drawing.Color.Transparent;
            this.bunifuImageButton7.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Logo_Hide.SetDecoration(this.bunifuImageButton7, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.bunifuImageButton7, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.bunifuImageButton7, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.bunifuImageButton7, BunifuAnimatorNS.DecorationType.None);
            this.bunifuImageButton7.Image = global::PhishDetect.Properties.Resources.cross;
            this.bunifuImageButton7.ImageActive = null;
            this.bunifuImageButton7.Location = new System.Drawing.Point(1189, 0);
            this.bunifuImageButton7.Name = "bunifuImageButton7";
            this.bunifuImageButton7.Size = new System.Drawing.Size(36, 38);
            this.bunifuImageButton7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.bunifuImageButton7.TabIndex = 7;
            this.bunifuImageButton7.TabStop = false;
            this.bunifuImageButton7.Zoom = 10;
            this.bunifuImageButton7.Click += new System.EventHandler(this.bunifuImageButton7_Click);
            // 
            // Logo_Animator
            // 
            this.Logo_Animator.AnimationType = BunifuAnimatorNS.AnimationType.Scale;
            this.Logo_Animator.Cursor = null;
            animation3.AnimateOnlyDifferences = true;
            animation3.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.BlindCoeff")));
            animation3.LeafCoeff = 0F;
            animation3.MaxTime = 1F;
            animation3.MinTime = 0F;
            animation3.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicCoeff")));
            animation3.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation3.MosaicShift")));
            animation3.MosaicSize = 0;
            animation3.Padding = new System.Windows.Forms.Padding(0);
            animation3.RotateCoeff = 0F;
            animation3.RotateLimit = 0F;
            animation3.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.ScaleCoeff")));
            animation3.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation3.SlideCoeff")));
            animation3.TimeCoeff = 0F;
            animation3.TransparencyCoeff = 0F;
            this.Logo_Animator.DefaultAnimation = animation3;
            // 
            // TabArea
            // 
            this.TabArea.AllowDrop = true;
            this.TabArea.Controls.Add(this.upload1);
            this.TabArea.Controls.Add(this.ruleset1);
            this.TabArea.Controls.Add(this.ruleset2);
            this.TabArea.Controls.Add(this.extracted1);
            this.TabArea.Controls.Add(this.train1);
            this.TabArea.Controls.Add(this.tree1);
            this.Panel_Animation.SetDecoration(this.TabArea, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.TabArea, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.TabArea, BunifuAnimatorNS.DecorationType.None);
            this.Panel_shrink.SetDecoration(this.TabArea, BunifuAnimatorNS.DecorationType.None);
            this.TabArea.Location = new System.Drawing.Point(285, 32);
            this.TabArea.Name = "TabArea";
            this.TabArea.Size = new System.Drawing.Size(940, 705);
            this.TabArea.TabIndex = 18;
            // 
            // upload1
            // 
            this.upload1.AllowDrop = true;
            this.upload1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.Panel_shrink.SetDecoration(this.upload1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.upload1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.upload1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.upload1, BunifuAnimatorNS.DecorationType.None);
            this.upload1.Location = new System.Drawing.Point(3, 3);
            this.upload1.Name = "upload1";
            this.upload1.Size = new System.Drawing.Size(937, 705);
            this.upload1.TabIndex = 5;
            this.upload1.Load += new System.EventHandler(this.upload1_Load);
            // 
            // ruleset1
            // 
            this.ruleset1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.Panel_shrink.SetDecoration(this.ruleset1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.ruleset1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.ruleset1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.ruleset1, BunifuAnimatorNS.DecorationType.None);
            this.ruleset1.Location = new System.Drawing.Point(3, 714);
            this.ruleset1.Name = "ruleset1";
            this.ruleset1.Size = new System.Drawing.Size(940, 705);
            this.ruleset1.TabIndex = 2;
            // 
            // ruleset2
            // 
            this.ruleset2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.Panel_shrink.SetDecoration(this.ruleset2, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.ruleset2, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.ruleset2, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.ruleset2, BunifuAnimatorNS.DecorationType.None);
            this.ruleset2.Location = new System.Drawing.Point(3, 1425);
            this.ruleset2.Name = "ruleset2";
            this.ruleset2.Size = new System.Drawing.Size(940, 705);
            this.ruleset2.TabIndex = 3;
            // 
            // extracted1
            // 
            this.extracted1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.Panel_shrink.SetDecoration(this.extracted1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.extracted1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.extracted1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.extracted1, BunifuAnimatorNS.DecorationType.None);
            this.extracted1.Location = new System.Drawing.Point(3, 2136);
            this.extracted1.Name = "extracted1";
            this.extracted1.Size = new System.Drawing.Size(940, 705);
            this.extracted1.TabIndex = 4;
            // 
            // train1
            // 
            this.train1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.Panel_shrink.SetDecoration(this.train1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.train1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.train1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.train1, BunifuAnimatorNS.DecorationType.None);
            this.train1.Location = new System.Drawing.Point(3, 2847);
            this.train1.Name = "train1";
            this.train1.Size = new System.Drawing.Size(940, 705);
            this.train1.TabIndex = 0;
            // 
            // tree1
            // 
            this.tree1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.Panel_shrink.SetDecoration(this.tree1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this.tree1, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this.tree1, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this.tree1, BunifuAnimatorNS.DecorationType.None);
            this.tree1.Location = new System.Drawing.Point(3, 3558);
            this.tree1.Name = "tree1";
            this.tree1.Size = new System.Drawing.Size(940, 705);
            this.tree1.TabIndex = 6;
            // 
            // Panel_Animation
            // 
            this.Panel_Animation.AnimationType = BunifuAnimatorNS.AnimationType.HorizSlide;
            this.Panel_Animation.Cursor = null;
            animation2.AnimateOnlyDifferences = true;
            animation2.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.BlindCoeff")));
            animation2.LeafCoeff = 0F;
            animation2.MaxTime = 1F;
            animation2.MinTime = 0F;
            animation2.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicCoeff")));
            animation2.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation2.MosaicShift")));
            animation2.MosaicSize = 0;
            animation2.Padding = new System.Windows.Forms.Padding(0);
            animation2.RotateCoeff = 0F;
            animation2.RotateLimit = 0F;
            animation2.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.ScaleCoeff")));
            animation2.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation2.SlideCoeff")));
            animation2.TimeCoeff = 0F;
            animation2.TransparencyCoeff = 0F;
            this.Panel_Animation.DefaultAnimation = animation2;
            // 
            // Panel_shrink
            // 
            this.Panel_shrink.AnimationType = BunifuAnimatorNS.AnimationType.Particles;
            this.Panel_shrink.Cursor = null;
            animation4.AnimateOnlyDifferences = true;
            animation4.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.BlindCoeff")));
            animation4.LeafCoeff = 0F;
            animation4.MaxTime = 1F;
            animation4.MinTime = 0F;
            animation4.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicCoeff")));
            animation4.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation4.MosaicShift")));
            animation4.MosaicSize = 1;
            animation4.Padding = new System.Windows.Forms.Padding(100, 50, 100, 150);
            animation4.RotateCoeff = 0F;
            animation4.RotateLimit = 0F;
            animation4.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.ScaleCoeff")));
            animation4.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation4.SlideCoeff")));
            animation4.TimeCoeff = 2F;
            animation4.TransparencyCoeff = 0F;
            this.Panel_shrink.DefaultAnimation = animation4;
            this.Panel_shrink.MaxAnimationTime = 2000;
            // 
            // Logo_Hide
            // 
            this.Logo_Hide.AnimationType = BunifuAnimatorNS.AnimationType.Transparent;
            this.Logo_Hide.Cursor = null;
            animation1.AnimateOnlyDifferences = true;
            animation1.BlindCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.BlindCoeff")));
            animation1.LeafCoeff = 0F;
            animation1.MaxTime = 1F;
            animation1.MinTime = 0F;
            animation1.MosaicCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicCoeff")));
            animation1.MosaicShift = ((System.Drawing.PointF)(resources.GetObject("animation1.MosaicShift")));
            animation1.MosaicSize = 0;
            animation1.Padding = new System.Windows.Forms.Padding(0);
            animation1.RotateCoeff = 0F;
            animation1.RotateLimit = 0F;
            animation1.ScaleCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.ScaleCoeff")));
            animation1.SlideCoeff = ((System.Drawing.PointF)(resources.GetObject("animation1.SlideCoeff")));
            animation1.TimeCoeff = 0F;
            animation1.TransparencyCoeff = 1F;
            this.Logo_Hide.DefaultAnimation = animation1;
            // 
            // bunifuDragControl1
            // 
            this.bunifuDragControl1.Fixed = true;
            this.bunifuDragControl1.Horizontal = true;
            this.bunifuDragControl1.TargetControl = this.panel1;
            this.bunifuDragControl1.Vertical = true;
            // 
            // Training
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(35)))), ((int)(((byte)(41)))));
            this.ClientSize = new System.Drawing.Size(1225, 737);
            this.Controls.Add(this.TabArea);
            this.Controls.Add(this.SideMenu);
            this.Controls.Add(this.panel1);
            this.Panel_shrink.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Hide.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Logo_Animator.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.Panel_Animation.SetDecoration(this, BunifuAnimatorNS.DecorationType.None);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Training";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Training";
            this.SideMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MenuButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LogoBox)).EndInit();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuImageButton7)).EndInit();
            this.TabArea.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel SideMenu;
        private Bunifu.Framework.UI.BunifuImageButton MenuButton;
        private System.Windows.Forms.PictureBox LogoBox;
        private System.Windows.Forms.Panel panel1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton1;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton8;
        private Bunifu.Framework.UI.BunifuImageButton bunifuImageButton7;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton1;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton3;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton2;
        private BunifuAnimatorNS.BunifuTransition Panel_Animation;
        private BunifuAnimatorNS.BunifuTransition Logo_Animator;
        private BunifuAnimatorNS.BunifuTransition Panel_shrink;
        private System.Windows.Forms.FlowLayoutPanel TabArea;
        private UserControls.Train train1;
        private UserControls.Ruleset ruleset1;
        private UserControls.Ruleset ruleset2;
        private BunifuAnimatorNS.BunifuTransition Logo_Hide;
        private Bunifu.Framework.UI.BunifuFlatButton bunifuFlatButton5;
        private UserControls.Extracted extracted1;
        private Bunifu.Framework.UI.BunifuDragControl bunifuDragControl1;
        private UserControls.Upload upload1;
        private UserControls.Tree tree1;
    }
}