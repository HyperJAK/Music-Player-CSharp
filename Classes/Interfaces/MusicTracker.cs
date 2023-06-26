using NAudio.Wave;
using System;
using System.Windows.Forms;

namespace NiceUIDesign.Classes.Abstract
{
    public abstract class MusicTracker
    {

        public abstract void AddPanel(FlowLayoutPanel panel);
        public abstract void AddImage(PictureBox pic);

        public abstract void AddLabel(Label label);

        public abstract void StopSong();

        public abstract void PauseOrPlaySong();

        public abstract void PlaySong(string songPath);

        public abstract void OutputDevice_finishedSong(object sender, StoppedEventArgs e);

        public abstract void GetOutputInfo();

        public abstract void Panel_Click(object sender, EventArgs e);


    }
}
