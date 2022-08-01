using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Managers
{
    public class EndGameManager : MonoBehaviour
    {
        public string sceneName;
        private void Update()
        {
            if (transform.childCount == 0)
            {
                SceneManager.LoadScene(sceneName);
            }
        }
    }
}