using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuControl : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Pacman_Game");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Juego cerrado");
    }
}
