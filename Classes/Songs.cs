﻿using Newtonsoft.Json;
using NiceUIDesign.Custom;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class Songs : FlowLayoutPanel
    {

        public List<Song> allSongs = new List<Song>();

        public int songCounter = 0;

        private static Dictionary<int, string> songNameById = new Dictionary<int, string>();
        private static Dictionary<int, string> songPathById = new Dictionary<int, string>();

        public Songs()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.Black;
            this.TabIndex = 1;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.WrapContents = true;
            this.AllowDrop = true;
            this.AutoScroll = true;

            GetSongs();
            

            this.SuspendLayout();
            foreach (Song s in allSongs)
            {
                add_song(s);
            }
            this.ResumeLayout();
            this.PerformLayout();

            createSongsDicts();
            saveSongs(allSongs);

        }

        public void add_new_songs()
        {
            string[] songs = GetSelectedMusicFilePaths();
            List<Song> tempSongs = new List<Song>();

            if (songs != null)
            {
                this.SuspendLayout();
                int tempCounter = 1;
                foreach (string s in songs)
                {
                    Song song = new Song(s, songCounter + tempCounter);
                    tempCounter++;
                    tempSongs.Add(song);

                }

                //Adding additional info on song
                getSongInfo(tempSongs);

                foreach (Song s in tempSongs)
                {

                    allSongs.Add(s);
                    add_song(s);

                    //Adding the new song to dictionaries
                    songNameById.Add(s.id, s.name);
                    songPathById.Add(s.id, s.path);
                }
                this.ResumeLayout();
                this.PerformLayout();

                saveSongs(allSongs);
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

        public void getSongInfo(List<Song> songList)
        {
            // Start the process silently
            Process process = new Process();

            foreach (Song song in songList)
            {
                string songPath = song.path;

                // Set the process start information
                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = "explorer.exe";
                startInfo.Arguments = $"/select, \"{songPath}\"";
                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                startInfo.CreateNoWindow = true;

                process.StartInfo = startInfo;
                process.Start();

                // Get file information
                var fileInfo = new FileInfo(songPath);

                song.name = fileInfo.Name;
                song.songDir = fileInfo.DirectoryName;
                song.size = fileInfo.Length;
                song.creationDate = fileInfo.CreationTime;
                song.lastModifiedDate = fileInfo.LastWriteTime;

            }
            // Wait for the process to exit
            process.WaitForExit();


            //Releases resources
            process.Dispose();

        }

        public static string getSongName(int id)
        {
            string value;
            songNameById.TryGetValue(id, out value);

            return value;
        }

        public static string getSongPath(int id)
        {
            string value;
            songPathById.TryGetValue(id, out value);

            return value;

        }

        private void createSongsDicts()
        {
            foreach (Song s in allSongs)
            {
                songNameById.Add(s.id, s.name);
                songPathById.Add(s.id, s.path);
            }
        }

        public void init_options()
        {

        }


        public void add_song(Song song)
        {
            songCounter++;

            int tagid = song.id;
            CustomFlowLayoutPanel panel = new CustomFlowLayoutPanel($"panel:{song.name}", 160, 180, FlowDirection.TopDown, tagid);
            CustomPictureBox pic = new CustomPictureBox($"pic:{song.name}", tagid);
            CustomLabel label = new CustomLabel($"label:{song.name}", song.name, tagid);

            pic.BackColor = Color.Black;
            pic.Width = panel.Width - 6;
            pic.Height = panel.Height - 60;
            label.Width = panel.Width - 6;
            label.Height = 50;
            label.BackColor = Color.Yellow;

            //To add round edges to song containers
            pic.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, pic.Width, pic.Height, 10, 10));
            panel.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 10, 10));

            panel.Margin = new Padding(12);

            panel.Controls.Add(pic);
            panel.Controls.Add(label);


            //Adding listeners for each of these
            SongsTracker songTracker = new SongsTracker();
            songTracker.addPanel(panel);
            songTracker.addImage(pic);
            songTracker.addLabel(label);


            //Adds the new song to this class (flowpanel)
            this.Controls.Add(panel);


        }

        public void saveSongs(List<Song> allSongs)
        {
            string json = JsonConvert.SerializeObject(allSongs, Formatting.Indented);
            File.WriteAllText("dictionary.json", json);
        }

        public void GetSongs()
        {
            string json2 = File.ReadAllText("dictionary.json");

            var jsonData2 = JsonConvert.DeserializeObject<List<Song>>(json2);

            if(jsonData2 != null){
                foreach (Song song in jsonData2)
                {
                    songCounter++;

                    Console.WriteLine(song);
                    allSongs.Add((Song)song);

                    Console.WriteLine($"Song Name: {song.name}, Song ID: {allSongs.Count}, Song Path: {song.path}, Song id: {song.id}");
                }
            }
        }


    }
}
