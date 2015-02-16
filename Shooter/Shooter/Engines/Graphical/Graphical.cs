using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Engines.Graphical
{
    public static class Graphical
    {
        // Methods to Recieve an Angle
        // Between two points
        public static double AngleBetween(Vector2 vector1, Vector2 vector2)
        {
            float angle = (float)Math.Atan2(vector2.Y - vector1.Y, vector2.X - vector1.X);
            return MathHelper.ToDegrees(angle);
        }

        //Overload
        public static double AngleBetween(Rectangle vector1, Rectangle vector2)
        {
            return AngleBetween(new Vector2(vector1.X, vector1.Y), new Vector2(vector2.X, vector2.Y));
        }

        //Overload
        public static double AngleBetween(Vector2 vector1, Rectangle vector2)
        {
            return AngleBetween(vector1, new Vector2(vector2.X, vector2.Y));
        }

        //Overload
        public static double AngleBetween(Rectangle vector1, Vector2 vector2)
        {
            return AngleBetween(new Vector2(vector1.X, vector1.Y), vector2);
        }

        public static Vector2 AngleSpeed(double angle, double speed)
        {
            Vector2 nSpeed = new Vector2();
            nSpeed.Y = (float)(Math.Sin(Math.PI * angle / 180.0) * speed);
            nSpeed.X = (float)(Math.Cos(Math.PI * angle / 180.0) * speed);

            return nSpeed;
        }

        // Method to read pixel by pixel
        // Return if contacts or not

        public static bool IntersectsPixelPerPixel( Texture2D text1, Rectangle rect1,
                                                    Texture2D text2, Rectangle rect2)
        {
            Color[] data1 = new Color[text1.Width * text1.Height]; 
            Color[] data2 = new Color[text2.Width * text2.Height];

            text1.GetData<Color>(data1);
            text2.GetData<Color>(data2);

            int top = Math.Max(rect1.Top, rect2.Top);
            int bottom = Math.Min(rect1.Bottom, rect2.Bottom);
            int left = Math.Max(rect1.Left, rect2.Left);
            int right = Math.Min(rect1.Right, rect2.Right);

            for (int y = top; y < bottom; y++)
                for (int x = left; x < right; x++)
                {
                    Color color1 = data1[(y - rect1.Top) * (rect1.Width) + (x - rect1.Left)];
                    Color color2 = data2[(y - rect2.Top) * (rect2.Width) + (x - rect2.Left)];

                    if (color1.A != 0 && color2.A != 0) { return true; }
                }

                    return false;
        }
    }
}
