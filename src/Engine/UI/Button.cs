using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using MonoGameEngine.src;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;
using System;

namespace MonoGameEngine.src.Engine
{
	internal class Button : Drawable
	{
		Texture2D mask;
		private bool drawMask = false;
		Action func;
		SoundEffect soundEffect;
		bool disabled;
		public Button(Action _func, bool _disabled = false) 
		{ 
			this.func = _func;
			mask = Config.Instance.hoverMask;
			disabled = _disabled;
		}
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
			SoundPlayer.playSound(soundEffect);
		}

		public void setSoundEff(SoundEffect _eff)
        {
			soundEffect = _eff;
        }

		public override void draw()
		{
			base.draw();

			if (drawMask && mask != null || disabled)
			{
				Texture2D temp = Texture;
				if (disabled)
				{
					Texture = Config.Instance.disabledMask;
				} else
				{
					Texture = mask;
				}
				Render.draw(this);
				Texture = temp;
			}

		}
	}
}
