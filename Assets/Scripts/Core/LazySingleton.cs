using UnityEngine;

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
                var gameObject = new GameObject(typeof(T).Name);
                instance = gameObject.AddComponent<T>();
            }

            return instance;
        }
    }
}