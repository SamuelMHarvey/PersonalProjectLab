using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProjectLab
{
    public class Player
    {
        int _playerHealth;
        int _maxPlayerHealth;
        int _armorClass;
        int _playerWeaponDamage;
        bool _isPlayerAlive = true;

        public Player(int playerHealth, int armorClass, int playerWeaponDamage)
        {
            _maxPlayerHealth = playerHealth;
            _playerHealth = playerHealth;
            _armorClass = armorClass;
            _playerWeaponDamage = playerWeaponDamage;
        }

        public int PlayerHealth()
        {
            return _playerHealth;
        }

        public void FillPlayerHealth()
        {
            _playerHealth = _maxPlayerHealth;
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
            Console.WriteLine("The attack hits for " + damage + " damage.");

            if (_playerHealth <= 0)
            {
                _isPlayerAlive = false;
            }
        }

        public bool IsPlayerAlive()
        {
            return _isPlayerAlive;
        }
    }
}
