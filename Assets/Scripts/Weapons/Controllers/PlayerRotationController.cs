using DefaultNamespace;
using UnityEngine;
using Vector3 = UnityEngine.Vector3;

namespace Weapons.Controllers
{
    public class PlayerRotationController : MonoBehaviour
    {
        public MousePointerController mousePointerController;
        public bool facingRight = true;
        public Vector3 mousePointerPosition;

        private void Update()
        {
            if(mousePointerPosition.x > gameObject.GetComponent<Transform>().position.x)
            {
                if (facingRight) return;
                Flip();
            }
            else
            {
                if (!facingRight) return;
                Flip();
            }
        }

        private void OnEnable()
        {
            mousePointerController.MousePointerWorldPositionChangedEvent += OnMousePointerChange;
        }
        private void OnDisable()
        {
            mousePointerController.MousePointerWorldPositionChangedEvent -= OnMousePointerChange;
        }
        private void OnMousePointerChange(Vector3 mousePosition)
        {
            mousePointerPosition = mousePosition;
        }
        private void Flip()
        {
            Vector3 currentScale = gameObject.transform.localScale;
            currentScale.x *= -1;
            gameObject.transform.localScale = currentScale;
            facingRight = !facingRight;
        }
    }
}
