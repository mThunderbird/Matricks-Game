using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameEngine.src.prefabs;
using Microsoft.Xna.Framework;
using MonoGameEngine.src.Engine;

namespace MonoGameEngine.src.Game.States
{
    internal class SinglePlayer : State
    {
        public SinglePlayer() { }

        Drawable background;
        Drawable player1ScoreUI;
        Drawable player2ScoreUI;
        Rectangle player1Score;
        Rectangle player2Score;

        Grid grid;

        public static Vector2 gridDimensions = new Vector2(8, 8);

        public static int minGridSize = 4;
        public static int maxGridSize = 16;

        Button exitButton;
        Button backButton;

        public static int onTurn = 0;

        public override void Init()
        {
            base.Init();
            onTurn = 0;

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

            player1ScoreUI = new Drawable();
            player1ScoreUI.position = new Vector2(40, 340);
            player1ScoreUI.dimensions = new Vector2(360, 160);
            player1ScoreUI.Texture = Config.Instance.player1Score;
            player1Score = new Rectangle(160, 370, 230, 100);

            player2ScoreUI = new Drawable();
            player2ScoreUI.position = new Vector2(40, 580);
            player2ScoreUI.dimensions = new Vector2(360, 160);
            player2ScoreUI.Texture = Config.Instance.player2Score;
            player2Score = new Rectangle(160, 610, 230, 100);

            grid = new Grid(gridDimensions);
        }

        public override void Update()
        {
            base.Update();
            grid.update();
            backButton.update();
            exitButton.update();
        }

        public override void draw()
        {
            base.draw();
            background.draw();
            grid.draw();
            backButton.draw();
            exitButton.draw();
            player1ScoreUI.draw();
            player2ScoreUI.draw();

            float points1 = MathF.Round(grid.players[0].points, 1);
            float points2 = MathF.Round(grid.players[1].points, 1);

            Render.drawString(Config.Instance.arialFont, points1.ToString().Replace(",", "."), player1Score, Color.White, "XXXXXX");
            Render.drawString(Config.Instance.arialFont, points1.ToString().Replace(",", "."), player1Score, Color.White, "XXXXXX");
            Render.drawString(Config.Instance.arialFont, points2.ToString(), player2Score, Color.White, "XXXXXX");
        }

        public static void switchTurn()
        {
            if (onTurn == 0)
            {
                onTurn = 1;
            }
            else
            {
                onTurn = 0;
            }
        }
    }
}
