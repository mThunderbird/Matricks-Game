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
        Drawable logo;
        Drawable text;
        Drawable background;
        public LoadingScreen()
        {

        }

        public override void Init()
        {
            background = new Drawable();
            background.Texture = Config.Instance.background;
            background.position = new Vector2(0, 0);
            background.dimensions = new Vector2(1920, 1080);

            logo = new Drawable();
            logo.Texture = Config.Instance.logo;
            logo.position = new Vector2(545, 75);
            logo.dimensions = new Vector2(830, 735);

            text = new Drawable();
            text.Texture = Config.Instance.pressSpaceTexture;
            text.position = new Vector2(600, 1000);
            text.dimensions = new Vector2(720, 35);

            SoundPlayer.playSong(Config.Instance.introSong, 0.2f);
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
            background.Draw();
            logo.Draw();
            text.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}
