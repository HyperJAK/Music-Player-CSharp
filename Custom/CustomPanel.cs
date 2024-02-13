using Auplay.Resources;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Auplay.Custom
{
    public class CustomPanel : Panel
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
            graphicsPath.AddArc(ClientSize.Width - cornerRadius * 2, ClientSize.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            graphicsPath.AddLine(ClientSize.Width - cornerRadius, ClientSize.Height, cornerRadius, ClientSize.Height);
            graphicsPath.AddArc(0, ClientSize.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            graphicsPath.AddLine(0, ClientSize.Height - cornerRadius, 0, cornerRadius);
            graphicsPath.CloseFigure();

            pevent.Graphics.FillPath(new SolidBrush(this.BackColor), graphicsPath);

            base.OnPaint(pevent);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Do nothing to prevent background painting
        }



        public CustomPanel(string name, int width, int height, int tag)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Name = name;
            this.BackColor = Colors.elementsPanelBackground;
            this.Size = new Size(width, height);
            this.TabIndex = 1;
            this.Tag = tag;
        }

        public CustomPanel(int width, int height)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.BackColor = Colors.elementsPanelBackground;
            this.Size = new Size(width, height);
            this.TabIndex = 1;
        }

        public CustomPanel()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
