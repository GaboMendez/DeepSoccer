using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Soccer;

namespace Soccer
{
   public class Manager
    {
        public bool again = true;
        bool Overtime = false;
        public bool Over = false;
        public int minutos = 00;
        int nextline = -1;
        public String tiempo = "1er TIEMPO";
        public List<String> Documento = new List<string>();
        Random aleatorio = new Random();
        List<Team> equipos = new List<Team>();
        int[,] campo = new int[7, 12];
        public void Quarters(string tiempo)
        {
            Documento.Add(tiempo + "\n");
            nextline++;
        }
        public void PrintOutRecord()
        {
            int i = 0;
            foreach(String line in Documento)
            {
                Console.WriteLine(i + " - " + line);
                i++;
            }
        }
        public void Save()
        {
            File.AppendAllText("Record.txt", Documento[nextline] + Environment.NewLine);
        }
        public void ProximaJugada()
        {
            nextline++;
        }
        public string UltimaMovida()
        {
            return Documento[nextline];
        }
        public void Computer(Player a)
        {
            int opcion = aleatorio.Next(1, 4);
            {
                switch (opcion)
                {
                    case 1:
                        int jugador = aleatorio.Next(0, 11);
                        Pase(a, GetTeam(a).Players[jugador]);                                    
                        break;
                    case 2:
                        Gol(a);                
                        break;
                    case 3:
                        Documento[nextline] += ("Ninguna accion importante fue tomada" + "." );
                        MoverJugadores();
                        Resetearposiciones();
                        break;
                }
            }
        }
        public String GenerarScoreboard()
        {
            string score = ( GetTeam("Francia").Score.ToString() + "-" + GetTeam("Computador").Score.ToString());
            return score;
        }
        public void CrearEquipos(string nombre1, string nombre2)
        {
            Team equipo1 = new Team(nombre1);
            equipos.Add(equipo1);
            equipo1.Players.Add(new Player(0, 11));
            equipo1.Players.Add(new Player(1, 21));
            equipo1.Players.Add(new Player(1, 22));
            equipo1.Players.Add(new Player(1, 23));
            equipo1.Players.Add(new Player(1, 24));
            equipo1.Players.Add(new Player(2, 31));
            equipo1.Players.Add(new Player(2, 32));
            equipo1.Players.Add(new Player(2, 33));
            equipo1.Players.Add(new Player(3, 41));
            equipo1.Players.Add(new Player(3, 42));
            equipo1.Players.Add(new Player(3, 43));

            Team equipo2 = new Team(nombre2);
            equipos.Add(equipo2);
            equipo2.Players.Add(new Player(0, 15));
            equipo2.Players.Add(new Player(1, 25));
            equipo2.Players.Add(new Player(1, 26));
            equipo2.Players.Add(new Player(1, 27));
            equipo2.Players.Add(new Player(1, 28));
            equipo2.Players.Add(new Player(2, 35));
            equipo2.Players.Add(new Player(2, 36));
            equipo2.Players.Add(new Player(2, 37));
            equipo2.Players.Add(new Player(3, 45));
            equipo2.Players.Add(new Player(3, 46));
            equipo2.Players.Add(new Player(3, 47));



        }
        public Team GetTeam(string nombre)
        {
            foreach (Team e in equipos)
            {
                if (e.Nombre == nombre)
                {
                    return e;
                }
            }
            return null;
        }
        public Player GetPlayer(int num)
        {
            List<Player> jugadores = new List<Player>();
            foreach (Team e in equipos)
            {
                foreach (Player p in e.Players)
                {
                    jugadores.Add(p);
                }
            }
            foreach (Player j in jugadores)
            {
                if (j.Numero == num)
                {
                    return j;
                }
            }
            return null;
        }
        public double GetDistance(Player a, Player b)
        {
            int distanciai = (a.posicion1 - b.posicion1);
            int distanciaj = (a.posicion1 - b.posicion1);
            double distancia = (distanciai * distanciai + distanciaj * distanciaj);
            distancia = Math.Sqrt(distancia);
            return distancia;
        }
        public bool Pase(Player a, Player b)
        {
            if (!VerificarBanderas(b))
            { 
                int probabilidad;
                if (GetDistance(a, b) > 3)
                {
                    probabilidad = aleatorio.Next(0, 3);
                }
                else
                {
                    probabilidad = aleatorio.Next(0, 2);

                }
                if (probabilidad == 0)
                {
                    a.HasBall = false;
                    b.HasBall = true;
                    Documento[nextline] += ("El equipo " + GetTeam(a).Nombre.ToString() +  " ha logrado un pase exitoso al jugador: " +  b.Numero.ToString() + "." );
                    MoverJugadores();
                    Resetearposiciones();
                    VerficiarFaltas();
                    return true;
                }
            }
            else
            {
                Documento[nextline] += ("Posicion adelantada(Regla #11) por parte de: " + b.Numero.ToString()+ ".");
            }
            a.HasBall = false;
            GetTeam(a).HashBall = false;
            GetotherTeam(GetTeam(a)).HashBall = true;
            int jugador = aleatorio.Next(0, 11);
            GetotherTeam(GetTeam(a)).Players[jugador].HasBall = true;
            Documento[nextline] += ("El equipo " + GetTeam(a).Nombre.ToString() + " ha realizado un pase fallido, la pelota pertenece al equipo de " + EquipoPelota().Nombre.ToString() + ".");
            MoverJugadores();
            Resetearposiciones();
            VerficiarFaltas();
            return false;
        }
        public bool VerificarBanderas(Player b)
        {
            Team one = GetTeam(b);
            Team two = GetotherTeam(one);
            if (b.posicion2 > 6)
            {   
                if(GetTeam(b).Nombre == "Computador")
                {
                    return false;
                }
                for (int i = b.posicion2; i < 12; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (campo[j, i] != 00 && campo[j, i] != GetFromMain(15).Numero)
                        {

                            if (two.Players.Contains(GetPlayer(campo[j, i]))) {
                                return false;
                            }
                        }
                    }
                }
            }
            else
            {
                if(GetTeam(b).Nombre == "Francia")
                {
                    return false;
                }
                for (int i = 0; i < b.posicion2; i++)
                {
                    for (int j = 0; j < 7; j++)
                    {
                        if (campo[j, i] != 00 && campo[j, i] != GetFromMain(11).Numero)
                        {

                            if (two.Players.Contains(GetPlayer(campo[j, i]))) {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;
        }
        public void Gameover()
        {
            Documento[nextline] += (Environment.NewLine + "El juego ha concluido, la cuenta final es: " + GenerarScoreboard().ToString());
            Save();
        }
        public void Tiempo()
        {
            
            Documento[nextline]+=("                            " + minutos.ToString("00") + ":00 \n");
            if(Overtime && minutos == 15)
            {
                Documento[nextline] = ("Se han acabado los primeros 15 minutos del tiempo extra. ");
                Quarters("2do TIEMPO EXTRA");
            }else if(Overtime && minutos >= 30){
                
                Documento[nextline] = ("Gameover" + "La cuenta final es: " + GenerarScoreboard().ToString());
                Console.ReadLine();
                Over = true;
            }
            else if(minutos==45)
            {
                Quarters("2do TIEMPO");
            }else if(minutos>=90){
                if(GetTeam("Francia").Score == GetTeam("Computador").Score)
                {
                    Documento[nextline] += " Se ha acabado el tiempo y el juego esta empatado; tiempo extra. ";
                    minutos = 0;
                    Quarters("Overtime");
                    Quarters("1er TIEMPO EXTRA");
                    Overtime = true;
                }
                else
                {
                    Over = true;
                }
            }
            
            minutos += 3;
        }
        public void ImprimirPosiciones()
        {
            
            Console.WriteLine(" _______________________________________________________________");
            Console.WriteLine("|                                                               |");
            for (int i = 0; i < 7; i++)
           {
                Console.Write("|   ");
                for (int j = 0; j < 12; j++)
                {
                    Console.Write(campo[i, j].ToString("00") + "   ");
                }
                Console.Write("|   ");

                Console.WriteLine();
            }
            Console.Write("|");
            Console.WriteLine("_______________________________________________________________|");

            Console.WriteLine();
        }
        //public void imprimirJugadores()
       //{
         //   foreach(Team e in equipos)
           // {
             //  foreach(Player p in e.Players)
               // {
                 //   Console.WriteLine(p.posicion1.ToString() + "." + p.posicion2.ToString());
                //}
            //}
        //}
        public Player CurrentBallHolder()
        {
            foreach(Team e in equipos)
            {
                if (e.HashBall)
                {
                    foreach(Player p in e.Players)
                    {
                        if (p.HasBall)
                        {
                            return p;
                        }
                    }
                }
            }
            return null;
        }
        
        public void MoverJugadores()
        {
            foreach (Team e in equipos)
            {
                foreach (Player p in e.Players)
                {
                    int movible = aleatorio.Next(0, 4);
                    int amover = aleatorio.Next(0, 3);
                    if (p.main != 11 && p.main != 15)
                    {
                        switch (movible)
                        {
                            case 0:
                                p.posicion2 += amover;
                                break;
                            case 1:
                                p.posicion2 -= amover;
                                break;
                            case 2:
                                p.posicion1 += amover;
                                break;
                            case 3:
                                p.posicion1 -= amover;
                                break;
                        }
                    }
                }
            }
        }
        public bool FueradeCancha(Player a)
        {
            if(a.posicion1>=7 || a.posicion2>= 12 || a.posicion1<0 || a.posicion2 < 0)
            {
                return true;
            }
            return false;
        }
        public void Generarposicion(Player a)
        {
            int i = aleatorio.Next(0, 7);
            int j = aleatorio.Next(0, 11);
            if (!PosicionOcupada(i, j))
            {
                a.posicion1 = i;
                a.posicion2 = j;
                return;
            }
            else
            {
                Generarposicion(a);
            }
        }
        public bool PosicionOcupada(int i, int j)
        {
            if(j==3 && (i==0 || j == 11))
            {
                return true;
            }
            foreach(Team e in equipos)
            {
                foreach(Player p in e.Players)
                {
                    if (p.posicion1 == i && p.posicion2 == j)
                        return true;
                }
            }
            return false;
        }
        public Team EquipoPelota()
        {
            foreach(Team e in equipos)
            {
                if (e.HashBall)
                {
                    return e;
                }
            }
            return null;

        }
        public bool Resetearposiciones()
        {
            bool cambio = false;
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    campo[i, j] = 00;
                }
            }
              foreach(Team e in equipos)
            {
                foreach(Player p in e.Players)
                {
                    if(p.main== 11 || p.main == 15)
                    {
                        campo[p.posicion1, p.posicion2] = p.Numero;
                    }
                    else {
                        if (!FueradeCancha(p) && !PosicionOcupada(p.posicion1, p.posicion2))
                        {
                            campo[p.posicion1, p.posicion2] = p.Numero;
                        }
                        else
                        {
                            Generarposicion(p);
                            campo[p.posicion1, p.posicion2] = p.Numero;
                            if (p.HasBall && aleatorio.Next(0, 6) == 0)
                            {
                                cambio = true;
                                e.HashBall = false;
                                p.HasBall = false;
                                int jugadorindice = aleatorio.Next(0, 11);
                                GetotherTeam(e).HashBall = true;
                                GetotherTeam(e).Players[jugadorindice].HasBall = true;
                                Documento[nextline] += ("La pelota ha salido de la cancha, ahora le pertenece al equipo: " + EquipoPelota().Nombre.ToString() + ".");
                            }
                        }
                    }
                }
            }
            if(cambio)
            {
                return true;
            }
            return false;
        }
        public bool ContainsPlayer(int numero)
        {
            if (GetTeam("Francia").Players.Contains(GetPlayer(numero)))
            {
                return true;
            }

            return false;
        }
        public Team GetTeam(Player a)
        {
            foreach(Team e in equipos)
            {
                if (e.Players.Contains(a))
                {
                    return e;
                }
            }
            return null;
        }
        public Team GetotherTeam(Team a)
        {
            foreach(Team e in equipos)
            {
                if(e.Nombre != a.Nombre)
                {
                    return e;
                }
            }
            return null;
        }
        public bool VerficiarFaltas()
        {
            bool cambio = false;
            int probabilidad = aleatorio.Next(0, 26);
            int jugador = aleatorio.Next(0, 11);
            int equipo = aleatorio.Next(0, 2);
            Player eval = equipos[equipo].Players[jugador];
            if (probabilidad >= 20)
            {
                cambio = true;
                if (probabilidad == 23 || probabilidad == 24)
                {
                    
                    eval.CantTarjetasAm++;
                    Documento[nextline] += ("El jugador numero " + eval.Numero.ToString() + " Ha recibido una tarjeta Amarilla. ");
                    GetTeam(eval).Amarillas++;
                    if(eval.CantTarjetasAm >= 2)
                    {
                        Documento[nextline] += ("El jugador numero " + eval.Numero.ToString() + " Ha excedido el numero de tarjetas amarillas permitidas y fue suplantado por el jugador numero: " + NuevoJugador(eval).Numero.ToString()+ ".");
                        
                    }
                    
                }
                else if(probabilidad == 25)
                {
                    Documento[nextline] += ("El jugador numero " + eval.Numero.ToString() + " Ha recibido una tarjeta roja. Razon por la cual fue suplantado por el jugador numero: " + NuevoJugador(eval).Numero.ToString()+ ".");
                    GetTeam(eval).Rojas++;
                }
                Team x = GetTeam(equipos[equipo].Players[jugador]);
                x.HashBall = false;
                GetotherTeam(x).HashBall = true;
                jugador = aleatorio.Next(0, 11);
                GetotherTeam(x).Players[jugador].HasBall = true;
                Documento[nextline] += (" Se ha cometido una falta. La pelota ahora esta en manos del equipo: " + EquipoPelota().Nombre.ToString() + ".");
            }
        // if(probabilidad >= 0 || probabilidad<=4)
         //   {
          //      cambio = true;
          //      Gol(eval);
          //  }
            if (cambio)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public Player NuevoJugador(Player a)
        {      
            a.Numero = aleatorio.Next(50, 99);
            return a;

        }
        public bool Gol(Player a)
        {
            if (!a.HasBall) {
                Documento[nextline] += ("Intento de gol fallido por parte del equipo: " + GetTeam(a).Nombre.ToString());
                return false;
            }
        if(a.Posicion == (Posicion)2)
            {
                if(aleatorio.Next(0,4) == 0)
                {
                    GetTeam(a).Score += 1;
                    InicializarEquipos();
                    GetTeam(a).HashBall = false;
                    GetotherTeam(GetTeam(a)).HashBall = true;
                    a.HasBall = false;
                    foreach(Player p in GetotherTeam(GetTeam(a)).Players)
                    {
                        if(p.Numero == 32 || p.Numero == 36)
                        {
                            p.HasBall = true;
                        }
                    }
                    Documento[nextline] += ("El equipo " + GetTeam(a).Nombre + " ha anotado gol, la cuenta actual es: " + GenerarScoreboard()+ "." );
                    InicializarEquipos();
                    VerficiarFaltas();
                    return true;
                }
            }else
            {
                if(aleatorio.Next(0,5) == 2)
                {
                    GetTeam(a).Score += 1;
                    InicializarEquipos();
                    GetTeam(a).HashBall = false;
                    GetotherTeam(GetTeam(a)).HashBall = true;
                    a.HasBall = false;
                    foreach (Player p in GetotherTeam(GetTeam(a)).Players)
                    {
                        if (p.Numero == 32 || p.Numero == 36)
                        {
                            p.HasBall = true;
                        }
                    }
                    Documento[nextline] += ("El equipo " + GetTeam(a).Nombre.ToString() + " ha anotado gol, la cuenta actual es: " + GenerarScoreboard() + ".");
                    MoverJugadores();
                    Resetearposiciones();
                    VerficiarFaltas();
                    return true;

                }
            }
            GetTeam(a).HashBall = false;
            GetotherTeam(GetTeam(a)).HashBall = true;
            a.HasBall = false;
            foreach (Player p in GetotherTeam(GetTeam(a)).Players)
            {
                if (p.main == 11 || p.main == 15)
                {
                    p.HasBall = true;
                }
            }
            Documento[nextline] += ("El equipo " + GetTeam(a).Nombre.ToString() + " intento y fallo meter gol, La pelota le pertenece al equipo de " + EquipoPelota().Nombre.ToString() + ".");
            MoverJugadores();
            Resetearposiciones();
            VerficiarFaltas();
            return false;
        }
        public void Crearespacio()
        {
            string espacio = "";
            Documento.Add(espacio);
        }
        public Player GetFromMain(int numero)
        {
            foreach(Team e in equipos)
            {
                foreach(Player p in e.Players)
                {
                    if(p.main == numero)
                    {
                        return p;
                    }
                }
            }
            return null;
        }
        public void InicializarEquipos()
        {
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    campo[i, j] = 00;
                }
            }
            campo[3, 0] = GetFromMain(11).Numero;
            (GetFromMain(11)).posicion1 = 3;
            (GetFromMain(11)).posicion2 = 0;
            campo[0, 1] = GetFromMain(21).Numero;
            GetFromMain(21).posicion1 = 0;
            GetFromMain(21).posicion2 = 1;
            campo[2, 1] = GetFromMain(22).Numero;
            GetFromMain(22).posicion1 = 2;
            GetFromMain(22).posicion2 = 1;
            campo[4, 1] = GetFromMain(23).Numero;
            GetFromMain(23).posicion1 = 4;
            GetFromMain(23).posicion2 = 1;
            campo[6, 1] = GetFromMain(24).Numero;
            GetFromMain(24).posicion1 = 6;
            GetFromMain(24).posicion2 = 1;
            campo[3, 2] = GetFromMain(42).Numero;
            GetFromMain(42).posicion1 = 3;
            GetFromMain(42).posicion2 = 2;
            campo[1, 3] = GetFromMain(41).Numero;
            GetFromMain(41).posicion1 = 1;
            GetFromMain(41).posicion2 = 3;
            campo[5, 3] = GetFromMain(43).Numero;
            GetFromMain(43).posicion1 = 5;
            GetFromMain(43).posicion2 = 3;
            campo[0, 4] = GetFromMain(31).Numero;
            GetFromMain(31).posicion1 = 0;
            GetFromMain(31).posicion2 = 4;
            campo[6, 4] = GetFromMain(33).Numero;
            GetFromMain(33).posicion1 = 6;
            GetFromMain(33).posicion2 = 4;
            campo[3, 5] = GetFromMain(32).Numero;
            GetFromMain(32).posicion1 = 3;
            GetFromMain(32).posicion2 = 5;
            campo[3, 6] = GetFromMain(36).Numero;
            GetFromMain(36).posicion1 = 3;
            GetFromMain(36).posicion2 = 6;
            campo[0, 7] = GetFromMain(35).Numero;
            GetFromMain(35).posicion1 = 0;
            GetFromMain(35).posicion2 = 7;
            campo[6, 7] = GetFromMain(37).Numero;
            GetFromMain(37).posicion1 = 6;
            GetFromMain(37).posicion2 = 7;
            campo[1, 8] = GetFromMain(45).Numero;
            GetFromMain(45).posicion1 = 1;
            GetFromMain(45).posicion2 = 8;
            campo[5, 8] = GetFromMain(47).Numero;
            GetFromMain(47).posicion1 = 5;
            GetFromMain(47).posicion2 = 8;
            campo[3, 9] = GetFromMain(46).Numero;
            GetFromMain(46).posicion1 = 3;
            GetFromMain(46).posicion2 = 9;
            campo[0, 10] = GetFromMain(25).Numero;
            GetFromMain(25).posicion1 = 0;
            GetFromMain(25).posicion2 = 10;
            campo[2, 10] = GetFromMain(26).Numero;
            GetFromMain(26).posicion1 = 2;
            GetFromMain(26).posicion2 = 10;
            campo[4, 10] = GetFromMain(27).Numero;
            GetFromMain(27).posicion1 = 4;
            GetFromMain(27).posicion2 = 10;
            campo[6, 10] = GetFromMain(28).Numero;
            GetFromMain(28).posicion1 = 6;
            GetFromMain(28).posicion2 = 10;
            campo[3, 11] = GetFromMain(15).Numero;
            GetFromMain(15).posicion1 = 3;
            GetFromMain(15).posicion2 = 11;
        }


    }
}
