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

        Button exitButton;
        Button backButton;

        bool test = true;
        public override void Init()
        {
            base.Init();

            background = new Drawable();
            background.Texture = Config.Instance.background;
            background.mPosition = new Vector2(0, 0);
            background.mDimensions = new Vector2(1920, 1080);

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

            grid = new Grid(new Vector2(8, 8));
        }

        public override void Update()
        {
            base.Update();
            grid.update();
            backButton.update();
            exitButton.update();

            if(test)
            {
                Unit temp = new Unit();
                temp.Texture = Config.Instance.character1;
                grid.addUnit(temp, 2 , 3);
                test = false;
            }
        }

        public override void Draw()
        {
            base.Draw();
            background.Draw();
            grid.draw();
            backButton.Draw();
            exitButton.Draw();
        }

    }
}
