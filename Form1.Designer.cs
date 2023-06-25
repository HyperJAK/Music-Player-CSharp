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
            this.navBar = new System.Windows.Forms.Panel();
            this.nav_panel = new System.Windows.Forms.Panel();
            this.browseSongs_btn = new System.Windows.Forms.Button();
            this.settings_btn = new System.Windows.Forms.Button();
            this.contactUs_btn = new System.Windows.Forms.Button();
            this.playlists_btn = new System.Windows.Forms.Button();
            this.addSong_btn = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.user_name = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.right_displayer = new System.Windows.Forms.Panel();
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
            this.navBar.Controls.Add(this.contactUs_btn);
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
            this.browseSongs_btn.Leave += new System.EventHandler(this.browseSongs_btn_Leave);
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
            this.settings_btn.Leave += new System.EventHandler(this.settings_btn_Leave);
            // 
            // contactUs_btn
            // 
            this.contactUs_btn.FlatAppearance.BorderSize = 0;
            this.contactUs_btn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.contactUs_btn.Font = new System.Drawing.Font("Nirmala UI", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.contactUs_btn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(126)))), ((int)(((byte)(249)))));
            this.contactUs_btn.Location = new System.Drawing.Point(0, 440);
            this.contactUs_btn.Margin = new System.Windows.Forms.Padding(4);
            this.contactUs_btn.Name = "contactUs_btn";
            this.contactUs_btn.Size = new System.Drawing.Size(248, 52);
            this.contactUs_btn.TabIndex = 2;
            this.contactUs_btn.Text = "Contact Us";
            this.contactUs_btn.TextImageRelation = System.Windows.Forms.TextImageRelation.TextBeforeImage;
            this.contactUs_btn.UseVisualStyleBackColor = true;
            this.contactUs_btn.Click += new System.EventHandler(this.contactUs_click);
            this.contactUs_btn.Leave += new System.EventHandler(this.contactUs_btn_Leave);
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
            this.playlists_btn.Leave += new System.EventHandler(this.playlist_btn_Leave);
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
            this.addSong_btn.Leave += new System.EventHandler(this.addSong_btn_Leave);
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
            this.user_name.AutoSize = true;
            this.user_name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.user_name.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(156)))), ((int)(((byte)(149)))));
            this.user_name.Location = new System.Drawing.Point(61, 143);
            this.user_name.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.user_name.Name = "user_name";
            this.user_name.Size = new System.Drawing.Size(103, 20);
            this.user_name.TabIndex = 1;
            this.user_name.Text = "User Name";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::NiceUIDesign.Properties.Resources.Megumin;
            this.pictureBox1.Location = new System.Drawing.Point(65, 15);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 124);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
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
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(46)))), ((int)(((byte)(51)))), ((int)(((byte)(73)))));
            this.ClientSize = new System.Drawing.Size(1274, 710);
            this.Controls.Add(this.right_displayer);
            this.Controls.Add(this.navBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResizeBegin += new System.EventHandler(this.ResizeMainWindow);
            this.ResizeEnd += new System.EventHandler(this.ResizeEndMainWindow);
            this.SizeChanged += new System.EventHandler(this.Form1SizeChanged);
            this.navBar.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Button contactUs_btn;
        private System.Windows.Forms.Panel nav_panel;
        private System.Windows.Forms.Panel right_displayer;
    }
}

