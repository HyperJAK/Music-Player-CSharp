using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
