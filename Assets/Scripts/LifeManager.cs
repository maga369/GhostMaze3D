using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LifeManager : MonoBehaviour
{
    public static LifeManager instance;

    public int lives = 3;
    public Text livesText;

    private Vector3 playerStartPosition;
    private GameObject player;

    private bool isDead = false;

    void Awake()
    {
        // Si no existe una instancia del LifeManager se asigna esta
        if (instance == null)
            instance = this;
        else
            // Si ya existe otro se destruye este
            Destroy(gameObject);
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerStartPosition = player.transform.position;
        UpdateLivesUI();
    }

    public void LoseLife()
    {
        // Evita que se sigan perdiendo vidas después de morir
        if (isDead) return;
        AudioManager.instance.PlayDeath();
        lives--;
        UpdateLivesUI();

        if (lives <= 0)
        {
            isDead = true;
            SceneManager.LoadScene("GameOver");
        }
        else
        {
            player.transform.position = playerStartPosition;
            Rigidbody rb = player.GetComponent<Rigidbody>();
            if (rb != null)
                rb.linearVelocity = Vector3.zero;
        }
    }

    void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Vidas: " + lives;
    }
}
