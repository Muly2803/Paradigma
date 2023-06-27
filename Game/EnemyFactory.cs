using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum EnemyType
    {
        Slow = 0,
        Fast = 1,
        SuperFast = 2
    }

    public static class EnemyFactory
    {
        public static Enemy CreateEnemy(EnemyType enemy, Vector2 position)
        {
            switch (enemy)
            {
                case EnemyType.Slow:
                    return new Enemy(position, new Vector2(.75f, .75f), 0, 100);
                case EnemyType.Fast:
                    return new Enemy(position, new Vector2(.9f, .9f), 0, 400);
                case EnemyType.SuperFast:
                    return new Enemy(position, new Vector2(1f, 1f), 0, 600);
            }
            return null;
        }
    }
}