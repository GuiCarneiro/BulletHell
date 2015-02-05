using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;

namespace Shooter.Enemies 
{
    public class EnemyBullet : Bullet
    {
        public EnemyBullet(Texture2D newTexture) : base(newTexture)
        {
            base.speed = 10;
            base.damage = 20;
        }

        // Update 
        public new void Update(GameTime gameTime)
        {
            //Update Position
            position.Y = position.Y + speed;

            //Update Bounding Box
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            if (position.Y <= 0) { isVisible = false; }
        }
    }
}
