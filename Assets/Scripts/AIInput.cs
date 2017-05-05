using UnityEngine;
using System.Collections;

public class AIInput : MonoBehaviour,IMovement
{
    public GameObject ObjToFollowGameObject;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        MovementDirection();
    }

    public Vector3 MovementDirection()
    {
        var h = ObjToFollowGameObject.transform.position.x - transform.position.x;
        var v = ObjToFollowGameObject.transform.position.z;
        return new Vector3(h,0,v).normalized;
    }
}
