using Auplay.Classes.Abstract;
using Auplay.Custom;
using System;
using System.Collections.Generic;

namespace Auplay.Classes.Playlists
{
    public class PlaylistsTracker : MusicTracker
    {

        private List<CustomPanel> panels;
        private List<CustomPictureBox> pics;
        private List<CustomLabel> labels;



        public PlaylistsTracker()
        {
            panels = new List<CustomPanel>();
            pics = new List<CustomPictureBox>();
            labels = new List<CustomLabel>();
        }


        public override void AddImage(CustomPictureBox pic)
        {
            pic.Click += Panel_Click;
            pic.MouseHover += Panel_Hover;
            pics.Add(pic);
        }

        public override void AddLabel(CustomLabel label)
        {
            label.Click += Panel_Click;
            label.MouseHover += Panel_Hover;
            labels.Add(label);
        }

        public override void AddPanel(CustomPanel panel)
        {
            panel.Click += Panel_Click;
            panel.MouseHover += Panel_Hover;
            panel.MouseLeave += Panel_Hover_Exited;
            panels.Add(panel);
        }


        public override void Panel_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Panel_Hover(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        public override void Panel_Hover_Exited(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }


    }
}
