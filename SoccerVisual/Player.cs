using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Soccer
{
    public class Player
    {
        public Posicion Posicion { get; set; }
        public bool HasBall { get; set; }
        public int CantTarjetasAm { get; set; }
        public  int Numero { get; set; }
        public int posicion1;
        public int main;
        public int posicion2;

        public Player(int posicion, int numero)
        {
            this.HasBall = false;
            this.CantTarjetasAm = 0;
            this.Posicion = (Posicion)posicion;
            this.Numero = numero;
            this.main = numero;
        }

    }
}
