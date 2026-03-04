using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Pacman_Game"); 
        // o SceneManager.LoadScene(0);
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("Main_Menu");
    }
}
