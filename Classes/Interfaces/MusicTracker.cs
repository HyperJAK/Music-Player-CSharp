using NiceUIDesign.Custom;
using System;

namespace NiceUIDesign.Classes.Abstract
{
    public abstract class MusicTracker
    {

        public abstract void AddPanel(CustomPanel panel);
        public abstract void AddImage(CustomPictureBox pic);

        public abstract void AddLabel(CustomLabel label);


        public abstract void Panel_Click(object sender, EventArgs e);

        public abstract void Panel_Hover(object sender, EventArgs e);

        public abstract void Panel_Hover_Exited(object sender, EventArgs e);


    }
}
