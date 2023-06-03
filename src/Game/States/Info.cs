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
    internal class Info : State
    {
        Drawable background;
        Button backButton;
        Button exitButton;
        Drawable info;

        public Info()
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

            info = new Drawable();
            info.Texture = Config.Instance.info;
            info.position = new Vector2(260, 140);
            info.dimensions = new Vector2(1400, 800);
        }

        public override void Update()
        {
            backButton.update();
            exitButton.update();

            base.Update();
        }

        public override void draw()
        {
            base.draw();

            background.draw();
            exitButton.draw();
            backButton.draw();
            info.draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

