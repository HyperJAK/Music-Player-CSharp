using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomPictureBox:PictureBox
    {
        public CustomPictureBox(string name, string tag)
        {
            this.Name = name;
            this.Tag = tag;
        }
    }
}
