using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Enemies;
using Shooter.Engines.Graphical;
using Shooter.Engines.Particle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Factories
{
    public class EnemyFactory
    {
        public IList<Enemy> enemies = new List<Enemy>();

        public EnemyFactory()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);        
        }

        public void Update(GameTime gameTime, ContentManager content, Player p1, HUD hud, ParticleEngine particleEngine, ItemFactory itemFactory)
        {

            for (int i = 0; i < enemies.Count(); i++)
            {
                enemies[i].Update(gameTime);

                // Colision between enemy and player
                if (enemies[i].boundingBox.Intersects(p1.boundingBox))
                {
                    enemies[i].Die();
                    p1.Damaged(enemies[i].health);
                }

                foreach (Bullet b in p1.bulletsFactory.bullets)
                {
                    // Colision between bullet and enemy
                    if (b.boundingBox.Intersects(enemies[i].boundingBox))
                    {
                        if (Graphical.IntersectsPixelPerPixel(b.texture, b.boundingBox, enemies[i].texture, enemies[i].boundingBox))
                        {
                            if (enemies[i].Damaged(b.damage))
                            {
                                if (enemies[i].health <= 0)
                                {
                                    if (enemies[i].Die())
                                    {
                                        itemFactory.CreateItem(content, enemies[i].position, p1);
                                    }
                                    particleEngine.BurstParticle(new Vector2(enemies[i].position.X, enemies[i].position.Y), extraTime: 60, variationY: -1);
                                    hud.score = hud.score + enemies[i].points;
                                    p1.addPoints(enemies[i].points);
                                }
                            }
                            b.Disappear();

                        }
                    }
                }

                // Delete any invisible enemy
                if (!enemies[i].isVisible)
                {
                    enemies.RemoveAt(i);
                }
            }


        }

        public void CreateEnemy(int type, int pattern, ContentManager content)
        {
            Enemy e;
                switch (type)
                {
                    case 0:
                       e = new Asteroid(pattern);
                       break;
                    case 1:
                       e = new EnemyRed1(pattern);
                       break;
                    case 2:
                       e = new EnemyRed2(pattern);
                       break;
                    default:
                       e = new Asteroid(pattern);
                       break;
                }

                e.LoadContent(content);
                enemies.Add(e);
        }


    }
}
