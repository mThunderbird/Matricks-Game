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
		public void waitForAction()
		{

		}
		public void playTurn()
		{
			GamePlay.switchTurn();
		}
	}
}
