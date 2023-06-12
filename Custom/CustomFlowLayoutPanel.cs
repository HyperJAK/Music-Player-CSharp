using System.Drawing;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomFlowLayoutPanel : FlowLayoutPanel
    {
        public CustomFlowLayoutPanel(string name, int width, int height, FlowDirection direct, int tag)
        {
            this.Name = name;
            this.BackColor = Color.Red;
            this.Size = new Size(width, height);
            this.TabIndex = 1;
            this.FlowDirection = direct;
            this.WrapContents = true;
            this.Tag = tag;
        }
    }
}
