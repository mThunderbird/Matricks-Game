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
	internal class InputManager
	{
		private static readonly InputManager instance = new InputManager();
		public static InputManager Instance { get { return instance; } }

		private KeyboardState previousKeyboardState;
		private MouseState previousMouseState;

		private InputManager() { }

		public Point getMouseCoordinates() { return new Point(Mouse.GetState().X, Mouse.GetState().Y); }

		public bool isMouseButtonPressed(MOUSE_BUTTON button) {
			if (button == MOUSE_BUTTON.LEFT)
			{
				return Mouse.GetState().LeftButton == ButtonState.Pressed ? true : false;
			}
			return Mouse.GetState().RightButton == ButtonState.Pressed ? true : false;
		}
		public bool eventIsMouseReleased()
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
		public bool eventIsKeyReleased(Keys key)
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
