using UnityEngine;
using UnityEngine.SceneManagement;

namespace Assets.Scripts
{
    public class PongGameManager : Singleton<PongGameManager>
    {
        public GameObject Ball;
        public GameObject Paddle;
        public GameStates CurrentGameStates;
        public enum GameStates
        {
            Title,
            MainMenu,
            DifficultySelect,
            MultiplayerLogin,
            MultiplayerGame,
            SinglePlayerGame
        }

        public enum DifficultyLevel
        {
            Chicken,
            Normal,
            Master
        }
        protected PongGameManager() { }

        void Awake()
        {
            EventManager.Instance.AddListener<LoadScene>(LoadSceneByName);
        }

        private void LoadSceneByName(LoadScene e)
        {
            if (!CheckCurrentScene(e.SceneName.ToString()))
            {
                CurrentGameStates = e.SceneName;
                SceneManager.LoadScene(e.SceneName.ToString());
            }
        }

        // Use this for initialization
        void Start()
        {
            CurrentGameStates = GameStates.Title;
            if (CheckCurrentScene("TitleScreenScene"))
            { 
                return;
            }
            SceneManager.LoadScene("TitleScreenScene");

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
            if (!CheckCurrentScene("MainMenuScene"))
            {
                SceneManager.LoadScene("MainMenuScene");
            }
        }

        private bool CheckCurrentScene(string sceneName)
        {
            return SceneManager.GetActiveScene().name == sceneName;
        }

        private void TitleSceneLogic()
        {
            if (Input.anyKey)
            {
                CurrentGameStates = GameStates.MainMenu;
            }
        }
    }
}
