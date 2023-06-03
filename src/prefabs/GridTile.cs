using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;
using Microsoft.Xna.Framework.Graphics;

namespace MonoGameEngine.src.prefabs
{
    internal class GridTile : Drawable
    {
        Texture2D mask;
        public bool drawMask = false;
        Operation operation;

        bool isTaken = false;

        public GridTile()
        {
            mask = Config.Instance.hoverMask;
        }

        public override void Draw()
        {
            base.Draw();

            if (drawMask)
            {
                Texture2D temp = Texture;
                Texture = mask;
                Render.Draw(this);
                Texture = temp;
            }

            if(!isTaken)
            {
                operation.draw();
            }
        }

        public void setOperation(Operation operation)
        {
            this.operation = operation;
        }
    }
}
