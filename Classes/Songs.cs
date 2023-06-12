using Newtonsoft.Json;
using NiceUIDesign.Custom;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class Songs : FlowLayoutPanel
    {

        public List<Song> allSongs = new List<Song>();

        public int songCounter = 0;

        private Dictionary<Song,int> songs_dict = new Dictionary<Song,int>();
            
        public Songs() {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.AliceBlue;
            this.TabIndex = 1;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.WrapContents = true;
            this.AllowDrop = true;

            GetSongs();
            //Song song1 = new Song("hi", "path1", songCounter + 1);
            // Song song2 = new Song("hi2", "path2", songCounter + 2);
            //Song song3 = new Song("hi3", "path3", songCounter + 3);

            foreach (Song s in allSongs) {
                add_song(s);
            }

            // saveSongs(allSongs);

        }

        public void init_options()
        {
            
        }


        public void add_song(Song song)
        {
            songCounter++;

            int tagid = songCounter;
            CustomFlowLayoutPanel panel = new CustomFlowLayoutPanel($"panel:{song.name}",160,180, FlowDirection.TopDown, tagid);
            CustomPictureBox pic = new CustomPictureBox($"pic:{song.name}", tagid);
            CustomLabel label = new CustomLabel($"label:{song.name}", song.name, tagid);

            pic.BackColor = Color.Black;
            pic.Width = panel.Width - 6;
            pic.Height = panel.Height - 60;

            pic.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, pic.Width, pic.Height, 10, 10));
            panel.Region = Region.FromHrgn(Form1.CreateRoundRectRgn(0, 0, panel.Width, panel.Height, 10, 10));

            panel.Margin = new Padding(15);

            panel.Controls.Add(pic);
            panel.Controls.Add(label);



            SongsTracker songTracker = new SongsTracker();
            songTracker.addPanel(panel);
            songTracker.addImage(pic);
            songTracker.addLabel(label);


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


            foreach (Song song in jsonData2)
            {
                Console.WriteLine(song);
                allSongs.Add((Song)song);

                Console.WriteLine($"Song Name: {song.name}, Song ID: {allSongs.Count}, Song Path: {song.path}, Song id: {song.id}");
            }
        }


    }
}
