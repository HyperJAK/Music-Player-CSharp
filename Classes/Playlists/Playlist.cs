using System;
using System.Collections.Generic;

namespace Auplay.Classes.Playlists
{
    public class Playlist
    {

        public List<Song> currentPlaylist_songs = new List<Song>();
        public Playlist() { }

        public Playlist(string name, string path, int id)
        {
            this.name = name;
            this.path = path;
            this.id = id;
        }
        public Playlist(string path, int id)
        {
            this.path = path;
            this.id = id;
        }

        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public string songDir { get; set; }
        public long size { get; set; }
        public DateTime creationDate { get; set; }
        public DateTime lastModifiedDate { get; set; }
        public List<string> categories { get; set; }
    }
}
