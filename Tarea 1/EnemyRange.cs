using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_T1_LiamTeixido
{
    class EnemyRange : Enemy
    {
        public int bullet;
        public EnemyRange(int life, int damage, int bullet) : base(life, damage)
        {
            this.bullet = bullet;
        }

        public int GetBullet()
        {
            return bullet;
        }

        public bool Ammo()
        {
            return bullet > 0;
        }
        public void UsedBullet()
        {
            if(bullet>0)
            {
                bullet --;
            }
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
