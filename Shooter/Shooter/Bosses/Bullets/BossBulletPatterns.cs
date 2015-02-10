using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;


namespace Shooter.Bosses.Bullets
{
    public static class BossBulletPatterns
    {
        public static Vector2 patternSpeedStraight(int pattern, Vector2 position, Vector2 speed, int angle)
        {
            switch (pattern)
            {
                case (1):
                    if (position.Y > Globals.GameHeight / 4)
                    {
                        return new Vector2(speed.X - (float)0.2, speed.Y);
                    }
                    else
                    {
                        return new Vector2(speed.X, speed.Y + (float)0.1);
                    }
                case (2):
                    if (position.Y > Globals.GameHeight / 4)
                    {
                        return new Vector2(speed.X + (float)0.2, speed.Y);
                    }
                    else
                    {
                        return new Vector2(speed.X, speed.Y + (float)0.1);
                    }
                case (3):
                    if (position.Y > Globals.GameHeight / 4)
                    {
                        return new Vector2(speed.X - (float)0.2, speed.Y);
                    }
                    else
                    {
                        return new Vector2(speed.X + (float)0.2, speed.Y);
                    }
                case (4):
                    if (position.Y > Globals.GameHeight / 4)
                    {
                        return new Vector2(speed.X + (float)0.2, speed.Y);
                    }
                    else
                    {
                        return new Vector2(speed.X - (float)0.2, speed.Y);
                    }

                case (5):
                    return new Vector2(speed.X - (float)(Math.Cos((int)position.Y / 50) / 2), speed.Y + (float)0.1);
                case (6):
                    return new Vector2(speed.X + (float)(Math.Cos((int)position.Y / 50) / 2), speed.Y + (float)0.1);
                case (7):
                    return new Vector2((float)(Math.Cos(Math.Abs(position.Y / 100) / 2) * Math.PI) * 2, speed.Y + (float)0.1);
                case (8):
                    return new Vector2(-(float)(Math.Cos(Math.Abs(position.Y / 100) / 2) * Math.PI) * 2, speed.Y + (float)0.1);
               
                default:
                    return new Vector2(speed.X + (float)0.2, speed.Y);
            }

        }



        public static Vector2 patternSpeedHoming(int pattern, Vector2 position, Vector2 speed, Vector2 pPosition)
        {
            switch (pattern)
            {                
                default:
                    return new Vector2(speed.X + (float)0.2, speed.Y);
            }

        }

        public static Vector2 patternSpeedBlindHoming(int pattern, Vector2 position, Vector2 speed, Vector2 pPosition)
        {
            switch (pattern)
            {
                default:
                    return new Vector2(speed.X + (float)0.2, speed.Y);
            }

        }
    }
}
