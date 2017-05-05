using UnityEngine;

namespace Assets.Scripts
{
    [RequireComponent(typeof(AbstractMovementController))]
    public class RigidBodyMovement : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        public float Speed = 6f;
        
        private AbstractMovementController _movementController;

        void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _movementController = GetComponent<AbstractMovementController>();
        }

        void OnEnable()
        {          
            _movementController.RicochetEvent += Ricochet;
            EventManager.Instance.AddListener<AddForceEvent>(AddForce);
        }

        private void Ricochet(Vector3 normal,float force)
        {
            var randomness = new Vector3(Random.Range(0.3f, 0.5f), Random.Range(0.1f, 0.2f), 0) * Mathf.Sign(_rigidbody.velocity.x);
            _rigidbody.velocity = Vector3.Reflect(_rigidbody.velocity, normal+randomness);
            _rigidbody.velocity += ((normal+randomness)*force);
        }

        private void AddForce(AddForceEvent addForceEvent)
        {
            var forceVector = addForceEvent.Direction.normalized * addForceEvent.Amount;
            _rigidbody.velocity = Vector3.zero;
            
            _rigidbody.AddForce(forceVector,ForceMode.Impulse);
        }

        // Update is called once per frame
        void FixedUpdate () {
            if (_movementController == null)
            {
                Debug.Log("NULL");
                return;
            }
            var moveVector = _movementController.MovementDirection() * Speed;
            _rigidbody.MovePosition(transform.position + moveVector * Time.deltaTime);

            if (_movementController.MovementDirection() == Vector3.zero && _movementController.tag == "LeftPaddle")
            {
                _rigidbody.velocity = Vector3.zero;
            }
        }


    }
}
