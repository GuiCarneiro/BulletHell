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
using Shooter.Engines.Graphical;
using Shooter.Bosses.Bullets;
using Shooter.Itens;
using Shooter.Factories;
using Shooter.Components;

namespace Shooter.Level
{
    public class Level1
    {
        Player p1; // Our ship
        Boss1 boss; // First boss

        //Objects used on game
        BulletFactory bulletFactory = new BulletFactory();
        EnemyFactory enemyFactory = new EnemyFactory();
        ItemFactory itemFactory = new ItemFactory();
        Camera camera;
        // ### //

        StarField starField = new StarField(); // Moving wallpaper

        double timeInGame = 0; // Counter of time after the level1 begins

        private double elapsedTime = 0;

        ParticleEngine particleEngine;

        HUD hud = new HUD(); // Head's on Display

        Random random = new Random();

        private SoundEffect inGame;
        private SoundEffectInstance instance;

        public Level1(Player player, ref Camera camera)
        {
            this.p1 = player;
            this.camera = camera;
            this.boss = new Boss1(ref camera);
        }

        public void levelBegin()
        {
            if (timeInGame == 0)
            {
                instance.IsLooped = true;
                instance.Volume = 0.05f;
                instance.Play();
            }
        }

        public void Update(GameTime gameTime, ContentManager content)
        {
            levelBegin();

            KeyboardState keyState = Keyboard.GetState();
            timeInGame = timeInGame += gameTime.ElapsedGameTime.TotalSeconds; 

            starField.Update(gameTime);

            LoadEnemies(gameTime, content);

            enemyFactory.Update(gameTime, content, p1, hud, particleEngine, itemFactory);

            bulletFactory.Update(gameTime, p1);

            itemFactory.Update(gameTime, p1);

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

            inGame = content.Load<SoundEffect>("Sound/InGame");
            instance = inGame.CreateInstance();

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

            itemFactory.Draw(spriteBatch);

            enemyFactory.Draw(spriteBatch);
            bulletFactory.Draw(spriteBatch);

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

            // First Wave - Asteroids
            if (timeInGame > 3 && timeInGame < 5 && elapsedTime > 0.2)
            {
                enemyFactory.CreateEnemy(0, 1, content);
                enemyFactory.CreateEnemy(0, 2, content);
                elapsedTime = 0;
            }

            // Second Wave - Asteroids
            if (timeInGame > 5 && timeInGame < 7 && elapsedTime > 0.2)
            {
                enemyFactory.CreateEnemy(0, 3, content);
                enemyFactory.CreateEnemy(0, 4, content);
                elapsedTime = 0;
            }

            // Third Wave - EnemyRed1
            if (timeInGame > 8 && timeInGame < 9 && elapsedTime > 0.2)
            {
                enemyFactory.CreateEnemy(1, 1, content);
                enemyFactory.CreateEnemy(1, 2, content);
                elapsedTime = 0;
            }

            // First Bullet Wave
            if (timeInGame > 9 && timeInGame < 10)
            {
                bulletFactory.Shoot(enemyFactory.enemies);
            }

            // Forth Wave - EnemyRed1
            if (timeInGame > 10 && timeInGame < 11 && elapsedTime > 0.2)
            {
                enemyFactory.CreateEnemy(1, 3, content);
                enemyFactory.CreateEnemy(1, 4, content);
                elapsedTime = 0;
            }

            // Second Bullet Wave
            if (timeInGame > 11 && timeInGame < 12)
            {
                bulletFactory.Shoot(enemyFactory.enemies);
            }

            // Fifth Wave - EnemyRed2
            if (timeInGame > 12 && timeInGame < 14 && elapsedTime > 0.2)
            {
                enemyFactory.CreateEnemy(2, 5, content);
                enemyFactory.CreateEnemy(2, 6, content);
                elapsedTime = 0;
            }

            // Third Bullet Wave
            if (timeInGame > 12 && timeInGame < 13)
            {
                bulletFactory.Shoot(enemyFactory.enemies);
            }

            // Sixth Wave - EnemyRed2
            if (timeInGame > 13 && timeInGame < 18 && elapsedTime > 0.2)
            {
                enemyFactory.CreateEnemy(2, 7, content);
                enemyFactory.CreateEnemy(2, 8, content);
                elapsedTime = 0;
            }

            if (timeInGame >20 && timeInGame < 21)
            {
                hud.warning.Activate();
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

                foreach (Bullet b in p1.bulletsFactory.bullets)
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
                                    p1.addPoints(boss.score);
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
    }
}
