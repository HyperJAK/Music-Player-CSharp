using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NiceUIDesign
{
    public partial class Form1 : Form
    {

        Classes.Songs songs = new Classes.Songs();

        public Form1()
        {
            InitializeComponent();

            /*            nav_panel.Height = dashboard_btn.Height;
                        nav_panel.Top = dashboard_btn.Top;
                        nav_panel.Left = dashboard_btn.Left;
                        dashboard_btn.BackColor = Color.FromArgb(46, 51, 73);*/
            
            right_displayer.Left = panel1.Right;
            right_displayer.Height = panel1.Height;
            right_displayer.Top = panel1.Top;
            right_displayer.BackColor = Color.White;

            right_displayer.Controls.Add(songs);


        }

        public void DisposeOfItem(object obj) {

            if(obj is Classes.Songs songs) {
               // Console.WriteLine("deleting");
                songs.Dispose();
                while (songs.Disposing)
                {
                }
            }
            /*else if ()
            {

            }
            else if ()
            {

            }*/
        }
        

        private void browseSongs_btn_Click(object sender, EventArgs e)
        {
            nav_panel.Height = browseSongs_btn.Height;
            nav_panel.Top = browseSongs_btn.Top;
            nav_panel.Left = browseSongs_btn.Left;
            browseSongs_btn.BackColor = Color.FromArgb(46,51,73);
        }

        private void browseSongs_btn_Leave(object sender, EventArgs e)
        {
            browseSongs_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void settings_btn_Click(object sender, EventArgs e)
        {
            DisposeOfItem(songs);

            nav_panel.Height = settings_btn.Height;
            nav_panel.Top = settings_btn.Top;
            nav_panel.Left = settings_btn.Left;
            settings_btn.BackColor = Color.FromArgb(46, 51, 73);
        }

        private void settings_btn_Leave(object sender, EventArgs e)
        {
            settings_btn.BackColor = Color.FromArgb(24, 30, 54);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void right_displayer_Paint(object sender, PaintEventArgs e)
        {

        }

        private void mouseDoubleClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine("Hello there");
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void addSong_btn_Click(object sender, EventArgs e)
        {

        }

        private void ResizeMainWindow(object sender, EventArgs e)
        {
            panel3.Width = songsDisplayer.Width;
        }

        private void ResizeEndMainWindow(object sender, EventArgs e)
        {
            panel3.Width = songsDisplayer.Width;

        }

        private void Form1SizeChanged(object sender, EventArgs e)
        {
            panel3.Width = songsDisplayer.Width;

        }
    }
}
