using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static public class Class1
    {
        
        static public Vector2 RandomPosition(CustomVector2 minPosition, CustomVector2 maxPosition)
        {
            System.Random random = new System.Random();
            float randomX = (float)random.NextDouble() * (maxPosition.X - minPosition.X) + minPosition.X;
            float randomY = (float)random.NextDouble() * (maxPosition.Y - minPosition.Y) + minPosition.Y;
            return new Vector2(randomX, randomY);

        }
       
    }
}
