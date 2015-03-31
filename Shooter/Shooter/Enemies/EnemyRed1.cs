using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Enemies
{
    class EnemyRed1 : Enemy
    {
        // Constructor
        public EnemyRed1(int pattern) : base()
        {
            this.pattern = pattern;
            this.position = PatternsEnemies.patternPosition(pattern);
            this.points = 10;

        }
        // Load Content
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Enemies/enemyRed1");
        }
    }
}
