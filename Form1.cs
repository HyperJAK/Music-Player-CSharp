using AltoHttp;
using NiceUIDesign.Classes;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VideoLibrary;

namespace NiceUIDesign
{
    public partial class Form1 : Form
    {
        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]

        public static extern IntPtr CreateRoundRectRgn(
             int nLeft,
             int nTop,
             int nRight,
             int nBottom,
             int nWidthEllipse,
             int nHeightEllipse

             );

        private Songs songs = new Songs();
        private static SongControl songControl = new SongControl();
        public string selectedPanel;

        public static void updateControlInfo(string songName, Image image)
        {
            songControl.control_label.Text = songName;
            songControl.control_image.Image = image;
        }

        public Form1()
        {
            InitializeComponent();

            /*            nav_panel.Height = dashboard_btn.Height;
                        nav_panel.Top = dashboard_btn.Top;
                        nav_panel.Left = dashboard_btn.Left;
                        dashboard_btn.BackColor = Color.FromArgb(46, 51, 73);*/


            right_displayer.Left = navBar.Right;
            right_displayer.Height = navBar.Height;
            right_displayer.Top = navBar.Top;
            right_displayer.BackColor = Color.White;

            updateControlsPosition();
            songControl.control_label.Height = browseSongs_btn.Height;

            songControl.Height = browseSongs_btn.Height * 3;
            songControl.Dock = DockStyle.Bottom;

            songControl.pause_btn.Click += pauseButton_Click;
            songControl.next_btn.Click += nextButton_Click;
            songControl.prev_btn.Click += prevButton_Click;
            songControl.repeat_btn.Click += repeatButton_Click;

            songControl.control_image.Click += label_Image_Click;
            songControl.control_label.Click += label_Image_Click;

            songControl.Visible = false;


            //pictureBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox2.Width, pictureBox2.Height, 30, 30));

            //downloadSong(GetYouTubeAudioDownloadLink("https://youtu.be/20EWCIEnSLI","mp3"), "nothin");

        }

        private void updateControlsPosition()
        {
            //Initializing SongControl class stuff
  
            songControl.pause_btn.Location = new Point((right_displayer.Width / 2) - (songControl.pause_btn.Width / 2), ((browseSongs_btn.Height * 3) / 2) + (songControl.pause_btn.Height / 10));
            songControl.prev_btn.Location = new Point((right_displayer.Width / 2) - (songControl.prev_btn.Width * 2), ((browseSongs_btn.Height * 3) / 2) + (songControl.prev_btn.Height / 10));
            songControl.next_btn.Location = new Point((right_displayer.Width / 2) + (songControl.next_btn.Width), ((browseSongs_btn.Height * 3) / 2) + (songControl.next_btn.Height / 10));
            songControl.control_image.Location = new Point(10, 10);
            songControl.control_label.Location = new Point(15 + songControl.control_image.Width, 11);
            songControl.control_label.Width = right_displayer.Width - 10;
            songControl.repeat_btn.Location = new Point(((right_displayer.Width / 2) - (songControl.repeat_btn.Width * 6)), ((browseSongs_btn.Height * 3) / 2) + (songControl.repeat_btn.Height / 2));
        }

        public static void changeSongControl_visibility(bool value)
        {
            songControl.Visible = value;
        }


        public string GetYouTubeAudioDownloadLink(string videoUrl, string fileExtension)
        {
            var youTube = YouTube.Default;
            //var video = youTube.GetVideo(videoUrl);

            // Filter the available streams to get audio streams only
            var videoInfos = youTube.GetAllVideosAsync(videoUrl).GetAwaiter().GetResult();
            var audioStreams = videoInfos.Where(s => s.Format == VideoFormat.Unknown);

            // Get the audio stream with the highest bitrate
            var audioStream = audioStreams.OrderByDescending(s => s.AudioBitrate).FirstOrDefault();

            if (audioStream == null)
            {
                // No audio streams found
                return null;
            }

            // Construct the download link with the specified file extension
            string downloadLink = $"{audioStream.Uri}.{fileExtension}";

            return downloadLink;
        }




        private void downloadSong(string download_url, string download_path)
        {
            HttpDownloader downloader;
            try
            {
                downloader = new HttpDownloader(download_url, $"C:\\Users\\james\\Desktop\\yup33.mp3");
                downloader.DownloadCompleted += DownloadCompleted_listener;
                downloader.ProgressChanged += DownloadProgressChanged_listener;
                downloader.DownloadPaused += DownloadPaused_listener;
                downloader.Start();
            }
            catch (Exception)
            {

            }
        }

        private void DownloadPaused_listener(object sender, EventArgs e)
        {

        }

