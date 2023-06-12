using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class SongsTracker
    {
        private List<FlowLayoutPanel> panels;
        private List<PictureBox> pics;
        private List<Label> labels;

        public SongsTracker() {
            panels = new List<FlowLayoutPanel>();
            pics = new List<PictureBox>();
            labels = new List<Label>();
        }



        public void addPanel(FlowLayoutPanel panel) {
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
            try
            {
                FlowLayoutPanel panelClicked = (FlowLayoutPanel)sender;
                Console.WriteLine($"Song: {panelClicked.Tag} was clicked");
            }
            catch(Exception)
            {
                try
                {
                    PictureBox picClicked = (PictureBox)sender;
                    Console.WriteLine($"Song: {picClicked.Tag} was clicked");
                }
                catch (Exception)
                {
                    try
                    {
                        Label labelClicked = (Label)sender;

                        Console.WriteLine($"Song: {labelClicked.Tag} was clicked");
                    }
                    catch (Exception)
                    {

                    }
                }
            }


            


        }

        public void Image_Click(object sender, EventArgs e)
        {
            Panel_Click(sender, e);

        }

        public void Label_Click(object sender, EventArgs e)
        {

            Panel_Click(sender, e);

        }

    }
}
