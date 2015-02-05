using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Content;
using Shooter.Enemies;
using Shooter.Engines;

namespace Shooter
{
    public class Asteroid : Enemy
    {
        // Constructor
        public Asteroid(int pattern) : base()
        {
            this.speed = new Vector2(0, 3);
            this.pattern = pattern;
            this.position = PatternsEnemies.patternPosition(pattern);            
        }
        // Load Content
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("meteor");
        }

        // Update 
        public new void Update(GameTime gameTime)
        {
            boundingBox = new Rectangle((int)position.X, (int)position.Y, texture.Width, texture.Height);
            speed = PatternsEnemies.patternSpeed(pattern, position, speed);
            position.Y = position.Y + speed.Y;
            position.X = position.X + speed.X;

            if (position.Y > Globals.GameHeight + texture.Height) { isVisible = false; }
            if (position.X > Globals.GameWidth + texture.Width) { isVisible = false; }
            if (position.X < 0 - texture.Width) { isVisible = false; }
        }

        public new void Shoot() { }
       
    }
}