        private void DownloadProgressChanged_listener(object sender, EventArgs e)
        {


        }


        private void DownloadCompleted_listener(object sender, EventArgs e)
        {

        }

        public void DisposeOfItem(string obj)
        {

            switch (obj)
            {
                case "browse":
                    {
                        right_displayer.Controls.Remove(songs);
                    }
                    break;
                case "add_song":
                    {
                        //right_displayer.Controls.Remove(settings);
                    }
                    break;
                case "playlist":
                    {
                        //right_displayer.Controls.Remove(playlist);
                    }
                    break;

                case "contact_us":
                    {
                        //right_displayer.Controls.Remove(playlist);
                    }
                    break;

                case "settings":
                    {
                        //right_displayer.Controls.Remove(ytDownloader);
                    }
                    break;
            }
        }


        private void browseSongs_btn_Click(object sender, EventArgs e)
        {
            if (selectedPanel != "browse")
            {
                if (selectedPanel != null)
                    DisposeOfItem(selectedPanel);
                switchPanel("browse");


            }

        }



        private void switchPanel(string target)
        {
            switch (target)
            {
                case "browse":
                    {
                        nav_panel.Height = browseSongs_btn.Height;
                        nav_panel.Top = browseSongs_btn.Top;
                        nav_panel.Left = browseSongs_btn.Left;

                        selectedPanel = "browse";

                        //stops the panel from calculating, in order to update its elements faster
                        //right_displayer.SuspendLayout();
                        right_displayer.Visible = false;
                        right_displayer.Controls.Add(songs);
                        right_displayer.Controls.Add(songControl);
                        right_displayer.Visible = true;

                        //Makes panel resume calculations
                        //right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        //right_displayer.PerformLayout();
                        //songs.PerformLayout();

                        browseSongs_btn.BackColor = Color.FromArgb(46, 51, 73);
                    }
                    break;

                case "add_song":
                    {
                        nav_panel.Height = addSong_btn.Height;
                        nav_panel.Top = addSong_btn.Top;
                        nav_panel.Left = addSong_btn.Left;

                        selectedPanel = "add_song";

                        /*//stops the panel from calculating, in order to update its elements faster
                        right_displayer.SuspendLayout();

                        right_displayer.Controls.Add(songs);

                        //Makes panel resume calculations
                        right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        right_displayer.PerformLayout();*/
                        addSong_btn.BackColor = Color.FromArgb(46, 51, 73);
                    }
                    break;

                case "playlist":
                    {
                        nav_panel.Height = playlists_btn.Height;
                        nav_panel.Top = playlists_btn.Top;
                        nav_panel.Left = playlists_btn.Left;

                        selectedPanel = "playlist";

                        /*//stops the panel from calculating, in order to update its elements faster
                        right_displayer.SuspendLayout();

                        right_displayer.Controls.Add(songs);

                        //Makes panel resume calculations
                        right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        right_displayer.PerformLayout();*/
                        playlists_btn.BackColor = Color.FromArgb(46, 51, 73);
                    }
                    break;

                case "contact_us":
                    {
                        nav_panel.Height = contactUs_btn.Height;
                        nav_panel.Top = contactUs_btn.Top;
                        nav_panel.Left = contactUs_btn.Left;

                        selectedPanel = "contact_us";

                        /*//stops the panel from calculating, in order to update its elements faster
                        right_displayer.SuspendLayout();

                        right_displayer.Controls.Add(songs);

                        //Makes panel resume calculations
                        right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        right_displayer.PerformLayout();*/
                        contactUs_btn.BackColor = Color.FromArgb(46, 51, 73);
                    }
                    break;

                case "settings":
                    {
                        nav_panel.Height = settings_btn.Height;
                        nav_panel.Top = settings_btn.Top;
                        nav_panel.Left = settings_btn.Left;

                        selectedPanel = "settings";

                        /*//stops the panel from calculating, in order to update its elements faster
                        right_displayer.SuspendLayout();

                        right_displayer.Controls.Add(songs);

                        //Makes panel resume calculations
                        right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        right_displayer.PerformLayout();*/
                        settings_btn.BackColor = Color.FromArgb(46, 51, 73);
                    }
                    break;
            }
        }

        private void browseSongs_btn_Leave(object sender, EventArgs e)
        {
            browseSongs_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            if (selectedPanel != "settings")
            {
                if (selectedPanel != null)
                    DisposeOfItem(selectedPanel);
                switchPanel("settings");

            }

        }

