using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Engines
{
    static class PatternsEnemies
    {
        public static Vector2 patternPosition(int pattern)        
        {
            switch (pattern)
            {
                /// 
                /// <For Red1>
                ///
                case (1):
                    return new Vector2((Globals.GameWidth * 3) / 4, -50);
                case (2):
                    return new Vector2((Globals.GameWidth * 1) / 4, -50);
                case (3):
                    return new Vector2(0, -50);
                case (4):
                    return new Vector2((Globals.GameWidth), -50);
                /// 
                /// </For Red1>
                ///

                /// 
                /// <For Red2>
                ///
                case (5):
                    return new Vector2((Globals.GameWidth * 3) / 4, -50);
                case (6):
                    return new Vector2((Globals.GameWidth * 1) / 4, -50);
                case (7):
                    return new Vector2((Globals.GameWidth * 1) / 4, -50);
                case (8):
                    return new Vector2((Globals.GameWidth * 3) / 4, -50);
                /// 
                /// </For Red2>
                ///

                /// 
                /// <For Asteroids>
                ///
                case (9):
                    return new Vector2(50, -50);
                case (10):
                    return new Vector2((Globals.GameWidth) - 50, -50);
                case (11):
                    return new Vector2(50, -50);
                case (12):
                    return new Vector2((Globals.GameWidth) - 50, -50);
                /// 
                /// </For Asteroids>
                ///

                default:
                    return new Vector2(0, -50);
            }
        }

        public static Vector2 patternSpeed(int pattern, Vector2 position, Vector2 speed)
        {
            switch (pattern)
            {
                /// 
                /// <For Red1>
                /// 
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
                /// 
                /// </For Red1>
                /// 

                /// 
                /// <For Red2>
                /// 
                case (5):
                    return new Vector2(speed.X - (float)(Math.Cos((int)position.Y / 50) / 2), speed.Y + (float)0.1);
                case (6):
                    return new Vector2(speed.X + (float)(Math.Cos((int)position.Y / 50) / 2), speed.Y + (float)0.1); 
                case (7):
                    return new Vector2((float)(Math.Cos(Math.Abs(position.Y / 100) / 2) * Math.PI) * 2, speed.Y + (float)0.1);
                case (8):
                    return new Vector2(- (float)(Math.Cos(Math.Abs(position.Y / 100) / 2) * Math.PI) * 2, speed.Y + (float)0.1);
                /// 
                /// </For Red2>
                /// 

                /// 
                /// <For Asteroids>
                /// 
                case (9):
                    return new Vector2(speed.X + (float)0.2, speed.Y + (float)0.1);
                case (10):
                    return new Vector2(speed.X - (float)0.2, speed.Y + (float)0.1);
                case (11):
                    if (position.Y > Globals.GameHeight / 4) { return new Vector2(speed.X - (float)0.2, speed.Y + (float)0.1); }
                    else { return new Vector2(speed.X + (float)0.2, speed.Y + (float)0.1); }
                case (12):
                    if (position.Y > Globals.GameHeight / 4) { return new Vector2(speed.X + (float)0.2, speed.Y + (float)0.1); }
                    else { return new Vector2(speed.X - (float)0.2, speed.Y + (float)0.1); }
                /// 
                /// </For Asteroids>
                /// 

                default:
                    return new Vector2(speed.X + (float)0.2, speed.Y);
            }

        }
    }
}
