using System.Collections.Generic;

namespace NiceUIDesign.Classes.Abstract
{
    public interface Music
    {
        void ReloadSongs();

        //string GetName(int id);

        //string GetPath(int id);

        void CreateDicts();

        void AddElement(Song song);

        void SaveInfo(List<Song> allSongs);

        void GetInfo();


    }
}
