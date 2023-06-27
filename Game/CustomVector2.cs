using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    
    public class CustomVector2
    {
        public float X { get; set; }
        public float Y { get; set; }

        public CustomVector2(float x, float y)
        {
            X = x;
            Y = y;
        }
        public static explicit operator Vector2(CustomVector2 customVector2)
        {
            return new Vector2(customVector2.X, customVector2.Y);
        }
    }
}
