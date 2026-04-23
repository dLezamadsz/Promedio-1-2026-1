using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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

        static void Juego(Jugador j)
        {
            while (true)
            {
                Console.WriteLine("Andas perdido en una cueva y encuentras dos caminos. ¿Cuál tomas?");
                Console.WriteLine("1 - Izquierda\n2 - Derecha");
                string path = Console.ReadLine();
                switch (path)
                {
                    case "1": Enemy1(j); break;
                    case "2": Chest(j); break;
                }
            }
        }

        static void Chest(Jugador j)
        {

        }

        static void Enemy1(Jugador j)
        {
            Console.WriteLine("Vas por la izquierda y encuentras a una criatura observándote y bloqueando el paso. ¿Qué haces?");
            Console.WriteLine("1 - Atacar\n2 - Nada");
        }
    }
}
