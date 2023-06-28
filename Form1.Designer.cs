namespace NiceUIDesign
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.navBar = new System.Windows.Forms.Panel();
            this.nav_panel = new System.Windows.Forms.Panel();
            this.browseSongs_btn = new System.Windows.Forms.Button();
            this.settings_btn = new System.Windows.Forms.Button();
            this.downloadYt_btn = new System.Windows.Forms.Button();
            this.playlists_btn = new System.Windows.Forms.Button();
            this.addSong_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.user_name = new System.Windows.Forms.Label();
            this.right_displayer = new System.Windows.Forms.Panel();
            this.keyboardListener = new System.ComponentModel.BackgroundWorker();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.navBar.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // navBar
            // 
            this.navBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.navBar.Controls.Add(this.nav_panel);
            this.navBar.Controls.Add(this.browseSongs_btn);
            this.navBar.Controls.Add(this.settings_btn);
            this.navBar.Controls.Add(this.downloadYt_btn);
            this.navBar.Controls.Add(this.playlists_btn);
            this.navBar.Controls.Add(this.addSong_btn);
            this.navBar.Controls.Add(this.panel2);
            this.navBar.Dock = System.Windows.Forms.DockStyle.Left;
            this.navBar.Location = new System.Drawing.Point(0, 0);
            this.navBar.Margin = new System.Windows.Forms.Padding(4);
            this.navBar.Name = "navBar";
            this.navBar.Size = new System.Drawing.Size(248, 710);
            this.navBar.TabIndex = 0;
            // 
            // nav_panel
            // 
            this.nav_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.nav_panel.Location = new System.Drawing.Point(0, 271);
            this.nav_panel.Margin = new System.Windows.Forms.Padding(4);
            this.nav_panel.Name = "nav_panel";
            this.nav_panel.Size = new System.Drawing.Size(4, 220);
            this.nav_panel.TabIndex = 1;
            // 
            // browseSongs_btn
            // 
            this.browseSongs_btn.FlatAppearance.BorderSize = 0;
            this.browseSongs_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.browseSongs_btn.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.browseSongs_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.browseSongs_btn.Location = new System.Drawing.Point(0, 263);
            this.browseSongs_btn.Margin = new System.Windows.Forms.Padding(4);
            this.browseSongs_btn.Name = "browseSongs_btn";
            this.browseSongs_btn.Size = new System.Drawing.Size(248, 52);
            this.browseSongs_btn.TabIndex = 2;
            this.browseSongs_btn.Text = "Browse songs";
            this.browseSongs_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.browseSongs_btn.UseVisualStyleBackColor = true;
            this.browseSongs_btn.Click += new System.EventHandler(this.browseSongs_btn_Click);
            this.browseSongs_btn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.keyboardSongControls);
            // 
            // settings_btn
            // 
            this.settings_btn.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.settings_btn.FlatAppearance.BorderSize = 0;
            this.settings_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settings_btn.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.settings_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.settings_btn.Location = new System.Drawing.Point(0, 658);
            this.settings_btn.Margin = new System.Windows.Forms.Padding(4);
            this.settings_btn.Name = "settings_btn";
            this.settings_btn.Size = new System.Drawing.Size(248, 52);
            this.settings_btn.TabIndex = 2;
            this.settings_btn.Text = "Settings";
            this.settings_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.settings_btn.UseVisualStyleBackColor = true;
            this.settings_btn.Click += new System.EventHandler(this.settings_btn_Click);
            this.settings_btn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.settings_keyUpListener);
            // 
            // downloadYt_btn
            // 
            this.downloadYt_btn.FlatAppearance.BorderSize = 0;
            this.downloadYt_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.downloadYt_btn.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.downloadYt_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.downloadYt_btn.Location = new System.Drawing.Point(0, 440);
            this.downloadYt_btn.Margin = new System.Windows.Forms.Padding(4);
            this.downloadYt_btn.Name = "downloadYt_btn";
            this.downloadYt_btn.Size = new System.Drawing.Size(248, 52);
            this.downloadYt_btn.TabIndex = 2;
            this.downloadYt_btn.Text = "Download";
            this.downloadYt_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.downloadYt_btn.UseVisualStyleBackColor = true;
            this.downloadYt_btn.Click += new System.EventHandler(this.downloadYt_click);
            this.downloadYt_btn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.downloadYt_keyUpListener);
            // 
            // playlists_btn
            // 
            this.playlists_btn.FlatAppearance.BorderSize = 0;
            this.playlists_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.playlists_btn.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.playlists_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.playlists_btn.Location = new System.Drawing.Point(0, 381);
            this.playlists_btn.Margin = new System.Windows.Forms.Padding(4);
            this.playlists_btn.Name = "playlists_btn";
            this.playlists_btn.Size = new System.Drawing.Size(248, 52);
            this.playlists_btn.TabIndex = 2;
            this.playlists_btn.Text = "Playlists";
            this.playlists_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.playlists_btn.UseVisualStyleBackColor = true;
            this.playlists_btn.Click += new System.EventHandler(this.playlist_click);
            this.playlists_btn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.playlist_keyUpListener);
            // 
            // addSong_btn
            // 
            this.addSong_btn.FlatAppearance.BorderSize = 0;
            this.addSong_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.addSong_btn.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.addSong_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.addSong_btn.Location = new System.Drawing.Point(0, 322);
            this.addSong_btn.Margin = new System.Windows.Forms.Padding(4);
            this.addSong_btn.Name = "addSong_btn";
            this.addSong_btn.Size = new System.Drawing.Size(248, 52);
            this.addSong_btn.TabIndex = 2;
            this.addSong_btn.Text = "Add song";
            this.addSong_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.addSong_btn.UseVisualStyleBackColor = true;
            this.addSong_btn.Click += new System.EventHandler(this.addSong_btn_Click);
            this.addSong_btn.KeyUp += new System.Windows.Forms.KeyEventHandler(this.addSong_keyUpListener);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.user_name);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 177);
            this.panel2.TabIndex = 1;
            // 
            // user_name
            // 
            this.user_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.ForeColor = System.Drawing.Color.DodgerBlue;
            this.user_name.Location = new System.Drawing.Point(61, 143);
            this.user_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(123, 34);
            this.user_name.TabIndex = 1;
            this.user_name.Text = "AuPlay";
            this.user_name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // right_displayer
            // 
            this.right_displayer.BackColor = System.Drawing.Color.White;
            this.right_displayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.right_displayer.Location = new System.Drawing.Point(248, 0);
            this.right_displayer.Margin = new System.Windows.Forms.Padding(0);
            this.right_displayer.Name = "right_displayer";
            this.right_displayer.Size = new System.Drawing.Size(1026, 710);
            this.right_displayer.TabIndex = 1;
            this.right_displayer.Paint += new System.Windows.Forms.PaintEventHandler(this.right_displayer_Paint);
            // 
            // keyboardListener
            // 
            this.keyboardListener.DoWork += new System.ComponentModel.DoWorkEventHandler(this.keyboardListener_DoWork);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NiceUIDesign.Properties.Resources.AuPlayLogo;
            this.pictureBox1.Location = new System.Drawing.Point(61, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(123, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1274, 710);
            this.Controls.Add(this.right_displayer);
            this.Controls.Add(this.navBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AuPlay";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.ResizeMainWindow);
            this.ResizeEnd += new System.EventHandler(this.ResizeEndMainWindow);
            this.SizeChanged += new System.EventHandler(this.Form1SizeChanged);
            this.navBar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel navBar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button browseSongs_btn;
        private System.Windows.Forms.Label user_name;
        private System.Windows.Forms.Button settings_btn;
        private System.Windows.Forms.Button playlists_btn;
        private System.Windows.Forms.Button addSong_btn;
        private System.Windows.Forms.Button downloadYt_btn;
        private System.Windows.Forms.Panel nav_panel;
        private System.Windows.Forms.Panel right_displayer;
        private System.ComponentModel.BackgroundWorker keyboardListener;
    }
}

