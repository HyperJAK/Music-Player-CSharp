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
            pevent.Graphics.Clear(this.Parent.BackColor);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphicsPath.StartFigure();
            graphicsPath.AddEllipse(0, 0, ClientSize.Width, ClientSize.Height);
            graphicsPath.CloseFigure();

            //this.Region = new Region(graphicsPath);
            pevent.Graphics.FillRegion(new SolidBrush(this.BackColor), new Region(graphicsPath));
            base.OnPaint(pevent);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Do nothing to prevent background painting
        }


        public CustomRoundButton(string name, int tag, int width, int height)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Name = name;
            this.Tag = tag;
            this.Width = width;
            this.Height = height;

        }

        public CustomRoundButton(string name, string tag, int width, int height)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Name = name;
            this.Tag = tag;
            this.Width = width;
            this.Height = height;
            this.Image = Properties.Resources.AuPlayLogo;
            this.ImageAlign = ContentAlignment.MiddleCenter;

        }

        public CustomRoundButton()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
