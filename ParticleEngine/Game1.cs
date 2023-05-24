using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace ParticleEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        Engine.ParticleEngine _particleEngine;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 1600;
            _graphics.PreferredBackBufferHeight = 1200;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            List<Texture2D> textures = new()
            {
                Content.Load<Texture2D>("Particles/bubble3"),
                Content.Load<Texture2D>("Particles/bubble2"),
                Content.Load<Texture2D>("Particles/bubble1")
            };
            _particleEngine = new Engine.ParticleEngine(textures, new Vector2(400, 300));
        }

        protected override void Update(GameTime gameTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _particleEngine.EmitterLocation = new Vector2(Mouse.GetState().X, Mouse.GetState().Y + 30);
            _particleEngine.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _particleEngine.Draw(_spriteBatch);

            base.Draw(gameTime);
        }
    }
}