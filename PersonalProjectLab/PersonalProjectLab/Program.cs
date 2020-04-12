using System;
using System.Collections.Generic;
using System.Threading;

namespace PersonalProjectLab
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();

            var playerStart = NewPlayer();

            Player Player = new Player(playerStart.health, playerStart.armorClass, playerStart.weaponDamage, playerStart.playerName);

            // Keep going while player is alive
            while (Player.PlayerHealth() > 0)
            {
                Enemy Enemy = new Enemy(RandomNumber(5, 15), RandomNumber(8, 12), NewEnemyName());
                
                Console.WriteLine("You are walking down a dark hallway.{0}", Environment.NewLine);

                Console.WriteLine("Suddenly, you see a " + Enemy.EnemyName() + " appear out of the darkness.");

                // Does the enemy get a surprise attack?
                if (RandomNumber(1, 20) > 15)
                {
                    Console.WriteLine("The " + Enemy.EnemyName() + " surprises you and attacks!");

                    if (AttackHit(Player.PlayerArmorClass()))
                    {
                      Player.PlayerTakesDamage(Enemy.EnemyAttack());
                    }
                    else
                    {
                        Console.WriteLine("The attack barely misses!");
                    }
                }
                else
                {
                    Console.WriteLine("It doesn't seem to notice you.");
                }

                // Keep going while enemy is alive
                while (Enemy.EnemyHealth() > 0)
                {
                    Console.WriteLine("{0}What would you like to do?", Environment.NewLine);
                    Console.WriteLine("(Attack, run, or surrender)");

                    string response = Console.ReadLine().ToLower();

                    // Player action
                    switch (response)
                    {
                        case "attack":
                            Console.WriteLine("{0}You attack the " + Enemy.EnemyName() + ".", Environment.NewLine);

                            if (AttackHit(Player.PlayerArmorClass()))
                            {
                                Enemy.EnemyTakesDamage(Player.PlayerAttack());

                                if (Enemy.EnemyHealth() <= 0)
                                {
                                    Console.WriteLine("The " + Enemy.EnemyName() + " dies!");
                                    goto EmptyHallway;
                                }
                                
                               
                            }
                            else
                            {
                                Console.WriteLine("Your attack misses.");
                            }
                            break;

                        case "run":
                            if (RandomNumber(1, 20) >= 8)
                            {
                                Console.WriteLine("You successfully run away, leaving the " + Enemy.EnemyName() + " far in the distance.");
                                goto EmptyHallway;
                            }
                            else
                            {
                                Console.WriteLine("You try to run, but the " + Enemy.EnemyName() + " quickly catches up to you.");
                            }
                            break;

                        case "surrender":
                            if (Enemy.EnemyGivesMercy())
                            {
                                Console.WriteLine("The " + Enemy.EnemyName() + " decides to let you go. He walks back into the darkness.");
                                goto EmptyHallway;
                            }
                            else
                            {
                                Console.WriteLine("Unfortunately, " + Enemy.EnemyName() + "s do not understand surrender. The " + Enemy.EnemyName() + " charges you.");
                            }
                            
                            break;

                        default:
                            Console.WriteLine("{0}That is not a valid action.", Environment.NewLine);
                            break;
                    }



                }

            EmptyHallway:
                Console.WriteLine("You now stand alone in the dark hallway. {0}Would you like to continue? Type yes or no.", Environment.NewLine);

                string keepGoing = Console.ReadLine();
                if (keepGoing == "yes")
                {

                }
            }

            int RandomNumber(int min, int max)
            {
                return random.Next(min, max);
            }

            (int health, int armorClass, int weaponDamage, string playerName) NewPlayer()
            {
                int playerHealth = 20;
                int playerArmorClass = 15;
                int playerWeaponDamage = 4;
                string playerName = "Player";

                return (playerHealth, playerArmorClass, playerWeaponDamage, playerName);
            }
            
            string NewEnemyName()
            {
                var enemyTypeList = new List<string> { "zombie", "wild bear", "skeleton", "goblin" };
                int index = random.Next(enemyTypeList.Count);

                return enemyTypeList[index];
            }

            bool AttackHit(int armorClass)
            {
                if(RandomNumber(8, 20) >= armorClass)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}