using System;
using System.Collections.Generic;
using System.Threading;

namespace PersonalProjectLab
{
    public class Program
    {
        static void Main(string[] args)
        {
            Engine Engine = new Engine();

            var playerStart = NewPlayer();

            Player Player = new Player(playerStart.health, playerStart.armorClass, playerStart.weaponDamage);

            Console.WriteLine("Welcome to the game! You are playing as an adventurer exploring an abandoned house in the woods.");
            // Keep going while player is alive and wanting to play
            bool keepGoing = true;
            while (keepGoing)
            {
                Start:
                Player.FillPlayerHealth();

                Enemy Enemy = new Enemy(Engine.RandomNumber(5, 15), Engine.RandomNumber(8, 12), Engine.NewEnemyName());

                Console.WriteLine("You start to explore your surroundings.");
                Console.WriteLine("{0}You find yourself walking down a dark hallway.", Environment.NewLine);

                Thread.Sleep(1000);

                Console.WriteLine("{0}Suddenly, you see a " + Enemy.EnemyName() + " appear out of the darkness.", Environment.NewLine);

                Thread.Sleep(500);

                // Does the enemy get a surprise attack?
                if (Engine.RandomNumber(1, 20) > 15)
                {
                    Console.WriteLine("{0}The " + Enemy.EnemyName() + " surprises you and attacks!", Environment.NewLine);

                    if (Engine.AttackHit(Player.PlayerArmorClass()))
                    {
                        Player.PlayerTakesDamage(Enemy.EnemyAttack());
                    }
                    else
                    {
                        Console.WriteLine("{0}The attack barely misses!", Environment.NewLine);
                    }
                }
                else
                {
                    Console.WriteLine("It doesn't seem to notice you.");
                }

                // Keep going while enemy is alive
                while ((Enemy.EnemyHealth() > 0) & (Player.IsPlayerAlive()))
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("{0}What would you like to do?", Environment.NewLine);
                    Console.WriteLine("(Attack, run, or surrender)");

                    string response = Console.ReadLine().ToLower();

                    // Player action
                    switch (response)
                    {
                        case "attack":
                            Console.WriteLine("{0}You attack the " + Enemy.EnemyName() + ".", Environment.NewLine);

                            if (Engine.AttackHit(Player.PlayerArmorClass()))
                            {
                                Enemy.EnemyTakesDamage(Player.PlayerAttack());
                            }
                            else
                            {
                                Console.WriteLine("Your attack misses.");
                            }
                            break;

                        case "run":
                            if (Engine.RandomNumber(1, 20) >= 8)
                            {
                                Console.WriteLine("{0}You successfully run away, leaving the " + Enemy.EnemyName() + " far in the distance.", Environment.NewLine);
                                goto Start;
                            }
                            else
                            {
                                Console.WriteLine("{0}You try to run, but the " + Enemy.EnemyName() + " quickly catches up to you.", Environment.NewLine);
                            }
                            break;

                        case "surrender":
                            if (Enemy.EnemyGivesMercy())
                            {
                                Console.WriteLine("{0}The " + Enemy.EnemyName() + " decides to let you go. He walks back into the darkness.", Environment.NewLine);
                                goto Start;
                            }
                            else
                            {
                                Console.WriteLine("{0}Unfortunately, " + Enemy.EnemyName() + "s do not understand surrender.", Environment.NewLine);
                            }

                            break;

                        default:
                            Console.WriteLine("{0}That is not a valid action.", Environment.NewLine);
                            continue;
                    }

                    Thread.Sleep(1000);

                    Console.WriteLine("{0}The " + Enemy.EnemyName() + " attacks you.", Environment.NewLine);

                    if (Engine.AttackHit(Player.PlayerArmorClass()))
                    {
                        Player.PlayerTakesDamage(Enemy.EnemyAttack());
                    }
                    else
                    {
                        Console.WriteLine("The " + Enemy.EnemyName() + "'s attack misses you.");
                    }

                }


                if (Player.IsPlayerAlive() == false)
                {
                    keepGoing = Engine.EndOfEncounter(true, Enemy.EnemyName());
                }
                else
                {
                    Thread.Sleep(1000);

                    Console.WriteLine("{0}After the " + Enemy.EnemyName() + " makes its desperate final attack, it succumbs to its injuries. You have killed the " + Enemy.EnemyName() + ".", Environment.NewLine);
                    
                    keepGoing = Engine.EndOfEncounter(false, Enemy.EnemyName());
                }
            }
            
            {
                Console.WriteLine("You leave the dark hallway. Your adventure ends.");
                Console.WriteLine("Press any key to exit.");
                Environment.Exit(0);
            }

            (int health, int armorClass, int weaponDamage) NewPlayer()
            {
                int playerHealth = 15;
                int playerArmorClass = 14;
                int playerWeaponDamage = 4;

                return (playerHealth, playerArmorClass, playerWeaponDamage);
            }
            
 
        }
    }
}