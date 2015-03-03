using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Engines
{
    class PatternsBosses
    {
        public static Queue<Rectangle> movingPattern(int pattern)
        {
            Queue<Rectangle> movingPattern = new Queue<Rectangle>();
            switch (pattern)
            {
                case (1): // X
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.25), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.75), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.75), (int)(Globals.GameHeight * 0.25), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.75), (int)(Globals.GameHeight * 0.75), 10, 10));

                    return movingPattern;
                case (2): // Triangle
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.50), (int)(Globals.GameHeight * 0.05), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.75), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.75), (int)(Globals.GameHeight * 0.75), 10, 10));
                    return movingPattern;
                case (3): // Inverse Triangle
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.25), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.75), (int)(Globals.GameHeight * 0.75), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.50), (int)(Globals.GameHeight * 0.75), 10, 10));
                    return movingPattern;
                case (4): // Inverse Triangle
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.40), (int)(Globals.GameHeight * 0.25), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.60), (int)(Globals.GameHeight * 0.25), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.75), (int)(Globals.GameHeight * 0.40), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.75), (int)(Globals.GameHeight * 0.60), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.60), (int)(Globals.GameHeight * 0.75), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.40), (int)(Globals.GameHeight * 0.75), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.60), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.40), 10, 10));
                    return movingPattern;
                case (5): // Left and Right
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.15), (int)(Globals.GameHeight * 0.30), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.85), (int)(Globals.GameHeight * 0.30), 10, 10));
                    return movingPattern;
                case (6): // Up and Down
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.50), (int)(Globals.GameHeight * 0.15), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.50), (int)(Globals.GameHeight * 0.75), 10, 10));
                    return movingPattern;
                case (7): // Center
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.50), (int)(Globals.GameHeight * 0.50), 10, 10));
                    return movingPattern;
                default: // Inverse Triangle
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.40), (int)(Globals.GameHeight * 0.25), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.55), (int)(Globals.GameHeight * 0.25), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.70), (int)(Globals.GameHeight * 0.40), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.70), (int)(Globals.GameHeight * 0.55), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.55), (int)(Globals.GameHeight * 0.70), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.40), (int)(Globals.GameHeight * 0.70), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.55), 10, 10));
                    movingPattern.Enqueue(new Rectangle((int)(Globals.GameWidth * 0.25), (int)(Globals.GameHeight * 0.40), 10, 10));
                    return movingPattern;
            }

        }
    }
}
