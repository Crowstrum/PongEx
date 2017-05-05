using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class MainMenu : MonoBehaviour
{

    public void SinglePlayer()
    {
        var singlePlayerEvent = new LoadScene(PongGameManager.GameStates.DifficultySelect);
        EventManager.Instance.QueueEvent(singlePlayerEvent);
    }

    public void MultiPlayer()
    {
        var multiPlayerEvent = new LoadScene(PongGameManager.GameStates.MultiplayerLogin);
        EventManager.Instance.QueueEvent(multiPlayerEvent);
    }
}
