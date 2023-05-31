using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameEngine.src.Game;
using MonoGameEngine.src.gameSpecific;

namespace MonoGameEngine.src.Engine.States
{
    internal class LoadingScreen : State
    {
        Drawable mLogo;
        public LoadingScreen()
        {

        }

        public override void Init()
        {
            mLogo = new Drawable();
            mLogo.Texture = Config.Instance.Logo;
            mLogo.mPosition = new Vector2(Game1.WINDOW_WIDTH / 2, Game1.WINDOW_HEIGHT / 2);
            mLogo.mDimensions *= 0.3f;
            mLogo.mOrigin = mLogo.mDimensions / 2;

        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                StateManager.Instance.SwitchState(GAME_STATE.MENU);

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            if (InputManager.Instance.eventIsKeyReleased(Keys.A)) mLogo.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
