using UnityEngine;

namespace DefaultNamespace.AI.StateMachine
{
    public class TargetHandler : MonoBehaviour
    {
        public GameObject target;
        public float ClosestOpponentDistance()
        {
            return Vector3.Distance(target.transform.position, transform.position);
        }
    }
}