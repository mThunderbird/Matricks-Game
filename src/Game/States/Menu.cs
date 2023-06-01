using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameEngine.src.Game;


namespace MonoGameEngine.src.Engine.States
{
    internal class Menu : State
    {
        Drawable gameBanner;
        Drawable playButton;
        Drawable settingsButton;
        public Menu()
        {

        }

        public override void Init()
        {
            gameBanner = new Drawable();
            gameBanner.Texture = Config.Instance.gameBanner;
            gameBanner.mDimensions = new Vector2(1000, 350);
            gameBanner.mPosition = new Vector2(Game1.WINDOW_WIDTH / 2, 250);
            gameBanner.mOrigin = gameBanner.mDimensions / 2;

            playButton = new Drawable();
            playButton.Texture = Config.Instance.playButton;
            playButton.mDimensions = new Vector2(540, 160);
            playButton.mPosition = new Vector2(150, 800);

            settingsButton = new Drawable();
            settingsButton.Texture = Config.Instance.settingsButton;
            settingsButton.mDimensions = new Vector2(540, 160);
            settingsButton.mPosition = new Vector2(1230, 800);

        }

        public override void Update()
        {
            if (InputManager.eventIsKeyReleased(Keys.Space))
                StateManager.Instance.SwitchState(GAME_STATE.GAME_MODE_1);

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            gameBanner.Draw();
            playButton.Draw();
            settingsButton.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
