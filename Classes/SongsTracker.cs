using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NAudio.Wave;

namespace NiceUIDesign.Classes
{

    public class SongsTracker
    {
        private List<FlowLayoutPanel> panels;
        private List<PictureBox> pics;
        private List<Label> labels;

        public bool songIsStopped = true;
        public bool songIsPaused = false;


        //Output device for playing audio
        public static WaveOutEvent outputDevice = new WaveOutEvent();

        public SongsTracker()
        {
            panels = new List<FlowLayoutPanel>();
            pics = new List<PictureBox>();
            labels = new List<Label>();
        }



        public void addPanel(FlowLayoutPanel panel)
        {
            panel.Click += Panel_Click;
            panels.Add(panel);
        }

        public void addImage(PictureBox pic)
        {
            pic.Click += Panel_Click;
            pics.Add(pic);
        }

        public void addLabel(Label label)
        {
            label.Click += Panel_Click;
            labels.Add(label);
        }

        private static void playSong(string songPath)
        {
            // Create an audio file reader
            AudioFileReader audioFileReader = new AudioFileReader(songPath);

            // Set the audio file reader as the output device's audio source
            outputDevice.Init(audioFileReader);

            // Start playing the audio file
            outputDevice.Play();

        }

        private void getOutputInfo()
        {
            PlaybackState info = outputDevice.PlaybackState;

            switch(info)
            {
                case PlaybackState.Stopped:
                    {
                        songIsStopped = true;
                        songIsPaused = false;
                    }
                    break;

                case PlaybackState.Paused:
                    {
                        songIsStopped = false;
                        songIsPaused = true;
                    }
                    break;

                case PlaybackState.Playing:
                    {
                        songIsStopped = false;
                        songIsPaused = false;
                    }
                    break;
            }
        }


        public void Panel_Click(object sender, EventArgs e)
        {
            //Gets the state of the song
            getOutputInfo();

            //Retrieves the type of the sender, meaning if user clicked on image or texet or box itself to access song
            string typeOfSender = sender.GetType().ToString();
            switch (typeOfSender)
            //All use the same listener: Panel_Click()
            {
                case "NiceUIDesign.Custom.CustomFlowLayoutPanel":
                    {
                        FlowLayoutPanel panelClicked = (FlowLayoutPanel)sender;
                        Console.WriteLine($"The tag that is LinkClickedEventArgs is:{(int)panelClicked.Tag}");
                        string songName = Songs.getSongName((int)panelClicked.Tag);
                        string songPath = Songs.getSongPath((int)panelClicked.Tag);

                        if (!songIsStopped)
                        {
                            outputDevice.Dispose();
                            playSong(songPath);
                        }
                        else
                        {
                            playSong(songPath);
                            songIsStopped = false;
                        }
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomLabel":
                    {
                        Label labelClicked = (Label)sender;

                        string songPath = Songs.getSongPath((int)labelClicked.Tag);

                        if (!songIsStopped)
                        {
                            outputDevice.Dispose();
                            playSong(songPath);
                        }
                        else
                        {
                            playSong(songPath);
                            songIsStopped = false;
                        }
                        Console.WriteLine($"Song: {labelClicked.Text} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomPictureBox":
                    {
                        PictureBox picClicked = (PictureBox)sender;
                        string songName = Songs.getSongName((int)picClicked.Tag);
                        string songPath = Songs.getSongPath((int)picClicked.Tag);

                        if (!songIsStopped)
                        {
                            outputDevice.Dispose();
                            playSong(songPath);
                        }
                        else
                        {
                            playSong(songPath);
                            songIsStopped = false;
                        }
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;
            }

        }

    }
}
