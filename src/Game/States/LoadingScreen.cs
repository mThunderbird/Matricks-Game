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
    internal class LoadingScreen : State
    {
        Drawable mLogo;
        Drawable mText;
        public LoadingScreen()
        {

        }

        public override void Init()
        {
            mLogo = new Drawable();
            mLogo.Texture = Config.Instance.logo;
            mLogo.mPosition = new Vector2(Game1.WINDOW_WIDTH / 2, Game1.WINDOW_HEIGHT / 2);
            mLogo.mDimensions = new Vector2(500, 500);
            mLogo.mOrigin = mLogo.mDimensions / 2;

            mText = new Drawable();
            mText.Texture = Config.Instance.pressSpaceTexture;
            mText.mPosition = new Vector2(Game1.WINDOW_WIDTH / 2, Game1.WINDOW_HEIGHT - 200);
            mText.mDimensions = new Vector2(1000, 100);
            mText.mOrigin = mText.mDimensions / 2;
        }

        public override void Update()
        {

            if(InputManager.eventIsKeyReleased(Keys.Space))
            {
                StateManager.Instance.SwitchState(GAME_STATE.MENU);
            }

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            mLogo.Draw();
            mText.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