        private void settings_btn_Leave(object sender, EventArgs e)
        {
            settings_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void right_displayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addSong_btn_Click(object sender, EventArgs e)
        {
            if (selectedPanel != "add_song")
            {
                //put these in switchpanel method (later)
                if (selectedPanel != null)
                    DisposeOfItem(selectedPanel);

                songs.add_new_songs();
                songs.reloadSongs();
                switchPanel("browse");

            }
        }

        private void ResizeMainWindow(object sender, EventArgs e)
        {
            
        }

        private void ResizeEndMainWindow(object sender, EventArgs e)
        {

        }

        private void Form1SizeChanged(object sender, EventArgs e)
        {
            updateControlsPosition();

        }

        private void playlistItemClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Hello there");

        }

        private void onImageClick(object sender, EventArgs e)
        {
            playlistItemClicked(sender, e);
        }

        private void songsDisplayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void playlist_click(object sender, EventArgs e)
        {
            if (selectedPanel != "playlist")
            {
                if (selectedPanel != null)
                    DisposeOfItem(selectedPanel);
                switchPanel("playlist");

            }
        }

        private void contactUs_click(object sender, EventArgs e)
        {
            if (selectedPanel != "contact_us")
            {
                if (selectedPanel != null)
                    DisposeOfItem(selectedPanel);
                switchPanel("contact_us");

            }
        }

        private void addSong_btn_Leave(object sender, EventArgs e)
        {
            addSong_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void playlist_btn_Leave(object sender, EventArgs e)
        {
            playlists_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void contactUs_btn_Leave(object sender, EventArgs e)
        {
            contactUs_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        //This part is for SongControl class
        private void keyboard_KeyDown(object sender, KeyEventArgs e)
        {
            if (SongsTracker.songWasQueued)
            {
                if (e.KeyCode == Keys.MediaPlayPause || e.KeyCode == Keys.Space)
                {
                    // Perform your play/pause logic here
                    if (SongsTracker.songIsPaused)
                    {
                        // Resume playback
                        SongsTracker.outputDevice.Play();
                        SongsTracker.songIsPaused = false;
                        Console.WriteLine("Handled inside");
                    }
                    else
                    {
                        // Pause playback
                        SongsTracker.outputDevice.Pause();
                        SongsTracker.songIsPaused = true;
                    }
                    Console.WriteLine("Handled");
                    // Consume the key press event
                    e.Handled = true;
                }
            }
            // Consume the key press event
            e.Handled = true;
        }
        private void pauseButton_Click(object sender, EventArgs e)
        {
            SongsTracker.getOutputInfo();
            SongsTracker.pauseOrPlaySong();

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void prevButton_Click(object sender, EventArgs e)
        {

        }

        private void repeatButton_Click(object sender, EventArgs e)
        {
            if (!SongsTracker.songIsStopped && !SongsTracker.songIsPaused && SongsTracker.songWasQueued)
            {
                if (!SongsTracker.repeatSong)
                {
                    SongsTracker.repeatSong = true;
                }
                else
                {
                    SongsTracker.repeatSong = false;
                }
            }
            else
            {
                if (!SongsTracker.repeatSong)
                {
                    SongsTracker.repeatSong = true;
                    SongsTracker.getOutputInfo();

                    SongsTracker.pauseOrPlaySong();

                }
                else
                {
                    SongsTracker.repeatSong = false;
                }
                
            }
            
        }

        private void label_Image_Click(object sender, EventArgs e)
        {

        }

        private void keyboardListener_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private void keyboardSongControls(object sender, KeyEventArgs e)
        {
            SongsTracker.pauseOrPlaySong();
        }

        private void addSong_keyUpListener(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.MediaPlayPause || e.KeyCode == Keys.Space) && (SongsTracker.songWasQueued))
            {
                SongsTracker.getOutputInfo();
                SongsTracker.pauseOrPlaySong();
            }
            e.Handled = true;
                
        }

        private void playlist_keyUpListener(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.MediaPlayPause || e.KeyCode == Keys.Space) && (SongsTracker.songWasQueued))
            {
                SongsTracker.getOutputInfo();
                SongsTracker.pauseOrPlaySong();
            }
            e.Handled = true;
        }

        private void contactUs_keyUpListener(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.MediaPlayPause || e.KeyCode == Keys.Space) && (SongsTracker.songWasQueued))
            {
                SongsTracker.getOutputInfo();
                SongsTracker.pauseOrPlaySong();
            }
            e.Handled = true;
        }

        private void settings_keyUpListener(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.MediaPlayPause || e.KeyCode == Keys.Space) && (SongsTracker.songWasQueued))
            {
                SongsTracker.getOutputInfo();
                SongsTracker.pauseOrPlaySong();
            }
            e.Handled = true;
        }
    }
}
