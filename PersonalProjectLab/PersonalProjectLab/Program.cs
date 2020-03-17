using System;

namespace PersonalProjectLab
{
    class Program
    {
        static void Main(string[] args)
        {
            // Dungeons and Dragons based combat gives each combatant an armor class that represents how hard they are to hit. When attacking, the player has to roll a die to see if they can hit it
            int playerHealth = 20;
            int playerArmorClass = 15;
            int playerWeaponDamage = 3;
            // Player class with health and armor class
            // Start player with specific health and armor
            // Player health and armor can change at the end of each run
            Player Player = new Player(playerHealth, playerArmorClass, playerWeaponDamage);

            // Enemy class with health and armor class randomly decided
            Enemy Enemy1 = new Enemy(RandomNumber(10, 20), RandomNumber(12, 18));

            

            // Player class includes methods for determining attack roll and damage
            // Enemy class includes methods for armor class and health

            // If attack roll is higher than armor class attack hits
            // Damage reduces health

            // If enemy health is below 0, enemy dies
            // When enemy dies the player gets rewards
            // If the player dies they restart 

            int RandomNumber(int min, int max)
            {
                Random random = new Random();
                return random.Next(min, max);
            }
        }
    }
}