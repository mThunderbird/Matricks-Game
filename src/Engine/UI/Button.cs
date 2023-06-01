using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGameEngine.src;
using System;

namespace MonoGameEngine.src.Engine
{
	internal class Button : Drawable
	{
		Texture2D mask;
		private bool drawMask = false;
		Action func;

		public Button(Action _func) 
		{ 
			this.func = _func;
		}
		public Button(Texture2D _mask) { setMask(_mask); }
		public void update()
		{
			if (Bounds().Intersects(new Rectangle(InputManager.getMouseCoordinates().ToPoint(), new Point(1, 1))))
			{
				drawMask = true;
				if (InputManager.isMouseButtonPressed(MOUSE_BUTTON.LEFT))
				{
					onClick();
				}
			}
			else
			{
				drawMask = false;
			}
		}
		internal void onClick()
        {
			func();
		}
		internal void setMask(Texture2D _mask)
		{
			mask = _mask;
		}

		public override void Draw()
		{
			base.Draw();

			if (drawMask && mask != null)
			{
				Texture2D temp = Texture;
				Texture = mask;
				Render.Draw(this);
				Texture = temp;
			}

		}
	}
}
