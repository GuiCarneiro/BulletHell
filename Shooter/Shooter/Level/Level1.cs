using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Shooter.Enemies;
using Shooter.Engines.Particle;
using Shooter.Bosses;

namespace Shooter.Level
{
    public class Level1
    {
        Player p1;
        List<Asteroid> asteroids = new List<Asteroid>();
        List<Bullet> bullets = new List<Bullet>();
        IList<Enemy> enemies = new List<Enemy>();
        StarField starField = new StarField();
        Boss1 boss = new Boss1(0,0,0);
        double timeInGame = 0;
        ParticleEngine particleEngine;
        HUD hud = new HUD();
        private double elapsedTime;

        public Level1(Player player)
        {
            this.p1 = player;
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            KeyboardState keyState = Keyboard.GetState();
            timeInGame = timeInGame += gameTime.ElapsedGameTime.TotalSeconds; 

            starField.Update(gameTime);

            UpdateEnemies(gameTime);
            LoadEnemies(gameTime, content);

            p1.Update(gameTime);

            UpdateBoss(gameTime);

            particleEngine.Update();

            hud.Update(gameTime);

        }

        public void LoadContent(ContentManager content)
        {
            List<Texture2D> textures = new List<Texture2D>();

            textures.Add(content.Load<Texture2D>("FlowerBurst"));

            particleEngine = new ParticleEngine(textures);

            starField.LoadContent(content);

            hud.LoadContent(content);

            p1.LoadContent(content);
            if (boss.isVisible) boss.LoadContent(content);

        }

        public void UnloadContent()
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

            starField.Draw(spriteBatch);
            foreach (Asteroid asteroid in asteroids)
                asteroid.Draw(spriteBatch);

            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);

            p1.Draw(spriteBatch);

            if (boss.isVisible)
            {
                boss.Draw(spriteBatch);
            }
            hud.Draw(spriteBatch);
            particleEngine.Draw(spriteBatch);

        }

        private void LoadEnemies(GameTime gameTime, ContentManager content)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
            // First diagonal asteroids

            if (timeInGame > 3 && timeInGame < 5)
            {
                if (elapsedTime > 0.2)
                {
                    Asteroid asteroid = new Asteroid(1);
                    asteroid.LoadContent(content);
                    enemies.Add(asteroid);

                    asteroid = new Asteroid(2);
                    asteroid.LoadContent(content);
                    enemies.Add(asteroid);
                    elapsedTime = 0;
                }
            }

            // First diagonal asteroids
            if (timeInGame > 5 && timeInGame < 7)
            {
                if (elapsedTime > 0.2)
                {
                    Asteroid asteroid = new Asteroid(3);
                    asteroid.LoadContent(content);
                    enemies.Add(asteroid);

                    asteroid = new Asteroid(4);
                    asteroid.LoadContent(content);
                    enemies.Add(asteroid);
                    elapsedTime = 0;
                }
            }

            // First Enemy Wave
            if (timeInGame > 8 && timeInGame < 9)
            {
                if (elapsedTime > 0.2)
                {
                   EnemyRed1 e = new EnemyRed1(1);
                   e.LoadContent(content);
                   enemies.Add(e);


                   e = new EnemyRed1(2);
                   e.LoadContent(content);
                   enemies.Add(e);
                   elapsedTime = 0;
                }
            }

            if (timeInGame > 9 && timeInGame < 10)
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.Shoot();
                }
            }
            
            // Second Enemy Wave
            if (timeInGame > 10 && timeInGame < 11)
            {
                if (elapsedTime > 0.2)
                {
                   EnemyRed1 e = new EnemyRed1(3);
                   e.LoadContent(content);
                   enemies.Add(e);

                   e = new EnemyRed1(4);
                   e.LoadContent(content);
                   enemies.Add(e);

                    elapsedTime = 0;
                }
            }

            if (timeInGame > 11 && timeInGame < 12)
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.Shoot();
                }
            }

            // Second Enemy Wave
            if (timeInGame > 12 && timeInGame < 14)
            {
                if (elapsedTime > 0.2)
                {
                    EnemyRed2 e = new EnemyRed2(5);
                    e.LoadContent(content);
                    enemies.Add(e);

                    
                    e = new EnemyRed2(6);
                    e.LoadContent(content);
                    enemies.Add(e);

                    elapsedTime = 0;
                }
            }

            if (timeInGame > 12 && timeInGame < 13)
            {
                foreach (Enemy enemy in enemies)
                {
                    enemy.Shoot();
                }
            }


            // Second Enemy Wave
            if (timeInGame > 13 && timeInGame < 18)
            {
                if (elapsedTime > 0.2)
                {
                    EnemyRed2 e = new EnemyRed2(7);
                    e.LoadContent(content);
                    enemies.Add(e); 
                    
                    e = new EnemyRed2(8);
                    e.LoadContent(content);
                    enemies.Add(e);

                    elapsedTime = 0;
                }
            }
            // Second Enemy Wave
            if (timeInGame >20 && timeInGame < 21)
            {
                hud.warning.Activate();
            }


        }


        private void UpdateEnemies(GameTime gameTime)
        {
            for (int i = 0; i < enemies.Count(); i++)
            {
                enemies[i].Update(gameTime);
                if (enemies[i].boundingBox.Intersects(p1.boundingBox))
                {
                    enemies[i].isVisible = false;
                    p1.health = p1.health - 20;
                }

                foreach (Bullet b in p1.bulletList)
                {
                    if (b.boundingBox.Intersects(enemies[i].boundingBox))
                    {
                        b.isVisible = false;
                        if (enemies[i].Damaged(b.damage))
                        {
                            enemies[i].isVisible = false;
                            hud.score = hud.score + 5;
                            if (enemies[i].health == 0)
                            {
                                particleEngine.BurstParticle(new Vector2(enemies[i].position.X, enemies[i].position.Y), extraTime: 60, variationY: -1);
                                hud.score = hud.score + 10;
                            }
                        }
                    }
                }

                foreach (Bullet b in enemies[i].bulletList)
                {
                    if (b.boundingBox.Intersects(p1.boundingBox))
                    {
                        b.isVisible = false;
                        p1.Damaged(b.damage);
                    }
                }


                if (!enemies[i].isVisible)
                {
                    List<EnemyBullet> bullets = null;
                    if (enemies[i].bulletList.Count() > 0 && enemies.Count() > 1)
                    {
                        bullets = enemies[i].bulletList;
                    }

                    enemies.RemoveAt(i);

                    if (bullets != null)
                    {
                        foreach (EnemyBullet b in bullets) { enemies[0].bulletList.Add(b); }
                    }
                    i--;
                }
            }
        }


        private void UpdateBoss(GameTime gameTime)
        {
            if (timeInGame > 21)
            {
                boss.Update(gameTime);
            }
                if (boss.boundingBox.Intersects(p1.boundingBox))
                {
                    p1.health = 0;
                }

                foreach (Bullet b in p1.bulletList)
                {
                    if (b.boundingBox.Intersects(boss.boundingBox))
                    {
                        b.isVisible = false;
                        if (boss.Damaged(b.damage))
                        {
                            if (boss.health == 0)
                            {
                                boss.isVisible = false;
                                particleEngine.BurstParticle(new Vector2(boss.position.X + boss.texture.Width / 2, boss.position.Y + boss.texture.Height / 2), size: 500, extraTime: 240, intensity: 3);
                                hud.score = hud.score + boss.score;
                            }
                        }
                    }
                }
        }
    }
}
