using System;
using DefaultNamespace.AI.StateMachine;
using UnityEngine;

namespace AI.Helpers
{
    public class AIWeaponRotationController : MonoBehaviour
    {
        [SerializeField] private TargetHandler targetHandler;
        public GameObject character;
        void Update()
        {
            var aimDirection = (Vector2) (targetHandler.GetFirstOpponentPosition() - character.transform.position);
        
            float angleY = 0f;
            if (aimDirection.x < 0)
            {
                angleY = 180f;
                aimDirection.x = -aimDirection.x;
            }
            transform.rotation = Quaternion.Euler(0,angleY,Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg);

        }
    }
}


