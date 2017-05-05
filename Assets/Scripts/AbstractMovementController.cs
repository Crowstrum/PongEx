using UnityEngine;

namespace Assets.Scripts
{
    public abstract class AbstractMovementController : MonoBehaviour
    {
        

        public delegate void OnRicochetEvent(Vector3 normal,float force);
        public event OnRicochetEvent RicochetEvent;
        /// <summary>
        /// Used to return the direction of movement.
        /// </summary>
        /// <returns></returns>
        public abstract Vector3 MovementDirection();

       

        public virtual void Ricochet(Vector3 normal,float force)
        {
            if (RicochetEvent != null) RicochetEvent(normal,force);
        }
    }
}
