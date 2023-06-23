using System.Collections.Generic;
using System;

namespace NiceUIDesign.Classes
{
    public class Song
    {

        public Song() { }

        public Song(string name, string path, int id)
        {
            this.name = name;
            this.path = path;
            this.id = id;
        }
        public Song(string path, int id)
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
