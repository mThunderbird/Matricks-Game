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

        Drawable winner;
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

            winner = new Drawable();
            switch(Game1.winner)
            {
                case 0:
                    winner.Texture = Config.Instance.player1Wins;
                    break;
                case 1:
                    winner.Texture = Config.Instance.player2Wins;
                    break;
                case 2:
                    winner.Texture = Config.Instance.botWins;
                    break;
                case -1:
                    winner.Texture = Config.Instance.draw;
                    break;
            }

            winner.position.X = Game1.WINDOW_WIDTH / 2 - winner.dimensions.X / 2;
            winner.position.Y = Game1.WINDOW_HEIGHT / 2 - winner.dimensions.Y / 2;
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
            winner.draw();
        }

        public override void Dispose()
        {
            base.Dispose();
        }
    }
}


