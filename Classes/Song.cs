using System.Collections.Generic;

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

        public int id { get; set; }
        public string name { get; set; }
        public string path { get; set; }
        public List<string> categories { get; set; }
    }
}
