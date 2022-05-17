using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] public GameObject pauseMenu;
    public bool paused;
    
    // Quando chamado, abre o menu e pausa o jogo

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }
    
    //Quando chamado, fecha o menu e despausa o jogo.

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }
    
    // Quando inicia, a variável isPaused é falsa
    void Start()
    {
        paused = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

