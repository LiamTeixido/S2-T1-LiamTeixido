using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace S2_T1_LiamTeixido
{
    class Player
    {
        public int life;
        public int damage;

        public Player(int life, int damage)
        {
            if (life > 100 || damage > 100)

            {
                throw new ArgumentException("La vida y el daño no pueden superar 100 en total.");
            }
            this.life = life;
            this.damage = damage;
        }

        public int RecieveDamage(int damage)
        {
            life -= damage;
            return life;
        }

        public int GetLife()
        {
            return life;
        }

        public bool DetectIsAlive()
        {
            return life > 0;
        }
    }
}
