using UnityEngine;

namespace Assets.Scripts
{
    public class PlayerMovementController : AbstractMovementController
    {
        private bool _canMove;

        public override Vector3 MovementDirection()
        {
            if (_canMove)
            {
                var h = Input.GetAxisRaw("Horizontal");
                var v = Input.GetAxisRaw("Vertical");
                return new Vector3(h, v, 0).normalized;
            }
            return new Vector3();
        }

        void OnEnable()
        {
            CountdownTimer.Instance.TimerDone += EnableMovement;
        }

        private void EnableMovement()
        {
            _canMove = true;
        }


        void OnDisable()
        {
            CountdownTimer.Instance.TimerDone -= EnableMovement;
        }
    }
}
