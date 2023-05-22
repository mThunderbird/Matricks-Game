using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameEngine.src.prefabs;
using Microsoft.Xna.Framework;

namespace MonoGameEngine.src.Game.States
{
    internal class GamePlay : State
    {
        public GamePlay() { }

        private Grid grid;

        public override void Init()
        {
            base.Init();

            grid = new Grid(new Vector2(8, 8));
        }

        public override void Update()
        {
            base.Update();
        }

        public override void Draw()
        {
            base.Draw();
            grid.draw();
        }

    }
}
