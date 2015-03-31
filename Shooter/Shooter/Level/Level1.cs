﻿using System;
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
using Shooter.Engines.Graphical;
using Shooter.Bosses.Bullets;
using Shooter.Itens;
using Shooter.Factories;

namespace Shooter.Level
{
    public class Level1
    {
        Player p1; // Our ship
        Boss1 boss = new Boss1(); // First boss

        //Objects used on game
        BulletFactory bulletFactory = new BulletFactory();
        IList<Enemy> enemies = new List<Enemy>();
        IList<Item> itens = new List<Item>();
        // ### //

        StarField starField = new StarField(); // Moving wallpaper

        double timeInGame = 0; // Counter of time after the level1 begins

        ParticleEngine particleEngine;

        HUD hud = new HUD(); // Head's on Display

        private double elapsedTime;

        Random random = new Random();

        public Level1(Player player)
        {
            this.p1 = player;
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            KeyboardState keyState = Keyboard.GetState();
            timeInGame = timeInGame += gameTime.ElapsedGameTime.TotalSeconds; 

            starField.Update(gameTime);

            UpdateEnemies(gameTime, content);
            LoadEnemies(gameTime, content);
            bulletFactory.Update(gameTime, p1);

            UpdateItens(gameTime);

            p1.Update(gameTime);

            if(boss.isVisible)
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

            bulletFactory.LoadContent(content);

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

            foreach (Item item in itens)
                item.Draw(spriteBatch);

            foreach (Enemy enemy in enemies)
                enemy.Draw(spriteBatch);

            bulletFactory.Draw(spriteBatch);


            if (boss.isVisible)
            {
                boss.Draw(spriteBatch);
            }

            p1.Draw(spriteBatch);
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
                bulletFactory.Shoot(enemies);
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
                bulletFactory.Shoot(enemies);
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
                bulletFactory.Shoot(enemies);
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

        // Method responsable for checking any kind of Colision
        private void UpdateEnemies(GameTime gameTime, ContentManager content)
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

                foreach (Bullet b in p1.bulletList)
                {
                    // Colision between bullet and enemy
                    if (b.boundingBox.Intersects(enemies[i].boundingBox))
                    {
                        if (enemies[i].Damaged(b.damage))
                        {
                            if (enemies[i].health == 0)
                            {
                                if (enemies[i].Die())
                                {
                                    AddItem(content, enemies[i].position);
                                }
                                particleEngine.BurstParticle(new Vector2(enemies[i].position.X, enemies[i].position.Y), extraTime: 60, variationY: -1);
                                hud.score = hud.score + enemies[i].points;
                            }
                        }
                        b.Disappear();
                    }
                }

                // Delete any invisible enemy
                if (!enemies[i].isVisible)
                {
                    enemies.RemoveAt(i);
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
                    if (Graphical.IntersectsPixelPerPixel(p1.texture, p1.boundingBox, boss.texture, boss.boundingBox))
                        p1.Damaged(boss.health);
                }

                foreach (Bullet b in p1.bulletList)
                {
                    if (b.boundingBox.Intersects(boss.boundingBox))
                    {
                        if (Graphical.IntersectsPixelPerPixel(b.texture, b.boundingBox, boss.texture, boss.boundingBox))
                        {
                            b.isVisible = false;
                            if (boss.Damaged(b.damage))
                            {
                                if (boss.health == 0)
                                {
                                    boss.isVisible = false;
                                    particleEngine.BurstParticle(new Vector2(0, 0), size: 6000, extraTime: 180, intensity: 15);
                                    particleEngine.BurstParticle(new Vector2(Globals.GameWidth, Globals.GameHeight), size: 6000, extraTime: 180, intensity: -15);
                                    
                                    hud.score = hud.score + boss.score;
                                }
                            }

                        }
                    }
                }


                foreach (BossBulletCircular b in boss.bulletPattern1.bulletList)
                {
                    if (b.boundingBox.Intersects(p1.boundingBox))
                    {
                        b.isVisible = false;
                        p1.Damaged(b.damage);
                    }
                }

                foreach (BossBulletCircular b in boss.bulletPattern2.bulletList)
                {
                    if (b.boundingBox.Intersects(p1.boundingBox))
                    {
                        b.isVisible = false;
                        p1.Damaged(b.damage);
                    }
                }

                foreach (BossBulletCircular b in boss.bulletPattern3.bulletList)
                {
                    if (b.boundingBox.Intersects(p1.boundingBox))
                    {
                        b.isVisible = false;
                        p1.Damaged(b.damage);
                    }
                }
        }

        private void UpdateItens(GameTime gameTime)
        {
            for (int i = 0; i < itens.Count; i++)
            {
                itens[i].Update(gameTime);

                if (itens[i].boundingBox.Intersects(p1.boundingBox))
                {
                    itens[i].Disappear();
                    itens[i].Effect(p1);
                }

                if (!itens[i].isVisible)
                {
                    itens.RemoveAt(i);
                    i--;
                }
            }
        }

        private void AddItem(ContentManager content, Vector2 enemyPosition)
        {
            double i = random.NextDouble();
            


            if (i > 0.5 && p1.shield < 3)
            {
                Item item;
                item = new ItemShield(enemyPosition);
                item.LoadContent(content);
                itens.Add(item);
            }

            if(i < 0.5 && p1.health < 130)
            {
                Item item;
                item = new ItemLife(enemyPosition);
                item.LoadContent(content);
                itens.Add(item);
            }

        }
    }
}
