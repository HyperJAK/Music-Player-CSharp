using NiceUIDesign.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomCheckbox : CheckBox
    {

        public CustomCheckbox(string name, int tag, int width, int height)
        {
            this.Name = name;
            this.Tag = tag;
            this.Width = width;
            this.Height = height;
            this.FlatStyle = FlatStyle.Standard;
            this.BackColor = Colors.invisible;

        }


    }
}
