using NiceUIDesign.Custom;
using NiceUIDesign.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class AddSongs : Panel
    {

        private CustomPictureBox allowDrop_pic = new CustomPictureBox();
        public CustomSmoothEdgesButton browse_btn = new CustomSmoothEdgesButton("Browse");

        public AddSongs()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Colors.elementsPanelBackground;
            this.AllowDrop = true;
            this.AutoScroll = false;

            allowDrop_pic.Width = this.Width / 2;
            allowDrop_pic.Height = this.Height / 2;
            allowDrop_pic.BorderStyle = BorderStyle.None;

            browse_btn.Width = allowDrop_pic.Width / 2;
            browse_btn.Height = this.Height;

            allowDrop_pic.Dock = DockStyle.Fill;
            browse_btn.Dock = DockStyle.Bottom;

            this.Controls.Add(allowDrop_pic);
            this.Controls.Add(browse_btn);
        }
    }
}
