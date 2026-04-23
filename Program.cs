using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Promedio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Nombre del jugador:");
            string name = Console.ReadLine();
            Console.WriteLine("HP del jugador:");
            int hp = int.Parse(Console.ReadLine());

            Jugador j = new Jugador(name,20);
            Juego(j);
        }

        public static void Juego(Jugador j)
        {
            while (true)
            {
                List<string> choices = new List<string>();
                string ch1 = Inicio(j);
                string ch2;
                string ch3;
                choices.Add(ch1);
                switch (ch1)
                {
                    default: break;
                    case "1": ch2 = Chest(j); choices.Add(ch2); break;
                    case "2": ch2 = Enemy1(j); choices.Add(ch2); break;
                }
                ch3 = Enemy2(j);
                choices.Add(ch3);

                for(int i=0; i<choices.Count; i++)
                {
                    
                }
            }
        }

        static string Inicio(Jugador j)
        {
            Console.WriteLine("Andas perdido en una cueva y encuentras dos caminos. ¿Cuál tomas?");
            Console.WriteLine("1 - Izquierda\n2 - Derecha");
            string path = Console.ReadLine();
            return path;
        }

        static string Chest(Jugador j)
        {
            Console.WriteLine("Vas por la derecha y encuentras un cofre con dos items: una bolsa de snacks y una fruta. ¿Cuál tomas?");
            Console.WriteLine("1 - Bolsa\n2 - Fruta\n3 - Nada");
            string item = Console.ReadLine();
            return item;
        }

        static string Enemy1(Jugador j)
        {
            Console.WriteLine("Vas por la izquierda y encuentras a una criatura observándote y bloqueando el paso. ¿Qué haces?");
            Console.WriteLine("1 - Atacar\n2 - Nada");
            string action = Console.ReadLine();
            return action;
        }

        static string Enemy2(Jugador j)
        {
            Console.WriteLine("Sigues y encuentras a una criatura más grande y feroz. ¿Qué haces?");
            Console.WriteLine("1 - Atacar\n2 - Huir");
            string action = Console.ReadLine();
            return action;
        }
    }
}
