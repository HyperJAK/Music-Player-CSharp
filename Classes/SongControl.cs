﻿using NiceUIDesign.Custom;
using System;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace NiceUIDesign.Classes
{
    public class SongControl : Panel
    {
        public bool pauseClicked = false;
        public CustomLabel control_label = new CustomLabel();
        public CustomPictureBox control_image = new CustomPictureBox();
        public CustomButton pause_btn = new CustomButton("pause_btn", "pause");
        public CustomButton next_btn = new CustomButton("next_btn", "next");
        public CustomButton prev_btn = new CustomButton("prev_btn", "prev");
        public CustomButton repeat_btn = new CustomButton("repeat_btn", "repeat");

        public SongControl()
        {
            pause_btn.Size = new Size(50, 50);
            pause_btn.BackColor = Color.Blue;

            prev_btn.Size = new Size(40, 40);
            prev_btn.BackColor = Color.Blue;

            next_btn.Size = new Size(40, 40);
            next_btn.BackColor = Color.Blue;

            repeat_btn.Size = new Size(25, 25);
            repeat_btn.BackColor = Color.Blue;

            control_label.Text = "Just testing here";
            control_label.BackColor = Color.Blue;

            control_image.Size = new Size (100, 100);
            control_image.BackColor = Color.Blue;


            this.BackColor = Color.Red;
            this.Controls.Add(control_label);
            this.Controls.Add(control_image);
            this.Controls.Add(pause_btn);
            this.Controls.Add(next_btn);
            this.Controls.Add(prev_btn);
            this.Controls.Add(repeat_btn);


        }

        
    }
}
