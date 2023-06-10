using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class Songs : FlowLayoutPanel
    {

        private Dictionary<string, int> songs_dict = new Dictionary<string, int>();
            
        public Songs() {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.AliceBlue;
            this.Size = new Size(451, 558);
            this.TabIndex = 1;
            this.FlowDirection = FlowDirection.TopDown;
            this.WrapContents = true;
            this.AllowDrop = true;

            add_song("hi");
            add_song("hi2");
            add_song("hi3");

        }

        public void init_options()
        {
            
        }


        public void add_song(string songName)
        {
            Button test = new Button { Name = $"button{songName}", Text = $"This is button {songName}" };
            ButtonsTracker buttonTrack = new ButtonsTracker();
            buttonTrack.addButton(test);
            this.Controls.Add(test);



            var jsonData = new
            {
                song_ids = songs_dict
            };


            songs_dict.Add($"{songName}", songs_dict.Count() + 1);

            string json = JsonConvert.SerializeObject(jsonData, Formatting.Indented);
            File.WriteAllText("dictionary.json", json);

            GetSongs();

        }

        public void GetSongs()
        {
            string json2 = File.ReadAllText("dictionary.json");

            var jsonData2 = JsonConvert.DeserializeObject<dynamic>(json2);

            // Access the group name "song_ids" and iterate over the songs_dict dictionary
            var songIds = jsonData2.song_ids;

            foreach (var song in songIds)
            {
                string songName2 = song.Name;
                int songId = song.Value;

                Console.WriteLine($"Song Name: {songName2}, Song ID: {songId}");
            }
        }


    }
}
