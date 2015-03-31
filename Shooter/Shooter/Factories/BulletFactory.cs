using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Enemies;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Factories
{
    public class BulletFactory
    {
        List<EnemyBullet> bullets = new List<EnemyBullet>();
        Texture2D texture;

        public BulletFactory()
        {
            texture = null;
        }

        public void Update(GameTime gameTime, Player p1)
        {
            foreach (Bullet b in bullets)
            {
                // Colision between enemy's bullet and player
                if (b.boundingBox.Intersects(p1.boundingBox))
                {
                    b.Disappear();
                    p1.Damaged(b.damage);
                }
            }

            for (int i = 0; i < bullets.Count(); i++)
            {
                bullets[i].Update(gameTime);
                if (!bullets[i].isVisible)
                {
                    bullets.RemoveAt(i);
                    i--;
                }
            }
        }

        public void Shoot(IList<Enemy> enemies)
        {
            if(bullets.Count < 20)
                foreach (Enemy e in enemies)
                {
                    EnemyBullet newBullet = new EnemyBullet(texture);
                    newBullet.position = new Vector2(e.position.X + 32 - newBullet.texture.Width / 2, e.position.Y);

                    newBullet.isVisible = true;

                    bullets.Add(newBullet);
                }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (EnemyBullet b in bullets)
            {
                b.Draw(spriteBatch);
            }
        }

        // Load Content
        public virtual void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Enemies/laserRed");
        }
    }
}
