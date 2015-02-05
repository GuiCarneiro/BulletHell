using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Shooter.Engines.Particle
{
    public class ParticleEngine
    {
        private Random random;
        private List<Particle> particles;
        private List<Texture2D> textures;

        public ParticleEngine(List<Texture2D> textures)
        {
            this.textures = textures;
            this.particles = new List<Particle>();
            random = new Random();
        }

        private Particle GenerateNewParticle(Color nColor, Vector2 location, int minTTL = 20, int variationX = 0, int variationY = 0)
        {
            Texture2D texture = textures[random.Next(textures.Count)];
            Vector2 position = location;
            Vector2 velocity = new Vector2(
                    1f * (float)(random.NextDouble() * 2 - 1) + variationX,
                    1f * (float)(random.NextDouble() * 2 - 1) + variationY);
            float angle = 0;
            float angularVelocity = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = nColor;
            float size = (float)random.NextDouble();
            int ttl = minTTL + random.Next(40);

            return new Particle(texture, position, velocity, angle, angularVelocity, color, size, ttl);
        }

        public void BurstParticle(Vector2 location, int size = 15, int extraTime = 0, int variationX = 0, int variationY = 0)
        {
            for (int i = 0; i < size; i++)
            {
                particles.Add(GenerateNewParticle(Color.White, location, extraTime, variationX, variationY));
            }
        }

        public void Update()
        {

            for (int particle = 0; particle < particles.Count; particle++)
            {
                particles[particle].Update();
                if (particles[particle].TTL <= 0)
                {
                    particles.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int index = 0; index < particles.Count; index++)
            {
                particles[index].Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
