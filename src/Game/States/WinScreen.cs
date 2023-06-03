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
    internal class WinScreen : State
    {
        Drawable background;
        Button backButton;
        Button exitButton;

        public WinScreen()
        {

        }

        public override void Init()
        {
            background = new Drawable();
            background.Texture = Config.Instance.background;
            background.position = new Vector2(0, 0);
            background.dimensions = new Vector2(1920, 1080);

            exitButton = new Button(() => Game1.end = true);
            exitButton.Texture = Config.Instance.exitButton;
            exitButton.position = new Vector2(1770, 50);
            exitButton.dimensions = new Vector2(100, 100);
            exitButton.setSoundEff(Config.Instance.clickSound);

            backButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.MENU));
            backButton.Texture = Config.Instance.backButton;
            backButton.position = new Vector2(50, 50);
            backButton.dimensions = new Vector2(100, 100);
            backButton.setSoundEff(Config.Instance.clickSound);

        }

        public override void Update()
        {
            backButton.update();
            exitButton.update();

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();

            background.Draw();
            exitButton.Draw();
            backButton.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}


