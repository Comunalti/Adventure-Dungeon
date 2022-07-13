using UnityEngine;

namespace Weapons
{
    public class GameObjDestroyer : MonoBehaviour
    {

        public void DestroyGameObj()
        {
            Destroy(gameObject);
        }
    }
}