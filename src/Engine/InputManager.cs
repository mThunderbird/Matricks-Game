using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoGameEngine.src.Engine
{
	internal static class InputManager
	{
		private static KeyboardState previousKeyboardState;
		private static MouseState previousMouseState;

		public static Vector2 getMouseCoordinates() { return new Vector2(Mouse.GetState().X, Mouse.GetState().Y); }

		public static bool isMouseButtonPressed(MOUSE_BUTTON button) {
			if (button == MOUSE_BUTTON.LEFT)
			{
				return Mouse.GetState().LeftButton == ButtonState.Pressed ? true : false;
			}
			return Mouse.GetState().RightButton == ButtonState.Pressed ? true : false;
		}
		public static bool eventIsMouseReleased()
		{
			MouseState currentMouseState = Mouse.GetState();

			if (currentMouseState.LeftButton == ButtonState.Released &&
				previousMouseState.LeftButton == ButtonState.Pressed)
			{
				previousMouseState = currentMouseState;
				return true;
			}

			previousMouseState = currentMouseState;

			return false;
		}
		public static bool eventIsKeyReleased(Keys key)
		{
			KeyboardState currentKeyboardState = Keyboard.GetState();

			if (currentKeyboardState.IsKeyUp(key) && previousKeyboardState.IsKeyDown(key))
			{
				previousKeyboardState = currentKeyboardState;
				return true;
			}

			previousKeyboardState = currentKeyboardState;

			return false;
		}
	}
	public enum MOUSE_BUTTON
	{
		LEFT,
		RIGHT
	}
}
