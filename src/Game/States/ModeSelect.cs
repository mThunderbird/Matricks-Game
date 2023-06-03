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
    internal class ModeSelect : State
    {
        Drawable background;
        Button singlePlayerButton;
        Button twoPlayerButton;
        Button backButton;
        Button exitButton;

        public ModeSelect()
        {

        }

        public override void Init()
        {
            background = new Drawable();
            background.Texture = Config.Instance.background;
            background.position = new Vector2(0, 0);
            background.dimensions = new Vector2(1920, 1080);

            singlePlayerButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.GAME_MODE_1));
            singlePlayerButton.Texture = Config.Instance.singlePlayerButton;
            singlePlayerButton.position = new Vector2(300, 200);
            singlePlayerButton.dimensions = new Vector2(560, 620);
            singlePlayerButton.setSoundEff(Config.Instance.clickSound);

            twoPlayerButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.GAME_MODE_1));
            twoPlayerButton.Texture = Config.Instance.twoPlayerButton;
            twoPlayerButton.position = new Vector2(1920 - 860, 200);
            twoPlayerButton.dimensions = new Vector2(560, 620);
            twoPlayerButton.setSoundEff(Config.Instance.clickSound);

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
            singlePlayerButton.update();
            twoPlayerButton.update();

            base.Update();
        }

        public override void Draw()
        {
            base.Draw();

            background.Draw();
            exitButton.Draw();
            backButton.Draw();
            singlePlayerButton.Draw();
            twoPlayerButton.Draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}

