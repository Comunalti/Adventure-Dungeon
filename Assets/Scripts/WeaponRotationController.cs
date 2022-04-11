using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class WeaponRotationController : MonoBehaviour
    {
        public GameObject character;
        public MousePointerController mousePointerController;
        public Vector3 mousePointerPosition;
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
            var aimDirection = mousePointerPosition- character.transform.position;

            transform.rotation = Quaternion.Euler(0,0,Mathf.Atan2(aimDirection.y, aimDirection.x)*Mathf.Rad2Deg);
        }
    }
}