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
        private const int WINDOW_WIDTH = 1920;
        private const int WINDOW_HEIGHT = 1080;

        Drawable _epicPicture = new Drawable();
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
            _epicPicture.Texture = Content.Load<Texture2D>("cool_graphics/kiroIdrago");
            _epicPicture.mPosition = new Vector2(WINDOW_WIDTH/2, WINDOW_HEIGHT/2);
            _epicPicture.mDimensions *= 0.5f;
            _epicPicture.mPosition -= _epicPicture.mDimensions / 2;

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Bisque);

            // TODO: Add your drawing code here
            Render.Begin();

            _epicPicture.Draw();

            Render.End();

            base.Draw(gameTime);
        }
    }
}