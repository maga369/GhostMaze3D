using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public int score = 0;
    public Text scoreText;

    void Awake()
    {
        // Si no existe una instancia se asigna esta
        if (instance == null)
            instance = this;
        else
            // Si ya existe otro se destruye este objeto para evitar duplicados
            Destroy(gameObject);
    }

    void Start()
    {
        UpdateScoreUI();
    }

    public void AddScore(int amount)
    {
        score += amount;
        UpdateScoreUI();
    }

    void UpdateScoreUI()
    {
        if (scoreText != null)
            scoreText.text = "Score: " + score;
    }

    public void SaveGame()
    {
        PlayerPrefs.SetInt("Score", score);
        PlayerPrefs.Save();
    }

    public void LoadGame()
    {
        score = PlayerPrefs.GetInt("Score", 0);
        UpdateScoreUI();
    }
}
