using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomLabel:Label
    {
        public CustomLabel(string name, string text, int tag)
        {
            this.Name = name;
            this.Text = text;
            this.Tag = tag;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

        }
    }
}
