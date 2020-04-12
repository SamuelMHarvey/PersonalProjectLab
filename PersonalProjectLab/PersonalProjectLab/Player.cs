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
        string _playerName;

        public Player(int playerHealth, int armorClass, int playerWeaponDamage, string playerName)
        {
            _playerHealth = playerHealth;
            _armorClass = armorClass;
            _playerWeaponDamage = playerWeaponDamage;
            _playerName = playerName;
        }

        public int PlayerHealth()
        {
            return _playerHealth;
        }

        public int PlayerAttack()
        {
            return RandomNumber(1, 6) + _playerWeaponDamage;
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public int PlayerArmorClass()
        {
            return _armorClass;
        }

        public void PlayerTakesDamage(int damage)
        {
            _playerHealth -= damage;
            Console.WriteLine("The attack hits!");
            Console.WriteLine("You take " + damage + " damage!");
        }
    }
}
