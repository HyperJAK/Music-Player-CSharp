using NiceUIDesign.Custom;
using NiceUIDesign.Resources;
using System;
using System.Collections.Generic;

namespace NiceUIDesign.Classes
{

    public class SongsTracker
    {
        private List<CustomFlowLayoutPanel> panels;
        private List<CustomPictureBox> pics;
        private List<CustomLabel> labels;

        public List<string> songPath;


        public SongsTracker()
        {
            panels = new List<CustomFlowLayoutPanel>();
            pics = new List<CustomPictureBox>();
            labels = new List<CustomLabel>();
            songPath = new List<string>();
        }



        public void AddPanel(CustomFlowLayoutPanel panel)
        {
            panel.Click += Panel_Click;
            panel.MouseHover += Panel_Hover;
            panel.MouseLeave += Panel_Hover_Exited;
            panels.Add(panel);
        }


        public void AddImage(CustomPictureBox pic)
        {
            pic.Click += Panel_Click;
            pic.MouseHover += Panel_Hover;
            pics.Add(pic);
        }


        public void AddLabel(CustomLabel label)
        {
            label.Click += Panel_Click;
            label.MouseHover += Panel_Hover;
            labels.Add(label);
        }

        /*override
        public void PlaySong(string songPath)
        {
            //To remember what was the last song played (global var)
            lastSong = songPath;

            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OutputDevice_finishedSong;

            //Create an audio file reader
            audioFileReader = new AudioFileReader(songPath);

            //Set the audio file reader as the output device's audio source
            outputDevice.Init(audioFileReader);

            //Start playing the audio file
            outputDevice.Play();

        }

        override
        public void OutputDevice_finishedSong(object sender, StoppedEventArgs e)
        {
            Console.WriteLine("Here");
            if (repeatSong)
            {
                StopSong();
                PlaySong(lastSong);
                GetOutputInfo();
            }
        }*/

        /*override
        public void StopSong()
        {
            if (outputDevice != null)
            {
                if (outputDevice.PlaybackState == PlaybackState.Playing)
                {
                    repeatSong = false;
                    outputDevice.Stop();

                }

                if (audioFileReader != null)
                {
                    audioFileReader.Dispose();
                    audioFileReader = null;
                    Console.WriteLine("Stopped code 1");
                }
                Console.WriteLine("Stopped code 2");
                outputDevice.Dispose();
                outputDevice = null;
            }


        }*/

        /* override
         public void PauseOrPlaySong()
         {
             if (songIsPaused && !songIsStopped)
             {
                 outputDevice.Play();
                 GetOutputInfo();
             }
             else if (!songIsPaused && !songIsStopped)
             {
                 outputDevice.Pause();
                 GetOutputInfo();
             }
             else if (songIsStopped && !songIsPaused)
             {
                 PlaySong(lastSong);
                 GetOutputInfo();
             }

         }*/

        /*override
        public void GetOutputInfo()
        {
            if (outputDevice != null)
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

        }*/


        public void Panel_Hover(object sender, EventArgs e)
        {
            string typeOfSender = sender.GetType().ToString();

            switch (typeOfSender)
            //All use the same listener: Panel_Click()
            {
                case "NiceUIDesign.Custom.CustomFlowLayoutPanel":
                    {
                        CustomFlowLayoutPanel panelExited = (CustomFlowLayoutPanel)sender;
                        panelExited.BackColor = Colors.navButtonsColor;
                    }
                    break;

                case "NiceUIDesign.Custom.CustomLabel":
                    {
                        CustomLabel labelClicked = (CustomLabel)sender;
                        CustomFlowLayoutPanel panelExited;

                        foreach (CustomFlowLayoutPanel p in panels)
                        {
                            if ((int)p.Tag == (int)labelClicked.Tag)
                            {
                                panelExited = p;
                                panelExited.BackColor = Colors.navButtonsColor;
                                break;
                            }

                        }


                    }
                    break;

                case "NiceUIDesign.Custom.CustomPictureBox":
                    {
                        CustomPictureBox picClicked = (CustomPictureBox)sender;
                        CustomFlowLayoutPanel panelExited;

                        foreach (CustomFlowLayoutPanel p in panels)
                        {
                            if ((int)p.Tag == (int)picClicked.Tag)
                            {
                                panelExited = p;
                                panelExited.BackColor = Colors.navButtonsColor;
                                break;
                            }

                        }

                    }
                    break;
            }

        }


