using DefaultNamespace;
using UnityEngine;

namespace Weapons.Controllers
{
public class WeaponRotationController : MonoBehaviour
    {
        public GameObject character;
        public MousePointerController mousePointerController;
        private Vector3 mousePointerPosition;
        private void OnEnable()
        {
            mousePointerController.MousePointerWorldPositionChangedEvent += OnMousePointerChange;
        }

        private void OnMousePointerChange(Vector3 obj)
        {
            mousePointerPosition = obj;
        }

        private void OnDisable()
        {
            mousePointerController.MousePointerWorldPositionChangedEvent -= OnMousePointerChange;
        }

        private void Update()
        {
            var aimDirection = (Vector2) (mousePointerPosition - character.transform.position);
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