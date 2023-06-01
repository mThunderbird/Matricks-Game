using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using System;

using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;

namespace MonoGameEngine
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        public static int WINDOW_WIDTH = 1920;
        public static int WINDOW_HEIGHT = 1080;
        public static GameTime curr_time;
        public static double delta_time;
        public static bool end = false;
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
            _graphics.ToggleFullScreen();
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            // passing the graphics device to our spriteBatch wrapper class Render
            Render.SetBatch(new SpriteBatch(GraphicsDevice));

            // TODO: use this.Content to load your game content here
            // Passing Content.Load function to config manager to Init all required graphics
            Config.Instance.Init( 
            path => {
                try
                {
                    return Content.Load<Texture2D>(path);
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.Write(path + " NOT_FOUND!");
                    return Config.Instance.TEXTURE_NOT_FOUND;
                }
            },
            path =>
            {
                try
                {
                    return Content.Load<SpriteFont>(path);
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.Write(path + " NOT_FOUND!");
                    return null;
                }
            },
            path =>
            {
                try
                {
                    return Content.Load<Song>(path);
                }
                catch (Exception)
                {
                    System.Diagnostics.Debug.Write(path + " NOT_FOUND!");
                    return null;
                }
            });
        }

        protected override void Update(GameTime gameTime)
        {
            delta_time = gameTime.ElapsedGameTime.TotalMilliseconds/1000;
            curr_time = gameTime;

            if (end || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            StateManager.Instance.CurrentState.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.BlanchedAlmond);

            // TODO: Add your drawing code here
            Render.Begin();

            StateManager.Instance.CurrentState.Draw();

            Render.End();

            base.Draw(gameTime);
        }
    }
}