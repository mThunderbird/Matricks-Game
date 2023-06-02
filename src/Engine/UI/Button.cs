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
		Drawable mask = new Drawable();
		private bool drawMask = false;
		Action func;
		SoundEffect soundEffect;
		public Button(Action _func) 
		{ 
			this.func = _func;
			mask = this;
			mask.Texture = Config.Instance.maskHover;
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

		public override void Draw()
		{
			base.Draw();

			if (drawMask) mask.Draw();

		}
	}
}
