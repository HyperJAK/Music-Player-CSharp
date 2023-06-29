using Newtonsoft.Json;
using NiceUIDesign.Classes.Abstract;
using NiceUIDesign.Custom;
using NiceUIDesign.Resources;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class Songs : FlowLayoutPanel, Music
    {

        public List<Song> allSongs = new List<Song>();
        public SongsTracker songTracker;

        public int songCounter = 0;

        private static Dictionary<int, string> songNameById = new Dictionary<int, string>();
        private static Dictionary<int, string> songPathById = new Dictionary<int, string>();
        private static Dictionary<string, int> songIdByPath = new Dictionary<string, int>();

        public static bool latestAddedFirst = true;                                         //From config file

        //Used to halt other functions from running before all songs have been loaded
        private ManualResetEvent songsLoadedEvent = new ManualResetEvent(false);

        public Songs()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Colors.elementsPanelBackground;
            this.TabIndex = 1;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.WrapContents = true;
            this.AllowDrop = false;
            this.AutoScroll = true;

            GetInfo();
            songsLoadedEvent.WaitOne();


            this.SuspendLayout();
            if (!latestAddedFirst)
            {
                foreach (Song s in allSongs)
                {
                    AddElement(s);
                }
            }
            else
            {
                //Reverses list to get last element as first
                songTracker = new SongsTracker();

                allSongs.Reverse();
                foreach (Song s in allSongs)
                {
                    AddElement(s);
                }
                //Reverses list back to original
                allSongs.Reverse();
            }



            this.ResumeLayout();
            this.PerformLayout();

            CreateDicts();
            SaveInfo(allSongs);

        }


        public void ReloadSongs()
        {
            if (latestAddedFirst)
            {
                this.Controls.Clear();

                songTracker = new SongsTracker();

                allSongs.Reverse();
                foreach (Song s in allSongs)
                {
                    AddElement(s);
                }
                allSongs.Reverse();

            }
            else
            {
                foreach (Song s in allSongs)
                {
                    AddElement(s);
                }
            }

            CreateDicts();

        }

        private string[] CreateNoDuplicateList(string[] songs)
        {
            List<string> tempList = new List<string>();

            foreach (string s in songs)
            {
                Console.WriteLine(s);
                if (!songIdByPath.ContainsKey(s))
                {
                    Console.WriteLine("No duplicate found");
                    tempList.Add(s);
                }
            }

            return tempList.ToArray();
        }

        public bool Add_new_songs()
        {
            string[] songs = GetSelectedMusicFilePaths();
            List<Song> tempSongs = new List<Song>();

            songs = CreateNoDuplicateList(songs);

            if (songs.Length > 0)
            {
                this.SuspendLayout();
                int tempCounter = 1;
                foreach (string s in songs)
                {
                    Song song = new Song(s, songCounter + tempCounter);
                    tempCounter++;
                    //creating temp list to add only new songs to dicts
                    tempSongs.Add(song);

                }

                //Adding additional info on song
                GetSongInfo(tempSongs);

                foreach (Song s in tempSongs)
                {
                    AddElement(s);
                    allSongs.Add(s);

                    //Adding the new song to dictionaries
                    songNameById.Add(s.id, s.name);
                    songPathById.Add(s.id, s.path);
                    songIdByPath.Add(s.path, s.id);
                }


                this.ResumeLayout();
                this.PerformLayout();

                SaveInfo(allSongs);
                return true;
            }
            else
            {
                //If duplicates found then count them and create popup saying how many found
                Console.WriteLine("Create a popup that says song duplicate found");

                string message = "Duplicate song(s) found.";
                string title = "Duplicate";
                MessageBox.Show(message, title);

                return false;
            }
        }

        public static string[] GetSelectedMusicFilePaths()
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true; // Allow multiple file selection
                //Acceptable formats
                openFileDialog.Filter = "Music Files (*.mp3;*.wav;*.flac;*.m4a)|*.mp3;*.wav;*.flac;*.m4a";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    return openFileDialog.FileNames;
                }
            }

            return null;
        }

        public void GetSongInfo(List<Song> songList)
        {
            // Start the process silently
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "explorer.exe";
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.CreateNoWindow = true;

            bool processStarted = false;

            foreach (Song song in songList)
            {

                // Set the process start information

                startInfo.Arguments = $"/select, \"{song.path}\"";

                process.StartInfo = startInfo;

                if (!processStarted)
                {
                    process.Start();
                    processStarted = true;

                }


                // Get file information
                var fileInfo = new FileInfo(song.path);

                song.name = fileInfo.Name;
                song.songDir = fileInfo.DirectoryName;
                song.size = fileInfo.Length;
                song.creationDate = fileInfo.CreationTime;
                song.lastModifiedDate = fileInfo.LastWriteTime;

            }
            // Wait for the process to exit
            //process.WaitForExit();

            //Releases resources
            //process.Dispose();
            //process.Kill();
            Process temp_process = Process.GetProcessById(process.Id);
            temp_process.Kill();


        }


        public static string GetName(int id)
        {
            string value;
            songNameById.TryGetValue(id, out value);

            return value;
        }


        public static string GetPath(int id)
        {
            string value;
            songPathById.TryGetValue(id, out value);

            return value;

        }


        public void CreateDicts()
        {
            songNameById.Clear();
            songPathById.Clear();
            songIdByPath.Clear();


            foreach (Song s in allSongs)
            {
                songNameById.Add(s.id, s.name);
                songPathById.Add(s.id, s.path);
                songIdByPath.Add(s.path, s.id);
            }
        }




        public void AddElement(Song song)
        {
            songCounter++;

            int tagid = song.id;
            CustomFlowLayoutPanel panel = new CustomFlowLayoutPanel($"panel:{song.name}", 160, 180, FlowDirection.TopDown, tagid);
            CustomPictureBox pic = new CustomPictureBox($"pic:{song.name}", tagid);
            CustomLabel label = new CustomLabel($"label:{song.name}", song.name, tagid);

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
            songTracker.AddPanel(panel);
            songTracker.AddImage(pic);
            songTracker.AddLabel(label);


            //Adds the new song to this class (flowpanel)
            this.Controls.Add(panel);


        }


        public void SaveInfo(List<Song> allSongs)
        {
            string json = JsonConvert.SerializeObject(allSongs, Formatting.Indented);
            File.WriteAllText("dictionary.json", json);
        }


        public void GetInfo()
        {
            try
            {
                string json2 = File.ReadAllText("dictionary.json");
                var jsonData2 = JsonConvert.DeserializeObject<List<Song>>(json2);



                if (jsonData2 != null)
                {
                    foreach (Song song in jsonData2)
                    {
                        songCounter++;

                        Console.WriteLine(song);
                        allSongs.Add((Song)song);

                        Console.WriteLine($"Song Name: {song.name}, Song ID: {allSongs.Count}, Song Path: {song.path}, Song id: {song.id}");
                    }
                }
            }
            catch (Exception)
            {
                File.Create("dictionary.json");
            }
            finally
            {
                // Signal that songs have been loaded
                songsLoadedEvent.Set();
            }

        }


    }
}
