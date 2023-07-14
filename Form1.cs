using AltoHttp;
using NiceUIDesign.Classes;
using NiceUIDesign.Classes.Playlists;
using NiceUIDesign.Custom;
using NiceUIDesign.Resources;
using System;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Xml.Linq;
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

        public Songs songs = new Songs();
        public Playlists playlists = new Playlists();

        public static SongControl songControl = new SongControl();
        private AddSongs addSongs = new AddSongs();
        public static EditPanel editSongPanel = new EditPanel(200, 200);

        private string selectedPanel;

        public static void updateControlInfo(string songName, Image image)
        {
            songControl.control_label.Text = songName;
            songControl.control_image.BackgroundImage = image;
        }

        public void removeItem(object sender, EventArgs e)
        {

            switch (EditPanel.isPlaylist)
            {
                case false:
                    {
                        Console.WriteLine("deleting...");
                        //gets the id of the selected item that is passed to the lastSelectedElement from songTracker class in edit button listener
                        var selectedItemId = EditPanel.lastSelectedElement;
                        CustomPanel panelToDel = SongsTracker.panels.Find(panel => (int)panel.Tag == selectedItemId);
                        songs.Controls.Remove(panelToDel);
                        editSongPanel.Visible = false;
                        songs.Invalidate();
                    }
                    break;

                case true:
                    {
                        //Add here to remove playlists later
                    }
                    break;

            }
            
        }

        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true;

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

            EditPanel.deleteItem.Click += removeItem;
            songs.MouseDown += Container_MouseDown;

            songControl.Visible = false;
            editSongPanel.Visible = false;

            addSongs.browse_btn.Click += browseSongsListener_Click;

            right_displayer.Controls.Add(editSongPanel);
            editSongPanel.BringToFront();

            //pictureBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox2.Width, pictureBox2.Height, 30, 30));

            //downloadSong(GetYouTubeAudioDownloadLink("https://youtu.be/20EWCIEnSLI","mp3"), "nothin");
            // this.Focus();

        }

        //Makes editOptions not visible when user clicks away
        private void Container_MouseDown(object sender, MouseEventArgs e)
        {
            if (!editSongPanel.ClientRectangle.Contains(editSongPanel.PointToClient(e.Location)))
            {
                editSongPanel.Visible = false;
            }
        }



        private void updateControlsPosition()
        {
            //Initializing SongControl class stuff

            songControl.pause_btn.Location = new Point((right_displayer.Width / 2) - (songControl.pause_btn.Width / 2), ((browseSongs_btn.Height * 3) / 2) + (songControl.pause_btn.Height / 10));
            songControl.prev_btn.Location = new Point((right_displayer.Width / 2) - (songControl.prev_btn.Width * 2), ((browseSongs_btn.Height * 3) / 2) + (songControl.prev_btn.Height / 10));
            songControl.next_btn.Location = new Point((right_displayer.Width / 2) + (songControl.next_btn.Width), ((browseSongs_btn.Height * 3) / 2) + (songControl.next_btn.Height / 10));
            songControl.control_image.Location = new Point(10, 10);
            songControl.control_label.Location = new Point(30 + songControl.control_image.Width, 22);
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
                        right_displayer.Controls.Remove(songControl);
                        editSongPanel.Visible = false;
                    }
                    break;
                case "add_element":
                    {
                        right_displayer.Controls.Remove(addSongs);
                        right_displayer.Controls.Remove(songControl);
                        editSongPanel.Visible = false;
                    }
                    break;
                case "playlist":
                    {
                        right_displayer.Controls.Remove(playlists);
                        right_displayer.Controls.Remove(songControl);
                        editSongPanel.Visible = false;
                    }
                    break;

                case "download":
                    {
                        //right_displayer.Controls.Remove(playlist);
                        right_displayer.Controls.Remove(songControl);
                        editSongPanel.Visible = false;
                    }
                    break;

                case "settings":
                    {
                        //right_displayer.Controls.Remove(ytDownloader);
                        right_displayer.Controls.Remove(songControl);
                        editSongPanel.Visible = false;
                    }
                    break;

                default:
                    {

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

                        //disposing of elements if there are already some
                        if (selectedPanel != null)
                        {
                            DisposeOfItem(selectedPanel);
                        }

                        selectedPanel = "browse";
                        HighlightCorrectButton(selectedPanel);

                        //stops the panel from calculating, in order to update its elements faster
                        //right_displayer.SuspendLayout();
                        right_displayer.Visible = false;
                        right_displayer.Controls.Add(songs);

                        right_displayer.Controls.Add(songControl);

                        if(right_displayer.Controls.Contains(songControl) && Player.songWasQueued)
                        {
                            songControl.Visible = true;
                        }

                        right_displayer.Visible = true;

                        Player.notPlaylist = true;

                        //Makes panel resume calculations
                        //right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        //right_displayer.PerformLayout();
                        //songs.PerformLayout();


                    }
                    break;

                case "add_element":
                    {
                        nav_panel.Height = addSong_btn.Height;
                        nav_panel.Top = addSong_btn.Top;
                        nav_panel.Left = addSong_btn.Left;

                        //disposing of elements if there are already some
                        if (selectedPanel != null)
                        {
                            DisposeOfItem(selectedPanel);
                        }

                        selectedPanel = "add_element";
                        HighlightCorrectButton(selectedPanel);

                        right_displayer.Visible = false;
                        right_displayer.Controls.Add(addSongs);
                        if (right_displayer.Controls.Contains(songControl))
                        {
                            songControl.Visible = false;
                        }
                        right_displayer.Visible = true;

                        Player.notPlaylist = true;

                        /*//stops the panel from calculating, in order to update its elements faster
                        right_displayer.SuspendLayout();

                        right_displayer.Controls.Add(songs);

                        //Makes panel resume calculations
                        right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        right_displayer.PerformLayout();*/

                    }
                    break;

                case "playlist":
                    {
                        nav_panel.Height = playlists_btn.Height;
                        nav_panel.Top = playlists_btn.Top;
                        nav_panel.Left = playlists_btn.Left;

                        //disposing of elements if there are already some
                        if (selectedPanel != null)
                        {
                            DisposeOfItem(selectedPanel);
                        }

                        selectedPanel = "playlist";
                        HighlightCorrectButton(selectedPanel);

                        right_displayer.Visible = false;
                        right_displayer.Controls.Add(playlists);
                        if (right_displayer.Controls.Contains(songControl))
                        {
                            songControl.Visible = false;
                        }

                        right_displayer.Visible = true;

                        Player.notPlaylist = false;

                    }
                    break;

                case "download":
                    {
                        nav_panel.Height = downloadYt_btn.Height;
                        nav_panel.Top = downloadYt_btn.Top;
                        nav_panel.Left = downloadYt_btn.Left;

                        //disposing of elements if there are already some
                        if (selectedPanel != null)
                        {
                            DisposeOfItem(selectedPanel);
                        }

                        selectedPanel = "download";
                        HighlightCorrectButton(selectedPanel);

                        Player.notPlaylist = true;

                        /*//stops the panel from calculating, in order to update its elements faster
                        right_displayer.SuspendLayout();

                        right_displayer.Controls.Add(songs);

                        //Makes panel resume calculations
                        right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        right_displayer.PerformLayout();*/

                    }
                    break;

                case "settings":
                    {
                        nav_panel.Height = settings_btn.Height;
                        nav_panel.Top = settings_btn.Top;
                        nav_panel.Left = settings_btn.Left;

                        //disposing of elements if there are already some
                        if (selectedPanel != null)
                        {
                            DisposeOfItem(selectedPanel);
                        }

                        selectedPanel = "settings";
                        HighlightCorrectButton(selectedPanel);

                        Player.notPlaylist = true;

                        /*//stops the panel from calculating, in order to update its elements faster
                        right_displayer.SuspendLayout();

                        right_displayer.Controls.Add(songs);

                        //Makes panel resume calculations
                        right_displayer.ResumeLayout();
                        //Forces panel to update calculations
                        right_displayer.PerformLayout();*/

                    }
                    break;

                default:
                    {

                    }
                    break;
            }
        }

        public void HighlightCorrectButton(string btn_name)
        {
            switch (btn_name)
            {
                case "browse":
                    {
                        browseSongs_btn.BackColor = Colors.selectionBackground;

                        settings_btn.BackColor = Colors.defaultBackground;
                        addSong_btn.BackColor = Colors.defaultBackground;
                        playlists_btn.BackColor = Colors.defaultBackground;
                        downloadYt_btn.BackColor = Colors.defaultBackground;
                    }
                    break;

                case "add_element":
                    {
                        addSong_btn.BackColor = Colors.selectionBackground;

                        browseSongs_btn.BackColor = Colors.defaultBackground;
                        settings_btn.BackColor = Colors.defaultBackground;
                        playlists_btn.BackColor = Colors.defaultBackground;
                        downloadYt_btn.BackColor = Colors.defaultBackground;

                    }
                    break;

                case "playlist":
                    {
                        playlists_btn.BackColor = Colors.selectionBackground;

                        browseSongs_btn.BackColor = Colors.defaultBackground;
                        settings_btn.BackColor = Colors.defaultBackground;
                        addSong_btn.BackColor = Colors.defaultBackground;
                        downloadYt_btn.BackColor = Colors.defaultBackground;
                    }
                    break;

                case "download":
                    {
                        downloadYt_btn.BackColor = Colors.selectionBackground;

                        browseSongs_btn.BackColor = Colors.defaultBackground;
                        settings_btn.BackColor = Colors.defaultBackground;
                        addSong_btn.BackColor = Colors.defaultBackground;
                        playlists_btn.BackColor = Colors.defaultBackground;

                    }
                    break;

                case "settings":
                    {

                        settings_btn.BackColor = Colors.selectionBackground;

                        browseSongs_btn.BackColor = Colors.defaultBackground;
                        addSong_btn.BackColor = Colors.defaultBackground;
                        playlists_btn.BackColor = Colors.defaultBackground;
                        downloadYt_btn.BackColor = Colors.defaultBackground;
                    }
                    break;

                default:
                    {

                    }
                    break;
            }
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            if (selectedPanel != "settings")
            {

                switchPanel("settings");

            }

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
            if (selectedPanel != "add_element")
            {
                switchPanel("add_element");

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


                switchPanel("playlist");

            }
        }



        private void pauseButton_Click(object sender, EventArgs e)
        {
            Player.GetOutputInfo();
            Player.PauseOrPlaySong();

        }

        private void nextButton_Click(object sender, EventArgs e)
        {

        }

        private void prevButton_Click(object sender, EventArgs e)
        {

        }

        private void repeatButton_Click(object sender, EventArgs e)
        {
            if (!Player.songIsStopped && !Player.songIsPaused && Player.songWasQueued)
            {
                if (!Player.repeatSong)
                {
                    Player.repeatSong = true;
                }
                else
                {
                    Player.repeatSong = false;
                }
            }
            else
            {
                if (!Player.repeatSong)
                {
                    Player.repeatSong = true;
                    Player.GetOutputInfo();

                    Player.PauseOrPlaySong();

                }
                else
                {
                    Player.repeatSong = false;
                }

            }

        }

        private void label_Image_Click(object sender, EventArgs e)
        {

        }

        private void keyboardListener_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
        }

        private void browse_keyUpListener(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Space) && (Player.songWasQueued))
            {
                Player.GetOutputInfo();
                Player.PauseOrPlaySong();
            }
            e.Handled = true;
        }

        private void addSong_keyUpListener(object sender, KeyEventArgs e)
        {
            if ((e.KeyCode == Keys.Space) && (Player.songWasQueued))
            {
                Player.GetOutputInfo();
                Player.PauseOrPlaySong();
            }
            e.Handled = true;

        }

        private void playlist_keyUpListener(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && Player.songWasQueued)
            {
                Player.GetOutputInfo();
                Player.PauseOrPlaySong();
            }
            e.Handled = true;
        }


        private void settings_keyUpListener(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && Player.songWasQueued)
            {
                Player.GetOutputInfo();
                Player.PauseOrPlaySong();
            }
            e.Handled = true;
        }

        private void downloadYt_click(object sender, EventArgs e)
        {
            if (selectedPanel != "download")
            {


                switchPanel("download");

            }
        }


        private void downloadYt_keyUpListener(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space && Player.songWasQueued)
            {
                Player.GetOutputInfo();
                Player.PauseOrPlaySong();
            }
            e.Handled = true;
        }

        private void browseSongsListener_Click(object sender, EventArgs e)
        {
            if (songs.Add_new_songs())
            {
                songs.Reload();
                switchPanel("browse");
                Console.WriteLine("bypassed");
            }

        }
    }
}
