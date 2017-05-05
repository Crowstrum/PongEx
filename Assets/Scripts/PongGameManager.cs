using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PongGameManager : Singleton<PongGameManager>
    {
        public GameObject Ball;
        public GameObject Paddle;
        public GameStates CurrentGameStates;
        

        public enum DifficultyLevel
        {
            Chicken,
            Normal,
            Master
        }
        protected PongGameManager() { }

       

        // Use this for initialization
        void Start()
        {
           

        }

        // Update is called once per frame
        void Update()
        {
            switch (CurrentGameStates)
            {
                case GameStates.MainMenu:
                    MainMenuLogic();
                    break;
                case GameStates.DifficultySelect:
                    break;
                case GameStates.MultiplayerLogin:
                    break;
                case GameStates.MultiplayerGame:
                    break;
                case GameStates.SinglePlayerGame:
                    break;
                case GameStates.Title:
                    TitleSceneLogic();
                    break;
            }
        }

        private void MainMenuLogic()
        {
           
        }

       
        private void TitleSceneLogic()
        {
            if (Input.anyKey)
            {
                EventManager.Instance.QueueEvent(new LoadScene(GameStates.MainMenu));
            }
        }
    }
}
