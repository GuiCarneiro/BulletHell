using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Itens
{
    class ItemLife : Item
    {
        // Constructor
        public ItemLife(Vector2 position) : base(position)
        {

        }
        // Load Content
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Itens/powerupLife");
        }


        public override void Effect(Player p1) 
        {
            p1.health = p1.health + 20;
        }
    }
}
