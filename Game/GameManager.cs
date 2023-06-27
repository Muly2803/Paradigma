using Game;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public enum GameState
    {
        MainMenu,
        GameOverScreen,
        Level
    }

    public class GameManager
    {


        public SingleScreen GameOverScreen = new SingleScreen("Textures/Screens/Gameover.png");
        public SingleScreen MainMenuScreen = new SingleScreen("Textures/Screens/Mainmenu.png");
        
        private static GameManager instance;

        public LevelController LevelController { get; private set; }

        public static GameManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameManager();
                }

                return instance;
            }
        }

        public GameState CurrentState { get; private set; }

        public void Update()
        {
            switch (CurrentState)
            {

                case GameState.MainMenu:
                    MainMenuScreen.Update();
                    break;
                case GameState.GameOverScreen:
                    GameOverScreen.Update();
                    break;
                case GameState.Level:
                    LevelController.Update();
                    break;
                default:
                    break;
            }

        }

        public void Initilization()
        {
           
            ChangeGameState(GameState.MainMenu);
            LevelController = new LevelController();
            LevelController.Initialization();
        }

        public void Render()
{
            Engine.Clear();
            switch (CurrentState)
            {

                case GameState.MainMenu:
                    MainMenuScreen.Render();
                    break;
                case GameState.GameOverScreen:
                    GameOverScreen.Render();
                    break;
                case GameState.Level:
                    LevelController.Render();
                    break;
                default:
                    break;
            }
            Engine.Show();
}

    public void ChangeGameState(GameState newState)
    {
        CurrentState = newState;
    }

    }
}