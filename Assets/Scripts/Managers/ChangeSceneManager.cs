using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneManager : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
    }
}