using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProjectLab
{
    class Player
    {
        int _playerHealth;
        int _armorClass;
        int _playerWeaponDamage;

        public Player(int playerHealth, int armorClass, int playerWeaponDamage)
        {
            int _playerHealth = playerHealth;
            int _armorClass = armorClass;
            int _playerWeaponDamage = playerWeaponDamage;
        }

        public int PlayerHealth()
        {
            return _playerHealth;
        }

        public int PlayerDamage()
        {
            return RandomNumber(1, 4) + _playerWeaponDamage;
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
    }
}
