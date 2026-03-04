using UnityEngine;

public class PauseManager : MonoBehaviour
{
    public GameObject pausePanel;

    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // Si el juego ya esta pausado se reanuda
            if (isPaused)
                Resume();
            else
                // Si no esta pausado, se pausa el juego
                Pause();
        }
    }

    void Pause()
    {
        Time.timeScale = 0f;
        pausePanel.SetActive(true);
        isPaused = true;
    }

    void Resume()
    {
        // Restaura el tiempo
        Time.timeScale = 1f;
        pausePanel.SetActive(false);
        isPaused = false;
    }
}