using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProjectLab
{

    public class Engine
    {
        Random random = new Random();

        public int RandomNumber(int min, int max)
        {
            return random.Next(min, max);
        }

        public string NewEnemyName()
        {
            var enemyTypeList = new List<string> { "zombie", "wild bear", "skeleton", "goblin" };
            int index = random.Next(enemyTypeList.Count);

            return enemyTypeList[index];
        }

        public bool AttackHit(int armorClass)
        {
            if (RandomNumber(8, 20) >= armorClass)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool EndOfEncounter(bool playerDead, string enemyName)
        {
            if (playerDead)
            {
                Console.WriteLine("{0}You stagger away from the " + enemyName + " as everything fades to black.", Environment.NewLine);
                Console.WriteLine("You have died!");

                Console.WriteLine("{0}Would you like to continue? Type yes or no.", Environment.NewLine);
                string input = Console.ReadLine().ToLower();
                if (input == "yes")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                Console.WriteLine("{0}You now stand alone in the dark hallway.", Environment.NewLine);

                Console.WriteLine("{0}Would you like to continue? Type yes or no.", Environment.NewLine);
                string input = Console.ReadLine().ToLower();
                if (input == "yes")
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
