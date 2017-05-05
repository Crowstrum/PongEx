using UnityEngine;
using System.Collections;
using Assets.Scripts;

public class PaddleAIMaster : AbstractMovementController
{
    public GameObject Ball;

    private Rigidbody _ballRigidbody;

    // Use this for initialization
    void Start()
    {
        _ballRigidbody = Ball.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        MovementDirection();
    }

    public override Vector3 MovementDirection()
    {
        if ((Ball.transform.position - transform.position).magnitude < 10f)
        {
            if (transform.position.y < Ball.transform.position.y)
            {
                return new Vector3(0, 1, 0);
            }
            else
            {
                return new Vector3(0,-1,0);
            }
        }
        return Vector3.zero;
    }
}
