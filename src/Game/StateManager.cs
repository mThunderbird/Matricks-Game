using System;
using MonoGameEngine.src.Engine.States;

namespace MonoGameEngine.src.Game
{
    /// <summary>
    /// Solution using Lazy implementation.
    /// </summary>
    internal class StateManager
    {
        private static readonly Lazy<StateManager> instance =
        new Lazy<StateManager>(() => new StateManager());

        public static StateManager Instance { get { return instance.Value; } }

        public State CurrentState { get; private set; }
        private StateManager()
        {
            CurrentState = new LoadingScreen();
            CurrentState.Init();
        }

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
                case GAME_STATE.SETTINGS:
                    break;
                case GAME_STATE.GAME_MODE_1:
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
        SETTINGS,
        GAME_MODE_1,
        END_SCREEN_1
    }
}
