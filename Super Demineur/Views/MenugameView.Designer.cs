namespace WinformsMvc.Example.Views
{
    partial class MenugameView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenugameView));
            this.quitButton = new MetroFramework.Controls.MetroButton();
            this.metroToolTip1 = new MetroFramework.Components.MetroToolTip();
            this.metroProgressSpinner1 = new MetroFramework.Controls.MetroProgressSpinner();
            this.newgameTile = new MetroFramework.Controls.MetroTile();
            this.creditsButton = new MetroFramework.Controls.MetroButton();
            this.rulesTile = new MetroFramework.Controls.MetroTile();
            this.optionsTile = new MetroFramework.Controls.MetroTile();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quitButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("quitButton.BackgroundImage")));
            this.quitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.quitButton.Location = new System.Drawing.Point(504, 324);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(38, 38);
            this.quitButton.TabIndex = 3;
            this.toolTip1.SetToolTip(this.quitButton, "Quitter l\'application");
            this.quitButton.UseSelectable = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // metroToolTip1
            // 
            this.metroToolTip1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroToolTip1.StyleManager = null;
            this.metroToolTip1.Tag = "";
            this.metroToolTip1.Theme = MetroFramework.MetroThemeStyle.Light;
            // 
            // metroProgressSpinner1
            // 
            this.metroProgressSpinner1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.metroProgressSpinner1.Location = new System.Drawing.Point(255, 289);
            this.metroProgressSpinner1.Maximum = 100;
            this.metroProgressSpinner1.Name = "metroProgressSpinner1";
            this.metroProgressSpinner1.Size = new System.Drawing.Size(47, 44);
            this.metroProgressSpinner1.Style = MetroFramework.MetroColorStyle.Green;
            this.metroProgressSpinner1.TabIndex = 5;
            this.metroProgressSpinner1.UseSelectable = true;
            this.metroProgressSpinner1.UseStyleColors = true;
            this.metroProgressSpinner1.Value = 85;
            this.metroProgressSpinner1.Visible = false;
            // 
            // newgameTile
            // 
            this.newgameTile.ActiveControl = null;
            this.newgameTile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.newgameTile.BackColor = System.Drawing.Color.DarkGreen;
            this.newgameTile.Location = new System.Drawing.Point(71, 67);
            this.newgameTile.Name = "newgameTile";
            this.newgameTile.Size = new System.Drawing.Size(414, 40);
            this.newgameTile.TabIndex = 6;
            this.newgameTile.Text = "Nouvelle Partie";
            this.newgameTile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.newgameTile.TileImage = ((System.Drawing.Image)(resources.GetObject("newgameTile.TileImage")));
            this.newgameTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.newgameTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.toolTip1.SetToolTip(this.newgameTile, "Commencez une nouvelle partie");
            this.newgameTile.UseCustomBackColor = true;
            this.newgameTile.UseSelectable = true;
            this.newgameTile.Click += new System.EventHandler(this.newgameTile_Click);
            // 
            // creditsButton
            // 
            this.creditsButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.creditsButton.BackgroundImage = global::WinformsMvc.Example.Properties.Resources.editmirrorvert;
            this.creditsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.creditsButton.Location = new System.Drawing.Point(23, 324);
            this.creditsButton.Name = "creditsButton";
            this.creditsButton.Size = new System.Drawing.Size(38, 38);
            this.creditsButton.TabIndex = 7;
            this.toolTip1.SetToolTip(this.creditsButton, "A propos de MboaGeek");
            this.creditsButton.UseSelectable = true;
            this.creditsButton.Click += new System.EventHandler(this.creditsButton_Click);
            // 
            // rulesTile
            // 
            this.rulesTile.ActiveControl = null;
            this.rulesTile.BackColor = System.Drawing.Color.DarkGreen;
            this.rulesTile.Location = new System.Drawing.Point(71, 116);
            this.rulesTile.Name = "rulesTile";
            this.rulesTile.Size = new System.Drawing.Size(201, 108);
            this.rulesTile.TabIndex = 8;
            this.rulesTile.Text = "Règles du jeu";
            this.rulesTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.rulesTile.Theme = MetroFramework.MetroThemeStyle.Light;
            this.rulesTile.TileImage = global::WinformsMvc.Example.Properties.Resources.fileopen;
            this.rulesTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rulesTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.toolTip1.SetToolTip(this.rulesTile, "Besoin d\'aide? Voici les règles du jeu");
            this.rulesTile.UseCustomBackColor = true;
            this.rulesTile.UseSelectable = true;
            this.rulesTile.UseTileImage = true;
            this.rulesTile.Click += new System.EventHandler(this.rulesTile_Click);
            // 
            // optionsTile
            // 
            this.optionsTile.ActiveControl = null;
            this.optionsTile.BackColor = System.Drawing.Color.DarkGreen;
            this.optionsTile.Location = new System.Drawing.Point(284, 116);
            this.optionsTile.Name = "optionsTile";
            this.optionsTile.Size = new System.Drawing.Size(201, 108);
            this.optionsTile.TabIndex = 9;
            this.optionsTile.Text = "Options";
            this.optionsTile.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.optionsTile.Theme = MetroFramework.MetroThemeStyle.Light;
            this.optionsTile.TileImage = global::WinformsMvc.Example.Properties.Resources.disk;
            this.optionsTile.TileImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.optionsTile.TileTextFontWeight = MetroFramework.MetroTileTextWeight.Bold;
            this.toolTip1.SetToolTip(this.optionsTile, "Définissez vos préférences");
            this.optionsTile.UseCustomBackColor = true;
            this.optionsTile.UseSelectable = true;
            this.optionsTile.UseTileImage = true;
            this.optionsTile.Click += new System.EventHandler(this.optionsTile_Click);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.FontSize = MetroFramework.MetroLabelSize.Small;
            this.metroLabel1.Location = new System.Drawing.Point(179, 336);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(210, 15);
            this.metroLabel1.TabIndex = 10;
            this.metroLabel1.Text = "Chargement en cours, veuillez patienter...";
            this.metroLabel1.Visible = false;
            // 
            // toolTip1
            // 
            this.toolTip1.AutomaticDelay = 200;
            this.toolTip1.BackColor = System.Drawing.SystemColors.Highlight;
            this.toolTip1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.toolTip1.IsBalloon = true;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // MenugameView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackImage = ((System.Drawing.Image)(resources.GetObject("$this.BackImage")));
            this.BackImagePadding = new System.Windows.Forms.Padding(10, 10, 0, 0);
            this.BackMaxSize = 150;
            this.ClientSize = new System.Drawing.Size(560, 385);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.optionsTile);
            this.Controls.Add(this.rulesTile);
            this.Controls.Add(this.creditsButton);
            this.Controls.Add(this.newgameTile);
            this.Controls.Add(this.metroProgressSpinner1);
            this.Controls.Add(this.quitButton);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.MaximizeBox = false;
            this.Name = "MenugameView";
            this.ShadowType = MetroFramework.Forms.MetroFormShadowType.DropShadow;
            this.Style = MetroFramework.MetroColorStyle.Green;
            this.Text = "Le Démineur";
            this.TextAlign = MetroFramework.Forms.MetroFormTextAlign.Center;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MenugameView_FormClosed);
            this.Load += new System.EventHandler(this.MenugameView_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton quitButton;
        private MetroFramework.Components.MetroToolTip metroToolTip1;
        private MetroFramework.Controls.MetroProgressSpinner metroProgressSpinner1;
        private MetroFramework.Controls.MetroTile newgameTile;
        private MetroFramework.Controls.MetroButton creditsButton;
        private MetroFramework.Controls.MetroTile rulesTile;
        private MetroFramework.Controls.MetroTile optionsTile;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.Timer timer1;
    }
}