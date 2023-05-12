using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

using MonoGameEngine.src.Engine;

namespace MonoGameEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static int WINDOW_WIDTH = 1920;
        public static int WINDOW_HEIGHT = 1080;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = WINDOW_WIDTH;
            _graphics.PreferredBackBufferHeight = WINDOW_HEIGHT;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            //_spriteBatch = new SpriteBatch(GraphicsDevice);
            Render.SetBatch(new SpriteBatch(GraphicsDevice));

            // TODO: use this.Content to load your game content here
            ConfigurationManager.Instance.Logo = Content.Load<Texture2D>("cool_graphics/kiroIdrago");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            StateManager.Instance.CurrentState.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            // TODO: Add your drawing code here
            Render.Begin();

            StateManager.Instance.CurrentState.Draw();

            Render.End();

            base.Draw(gameTime);
        }
    }
}