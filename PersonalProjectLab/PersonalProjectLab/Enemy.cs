using System;
using System.Collections.Generic;
using System.Text;

namespace PersonalProjectLab
{
    class Enemy
    {
        int _enemyHealth;
        int _armorClass;

        public Enemy(int enemyHealth, int armorClass)
        {
            int _enemyHealth = enemyHealth;
        }

        public int EnemyHealth()
        {
            return _enemyHealth;
        }
    }
}
