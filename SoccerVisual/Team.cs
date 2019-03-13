using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    public class Team
    {
        public string Nombre { get; set; }
        public int Score { get; set; }
        public List<Player> Players = new List<Player>();
        public bool HashBall { get; set; }
        public int Amarillas;
        public int Rojas;

        public Team(string nombre)
        {
            this.Nombre = nombre;
            this.HashBall = false;
        }
    }
}
