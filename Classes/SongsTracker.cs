using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class SongsTracker
    {
        private List<FlowLayoutPanel> panels;
        private List<PictureBox> pics;
        private List<Label> labels;

        public SongsTracker()
        {
            panels = new List<FlowLayoutPanel>();
            pics = new List<PictureBox>();
            labels = new List<Label>();
        }



        public void addPanel(FlowLayoutPanel panel)
        {
            panel.Click += Panel_Click;
            panels.Add(panel);
        }

        public void addImage(PictureBox pic)
        {
            pic.Click += Panel_Click;
            pics.Add(pic);
        }

        public void addLabel(Label label)
        {
            label.Click += Panel_Click;
            labels.Add(label);
        }


        public void Panel_Click(object sender, EventArgs e)
        {
            //Retrieves the type of the sender, meaning if user clicked on image or texet or box itself to access song
            string typeOfSender = sender.GetType().ToString();
            switch (typeOfSender)
            //All use the same listener: Panel_Click()
            {
                case "NiceUIDesign.Custom.CustomFlowLayoutPanel":
                    {
                        FlowLayoutPanel panelClicked = (FlowLayoutPanel)sender;
                        Console.WriteLine($"The tag that is LinkClickedEventArgs is:{(int)panelClicked.Tag}");
                        string songName = Songs.getSongName((int)panelClicked.Tag);
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomLabel":
                    {
                        Label labelClicked = (Label)sender;
                        Console.WriteLine($"Song: {labelClicked.Text} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomPictureBox":
                    {
                        PictureBox picClicked = (PictureBox)sender;
                        string songName = Songs.getSongName((int)picClicked.Tag);
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;
            }

        }

    }
}
