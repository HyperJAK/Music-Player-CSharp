﻿using Auplay.Custom;
using Auplay.Resources;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Auplay.Classes
{

    public class SongsTracker
    {
        public static List<CustomPanel> panels;
        private List<CustomPictureBox> pics;
        private List<CustomLabel> labels;
        public static List<CustomRoundButton> playButtons;
        public List<CustomRoundButton> editButtons;
        public List<CustomCheckbox> checkBoxes;

        public List<int> listOfCheckedElements;

        public bool startedCheckingBoxes = false;

        public List<CustomPanel> elementsHoveredHistory = new List<CustomPanel>();

        public List<string> songPath;


        public SongsTracker()
        {
            panels = new List<CustomPanel>();
            pics = new List<CustomPictureBox>();
            labels = new List<CustomLabel>();
            playButtons = new List<CustomRoundButton>();
            editButtons = new List<CustomRoundButton>();
            checkBoxes = new List<CustomCheckbox>();

            listOfCheckedElements = new List<int>();

            songPath = new List<string>();
        }



        public void AddPanel(CustomPanel panel)
        {
            panel.Click += Panel_Click;
            panel.MouseEnter += Panel_Hover;
            //panel.MouseEnter += Panel_Hover_Exited;
            panels.Add(panel);
        }


        public void AddImage(CustomPictureBox pic)
        {
            pic.Click += Panel_Click;
            pic.MouseEnter += Panel_Hover;
            pics.Add(pic);
        }


        public void AddLabel(CustomLabel label)
        {
            label.Click += Panel_Click;
            label.MouseEnter += Panel_Hover;
            labels.Add(label);
        }

        public void AddPlayButton(CustomRoundButton button)
        {
            button.Click += Panel_Click;
            button.MouseEnter += Panel_Hover;
            playButtons.Add(button);
        }

        public void AddEditButton(CustomRoundButton button)
        {
            button.Click += EditElementPanel_listener;
            button.MouseEnter += Panel_Hover;
            editButtons.Add(button);
        }

        public void AddCheckBox(CustomCheckbox box)
        {
            box.Click += CheckElementPanel_listener;
            box.MouseEnter += Panel_Hover;
            checkBoxes.Add(box);
        }


        public void EditElementPanel_listener(object sender, EventArgs e)
        {
            CustomRoundButton button = (CustomRoundButton)sender;
            var idOfSelectedElement = (int)button.Tag;

            //putting panel near the clicked button
            Point cursorPosition = Cursor.Position;
            //setting position of box to cursor position
            Form1.editSongPanel.Location = Form1.editSongPanel.Parent.PointToClient(cursorPosition);
            Form1.editSongPanel.Visible = true;

            //Setting the current selected element id and type to be able to operate on it in Form1 functions
            EditPanel.lastSelectedElement = idOfSelectedElement;
            EditPanel.isPlaylist = false;
        }

        public void CheckElementPanel_listener(object sender, EventArgs e)
        {

            CustomCheckbox temp = (CustomCheckbox)sender;
            if (temp.Checked && !startedCheckingBoxes)
            {
                Console.WriteLine($"Checked state of this control is : {temp.Checked}");
                startedCheckingBoxes = true;
                Form1.songControl.Visible = false;

                listOfCheckedElements.Add((int)temp.Tag);

                //Adding the correct song to songpaths list to play it
                songPath.Add(Songs.GetPath((int)temp.Tag));

                foreach (CustomCheckbox box in checkBoxes)
                {
                    box.Visible = true;
                }

            }
            else if (!temp.Checked)
            {
                //remove element from lists of all checked elements
                listOfCheckedElements.Remove((int)temp.Tag);
                songPath.Remove(Songs.GetPath((int)temp.Tag));

            }
            else if (temp.Checked && startedCheckingBoxes)
            {
                listOfCheckedElements.Add((int)temp.Tag);

                //Adding the correct song to songpaths list to play it
                songPath.Add(Songs.GetPath((int)temp.Tag));

                //===================================This is to be linked to a specific play button
                //Player.PlaySong(songPath);
                //Player.GetOutputInfo();

            }

            if (listOfCheckedElements.Count == 0)
            {
                startedCheckingBoxes = false;
                if (Player.songIsStopped)
                {
                    Form1.songControl.Visible = false;
                }


                foreach (CustomCheckbox box in checkBoxes)
                {
                    box.Visible = false;
                    panels[0].Focus();
                }


            }
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
            if (listOfCheckedElements.Count == 0)
            {
                string typeOfSender = sender.GetType().ToString();

                switch (typeOfSender)
                //All use the same listener: Panel_Click()
                {
                    case "Auplay.Custom.CustomFlowLayoutPanel":
                        {
                            CustomPanel panelExited = (CustomPanel)sender;

                            CustomCheckbox checkBox;
                            CustomRoundButton playBtn;
                            CustomRoundButton editBtn;

                            checkBox = checkBoxes.Find(box => (int)box.Tag == (int)panelExited.Tag);
                            playBtn = playButtons.Find(btn => (int)btn.Tag == (int)panelExited.Tag);
                            editBtn = editButtons.Find(btn => (int)btn.Tag == (int)panelExited.Tag);

                            checkBox.Visible = true;
                            playBtn.Visible = true;
                            editBtn.Visible = true;

                            panelExited.BackColor = Colors.navButtonsColor;

                            if (!elementsHoveredHistory.Contains(panelExited))
                            {
                                elementsHoveredHistory.Add(panelExited);
                            }
                        }
                        break;

                    case "Auplay.Custom.CustomLabel":
                        {
                            CustomLabel labelClicked = (CustomLabel)sender;
                            CustomPanel panelExited;
                            CustomCheckbox checkBox;
                            CustomRoundButton playBtn;
                            CustomRoundButton editBtn;

                            panelExited = panels.Find(panel => (int)panel.Tag == (int)labelClicked.Tag);

                            checkBox = checkBoxes.Find(box => (int)box.Tag == (int)labelClicked.Tag);
                            playBtn = playButtons.Find(btn => (int)btn.Tag == (int)labelClicked.Tag);
                            editBtn = editButtons.Find(btn => (int)btn.Tag == (int)labelClicked.Tag);

                            checkBox.Visible = true;
                            playBtn.Visible = true;
                            editBtn.Visible = true;

                            panelExited.BackColor = Colors.navButtonsColor;

                            if (!elementsHoveredHistory.Contains(panelExited))
                            {
                                elementsHoveredHistory.Add(panelExited);
                            }

                        }
                        break;

                    case "Auplay.Custom.CustomPictureBox":
                        {
                            CustomPictureBox picClicked = (CustomPictureBox)sender;
                            CustomPanel panelExited;


                            CustomCheckbox checkBox;
                            CustomRoundButton playBtn;
                            CustomRoundButton editBtn;

                            panelExited = panels.Find(panel => (int)panel.Tag == (int)picClicked.Tag);

                            checkBox = checkBoxes.Find(box => (int)box.Tag == (int)picClicked.Tag);
                            playBtn = playButtons.Find(btn => (int)btn.Tag == (int)picClicked.Tag);
                            editBtn = editButtons.Find(btn => (int)btn.Tag == (int)picClicked.Tag);

                            checkBox.Visible = true;
                            playBtn.Visible = true;
                            editBtn.Visible = true;

                            panelExited.BackColor = Colors.navButtonsColor;

                            if (!elementsHoveredHistory.Contains(panelExited))
                            {
                                elementsHoveredHistory.Add(panelExited);
                            }

                        }
                        break;

                    case "Auplay.Custom.CustomRoundButton":
                        {
                            CustomRoundButton buttonClicked = (CustomRoundButton)sender;
                            CustomPanel panelExited;

                            panelExited = panels.Find(panel => (int)panel.Tag == (int)buttonClicked.Tag);

                            panelExited.BackColor = Colors.navButtonsColor;

                            if (!elementsHoveredHistory.Contains(panelExited))
                            {
                                elementsHoveredHistory.Add(panelExited);
                            }

                        }
                        break;
                }
            }

        }


        public void Panel_Hover_Exited(object sender, EventArgs e)
        {
            if (listOfCheckedElements.Count == 0)
            {


                string typeOfSender = sender.GetType().ToString();

                switch (typeOfSender)
                //All use the same listener: Panel_Click()
                {
                    case "Auplay.Custom.CustomFlowLayoutPanel":
                        {
                            CustomPanel panelExited = (CustomPanel)sender;
                            panelExited.BackColor = Colors.elementsPanelBackground;
                        }
                        break;

                    case "Auplay.Custom.CustomLabel":
                        {
                            CustomLabel labelClicked = (CustomLabel)sender;
                            CustomPanel panelExited;

                            panelExited = panels.Find(panel => (int)panel.Tag == (int)labelClicked.Tag);

                            panelExited.BackColor = Colors.defaultBackground;


                        }
                        break;

                    case "Auplay.Custom.CustomPictureBox":
                        {
                            CustomPictureBox picClicked = (CustomPictureBox)sender;
                            CustomPanel panelExited;

                            panelExited = panels.Find(panel => (int)panel.Tag == (int)picClicked.Tag);

                            panelExited.BackColor = Colors.defaultBackground;



                        }
                        break;
                }
            }
        }



        public void Panel_Click(object sender, EventArgs e)
        {
            if (listOfCheckedElements.Count == 0)
            {

                //Retrieves the type of the sender, meaning if user clicked on image or texet or box itself to access song
                string typeOfSender = sender.GetType().ToString();

                //Making the songControl visible
                Form1.changeSongControl_visibility(true);

                songPath.Clear();

                switch (typeOfSender)
                //All use the same listener: Panel_Click()
                {
                    case "Auplay.Custom.CustomFlowLayoutPanel":
                        {
                            CustomPanel panelClicked = (CustomPanel)sender;
                            Console.WriteLine($"The tag that is LinkClickedEventArgs is:{(int)panelClicked.Tag}");
                            string songName = Songs.GetName((int)panelClicked.Tag);
                            songPath.Add(Songs.GetPath((int)panelClicked.Tag));

                            CustomRoundButton buttonClicked = playButtons.Find(button => (int)button.Tag == (int)panelClicked.Tag);
                            //displaying pause image to indicate audio playing
                            buttonClicked.BackgroundImage = Properties.Resources.pauseBtn;

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

                    case "Auplay.Custom.CustomLabel":
                        {
                            CustomLabel labelClicked = (CustomLabel)sender;

                            songPath.Add(Songs.GetPath((int)labelClicked.Tag));

                            CustomRoundButton buttonClicked = playButtons.Find(button => (int)button.Tag == (int)labelClicked.Tag);
                            //displaying pause image to indicate audio playing
                            buttonClicked.BackgroundImage = Properties.Resources.pauseBtn;

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

                    case "Auplay.Custom.CustomPictureBox":
                        {
                            CustomPictureBox picClicked = (CustomPictureBox)sender;
                            string songName = Songs.GetName((int)picClicked.Tag);
                            songPath.Add(Songs.GetPath((int)picClicked.Tag));

                            CustomRoundButton buttonClicked = playButtons.Find(button => (int)button.Tag == (int)picClicked.Tag);
                            //displaying pause image to indicate audio playing
                            buttonClicked.BackgroundImage = Properties.Resources.pauseBtn;

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

                    case "Auplay.Custom.CustomRoundButton":
                        {
                            CustomRoundButton buttonClicked = (CustomRoundButton)sender;
                            string songName = Songs.GetName((int)buttonClicked.Tag);
                            songPath.Add(Songs.GetPath((int)buttonClicked.Tag));

                            //displaying pause image to indicate audio playing
                            buttonClicked.BackgroundImage = Properties.Resources.pauseBtn;

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
}
