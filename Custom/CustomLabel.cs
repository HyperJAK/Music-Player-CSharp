﻿using System.Drawing;
using System.Windows.Forms;

namespace Auplay.Custom
{
    public class CustomLabel : Label
    {
        public CustomLabel(string name, string text, int tag)
        {
            this.Name = name;
            this.Text = text;
            this.Tag = tag;
            this.ForeColor = Color.White;
            this.BackColor = Color.Transparent;
            this.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }

        public CustomLabel()
        {
            this.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
        }
    }
}
