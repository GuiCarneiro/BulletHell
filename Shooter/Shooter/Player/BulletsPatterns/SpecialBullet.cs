using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter
{
    class SpecialBullet: Bullet
    {
        public SpecialBullet(int type,Texture2D newTexture) : base(newTexture)
        {
            base.speed.Y = -15;
            base.speed.X = 5;
            switch (type)
            {
                case 0:
                    base.speed.X = (float)(base.speed.X * 0.5);
                    base.speed.Y = (float)(base.speed.Y * 0.8);
                    break;
                case 1:
                    base.speed.X = (float)(base.speed.X * 1);
                    base.speed.Y = (float)(base.speed.Y * 0.8);
                    break;
                case 2:
                    base.speed.X = (float)-(base.speed.X * 1);
                    base.speed.Y = (float)(base.speed.Y * 0.8);
                    break;
                case 3:
                    base.speed.X = (float)-(base.speed.X * 0.5);
                    base.speed.Y = (float)(base.speed.Y * 0.8);
                    break;
                default:
                    break;
            }
        }

        // Update 
        public new void Update(GameTime gameTime)
        {
            //Update Position
            position.Y = position.Y + speed.Y;
            position.X = position.X + speed.X;

            //Update Bounding Box
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.Y <= 0) { isVisible = false; }
        }
    }
}
