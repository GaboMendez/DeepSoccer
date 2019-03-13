using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Soccer;
using System.Media;
using WMPLib;

namespace SoccerVisual
{
    public partial class Form2 : Form
    {
        WindowsMediaPlayer wplayer;
        Manager manager;
        public Form2(Manager manager)
        {

            InitializeComponent();
            this.manager = manager;

            if (wplayer == null)
            {
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "Geometry Dash - Level 6-Can't Let Go (All Coins).mp3";
                wplayer.controls.play();
            }


        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (wplayer != null)
            {
                wplayer.controls.pause();
            }

            Form1 formita = new Form1( new Manager());
            formita.Visible = true;
            Visible = false;
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }

        private void TiTle_Click(object sender, EventArgs e)
        {
            
               
            
            
           
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (wplayer != null)
            {
                wplayer.controls.pause();
            }
            Form3 Help = new Form3();
            Help.Visible = true;
            Visible = false;
            //Help.Show();
            /*
            wplayer = new WindowsMediaPlayer();
            wplayer.URL = "Geometry Dash Meltdown- “The Seven Seas” 100% Complete [All Coins] - GuitarHeroStyles.mp3";
            wplayer.controls.play();*/

            
        }
    }
}
