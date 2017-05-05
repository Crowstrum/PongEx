using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class GameEvent{}

public class AddForceEvent : GameEvent
{
    public Vector3 Direction;
    public float Amount;

    public AddForceEvent(Vector3 dir, float amount)
    {
        this.Direction = dir;
        this.Amount = amount;
    }
}

public class LoadScene : GameEvent
{
    public PongGameManager.GameStates SceneName;

    public LoadScene(PongGameManager.GameStates name)
    {
        this.SceneName = name;
    }
}


