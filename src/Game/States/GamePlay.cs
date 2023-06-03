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
    internal class GamePlay : State
    {
        public GamePlay() { }

        Drawable background;
        Grid grid;
        public static Vector2 gridDimensions = new Vector2(8, 8);

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

            grid = new Grid(gridDimensions);
        }

        public override void Update()
        {
            base.Update();
            grid.update();
            backButton.update();
            exitButton.update();
        }

        public override void Draw()
        {
            base.Draw();
            background.Draw();
            grid.draw();
            backButton.Draw();
            exitButton.Draw();
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
