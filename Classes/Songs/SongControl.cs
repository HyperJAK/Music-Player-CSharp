using NiceUIDesign.Custom;
using NiceUIDesign.Resources;
using System.Drawing;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class SongControl : Panel
    {
        public bool pauseClicked = false;
        public CustomLabel control_label = new CustomLabel();
        public CustomPictureBox control_image = new CustomPictureBox();
        public CustomRoundButton pause_btn = new CustomRoundButton("pause_btn", "pause");
        public CustomRoundButton next_btn = new CustomRoundButton("next_btn", "next");
        public CustomRoundButton prev_btn = new CustomRoundButton("prev_btn", "prev");
        public CustomRoundButton repeat_btn = new CustomRoundButton("repeat_btn", "repeat");

        public SongControl()
        {
            pause_btn.Size = new Size(50, 50);
            pause_btn.BackColor = Color.Transparent;

            prev_btn.Size = new Size(40, 40);
            prev_btn.BackColor = Color.Transparent;

            next_btn.Size = new Size(40, 40);
            next_btn.BackColor = Color.Transparent;

            repeat_btn.Size = new Size(25, 25);
            repeat_btn.BackColor = Color.Transparent;

            control_label.Text = "Just testing here";
            control_label.BackColor = Color.Transparent;
            control_label.ForeColor = Color.White;

            control_image.Size = new Size(100, 100);
            control_image.BackColor = Color.Black;


            this.BackColor = Colors.defaultBackground;
            this.Controls.Add(control_label);
            this.Controls.Add(control_image);
            this.Controls.Add(pause_btn);
            this.Controls.Add(next_btn);
            this.Controls.Add(prev_btn);
            this.Controls.Add(repeat_btn);


        }


    }
}
