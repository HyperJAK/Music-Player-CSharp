using NiceUIDesign.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Custom
{
    public class CustomCheckbox : CheckBox
    {
        private const int cornerRadius = 20;
        public CustomCheckbox(string name, int tag, int width, int height)
        {
            this.Name = name;
            this.Tag = tag;
            this.Width = width;
            this.Height = height;
            this.FlatStyle = FlatStyle.Standard;
            this.BackColor = Colors.invisible;
            this.AutoSize = false;
            this.Width = width;
            this.Height = height;
            this.CheckAlign = ContentAlignment.MiddleCenter;

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            DoubleBuffered = true;

        }

        

    }
}