        public void Panel_Hover_Exited(object sender, EventArgs e)
        {

            string typeOfSender = sender.GetType().ToString();

            switch (typeOfSender)
            //All use the same listener: Panel_Click()
            {
                case "NiceUIDesign.Custom.CustomFlowLayoutPanel":
                    {
                        CustomFlowLayoutPanel panelExited = (CustomFlowLayoutPanel)sender;
                        panelExited.BackColor = Colors.elementsPanelBackground;
                    }
                    break;

                case "NiceUIDesign.Custom.CustomLabel":
                    {
                        CustomLabel labelClicked = (CustomLabel)sender;
                        CustomFlowLayoutPanel panelExited;

                        foreach (CustomFlowLayoutPanel p in panels)
                        {
                            if ((int)p.Tag == (int)labelClicked.Tag)
                            {
                                panelExited = p;
                                panelExited.BackColor = Colors.defaultBackground;
                                break;
                            }

                        }


                    }
                    break;

                case "NiceUIDesign.Custom.CustomPictureBox":
                    {
                        CustomPictureBox picClicked = (CustomPictureBox)sender;
                        CustomFlowLayoutPanel panelExited;

                        foreach (CustomFlowLayoutPanel p in panels)
                        {
                            if ((int)p.Tag == (int)picClicked.Tag)
                            {
                                panelExited = p;
                                panelExited.BackColor = Colors.defaultBackground;
                                break;
                            }

                        }

                    }
                    break;
            }
        }



        public void Panel_Click(object sender, EventArgs e)
        {

            //Retrieves the type of the sender, meaning if user clicked on image or texet or box itself to access song
            string typeOfSender = sender.GetType().ToString();

            //Making the songControl visible
            Form1.changeSongControl_visibility(true);

            songPath.Clear();

            switch (typeOfSender)
            //All use the same listener: Panel_Click()
            {
                case "NiceUIDesign.Custom.CustomFlowLayoutPanel":
                    {
                        CustomFlowLayoutPanel panelClicked = (CustomFlowLayoutPanel)sender;
                        Console.WriteLine($"The tag that is LinkClickedEventArgs is:{(int)panelClicked.Tag}");
                        string songName = Songs.GetName((int)panelClicked.Tag);
                        songPath.Add(Songs.GetPath((int)panelClicked.Tag));


                        //updating image and text of song in the control
                        Form1.updateControlInfo(songName, null);

                        if (Player.songWasQueued)
                        {
                            Player.StopSong();
                            Player.PlaySong(songPath);
                            Player.GetOutputInfo();
                        }
                        else
                        {
                            Player.PlaySong(songPath);
                            Player.GetOutputInfo();

                        }
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomLabel":
                    {
                        CustomLabel labelClicked = (CustomLabel)sender;

                        songPath.Add(Songs.GetPath((int)labelClicked.Tag));


                        //updating image and text of song in the control
                        Form1.updateControlInfo(labelClicked.Text, null);

                        if (Player.songWasQueued)
                        {
                            Player.StopSong();
                            Player.PlaySong(songPath);
                            Player.GetOutputInfo();
                        }
                        else
                        {
                            Player.PlaySong(songPath);
                            Player.GetOutputInfo();

                        }
                        Console.WriteLine($"Song: {labelClicked.Text} was clicked");
                    }
                    break;

                case "NiceUIDesign.Custom.CustomPictureBox":
                    {
                        CustomPictureBox picClicked = (CustomPictureBox)sender;
                        string songName = Songs.GetName((int)picClicked.Tag);
                        songPath.Add(Songs.GetPath((int)picClicked.Tag));


                        //updating image and text of song in the control
                        Form1.updateControlInfo(songName, null);

                        if (Player.songWasQueued)
                        {
                            Console.WriteLine("Danger");
                            Player.StopSong();
                            Player.PlaySong(songPath);
                            Player.GetOutputInfo();
                        }
                        else
                        {
                            Console.WriteLine("not danger");
                            Player.PlaySong(songPath);
                            Player.GetOutputInfo();

                        }
                        Console.WriteLine($"Song: {songName} was clicked");
                    }
                    break;
            }

        }

    }
}
