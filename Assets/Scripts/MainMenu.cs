using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MainMenu : MonoBehaviour
{

    public void SinglePlayer()
    {
        var singlePlayerEvent = new LoadScene(GameStates.DifficultySelect);
        EventManager.Instance.QueueEvent(singlePlayerEvent);
    }

    public void MultiPlayer()
    {
        var multiPlayerEvent = new LoadScene(GameStates.MultiplayerLogin);
        EventManager.Instance.QueueEvent(multiPlayerEvent);
    }
}
