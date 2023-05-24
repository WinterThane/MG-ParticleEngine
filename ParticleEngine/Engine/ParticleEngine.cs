using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace ParticleEngine.Engine
{
    public class ParticleEngine
    {
        private readonly Random random;
        public Vector2 EmitterLocation { get; set; }
        private List<Particle> ParticleList;
        private List<Texture2D> TextureList;

        public ParticleEngine(List<Texture2D> textures, Vector2 lococation)
        {
            EmitterLocation = lococation;
            TextureList = textures;
            ParticleList = new List<Particle>();
            random = new Random();
        }

        private Particle GenerateNewParticle()
        {
            Texture2D texture = TextureList[random.Next(TextureList.Count)];
            Vector2 position = EmitterLocation;
            Vector2 velocity = new Vector2(0.3f * (float)(random.NextDouble() * 2 - 1), 0.8f * (float)(random.NextDouble() * 6 - 1));
            float angle = 0;
            float angvel = 0.1f * (float)(random.NextDouble() * 2 - 1);
            Color color = new Color(0, 0, 0);
            float size = 0.4f;
            int ttl = 20 + random.Next(40);

            return new Particle(texture, position, velocity, angle, angvel, color, size, ttl);
        }

        public void Update()
        {
            int total = 50;

            for (int i = 0; i < total; i++)
            {
                ParticleList.Add(GenerateNewParticle());
            }

            for (int particle = 0; particle < ParticleList.Count; particle++)
            {
                ParticleList[particle].Update();
                if (ParticleList[particle].TimeToLive <= 0)
                {
                    ParticleList.RemoveAt(particle);
                    particle--;
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Begin();
            for (int index = 0; index < ParticleList.Count; index++)
            {
                ParticleList[index].Draw(spriteBatch);
            }
            spriteBatch.End();
        }
    }
}
