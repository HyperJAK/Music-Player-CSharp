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
        public CustomRoundButton pause_btn = new CustomRoundButton("pause_btn", "pause", 50, 50);
        public CustomRoundButton next_btn = new CustomRoundButton("next_btn", "next", 40, 40);
        public CustomRoundButton prev_btn = new CustomRoundButton("prev_btn", "prev", 40, 40);
        public CustomRoundButton repeat_btn = new CustomRoundButton("repeat_btn", "repeat", 25, 25);

        public SongControl()
        {
            pause_btn.BackColor = Color.Transparent;

            prev_btn.BackColor = Color.Transparent;

            next_btn.BackColor = Color.Transparent;

            repeat_btn.BackColor = Color.Transparent;

            control_label.Text = "Just testing here";
            control_label.BackColor = Color.Transparent;
            control_label.ForeColor = Color.White;

            control_image.Size = new Size(100, 100);
            control_image.BackColor = Color.Black;

            repeat_btn.BackgroundImage = Properties.Resources.repeatBtn;
            pause_btn.BackgroundImage = Properties.Resources.pauseBtn;
            next_btn.BackgroundImage = Properties.Resources.nextBtn;
            prev_btn.BackgroundImage = Properties.Resources.prevBtn;

            repeat_btn.BackgroundImageLayout = ImageLayout.Stretch;
            repeat_btn.ImageAlign = ContentAlignment.MiddleCenter;

            pause_btn.BackgroundImageLayout = ImageLayout.Stretch;
            pause_btn.ImageAlign = ContentAlignment.MiddleCenter;

            next_btn.BackgroundImageLayout = ImageLayout.Stretch;
            next_btn.ImageAlign = ContentAlignment.MiddleCenter;

            prev_btn.BackgroundImageLayout = ImageLayout.Stretch;
            prev_btn.ImageAlign = ContentAlignment.MiddleCenter;


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
