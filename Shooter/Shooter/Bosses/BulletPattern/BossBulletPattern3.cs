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
    public class BossBulletPattern3
    {
        public List<BossBulletCircular> bulletList = new List<BossBulletCircular>();

        public Texture2D bulletTexture, bulletTexture2;

        private double shootCounter1 = 0;
        private double expandCounter = 1;
        private double rotationCounter = 0;
        private int rotationAngle1 = 0;
        private int rotationAngle2 = 0;

        private int lastShoot = 1;


        // Constructor
        public BossBulletPattern3()
        {

        }

        // Load Content
        public void LoadContent(ContentManager content)
        {
            bulletTexture = content.Load<Texture2D>("Bullets/OrangeScale"); //Homing
            bulletTexture2 = content.Load<Texture2D>("Bullets/PurpleBall"); //Homing
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (BossBulletCircular bullet in bulletList)
            {
                bullet.Draw(spriteBatch);
            }
        }

        // Update 
        public void Update(GameTime gameTime, Vector2 nBossCenter, Vector2 nBossSpeed)
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
        }

        public void Shoot(GameTime gameTime, Vector2 nBossCenter)
        {
            BossBulletCircular newBullet;
            if (shootCounter1 < 0)
            {
                switch (lastShoot)
                {
                    case (1):
                        for (int i = rotationAngle1; i < 361 + rotationAngle1; i = i + 30)
                        {
                            newBullet = new BossBulletCircular(bulletTexture, i, 100);

                            newBullet.position = new Vector2(nBossCenter.X - newBullet.texture.Width / 2, nBossCenter.Y - newBullet.texture.Width / 2);

                            newBullet.isVisible = true;

                            bulletList.Add(newBullet);
                        }

                        lastShoot = 2;
                        break;

                    case (2):
                        for (int i = rotationAngle2; i < 361 + rotationAngle2; i = i + 45)
                        {
                            newBullet = new BossBulletCircular(bulletTexture2, i, 150, false);

                            newBullet.position = new Vector2(nBossCenter.X - newBullet.texture.Width / 2, nBossCenter.Y - newBullet.texture.Width / 2);

                            newBullet.isVisible = true;

                            bulletList.Add(newBullet);
                        }

                        lastShoot = 1;
                        break;

                    default:
                        break;


                }


                shootCounter1 = 0.1;
            }

            if (expandCounter < 0)
            {
                Expand();
                expandCounter = 0.1;
            }

            if (expandCounter < 0)
            {
                rotationAngle1 = rotationAngle1 + 1;
                rotationAngle2 = rotationAngle2 + 1;

                if (rotationAngle1 > 29)
                    rotationAngle1 = 0;

                if (rotationAngle2 > 44)
                    rotationAngle2 = 0;

                rotationCounter = 0.3;
            }


            expandCounter = expandCounter - gameTime.ElapsedGameTime.TotalSeconds;
            shootCounter1 = shootCounter1 - gameTime.ElapsedGameTime.TotalSeconds;
            rotationCounter = rotationCounter - gameTime.ElapsedGameTime.TotalSeconds;
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
