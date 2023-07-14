using NiceUIDesign.Custom;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class EditPanel : CustomPanel
    {
        //id(tag) of last selected element
        public static int lastSelectedElement = 0;
        public static bool isPlaylist = false;


        public static CustomButton deleteItem = new CustomButton("Remove From List");

        //===================================Change this when adding more stuff in panel
        public static int nbOfElementsInPanel = 4;
        public EditPanel(int width, int height) { 
            this.Width = width;
            this.Height = height;

            deleteItem.Top = this.Top;
            deleteItem.Width = this.Width;
            deleteItem.Height = this.Height / nbOfElementsInPanel;


            this.Controls.Add(deleteItem);
        }

        
    }
}
