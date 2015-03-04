using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Itens
{
    class ItemShield : Item
    {
        // Constructor
        public ItemShield(Vector2 position) : base(position)
        {

        }
        // Load Content
        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("Itens/powerupShield");
        }


        public override void Effect(Player p1)
        {
            if (p1.shield < 3)
                p1.shield = p1.shield + 1;
        }
    }
}
