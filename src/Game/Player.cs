using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Audio;
using MonoGameEngine.src;
using MonoGameEngine.src.Engine;
using MonoGameEngine.src.Game.States;
using System;

namespace MonoGameEngine.src.Game
{
	internal class Player
	{
		public Drawable body = new Drawable();
		int index = 0;
		public Vector2 coordinatesInGrid = new Vector2(1, 1);
		public bool isSelected = false;
		public int possibleMoves = -1;
		public Player(int _index)
		{
			index = _index;
			body.Texture = Config.Instance.character1;
			if (index == 1) {
				coordinatesInGrid = new Vector2(GamePlay.gridDimensions.X - 1, GamePlay.gridDimensions.Y - 1);
				body.Texture = Config.Instance.character2;
			}
		}
		public void draw()
		{
			body.Draw();
		}
	}
}
