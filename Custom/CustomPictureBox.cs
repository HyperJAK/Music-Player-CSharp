using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomPictureBox : PictureBox
    {
        public CustomPictureBox(string name, int tag)
        {
            this.Name = name;
            this.Tag = tag;
        }
    }
}
