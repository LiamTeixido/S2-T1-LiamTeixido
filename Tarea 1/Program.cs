using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_T1_LiamTeixido
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Bienvenido a Albion Online");
            Console.WriteLine("Crea tu personaje:");
            Console.WriteLine("Ingresar la vida del jugador. Solo valores entre 1 al 100");
            int playerLife = int.Parse(Console.ReadLine());

            Console.WriteLine("Ingresar el daño que hace el Jugador. Solo valores entre 1 al 100");
            int playerDamage = int.Parse(Console.ReadLine());

            Game game = new Game(1,1);
            game.Play(playerLife, playerDamage);
        }
    }
}
