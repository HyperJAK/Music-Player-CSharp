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

        public static Dictionary<int, string> songNameById = new Dictionary<int, string>();
        public static Dictionary<int, string> songPathById = new Dictionary<int, string>();
        public static Dictionary<string, int> songIdByPath = new Dictionary<string, int>();

        public static bool latestSongAddedFirst = true;                                         //From config file

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
            this.DoubleBuffered = true;

            this.MouseEnter += windowMouseEnter_listener;

            GetInfo();
            songsLoadedEvent.WaitOne();


            this.SuspendLayout();
            if (!latestSongAddedFirst)
            {
                foreach (Song s in allSongs)
                {
                    AddElement(s);
                }
            }
            else
            {

                songTracker = new SongsTracker();

                //Reverses list to get last element as first
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


        public void windowMouseEnter_listener(object sender, EventArgs e)
        {
            if (songTracker.listOfCheckedElements.Count == 0)
            {


                CustomCheckbox checkBox;
                CustomRoundButton playBtn;
                CustomRoundButton editBtn;



                foreach (CustomPanel cp in songTracker.elementsHoveredHistory)
                {
                    cp.BackColor = Colors.elementsPanelBackground;

                    checkBox = songTracker.checkBoxes.Find(box => (int)box.Tag == (int)cp.Tag);
                    playBtn = songTracker.playButtons.Find(btn => (int)btn.Tag == (int)cp.Tag);
                    editBtn = songTracker.editButtons.Find(btn => (int)btn.Tag == (int)cp.Tag);

                    if (!songTracker.startedCheckingBoxes)
                    {
                        checkBox.Visible = false;
                    }
                    playBtn.Visible = false;
                    editBtn.Visible = false;
                }
            }
        }


        public void Reload()
        {
            if (latestSongAddedFirst)
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

        public static int GetId(string path)
        {
            int value;
            songIdByPath.TryGetValue(path, out value);

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
            CustomPanel panel = new CustomPanel($"panel:{tagid}", 160, 180, tagid);
            CustomPictureBox pic = new CustomPictureBox($"pic:{tagid}", tagid);
            CustomLabel label = new CustomLabel($"label:{tagid}", song.name, tagid);
            CustomRoundButton play_btn = new CustomRoundButton($"button:{tagid}", tagid, 30, 30);
            CustomRoundButton edit_btn = new CustomRoundButton($"button:{tagid}", tagid, 25, 25);
            CustomCheckbox selectElement_checkBox = new CustomCheckbox($"checkbox:{tagid}", tagid, 13, 13);


            pic.BackColor = Color.Black;
            pic.Width = panel.Width - 7;
            pic.Height = panel.Height - 60;
            label.Width = panel.Width - 6;
            label.Height = 50;

            //Adding Images to buttons and other fields
            //pic.BackgroundImage = NiceUIDesign.Properties.Resources.AuPlayLogo;

            play_btn.BackgroundImage = Properties.Resources.playBtn;
            edit_btn.BackgroundImage = Properties.Resources.editBtn;

            play_btn.Location = new Point(pic.Right - (play_btn.Width + 5), pic.Bottom - play_btn.Height);
            play_btn.Visible = false;

            edit_btn.Location = new Point(pic.Right - (play_btn.Width + 3), pic.Top + edit_btn.Height / 2);
            edit_btn.Visible = false;

            pic.Location = new Point(panel.Left + 4, panel.Top + 5);

            selectElement_checkBox.Location = new Point(pic.Left + 12, pic.Top + edit_btn.Height / 2);
            selectElement_checkBox.Visible = false;

            //To add round edges to song containers
            pic.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, pic.Width, pic.Height, 40, 40));
            //selectElement_checkBox.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, (selectElement_checkBox.Width/2 + 3), selectElement_checkBox.Height - 5, 10, 10));

            panel.Margin = new Padding(12);

            panel.Controls.Add(play_btn);
            panel.Controls.Add(edit_btn);
            panel.Controls.Add(selectElement_checkBox);
            panel.Controls.Add(pic);
            panel.Controls.Add(label);
            panel.Capture = true;

            //pic.Dock = DockStyle.Fill;
            label.Dock = DockStyle.Bottom;


            //Adding listeners for each of these
            songTracker.AddPanel(panel);
            songTracker.AddImage(pic);
            songTracker.AddLabel(label);
            songTracker.AddPlayButton(play_btn);
            songTracker.AddEditButton(edit_btn);
            songTracker.AddCheckBox(selectElement_checkBox);


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
