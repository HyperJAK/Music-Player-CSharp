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

        public CustomRoundButton(string name, string tag)
        {
            this.Name = name;
            this.Tag = tag;

        }

        public CustomRoundButton()
        {

        }
    }
}
