using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Auplay.Custom
{
    public class CustomSmoothEdgesButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            GraphicsPath graphicsPath = new GraphicsPath();

            // Adjust the radius value to control the curvature of the corners
            int cornerRadius = 15;

            // Add rounded rectangle shape to the GraphicsPath
            graphicsPath.AddArc(0, 0, cornerRadius * 2, cornerRadius * 2, 180, 90);
            graphicsPath.AddLine(cornerRadius, 0, ClientSize.Width - cornerRadius, 0);
            graphicsPath.AddArc(ClientSize.Width - cornerRadius * 2, 0, cornerRadius * 2, cornerRadius * 2, 270, 90);
            graphicsPath.AddLine(ClientSize.Width, cornerRadius, ClientSize.Width, ClientSize.Height - cornerRadius);
            graphicsPath.AddArc(ClientSize.Width - cornerRadius * 2, ClientSize.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 0, 90);
            graphicsPath.AddLine(ClientSize.Width - cornerRadius, ClientSize.Height, cornerRadius, ClientSize.Height);
            graphicsPath.AddArc(0, ClientSize.Height - cornerRadius * 2, cornerRadius * 2, cornerRadius * 2, 90, 90);
            graphicsPath.AddLine(0, ClientSize.Height - cornerRadius, 0, cornerRadius);

            this.Region = new Region(graphicsPath);
            base.OnPaint(pevent);
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            // Do nothing to prevent background painting
        }


        public CustomSmoothEdgesButton(string text)
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            this.Text = text;
            this.ForeColor = Color.White;
            this.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

        }

        public CustomSmoothEdgesButton()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
        }
    }
}
