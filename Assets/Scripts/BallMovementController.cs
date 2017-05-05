using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public class BallMovementController : AbstractMovementController
    {
        public float StartingBallForce = 10f;
        private readonly List<Vector3> _startingDirections = new List<Vector3>
        {
            Vector3.right,
            Vector3.left
        };

        public override Vector3 MovementDirection()
        {
            return Vector3.zero;
        }

        void OnEnable()
        {
            CountdownTimer.Instance.TimerDone += StartBallMovement;

        }

        void OnDisable()
        {
            CountdownTimer.Instance.TimerDone -= StartBallMovement;
        }

        private void StartBallMovement()
        {
            var direction = _startingDirections[Random.Range(0, _startingDirections.Count)];
            var forceEvent = new AddForceEvent(direction,StartingBallForce);
            EventManager.Instance.TriggerEvent(forceEvent);
        
        }
    }
}
