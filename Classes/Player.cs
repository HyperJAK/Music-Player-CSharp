﻿using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NiceUIDesign.Classes
{
    public class Player
    {
        //Output device for playing audio
        public static WaveOutEvent outputDevice;
        public static AudioFileReader audioFileReader;

        public static List<string> lastSong = new List<string>();
        private static List<string> playlistTemp = new List<string>();

        public static bool songIsStopped = true;
        public static bool songIsPaused = false;
        public static bool songWasQueued = false;

        public static bool repeatSong = false;
        public static bool repeatPlaylist = false;
        public static bool notPlaylist = true;




        public void organiseList()
        {
            if (notPlaylist)
            {

            }
            else
            {

            }
        }
        public static void PlaySong(List<string> songPaths)
        {
            outputDevice = new WaveOutEvent();
            outputDevice.PlaybackStopped += OutputDevice_finishedSong;


            //To remember what was the last song played (global var)


            if (lastSong.Count == 0)
            {
                lastSong = songPaths;
                playlistTemp = lastSong;
            }


            //Create an audio file reader
            audioFileReader = new AudioFileReader(songPaths.First());

            //Set the audio file reader as the output device's audio source
            outputDevice.Init(audioFileReader);

            //Start playing the audio file
            outputDevice.Play();



        }

        public static void OutputDevice_finishedSong(object sender, StoppedEventArgs e)
        {
            Console.WriteLine("Here");
            if (repeatSong)
            {
                StopSong();
                PlaySong(lastSong);
                GetOutputInfo();
            }

            else if (lastSong.Count > 1)
            {
                lastSong.Remove(lastSong.First());
                StopSong();
                PlaySong(lastSong);
                GetOutputInfo();
            }
            else if (repeatPlaylist && lastSong.Count == 1 && !repeatSong)
            {
                lastSong = playlistTemp;
                StopSong();
                PlaySong(lastSong);
                GetOutputInfo();
            }


        }




        public static void StopSong()
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


        }

        public static void PauseOrPlaySong()
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

        }



        public static void GetOutputInfo()
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

        }


    }
}