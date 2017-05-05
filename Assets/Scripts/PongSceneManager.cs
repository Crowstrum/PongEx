using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PongSceneManager : Singleton<PongSceneManager> {
    protected PongSceneManager() { }
    void Start()
    {
        EventManager.Instance.AddListener<LoadScene>(LoadSceneByName);
    }

    public void LoadSceneByName(LoadScene e)
    {
        if (!CheckCurrentScene(e.SceneName.ToString()))
        {
            PongGameManager.Instance.CurrentGameStates = e.SceneName;
            SceneManager.LoadScene(e.SceneName.ToString());
        }
    }

    public bool CheckCurrentScene(string sceneName)
    {
        return SceneManager.GetActiveScene().name == sceneName;
    }

    public void Init()
    {
        Debug.Log("Loading SceneManager");
    }

}
