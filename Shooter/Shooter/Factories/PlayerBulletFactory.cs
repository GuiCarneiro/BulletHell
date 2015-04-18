using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Factories
{
    public class PlayerBulletFactory
    {
        public IList<Bullet> bullets = new List<Bullet>();
        private SoundEffect sound;

        private double elapsedTime = 0;
        Texture2D texture, textureSpecial;

        public PlayerBulletFactory()
        {
            texture = null;
        }

        public void Update(GameTime gameTime, Player p1)
        {
            elapsedTime += gameTime.ElapsedGameTime.TotalSeconds;
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

        public void Shoot(Player p1)
        {
            

            if (elapsedTime > 0.15)
            {
                Bullet newBullet = new Bullet(texture);
                newBullet.position = new Vector2(p1.position.X + 25 - newBullet.texture.Width/2, p1.position.Y - 5);

                newBullet.isVisible = true;

                bullets.Add(newBullet);

                SpeacialBullers(p1);
                elapsedTime = 0;
            }
        }

        private void SpeacialBullers(Player p1)
        {
            if (p1.points >= 300)
            {
                SpecialBullet newBullet = new SpecialBullet(2, textureSpecial);
                newBullet.position = new Vector2(p1.position.X + 25 - newBullet.texture.Width/2, p1.position.Y - 5);

                newBullet.isVisible = true;

                bullets.Add(newBullet);


                newBullet = new SpecialBullet(1, textureSpecial);
                newBullet.position = new Vector2(p1.position.X + 35 - newBullet.texture.Width/2, p1.position.Y - 5);

                newBullet.isVisible = true;

                bullets.Add(newBullet);
            }

            if (p1.points >= 900)
            {
                SpecialBullet newBullet = new SpecialBullet(0, textureSpecial);
                newBullet.position = new Vector2(p1.position.X + 35 - newBullet.texture.Width/2, p1.position.Y - 5);

                newBullet.isVisible = true;

                bullets.Add(newBullet);


                newBullet = new SpecialBullet(3, textureSpecial);
                newBullet.position = new Vector2(p1.position.X + 25 - newBullet.texture.Width/2, p1.position.Y - 5);

                newBullet.isVisible = true;

                bullets.Add(newBullet);

            }
        }

        // Draw
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Bullet b in bullets)
            {
                b.Draw(spriteBatch);
            }
        }

        // Load Content
        public virtual void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Player/specialBullet");
            textureSpecial = content.Load<Texture2D>("Player/specialBullet");
            sound = content.Load<SoundEffect>("Sound/laser");
        }
    }
}
