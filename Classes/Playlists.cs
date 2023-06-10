using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class Playlists : FlowLayoutPanel
    {

        public Playlists()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.AliceBlue;
            this.Size = new Size(451, 558);
            this.TabIndex = 1;
            this.FlowDirection = FlowDirection.LeftToRight;
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

        }
    }


}
