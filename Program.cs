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
            bool c = true;
            while (c)
            {
                Console.WriteLine("Nombre del jugador:");
                string name = Console.ReadLine();
                Console.WriteLine("HP del jugador:");
                int hp = int.Parse(Console.ReadLine());
                Jugador j = new Jugador(name, 10);

                while (j.hp > 0)
                {
                    Juego(j);
                }
                if(j.hp <= 0)
                {
                    Console.WriteLine("GAME OVER: HP agotado");
                }
                Console.WriteLine("¿Volver a intentar?\n1 - Sí\n2 - No");
                string cont = Console.ReadLine();
                if(cont == "2")
                {
                    c = false;
                }
            }
        }

        public static void Juego(Jugador j)
        {
            while (true)
            {
                string ch1 = Inicio(j); //primera situación
                string ch2;
                string ch3;
                //segunda situación
                switch (ch1)
                {
                    default: break;
                    case "1": ch2 = Chest(j); break;
                    case "2": ch2 = Enemy1(j); break;
                }
                //tercera situación
                ch3 = Enemy2(j);

                //bag check
                if (ch2 == "1")
                {
                    Item bag = new Item(+4);
                    j.hp += bag.effect;
                    if (j.hp > 10)
                    {
                        j.hp = 10;
                    }
                    Console.WriteLine("Después de escapar de la cueva comes de la bolsa y recuperas salud.");
                }

                //Finales buenos
                if (ch1 == "2" && ch2 == "1")
                {
                    Console.WriteLine("¡Conseguiste el final bueno!");
                }
                else if (ch1 == "1" && ch2 == "2" && ch3 == "1")
                {
                    Console.WriteLine("¡Conseguiste el final bueno!");
                }

                //Finales malos
                else if (ch1 == "2" && ch3 == "2")
                {
                    Console.WriteLine("¡Conseguiste el final malo!");
                }
                else if (ch1 == "1" && ch2 == "1" && ch3 == "2")
                {
                    Console.WriteLine("¡Conseguiste el final malo!");
                }

                //Finales neutros
                else
                {
                    Console.WriteLine("¡Conseguiste el final neutro!");
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
            switch (item)
            {
                default: break;
                case "1": Console.WriteLine("Tomas la bolsa y sigues tu camino."); break;
                case "2":
                    Item fruta = new Item(-5);
                    j.hp -= fruta.effect;
                    Console.WriteLine("Tomas la fruta y le das una mordida, olvidando que había estado guardada durante tanto tiempo."); break;
                case "3": Console.WriteLine("Dejas el cofre intacto y sigues tu camino."); break;
            }
            return item;
        }

        static string Enemy1(Jugador j)
        {
            Console.WriteLine("Vas por la izquierda y encuentras a una criatura observándote y bloqueando el paso. ¿Qué haces?");
            Console.WriteLine("1 - Atacar\n2 - Nada");
            string action = Console.ReadLine();
            switch (action)
            {
                default: break;
                case "1":
                    Enemigo e1 = new Enemigo(4);
                    j.hp -= e1.dmg;
                    Console.WriteLine("La criatura se asusta y devuelve el ataque."); break;
                case "2": Console.WriteLine("Al ver que no haces nada, la criatura se aburre y sigue su camino."); break;
            }
            return action;
        }

        static string Enemy2(Jugador j)
        {
            Console.WriteLine("Sigues y encuentras a una criatura más grande y feroz. ¿Qué haces?");
            Console.WriteLine("1 - Atacar\n2 - Huir");
            string action = Console.ReadLine();
            switch (action)
            {
                default: break;
                case "1": Console.WriteLine("Atacas a la criatura y la derrotas, esta te deja en paz."); break;
                case "2":
                    Enemigo boss = new Enemigo(7);
                    j.hp -= boss.dmg;
                    Console.WriteLine("Intentas huir, pero la criatura te alcanza y ataca antes de irse."); break;
            }
            return action;
        }
    }
}
