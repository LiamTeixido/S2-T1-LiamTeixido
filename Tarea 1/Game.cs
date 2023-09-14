using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_T1_LiamTeixido
{
    internal class Game
    {
        private List<Enemy> enemies;
        private Player player;

        public Game(int numEnemiesMelee, int numEnemiesRange)
        {
            
            enemies = new List<Enemy>(); // Contiene enemigos del juego

            // Bloque de enemigos melee
            for (int i = 0; i < numEnemiesMelee; i++)
            {
                enemies.Add(new EnemyMelee(50, 10, 10)); // Vida, Daño, Armadura
            }

            // Bloque de enemigos melee
            for (int i = 0; i < numEnemiesRange; i++)
            {
                enemies.Add(new EnemyRange(30, 10, 5)); // Vida, Daño, Balas
            }
        }

        public void Play(int playerLife, int playerDamage)
        {
            player = new Player(playerLife, playerDamage);
            int playerIndex = 0;
            bool playerTurn = true; // Empieza turno del Jugador

            // Mientras el player siga vivo y su indice sea menor al contador de enemigos podrá realizar acciones
            while (player.DetectIsAlive() && playerIndex < enemies.Count)
            {
                if (playerTurn) // Turno del player
                {
                    Console.WriteLine("Es el turno del jugador.");
                    Console.WriteLine($"Vida del jugador: {player.GetLife()}");
                    Console.WriteLine($"Daño del jugador: {playerDamage}");
                    Console.WriteLine("Elige un enemigo para atacar (1. Melee, 2. Range):");
                    int enemyChoice = int.Parse(Console.ReadLine());

                    // Contador de enemigos es mayor a 0 podrán realizar acciones
                    if (enemies.Count > 0)
                    {
                        if (enemyChoice == 1 && enemies.Any(e => e is EnemyMelee)) // La op 1 es Enemigo de tipo Melee
                        {
                            // busca el primer enemigo en la lista enemies que sea de tipo EnemyMelee
                            EnemyMelee currentEnemy = enemies.FirstOrDefault(e => e is EnemyMelee) as EnemyMelee;
                            if (currentEnemy != null)
                            {
                                Console.WriteLine($"Atacando al enemigo melee.");
                                currentEnemy.DamageForPlayer(playerDamage);


                                if (!currentEnemy.DetectIsAlive())
                                {
                                    Console.WriteLine($"El enemigo ({currentEnemy.GetType().Name}) ha sido derrotado.");
                                    enemies.Remove(currentEnemy);
                                }
                            }
                        }
                        else if (enemyChoice == 2 && enemies.Any(e => e is EnemyRange)) // La op 2 es Enemigo de tipo Rango
                        {
                            EnemyRange currentEnemy = enemies.FirstOrDefault(e => e is EnemyRange) as EnemyRange;
                            if (currentEnemy != null)
                            {
                                if (currentEnemy.Ammo())
                                {
                                    Console.WriteLine($"Atacando al enemigo de rango.");
                                    currentEnemy.DamageRecieved(playerDamage);

                                    if (!currentEnemy.DetectIsAlive())
                                    {
                                        Console.WriteLine($"El enemigo ({currentEnemy.GetType().Name}) ha sido derrotado.");
                                        enemies.Remove(currentEnemy);
                                    }

                                    currentEnemy.UsedBullet();
                                }
                                else
                                {
                                    currentEnemy.DamageRecieved(playerDamage);
                                    Console.WriteLine("El enemigo de rango se quedó sin balas y debe pasar de turno.");
                                    if (!currentEnemy.DetectIsAlive())
                                    {
                                        Console.WriteLine($"El enemigo ({currentEnemy.GetType().Name}) ha sido derrotado.");
                                        enemies.Remove(currentEnemy);
                                    }
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("Elección de enemigo no válida. Intente de nuevo");
                        }
                        if (enemies.Count <= 0)
                        {
                            Console.WriteLine("No quedan enemigos para atacar.");
                            Console.WriteLine("¡Ganaste!");
                        }
                    }
                    playerTurn = false; // Se acabó turno del player
                }
                else
                {
                    Console.WriteLine("Es el turno de los enemigos.");
                    foreach (Enemy enemy in enemies.ToList())
                    {
                        if (enemy.DetectIsAlive())
                        {
                            Console.WriteLine($"El enemigo ({enemy.GetType().Name}) tiene {enemy._life} de vida, {enemy._damage} de daño.");

                            if (enemy is EnemyMelee)
                            {
                                EnemyMelee currentEnemy = (EnemyMelee)enemy;
                                Console.WriteLine($"Armadura del enemigo melee: {currentEnemy.GetShield()}");

                                int damageToPlayer = Math.Max(0, playerDamage - currentEnemy.GetShield());
                                Console.WriteLine($"El enemigo melee ataca al jugador con {enemy._damage} de daño.");
                                player.RecieveDamage(enemy._damage);
                            }
                            else if (enemy is EnemyRange)
                            {
                                EnemyRange currentEnemy = (EnemyRange)enemy;
                                Console.WriteLine($"Balas del enemigo de rango: {currentEnemy.GetBullet()}");

                                if (currentEnemy.Ammo())
                                {
                                    int damageToPlayer = Math.Max(0, playerDamage);
                                    Console.WriteLine($"El enemigo rango ataca al jugador con {enemy._damage} de daño.");
                                    player.RecieveDamage(enemy._damage);

                                    if (!currentEnemy.DetectIsAlive())
                                    {
                                        enemies.Remove(currentEnemy);
                                    }

                                    currentEnemy.UsedBullet();
                                }
                                else
                                {
                                    Console.WriteLine("El enemigo de rango se quedó sin munición. Por ende, pasa su turno.");
                                }
                            }
                        }

                    }

                    playerTurn = true; // Turno del player
                }
            }

        }
    }

}
