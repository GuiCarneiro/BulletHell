using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Bosses.Bullets;
using Shooter.Engines;
using Shooter.Engines.Graphical;


namespace Shooter.Bosses
{
    public class Boss1 : Boss
    {
        Random random = new Random();
        Queue<Rectangle> movingPattern = new Queue<Rectangle>();
        
        public Boss1(int bp1, int bp2, int bp3) : base(bp1, bp2, bp3)
        {
            this.health = 1000;
            this.bulletList = new List<BossBullet>();
            this.texture = null;
            this.position = new Vector2(Globals.WindowWidth / 2, -Globals.WindowHeight); 

            //All three states of bullets
            this.bulletTexture1 = null;
            this.bulletTexture2 = null;
            this.bulletTexture3 = null;

            this.bulletPattern1 = bp1;
            this.bulletPattern2 = bp3;
            this.bulletPattern3 = bp2;

            this.isVisible = true;
            movingPattern = PatternsBosses.movingPattern(1);

            this.score = 500;

            this.initialLife = 2000;
            this.initialHeight = 1300;
            this.healthAnimation = 270;
        }

        // Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(texture, position, Color.White);
           foreach (BossBullet b in bulletList)
               b.Draw(spriteBatch);

           //If Life > 0 than draw life bar
           if (health > 0)
           {
               spriteBatch.Draw(healthTop, new Rectangle(healthRectangle.X, healthRectangle.Y - healthTop.Height, healthRectangle.Width, healthTop.Height), Color.White);
               spriteBatch.Draw(healthMid, healthRectangle, Color.White);
               spriteBatch.Draw(healthBottom, new Rectangle(healthRectangle.X, healthRectangle.Y + healthRectangle.Height, healthRectangle.Width, healthBottom.Height), Color.White);
           }

        }

        // Load Content
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Bosses/Boss2");
            bulletTexture1 = content.Load<Texture2D>("Bullets/OrangeBlast"); //Straight
            bulletTexture2 = content.Load<Texture2D>("Bullets/OrangeScale"); //Homing
            bulletTexture3 = content.Load<Texture2D>("Bullets/OrangeTail");  //Spread


            healthMid = content.Load<Texture2D>("HUD/bar_red_mid");
            healthTop = content.Load<Texture2D>("HUD/bar_red_top");
            healthBottom = content.Load<Texture2D>("HUD/bar_red_bottom");
        }


        // Update 
        public override void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            Move(gameTime);

            if (position.Y > Globals.GameHeight + texture.Height) { isVisible = false; }

            if (position.X > Globals.GameWidth + texture.Width) { isVisible = false; }

            if (position.X < 0 - texture.Width) { isVisible = false; }

            healthRectangle = new Rectangle(Globals.GameWidth - 40 + healthAnimation, 35, 20, (health * initialHeight) / initialLife);

            if (healthAnimation != 0)
                healthAnimation--;
        }

        public void Move(GameTime gameTime)
        {
            Rectangle movingPosition = movingPattern.Peek(); 
            Rectangle tmp;
            double degrees = Graphical.AngleBetween(position, movingPosition);

            Vector2 speed = Graphical.AngleSpeed(degrees, 3);

            position.Y = position.Y + speed.Y; 
            position.X = position.X + speed.X;

            if (movingPosition.Intersects(this.boundingBox))
            {
                tmp = movingPattern.Dequeue();
                movingPattern.Enqueue(tmp);
            }
        }
    }
}
