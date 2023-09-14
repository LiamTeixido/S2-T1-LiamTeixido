using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_T1_LiamTeixido
{
    class Enemy
    {
        public int _life { get; set; }
        public int _damage { get; set; }

        public Enemy(int life, int damage) 
        {
            _life = life;
            _damage = damage;
        }

        public bool DetectIsAlive()
        {
            return _life > 0;
        }
        public virtual int DamageRecieved(int damage)
        {
            _life = damage;
            return _life;
        }

    }
}
