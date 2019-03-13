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
    public partial class Form1 : Form
    {
        static WindowsMediaPlayer wplayer;
        Manager manager;
        
        public Form1(Manager manager)
        {
            this.manager = manager;
            InitializeComponent();
            manager.CrearEquipos("Francia", "Computador");
            manager.InicializarEquipos();
            Player currentBallHolder;
            manager.GetTeam("Francia").HashBall = true;
            currentBallHolder = manager.GetPlayer(32);
            currentBallHolder.HasBall = true;
            manager.Quarters(manager.tiempo);
            foreach (Control  c in this.Controls)
            {
                c.Anchor = AnchorStyles.Top;
                c.Anchor = AnchorStyles.Bottom;
            }
            MessageBox.Show("Bienvenido a una nueva partida, su equipo es el Naranja. \n\n Para Realizar un pase, haga click en el jugador. \n Para anotar gol, haga click en la cancha.");
           
            this.manager = manager;
            //if (wplayer == null)
            //{
                wplayer = new WindowsMediaPlayer();
                wplayer.URL = "Geometry Dash lvl 9   Cycles.mp3";
                wplayer.controls.play();
            //}


        }
        private void Computer()
        {
            if (manager.GetTeam("Computador").HashBall)
            {
                ProxJugada();
                manager.Computer(manager.CurrentBallHolder());
                Reset();
            }

        }
        
        
        private void ResetButtons()
        {
            C35.Text = manager.GetFromMain(35).Numero.ToString();
            C45.Text = manager.GetFromMain(45).Numero.ToString();
            C25.Text = manager.GetFromMain(25).Numero.ToString();
            C26.Text = manager.GetFromMain(26).Numero.ToString();
            C27.Text = manager.GetFromMain(27).Numero.ToString();
            C28.Text = manager.GetFromMain(28).Numero.ToString();
            C36.Text = manager.GetFromMain(36).Numero.ToString();
            C15.Text = manager.GetFromMain(15).Numero.ToString();
            C37.Text = manager.GetFromMain(37).Numero.ToString();
            C47.Text = manager.GetFromMain(47).Numero.ToString();
            C46.Text = manager.GetFromMain(46).Numero.ToString();

            F31.Text = manager.GetFromMain(31).Numero.ToString();
            F41.Text = manager.GetFromMain(41).Numero.ToString();
            F21.Text = manager.GetFromMain(21).Numero.ToString();
            F22.Text = manager.GetFromMain(22).Numero.ToString();
            F23.Text = manager.GetFromMain(23).Numero.ToString();
            F24.Text = manager.GetFromMain(24).Numero.ToString();
            F11.Text = manager.GetFromMain(11).Numero.ToString();
            F32.Text = manager.GetFromMain(32).Numero.ToString();
            F33.Text = manager.GetFromMain(33).Numero.ToString();
            F43.Text = manager.GetFromMain(43).Numero.ToString();
            F42.Text = manager.GetFromMain(42).Numero.ToString();

        }
         private void Reset()
        {
            if (!manager.Over)
            {
                Am1.Text = manager.GetTeam("Francia").Amarillas.ToString();
                Am2.Text = manager.GetTeam("Computador").Amarillas.ToString();
                Score.Text = manager.GenerarScoreboard();
                Red1.Text = manager.GetTeam("Francia").Rojas.ToString();
                Red2.Text = manager.GetTeam("Computador").Rojas.ToString();
                tiempo.Text = (manager.minutos.ToString("00") + ":00");
                mover();
                ResetButtons();
                manager.Save();
                MessageBox.Show(manager.UltimaMovida());
                Computer();
            }
            else
            {
                if (wplayer != null)
                {
                    wplayer.controls.pause();
                }
                Manager Obj = new Manager();
                //Form2 Menu = new Form2(Obj);
                MessageBox.Show("GAMEOVER" + " \nF " + manager.GenerarScoreboard() + " C");
                Form4 Intertar = new Form4();
                Intertar.Visible = true;
                Visible = false;
                //Menu.Visible = true;                
                //this.Close();
            }

        }
        public void ProxJugada()
        {
            manager.ProximaJugada();
            manager.Crearespacio();
            manager.Tiempo();


        }
        private int GetY(int pos1)
        {
            switch (pos1)
            {
                case 0:
                    return 55;
                case 1:
                    return 129;
                case 2:
                    return 201;
                case 3:
                    return 276;
                case 4:
                    return 359;
                case 5:
                    return 426;
                case 6:
                    return 490;
            }
            return 0;
        }
        private int GetX(int pos2)
        {
            switch (pos2)
            {
                case 0:
                    return 79;
                case 1:
                    return 206;
                case 2:
                    return 281;
                case 3:
                    return 359;
                case 4:
                    return 429;
                case 5:
                    return 486;
                case 6:
                    return 552;
                case 7:
                    return 613;
                case 8:
                    return 676;
                case 9:
                    return 762;
                case 10:
                    return 828;
                case 11:
                    return 961;
                
            }
            return 0;
        }   
        public void mover()
        {
            C15.Location = new Point(GetX(manager.GetFromMain(15).posicion2), GetY(manager.GetFromMain(15).posicion1));
            C25.Location = new Point(GetX(manager.GetFromMain(25).posicion2), GetY(manager.GetFromMain(25).posicion1));
            C26.Location = new Point(GetX(manager.GetFromMain(26).posicion2), GetY(manager.GetFromMain(26).posicion1));
            C27.Location = new Point(GetX(manager.GetFromMain(27).posicion2), GetY(manager.GetFromMain(27).posicion1));
            C28.Location = new Point(GetX(manager.GetFromMain(28).posicion2), GetY(manager.GetFromMain(28).posicion1));
            C46.Location = new Point(GetX(manager.GetFromMain(46).posicion2), GetY(manager.GetFromMain(46).posicion1));
            C45.Location = new Point(GetX(manager.GetFromMain(45).posicion2), GetY(manager.GetFromMain(45).posicion1));
            C47.Location = new Point(GetX(manager.GetFromMain(47).posicion2), GetY(manager.GetFromMain(47).posicion1));
            C35.Location = new Point(GetX(manager.GetFromMain(35).posicion2), GetY(manager.GetFromMain(35).posicion1));
            C37.Location = new Point(GetX(manager.GetFromMain(37).posicion2), GetY(manager.GetFromMain(37).posicion1));
            C36.Location = new Point(GetX(manager.GetFromMain(36).posicion2), GetY(manager.GetFromMain(36).posicion1));

            F32.Location = new Point(GetX(manager.GetFromMain(32).posicion2), GetY(manager.GetFromMain(32).posicion1));
            F31.Location = new Point(GetX(manager.GetFromMain(31).posicion2), GetY(manager.GetFromMain(31).posicion1));
            F33.Location = new Point(GetX(manager.GetFromMain(33).posicion2), GetY(manager.GetFromMain(33).posicion1));
            F41.Location = new Point(GetX(manager.GetFromMain(41).posicion2), GetY(manager.GetFromMain(41).posicion1));
            F43.Location = new Point(GetX(manager.GetFromMain(43).posicion2), GetY(manager.GetFromMain(43).posicion1));
            F42.Location = new Point(GetX(manager.GetFromMain(42).posicion2), GetY(manager.GetFromMain(42).posicion1));
            F21.Location = new Point(GetX(manager.GetFromMain(21).posicion2), GetY(manager.GetFromMain(21).posicion1));
            F22.Location = new Point(GetX(manager.GetFromMain(22).posicion2), GetY(manager.GetFromMain(22).posicion1));
            F23.Location = new Point(GetX(manager.GetFromMain(23).posicion2), GetY(manager.GetFromMain(23).posicion1));
            F24.Location = new Point(GetX(manager.GetFromMain(24).posicion2), GetY(manager.GetFromMain(24).posicion1));
            F11.Location = new Point(GetX(manager.GetFromMain(11).posicion2), GetY(manager.GetFromMain(11).posicion1));

            ball.Location = new Point(GetX(manager.CurrentBallHolder().posicion2)+16, GetY(manager.CurrentBallHolder().posicion1)+30);

        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Gol(manager.CurrentBallHolder());
                Reset();
            }
        }
        private void label1_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void label6_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(32).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(32));
                Reset();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            string total = "";
            foreach (String s in manager.Documento)
                total += (s + "\n");
            MessageBox.Show(total);
        }

        private void F31_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(31).HasBall)&& manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(31));
                Reset();
            }
        }

        private void F33_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(33).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(33));
                Reset();
            }
        }

        private void F43_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(43).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(43));
                Reset();
            }
        }

        private void F41_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(41).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(41));
                Reset();
            }
        }

        private void F42_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(42).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(42));
                Reset();
            }
        }

        private void F22_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(22).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(22));
                Reset();
            }
        }

        private void F23_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(23).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(23));
                Reset();
            }
        }

        private void F24_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(24).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(24));
                Reset();
            }
        }

        private void F21_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;
            if (!(manager.GetFromMain(21).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(21));
                Reset();
            }
        }

        private void F11_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

            if (!(manager.GetFromMain(11).HasBall) && manager.GetTeam("Francia").HashBall)
            {
                ProxJugada();
                manager.Pase(manager.CurrentBallHolder(), manager.GetFromMain(11));
                Reset();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void ball_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C36_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C37_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C47_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C45_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C35_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C46_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C25_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C26_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C27_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C28_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

        }

        private void C15_Click(object sender, EventArgs e)
        {
            this.DoubleBuffered = true;

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
    }
}
