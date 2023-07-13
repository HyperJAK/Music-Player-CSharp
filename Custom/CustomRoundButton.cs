using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomRoundButton : Button
    {

        protected override void OnPaint(PaintEventArgs pevent)
        {
            
            Graphics g = pevent.Graphics;
            g.SmoothingMode = SmoothingMode.AntiAlias;

            int radius = 100;
            int diameter = radius * 2;
            int x = (ClientSize.Width - diameter) / 2;
            int y = (ClientSize.Height - diameter) / 2;

            GraphicsPath graphicsPath = new GraphicsPath();
            graphicsPath.AddArc(x, y, diameter, diameter, 0, 180);
            graphicsPath.AddArc(x, y, diameter, diameter, 180, -180);

            g.DrawPath(Pens.Black, graphicsPath);

            using (SolidBrush backgroundBrush = new SolidBrush(BackColor))
            {
                pevent.Graphics.FillPath(backgroundBrush, graphicsPath);
            }

            base.OnPaint(pevent);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Do nothing to prevent background painting
        }


        public CustomRoundButton(string name, int tag, int width, int height)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            this.Name = name;
            this.Tag = tag;
            this.Width = width;
            this.Height = height;

            this.Image = Properties.Resources.AuPlayLogo;
            this.ImageAlign = ContentAlignment.MiddleCenter;

        }

        public CustomRoundButton(string name, string tag, int width, int height)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
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
            DoubleBuffered = true;
        }
    }
}
