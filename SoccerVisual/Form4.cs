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
namespace SoccerVisual
{
    public partial class Form4 : Form
    {
        Manager Obj = new Manager();
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 Repetir = new Form1(Obj);
            Repetir.Visible = true;
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 Menu = new Form2(Obj);
            Menu.Visible = true;
            Visible = false;

        }
    }
}
