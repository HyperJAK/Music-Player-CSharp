using NiceUIDesign.Classes.Abstract;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace NiceUIDesign.Classes.Playlists
{
    public class Playlists : FlowLayoutPanel, Music
    {

        public Playlists()
        {
            this.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.AliceBlue;
            this.Size = new Size(451, 558);
            this.TabIndex = 1;
            this.FlowDirection = FlowDirection.LeftToRight;
            this.WrapContents = true;
            this.AllowDrop = false;

        }

        public void AddElement(Song song)
        {
            throw new System.NotImplementedException();
        }

        public void CreateDicts()
        {
            throw new System.NotImplementedException();
        }

        public void GetInfo()
        {
            throw new System.NotImplementedException();
        }

        public string GetName(int id)
        {
            throw new System.NotImplementedException();
        }

        public string GetPath(int id)
        {
            throw new System.NotImplementedException();
        }

        public void ReloadSongs()
        {
            throw new System.NotImplementedException();
        }

        public void SaveInfo(List<Song> allSongs)
        {
            throw new System.NotImplementedException();
        }
    }


}
