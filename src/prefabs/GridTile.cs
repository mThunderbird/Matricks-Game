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
        Texture2D hMask;
        Texture2D disabledMask1;
        Texture2D disabledMask2;
        public bool isHovered = false;
        public bool isHighlighted = false;
        public bool isEnabled = true;
        public int owner;
        public Operation operation;
        public GridTile()
        {
            hMask = Config.Instance.hoverMask;
            disabledMask1 = Config.Instance.disabledMask1;
            disabledMask2 = Config.Instance.disabledMask2;
        }

        public void update()
        {

        }

        public override void draw()
        {
            base.draw();
            if (isHighlighted || isHovered || !isEnabled) drawMask();
            if (isEnabled) operation.draw();
        }

        public void drawMask()
        {
            Texture2D temp = Texture;
            Texture = hMask;
            if (!isEnabled)
            {
                Texture = disabledMask1;
                if (owner == 1) Texture = disabledMask2;
            }
            Render.draw(this);
            Texture = temp;
        }
        public void setOperation(Operation _operation)
        {
           operation = _operation;
        }
    }
}
