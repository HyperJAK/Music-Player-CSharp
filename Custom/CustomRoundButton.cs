using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomRoundButton : Button
    {

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            this.Region = new Region(graphicsPath);
            base.OnPaint(pevent);
        }

        public CustomRoundButton(string name, int tag, int width, int height)
        {
            this.Name = name;
            this.Tag = tag;
            this.Width = width;
            this.Height = height;

        }

        public CustomRoundButton(string name, string tag, int width, int height)
        {
            this.Name = name;
            this.Tag = tag;
            this.Width = width;
            this.Height = height;

        }

        public CustomRoundButton()
        {

        }
    }
}
