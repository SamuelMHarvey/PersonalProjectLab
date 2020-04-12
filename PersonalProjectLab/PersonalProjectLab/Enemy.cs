using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProjectLab
{
    public class Enemy
    {
        int _enemyHealth;
        int _armorClass;
        string _enemyName;

        public Enemy(int enemyHealth, int armorClass, string enemyName)
        {
            _enemyHealth = enemyHealth;
            _armorClass = armorClass;
            _enemyName = enemyName;
        }

        public int EnemyHealth()
        {
            return _enemyHealth;
        }

        public string EnemyName()
        {
            return _enemyName;
        }

        public int EnemyArmorClass()
        {
            return _armorClass;
        }

        public int EnemyAttack()
        {
            return RandomNumber(1, 4) + 2;
        }

        private int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }

        public void EnemyTakesDamage(int damage)
        {
            _enemyHealth -= damage;
            Console.WriteLine("Your attack hits the " + _enemyName + " for " + damage + " damage.");
        }

        public bool EnemyGivesMercy()
        {
            if (_enemyName == "zombie" || _enemyName == "wild bear" || _enemyName == "skeleton")
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
