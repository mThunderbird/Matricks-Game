using System;
using MonoGameEngine.src.Engine.States;
using MonoGameEngine.src.Game.States;
using Microsoft.Xna.Framework;

namespace MonoGameEngine.src.Game
{
    /// <summary>
    /// Solution using Lazy implementation.
    /// </summary>
    internal sealed class StateManager
    {
        private static readonly StateManager instance = new StateManager();
        static StateManager() { }
        private StateManager()
        {
            CurrentState = new GamePlay();
            CurrentState.Init();
        }
        public static StateManager Instance { get { return instance; } }

        public State CurrentState { get; private set; }


        public void SwitchState(GAME_STATE state)
        {
            CurrentState.Dispose();

            switch (state)
            {
                case GAME_STATE.LOADING_SCREEN:
                    CurrentState = new LoadingScreen();
                    break;
                case GAME_STATE.MENU:
                    CurrentState = new Menu();
                    break;
                case GAME_STATE.MODE_SELECT:
                    CurrentState = new ModeSelect();
                    break;
                case GAME_STATE.SETTINGS:
                    break;
                case GAME_STATE.GAME_MODE_1:
                    CurrentState = new GamePlay();
                    break;
                case GAME_STATE.WIN_SCREEN:
                    CurrentState = new WinScreen();
                    break;
                case GAME_STATE.END_SCREEN_1:
                    break;
            }

            CurrentState.Init();
        }
    }

    public enum GAME_STATE
    {
        LOADING_SCREEN,
        MENU,
        MODE_SELECT,
        SETTINGS,
        GAME_MODE_1,
        GAME_MODE_2,
        WIN_SCREEN,
        END_SCREEN_1
    }
}
