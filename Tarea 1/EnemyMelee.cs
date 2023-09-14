using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_T1_LiamTeixido
{
    class EnemyMelee : Enemy
    {
        public int shield;
        public EnemyMelee(int life, int damage, int shield) : base(life, damage)
        {
            this.shield = shield;
        }

        public int GetShield()
        {
            return shield;
        }
        public int DamageForPlayer(int damagePlayer)
        {
            int damageResult = damagePlayer - shield;
            _life -= damageResult;
            return _life;
        }

        public int Get_life()
        {
            return _life;
        }

        public int Get_damage()
        {
            return _damage;
        }
    }
}
