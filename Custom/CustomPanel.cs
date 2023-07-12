using NiceUIDesign.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomPanel : Panel
    {
        public CustomPanel(string name, int width, int height, int tag)
        {
            this.Name = name;
            this.BackColor = Colors.elementsPanelBackground;
            this.Size = new Size(width, height);
            this.TabIndex = 1;
            this.Tag = tag;
        }

        public CustomPanel()
        {

        }
    }
}
