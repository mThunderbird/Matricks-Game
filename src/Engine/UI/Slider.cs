using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game;

namespace MonoGameEngine.src.Engine.UI
{
	internal class Slider
	{
		Drawable bar;
		Drawable knob;
		int minValue = 0;
		int maxValue = 0;
		public int resultValue = 0;
		public Slider(Vector2 barPosition, int _minValue, int _maxValue)
		{
			minValue = _minValue;
			maxValue = _maxValue;

			bar = new Drawable();
			bar.Texture = Config.Instance.sliderBar;
			bar.position = barPosition;
			bar.dimensions = new Vector2(540,30);
			bar.origin = Vector2.Zero;

			knob = new Drawable();
			knob.Texture = Config.Instance.sliderKnob;
			knob.position = barPosition;
			knob.position.Y = barPosition.Y - 15;
			knob.dimensions = new Vector2(60, 60);
			knob.origin = Vector2.Zero;
		}
		public void update()
		{
			if (InputManager.isMouseButtonPressed(MOUSE_BUTTON.LEFT))
			{
				if (knob.Bounds().Intersects(new Rectangle(InputManager.getMouseCoordinates().ToPoint(), new Point(1, 1))))
				{
					knob.position.X = InputManager.getMouseCoordinates().X - 30;
					knob.position.X = clamp(knob.position.X, bar.position.X, bar.position.X + bar.dimensions.X);
					resultValue = (int)(knob.position.X - bar.position.X) * (maxValue - minValue) / (int)bar.dimensions.X;
				}
			}
			if (InputManager.eventIsMouseReleased()) knob.position.X = bar.position.X + (resultValue * bar.dimensions.X) / (maxValue - minValue) - 30;
		}
		public void draw()
		{
			bar.draw();
			knob.draw();
		}
		float clamp(float value, float _minValue, float _maxValue)
		{
			if (value < _minValue) return _minValue;
			if (value > _maxValue) return _maxValue;
			return value;
		}
	}
}
