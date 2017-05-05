using UnityEngine;
using System.Collections;
using System.Linq;
using Assets.Scripts;

public class BallCollisions : MonoBehaviour
{
    private AbstractMovementController _movementController;
    public float RicochetForce = 10f;
    public float PaddleForce = 10f;

    void Awake()
    {
        _movementController = GetComponent<AbstractMovementController>();
    }
    
    float hitFactor(Vector2 ballPos, Vector2 racketPos,
        float racketHeight)
    {
        // ascii art:
        // ||  1 <- at the top of the racket
        // ||
        // ||  0 <- at the middle of the racket
        // ||
        // || -1 <- at the bottom of the racket
        return (ballPos.y - racketPos.y) / racketHeight;
    }

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.tag == "LeftPaddle")
        {
            var yPos = hitFactor(transform.position, collision.transform.position, collision.transform.localScale.y);
            var direction = new Vector3(1,yPos,0).normalized;
            EventManager.Instance.QueueEvent(new AddForceEvent(direction, PaddleForce));
           
        }

        if (collision.gameObject.tag == "Wall")
        {
            collision.contacts.ToList().ForEach(_ =>
            {
             
                _movementController.Ricochet(_.normal, RicochetForce);
            });
            // _movementController.Ricochet(surfaceNormal,RicochetForce);
        }
    }
}
