using NAudio.Wave;
using NiceUIDesign.Custom;
using System;
using System.Windows.Forms;

namespace NiceUIDesign.Classes.Abstract
{
    public abstract class MusicTracker
    {

        public abstract void AddPanel(CustomFlowLayoutPanel panel);
        public abstract void AddImage(CustomPictureBox pic);

        public abstract void AddLabel(CustomLabel label);

        public abstract void StopSong();

        public abstract void PauseOrPlaySong();

        public abstract void PlaySong(string songPath);

        public abstract void OutputDevice_finishedSong(object sender, StoppedEventArgs e);

        public abstract void GetOutputInfo();

        public abstract void Panel_Click(object sender, EventArgs e);

        public abstract void Panel_Hover(object sender, EventArgs e);

        public abstract void Panel_Hover_Exited(object sender, EventArgs e);


    }
}
