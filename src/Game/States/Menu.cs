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
    internal class Menu : State
    {
        Drawable mLogo;
        public Menu()
        {

        }

        public override void Init()
        {
            mLogo = new Drawable();
            mLogo.Texture = Config.Instance.logo;
            mLogo.mPosition = new Vector2(Game1.WINDOW_WIDTH / 2, Game1.WINDOW_HEIGHT / 2);
            mLogo.mDimensions *= 0.3f;
            mLogo.mOrigin = mLogo.mDimensions / 2;
            mLogo.mColor = Color.Red;
        }

        public override void Update()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.Space))
                StateManager.Instance.SwitchState(GAME_STATE.LOADING_SCREEN);

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            mLogo.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
