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
using WMPLib;

namespace SoccerVisual
{
    public partial class Form3 : Form
    {
        WindowsMediaPlayer wplayer;
        Manager manager;
        public Form3()
        {
            InitializeComponent();
            if (wplayer == null)
            {
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "Geometry Dash Meltdown- “The Seven Seas” 100% Complete [All Coins] - GuitarHeroStyles.mp3";
                wplayer.controls.play();
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void TiTle_Click(object sender, EventArgs e)
        {
            if (wplayer != null)
            {
                wplayer.controls.pause();
            }
            Manager Obj = new Manager();
            Form2 Menu = new Form2(Obj);

            Menu.Visible = true;
            Visible = false;

        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void F32_Click(object sender, EventArgs e)
        {

        }
    }
}
