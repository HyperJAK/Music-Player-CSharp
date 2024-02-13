using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Auplay.Custom
{
    public class CustomPictureBox : Panel
    {

        private const int cornerRadius = 20;
        public CustomPictureBox()
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            BackColor = Color.Transparent;

        }

        public CustomPictureBox(string name, int tag)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;
            this.Name = name;
            this.Tag = tag;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.Clear(this.Parent.BackColor);

            // Draw the rounded rectangle shape
            using (GraphicsPath graphicsPath = DrawRoundedRectangle(ClientRectangle, cornerRadius))
            {
                using (SolidBrush backgroundBrush = new SolidBrush(BackColor))
                {
                    e.Graphics.FillPath(backgroundBrush, graphicsPath);
                }

                // Draw the background image, if set
                if (BackgroundImage != null)
                {
                    e.Graphics.SetClip(graphicsPath);
                    e.Graphics.DrawImage(BackgroundImage, ClientRectangle);
                    e.Graphics.ResetClip();
                }
            }

            base.OnPaint(e);
        }

        private GraphicsPath DrawRoundedRectangle(Rectangle rectangle, int radius)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            graphicsPath.AddArc(rectangle.Left, rectangle.Top, radius * 2, radius * 2, 180, 90);
            graphicsPath.AddLine(rectangle.Left + radius, rectangle.Top, rectangle.Right - radius, rectangle.Top);
            graphicsPath.AddArc(rectangle.Right - radius * 2, rectangle.Top, radius * 2, radius * 2, 270, 90);
            graphicsPath.AddLine(rectangle.Right, rectangle.Top + radius, rectangle.Right, rectangle.Bottom - radius);
            graphicsPath.AddArc(rectangle.Right - radius * 2, rectangle.Bottom - radius * 2, radius * 2, radius * 2, 0, 90);
            graphicsPath.AddLine(rectangle.Right - radius, rectangle.Bottom, rectangle.Left + radius, rectangle.Bottom);
            graphicsPath.AddArc(rectangle.Left, rectangle.Bottom - radius * 2, radius * 2, radius * 2, 90, 90);
            graphicsPath.AddLine(rectangle.Left, rectangle.Bottom - radius, rectangle.Left, rectangle.Top + radius);
            graphicsPath.CloseFigure();

            return graphicsPath;
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            if (BackgroundImage != null)
            {
                e.Graphics.DrawImage(BackgroundImage, ClientRectangle);
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }



    }
}




/*using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Auplay.Custom
{
    public class CustomPictureBox : PictureBox
    {

        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            // Adjust the radius value to control the curvature of the corners
            int cornerRadius = 20;

            pevent.Graphics.Clear(this.Parent.BackColor);
            pevent.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            graphicsPath.StartFigure();

            // Add rounded rectangle shape to the GraphicsPath
            graphicsPath.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
            graphicsPath.AddLine(cornerRadius, 0, ClientSize.Width - cornerRadius, 0);
            graphicsPath.AddArc(ClientSize.Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
            graphicsPath.AddLine(ClientSize.Width, cornerRadius, ClientSize.Width, ClientSize.Height - cornerRadius);
            graphicsPath.AddLine(ClientSize.Width, ClientSize.Height, 0, ClientSize.Height);
            graphicsPath.AddLine(0, ClientSize.Height, 0, 0);
            graphicsPath.CloseFigure();

            pevent.Graphics.FillRegion(new SolidBrush(this.BackColor), new Region(graphicsPath));

            base.OnPaint(pevent);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Do nothing to prevent background painting
        }



        public CustomPictureBox(string name, int tag)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Name = name;
            this.Tag = tag;
        }

        public CustomPictureBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}*/

