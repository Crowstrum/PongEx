using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class TitleScreen : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        PongGameManager.Instance.CurrentGameStates = PongGameManager.GameStates.Title;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
