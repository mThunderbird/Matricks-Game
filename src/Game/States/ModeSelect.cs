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
        Drawable gameBanner;
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
            background.mPosition = new Vector2(0, 0);
            background.mDimensions = new Vector2(1920, 1080);

            gameBanner = new Drawable();
            gameBanner.Texture = Config.Instance.gameBanner;
            gameBanner.mPosition = new Vector2(260, 150);
            gameBanner.mDimensions = new Vector2(1400, 600);

            singlePlayerButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.GAME_MODE_1));
            singlePlayerButton.Texture = Config.Instance.singlePlayerButton;
            singlePlayerButton.mPosition = new Vector2(260, 820);
            singlePlayerButton.mDimensions = new Vector2(540, 160);
            singlePlayerButton.setSoundEff(Config.Instance.clickSound);

            twoPlayerButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.GAME_MODE_1));
            twoPlayerButton.Texture = Config.Instance.twoPlayerButton;
            twoPlayerButton.mPosition = new Vector2(1120, 820);
            twoPlayerButton.mDimensions = new Vector2(540, 160);
            twoPlayerButton.setSoundEff(Config.Instance.clickSound);

            exitButton = new Button(() => Game1.end = true);
            exitButton.Texture = Config.Instance.exitButton;
            exitButton.mPosition = new Vector2(1770, 50);
            exitButton.mDimensions = new Vector2(100, 100);
            exitButton.setSoundEff(Config.Instance.clickSound);

            backButton = new Button(() => StateManager.Instance.SwitchState(GAME_STATE.MENU));
            backButton.Texture = Config.Instance.backButton;
            backButton.mPosition = new Vector2(50, 50);
            backButton.mDimensions = new Vector2(100, 100);
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
            gameBanner.Draw();
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

