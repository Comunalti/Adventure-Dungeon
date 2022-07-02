using UnityEngine;

namespace Core
{
    public class LazySingleton<T> : MonoBehaviour where T : LazySingleton<T>
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance is null)
                {
                    instance = FindObjectOfType<T>();
                }

                if (instance is null)
                {
                    Debug.LogError($"No {typeof(T).Name} found");
                }

                return instance;
            }
        }
    }
}