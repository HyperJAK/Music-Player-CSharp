using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Numerics;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{

    public class SongsTracker
    {
        private List<FlowLayoutPanel> panels;
        private List<PictureBox> pics;
        private List<Label> labels;
        public static string lastSong;

        public static bool songIsStopped = true;
        public static bool songIsPaused = false;
        public static bool songWasQueued = false;
        public static bool repeatSong = false;


        //Output device for playing audio
        public static WaveOutEvent outputDevice;
        public static AudioFileReader audioFileReader;

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

        public static void playSong(string songPath)
        {
            //to remember what was the last song played (global var)
            lastSong = songPath;

            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += outputDevice_finishedSong;

            // Create an audio file reader
            audioFileReader = new AudioFileReader(songPath);

            // Set the audio file reader as the output device's audio source
            outputDevice.Init(audioFileReader);

            // Start playing the audio file
            outputDevice.Play();

        }

        private static void outputDevice_finishedSong(object sender, StoppedEventArgs e)
        {
            if (repeatSong)
            {
                Console.WriteLine("Entered");
                stopSong();
                playSong(lastSong);
            }
            else
            {
                stopSong();
            }
            
        }

        public static void stopSong()
        {
            if (outputDevice != null)
            {
                outputDevice.Stop();
                outputDevice.Dispose();
                outputDevice = null;
            }
            if (audioFileReader != null)
            {
                audioFileReader.Dispose();
                audioFileReader = null;
            }
        }

        public static void pauseOrPlaySong()
        {
            if (songIsPaused && !songIsStopped)
            {
                outputDevice.Play();
                getOutputInfo();
            }
            else if (!songIsPaused && !songIsStopped)
            {
                Console.WriteLine(songIsPaused);
                Console.WriteLine(songIsStopped);
                Console.WriteLine(songWasQueued);

                outputDevice.Pause();
                getOutputInfo();
            }
            else if (songIsStopped && songWasQueued && !songIsPaused)
            {
                playSong(lastSong);
                getOutputInfo();
            }
        }

        public static void getOutputInfo()
        {   if(outputDevice != null)
            {
                PlaybackState info = outputDevice.PlaybackState;

                switch (info)
                {
                    case PlaybackState.Stopped:
                        {
                            songIsStopped = true;
                            songWasQueued = true;
                            songIsPaused = false;
                        }
                        break;

                    case PlaybackState.Paused:
                        {
                            songIsStopped = false;
                            songWasQueued = true;
                            songIsPaused = true;
                        }
                        break;

                    case PlaybackState.Playing:
                        {
                            songIsStopped = false;
                            songWasQueued = true;
                            songIsPaused = false;
                        }
                        break;
                }
            }
            else
            {
                songIsStopped = true;
                songWasQueued = true;
                songIsPaused = false;
            }
            
        }


        public void Panel_Click(object sender, EventArgs e)
        {

            //Retrieves the type of the sender, meaning if user clicked on image or texet or box itself to access song
            string typeOfSender = sender.GetType().ToString();

            //Making the songControl visible
            Form1.changeSongControl_visibility(true);

            switch (typeOfSender)
            //All use the same listener: Panel_Click()
            {
                case "NiceUIDesign.Custom.CustomFlowLayoutPanel":
                    {
                        FlowLayoutPanel panelClicked = (FlowLayoutPanel)sender;
                        Console.WriteLine($"The tag that is LinkClickedEventArgs is:{(int)panelClicked.Tag}");
                        string songName = Songs.getSongName((int)panelClicked.Tag);
                        string songPath = Songs.getSongPath((int)panelClicked.Tag);


                        //updating image and text of song in the control
                        Form1.updateControlInfo(songName, null);

                        if (songWasQueued)
                        {
                            outputDevice.Dispose();
                            playSong(songPath);
                        }
                        else
                        {
                            playSong(songPath);
                            getOutputInfo();

                        }
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomLabel":
                    {
                        Label labelClicked = (Label)sender;

                        string songPath = Songs.getSongPath((int)labelClicked.Tag);


                        //updating image and text of song in the control
                        Form1.updateControlInfo(labelClicked.Text, null);

                        if (songWasQueued)
                        {
                            outputDevice.Dispose();
                            playSong(songPath);
                        }
                        else
                        {
                            playSong(songPath);
                            getOutputInfo();

                        }
                        Console.WriteLine($"Song: {labelClicked.Text} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomPictureBox":
                    {
                        PictureBox picClicked = (PictureBox)sender;
                        string songName = Songs.getSongName((int)picClicked.Tag);
                        string songPath = Songs.getSongPath((int)picClicked.Tag);


                        //updating image and text of song in the control
                        Form1.updateControlInfo(songName, null);

                        if (songWasQueued)
                        {
                            outputDevice.Dispose();
                            playSong(songPath);
                        }
                        else
                        {

                            playSong(songPath);
                            getOutputInfo();

                        }
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;
            }

        }

    }
}
