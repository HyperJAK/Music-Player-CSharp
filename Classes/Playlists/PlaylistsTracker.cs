using NiceUIDesign.Classes.Abstract;
using NiceUIDesign.Custom;
using System;
using System.Collections.Generic;

namespace NiceUIDesign.Classes.Playlists
{
    public class PlaylistsTracker : MusicTracker
    {

        private List<CustomFlowLayoutPanel> panels;
        private List<CustomPictureBox> pics;
        private List<CustomLabel> labels;



        public PlaylistsTracker()
        {
            panels = new List<CustomFlowLayoutPanel>();
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

        public override void AddPanel(CustomFlowLayoutPanel panel)
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
