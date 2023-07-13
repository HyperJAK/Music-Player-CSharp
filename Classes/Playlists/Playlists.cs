using Newtonsoft.Json;
using NiceUIDesign.Classes.Abstract;
using NiceUIDesign.Custom;
using NiceUIDesign.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NiceUIDesign.Classes.Playlists
{
    public class Playlists : FlowLayoutPanel, Music
    {

        public int playlistCounter = 0;
        public List<Playlist> allPlaylists = new List<Playlist>();
        public PlaylistsTracker playlistTracker;

        private static Dictionary<int, string> playlistNameById = new Dictionary<int, string>();
        private static Dictionary<int, string> playlistPathById = new Dictionary<int, string>();
        private static Dictionary<string, int> playlistIdByPath = new Dictionary<string, int>();

        private ManualResetEvent playlistsLoadedEvent = new ManualResetEvent(false);
        public static bool latestPlayistAddedFirst = true;                                         //From config file

        public Playlists()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Colors.elementsPanelBackground;
            this.Size = new Size(451, 558);
            this.TabIndex = 1;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.WrapContents = true;
            this.AllowDrop = false;
            this.DoubleBuffered = true;

            GetInfo();
            playlistsLoadedEvent.WaitOne();

            this.SuspendLayout();
            if (!latestPlayistAddedFirst)
            {
                foreach (Playlist p in allPlaylists)
                {
                    AddElement(p);
                }
            }
            else
            {

                playlistTracker = new PlaylistsTracker();

                //Reverses list to get last element as first
                allPlaylists.Reverse();
                foreach (Playlist p in allPlaylists)
                {
                    AddElement(p);
                }
                //Reverses list back to original
                allPlaylists.Reverse();
            }



            this.ResumeLayout();
            this.PerformLayout();

            CreateDicts();
            SaveInfo(allPlaylists);

        }
        public void AddElement(Playlist playlist)
        {
            playlistCounter++;

            int tagid = playlist.id;
            CustomPanel panel = new CustomPanel($"panel:{playlist.name}", 160, 180, tagid);
            CustomPictureBox pic = new CustomPictureBox($"pic:{playlist.name}", tagid);
            CustomLabel label = new CustomLabel($"label:{playlist.name}", playlist.name, tagid);

            pic.BackColor = Color.Black;
            pic.Width = panel.Width - 7;
            pic.Height = panel.Height - 60;
            label.Width = panel.Width - 6;
            label.Height = 50;

            //To add round edges to song containers
            //pic.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, pic.Width, pic.Height, 10, 10));
            panel.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 10, 10));

            panel.Margin = new Padding(12);

            panel.Controls.Add(pic);
            panel.Controls.Add(label);
            panel.Capture = true;


            //Adding listeners for each of these
            playlistTracker.AddPanel(panel);
            playlistTracker.AddImage(pic);
            playlistTracker.AddLabel(label);


            //Adds the new song to this class (flowpanel)
            this.Controls.Add(panel);
        }

        public void CreateDicts()
        {
            playlistNameById.Clear();
            playlistPathById.Clear();
            playlistIdByPath.Clear();


            foreach (Playlist p in allPlaylists)
            {
                playlistNameById.Add(p.id, p.name);
                playlistPathById.Add(p.id, p.path);
                playlistIdByPath.Add(p.path, p.id);
            }
        }

        public void GetInfo()
        {
            try
            {
                string json2 = File.ReadAllText("playlists.json");
                var jsonData2 = JsonConvert.DeserializeObject<List<Playlist>>(json2);



                if (jsonData2 != null)
                {
                    foreach (Playlist playlist in jsonData2)
                    {
                        playlistCounter++;
                        Console.WriteLine(playlist);
                        allPlaylists.Add((Playlist)playlist);

                        Console.WriteLine($"Playlist Name: {playlist.name}, Playlist ID: {allPlaylists.Count}, Playlist Path: {playlist.path}, Playlist id: {playlist.id}");
                    }
                }
            }
            catch (Exception)
            {
                File.Create("playlists.json");
            }
            finally
            {
                // Signal that songs have been loaded
                playlistsLoadedEvent.Set();
            }
        }

        public string GetName(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetPath(int id)
        {
            throw new System.NotImplementedException();
        }

        public void Reload()
        {
            if (latestPlayistAddedFirst)
            {
                this.Controls.Clear();

                playlistTracker = new PlaylistsTracker();

                allPlaylists.Reverse();
                foreach (Playlist p in allPlaylists)
                {
                    AddElement(p);
                }
                allPlaylists.Reverse();

            }
            else
            {
                foreach (Playlist p in allPlaylists)
                {
                    AddElement(p);
                }
            }

            CreateDicts();
        }

        public void SaveInfo(List<Playlist> allPlaylists)
        {
            string json = JsonConvert.SerializeObject(allPlaylists, Formatting.Indented);
            File.WriteAllText("playlists.json", json);
        }
    }


}
