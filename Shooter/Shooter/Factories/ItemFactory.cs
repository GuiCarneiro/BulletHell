using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Shooter.Itens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Shooter.Factories
{
    public class ItemFactory
    {
        IList<Item> itens = new List<Item>();
        Random random = new Random();

        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Item item in itens)
                item.Draw(spriteBatch);
        }

        public void Update(GameTime gameTime, Player p1)
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

        public void CreateItem(ContentManager content, Vector2 enemyPosition, Player p1)
        {
            double i = random.NextDouble();

            if (i > 0.5 && p1.shield < 3)
            {
                Item item;
                item = new ItemShield(enemyPosition);
                item.LoadContent(content);
                itens.Add(item);
            }

            if (i < 0.5 && p1.health < 130)
            {
                Item item;
                item = new ItemLife(enemyPosition);
                item.LoadContent(content);
                itens.Add(item);
            }
        }
    }
}
