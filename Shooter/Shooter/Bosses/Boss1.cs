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
            movingPattern = PatternsBosses.movingPattern(2);

            this.score = 500;
        }

        // Draw
        public override void Draw(SpriteBatch spriteBatch)
        {
           spriteBatch.Draw(texture, position, Color.White);
           foreach (BossBullet b in bulletList)
               b.Draw(spriteBatch);
        }

        // Load Content
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Bosses/Boss2");
            bulletTexture1 = content.Load<Texture2D>("Bullets/OrangeBlast"); //Straight
            bulletTexture2 = content.Load<Texture2D>("Bullets/OrangeScale"); //Homing
            bulletTexture3 = content.Load<Texture2D>("Bullets/OrangeTail");  //Spread
        }


        // Update 
        public override void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);

            Move(gameTime);

            if (position.Y > Globals.GameHeight + texture.Height) { isVisible = false; }

            if (position.X > Globals.GameWidth + texture.Width) { isVisible = false; }

            if (position.X < 0 - texture.Width) { isVisible = false; }
        }

        public void Move(GameTime gameTime)
        {
            Rectangle movingPosition = movingPattern.Peek(); 
            Rectangle tmp;
            double degrees = Graphical.AngleBetween(position, movingPosition);

            Vector2 center = new Vector2(position.X + texture.Width / 2, position.Y + texture.Height / 2);

            position.Y = (float)(position.Y + Math.Sin(Math.PI * degrees / 180.0) * 3); 
            position.X = (float)(position.X + Math.Cos(Math.PI * degrees / 180.0) * 3);

            if (movingPosition.Intersects(this.boundingBox))
            {
                tmp = movingPattern.Dequeue();
                movingPattern.Enqueue(tmp);
            }
        }
    }
}
