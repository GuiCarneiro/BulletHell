using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Bosses.Bullets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Bosses.BulletPattern
{
    public class BossBulletPattern1
    {
        public List<BossBulletCircular> bulletList = new List<BossBulletCircular>(); 
        public Queue<int> radiusPattern = new Queue<int>();

        public Texture2D bulletTexture;

        private int bossLife;

        private double shootCounter = 3;


        // Constructor
        public BossBulletPattern1(int bossLife)
        {
            this.bossLife = bossLife;

            radiusPattern.Enqueue(150);
            radiusPattern.Enqueue(200);
            radiusPattern.Enqueue(250);
            radiusPattern.Enqueue(300);
        }

        // Load Content
        public void LoadContent(ContentManager content)
        {
            bulletTexture = content.Load<Texture2D>("Bullets/OrangeScale"); //Homing
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach( BossBulletCircular bullet in bulletList )
            {
                bullet.Draw(spriteBatch);
            }
        }

        // Update 
        public void Update(GameTime gameTime, Vector2 nBossCenter, Vector2 nBossSpeed, int nBossLife)
        {
            for (int i = 0; i < bulletList.Count(); i++)
            {
                Vector2 center = nBossCenter;

                bulletList[i].Update(gameTime, center, nBossSpeed);
                if (!bulletList[i].isVisible)
                {
                    bulletList.RemoveAt(i);
                    i--;
                }
            }            

            if (bossLife > nBossLife)
            {
                Expand();
                bossLife = nBossLife;
            }
        }

        public void Shoot(GameTime gameTime, Vector2 nBossCenter)
        {
            BossBulletCircular newBullet;

            if (shootCounter < 0)
            {
                int radius = radiusPattern.Dequeue();

                for (int i = 0; i < 361; i = i + 30)
                {
                    newBullet = new BossBulletCircular(bulletTexture, i, radius);

                    newBullet.position = new Vector2(nBossCenter.X - newBullet.texture.Width / 2, nBossCenter.Y - newBullet.texture.Width / 2);

                    newBullet.isVisible = true;

                    bulletList.Add(newBullet);
                }

                radiusPattern.Enqueue(radius);
                shootCounter = 2;
            }


            shootCounter = shootCounter - gameTime.ElapsedGameTime.TotalSeconds;
        }

        public void Expand()
        {
            foreach (BossBulletCircular bullet in bulletList)
            {
                bullet.Expand();
            }               
        }
    }
}
