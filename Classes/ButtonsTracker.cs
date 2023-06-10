using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class ButtonsTracker
    {
        private List<Button> buttons;

        public ButtonsTracker() {
            buttons = new List<Button>();
        }



        public void addButton(Button button) {
            button.Click += Button_Click;
            buttons.Add(button);
        }


        public void Button_Click(object sender, EventArgs e)
        {
            Button buttonClicked = (Button)sender;

            Console.WriteLine(buttonClicked.Text);


        }

    }
}
