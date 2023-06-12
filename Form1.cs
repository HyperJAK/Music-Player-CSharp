using AltoHttp;
using System;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using VideoLibrary;
using System.Linq;

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

        private Classes.Songs songs = new Classes.Songs();
        public string selectedPanel;

        public Form1()
        {
            InitializeComponent();

            /*            nav_panel.Height = dashboard_btn.Height;
                        nav_panel.Top = dashboard_btn.Top;
                        nav_panel.Left = dashboard_btn.Left;
                        dashboard_btn.BackColor = Color.FromArgb(46, 51, 73);*/

            right_displayer.Left = panel1.Right;
            right_displayer.Height = panel1.Height;
            right_displayer.Top = panel1.Top;
            right_displayer.BackColor = Color.White;

            pictureBox2.Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, pictureBox2.Width, pictureBox2.Height, 30, 30));

           // downloadSong(GetYouTubeAudioDownloadLink("https://www.youtube.com/watch?v=8eJX6CmzwyM","mp3"), "nothin");

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
                downloader = new HttpDownloader(download_url, $"C:\\Users\\james\\Desktop\\yup.mp3");
                downloader.DownloadCompleted += DownloadCompleted_listener;
                downloader.ProgressChanged += DownloadProgressChanged_listener;
                downloader.DownloadPaused += DownloadPaused_listener;
                downloader.Start();
            }
            catch (Exception ex)
            {

            }
        }

        private void DownloadPaused_listener(object sender , EventArgs e)
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
                case "songs":
                    {
                        right_displayer.Controls.Remove(songs);

                    }
                    break;
                case "settings":
                    {
                        //right_displayer.Controls.Remove(settings);
                    }
                    break;
                case "playlist":
                    {
                        //right_displayer.Controls.Remove(playlist);
                    }
                    break;
                case "ytdownloader":
                    {
                        //right_displayer.Controls.Remove(ytDownloader);
                    }
                    break;
            }
        }


        private void browseSongs_btn_Click(object sender, EventArgs e)
        {
            if (selectedPanel != "songs")
            {
                //if(selectedPanel != null)
                //DisposeOfItem(selectedPanel);

                selectedPanel = "songs";

                right_displayer.Controls.Add(songs);

                nav_panel.Height = browseSongs_btn.Height;
                nav_panel.Top = browseSongs_btn.Top;
                nav_panel.Left = browseSongs_btn.Left;
                browseSongs_btn.BackColor = Color.FromArgb(46, 51, 73);
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

                selectedPanel = "settings";

                nav_panel.Height = settings_btn.Height;
                nav_panel.Top = settings_btn.Top;
                nav_panel.Left = settings_btn.Left;
                settings_btn.BackColor = Color.FromArgb(46, 51, 73);
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
            Console.WriteLine("Hello there");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addSong_btn_Click(object sender, EventArgs e)
        {

        }

        private void ResizeMainWindow(object sender, EventArgs e)
        {

        }

        private void ResizeEndMainWindow(object sender, EventArgs e)
        {


        }

        private void Form1SizeChanged(object sender, EventArgs e)
        {


        }

        private void playlistItemClicked(object sender, EventArgs e)
        {
            Console.WriteLine("Hello there");
            label1.Text = "Nope";

        }

        private void onImageClick(object sender, EventArgs e)
        {
            playlistItemClicked(sender, e);
        }
    }
}
