using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public int totalPoints;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            // Para evitar duplicados
            Destroy(gameObject);
    }

    void Start()
    {
        // Se buscan todos los objetos con el tag "Point" esto permite saber cuántos puntos hay
        totalPoints = GameObject.FindGameObjectsWithTag("Point").Length;
    }

    public void CollectPoint()
    {
        totalPoints--;

        if (totalPoints <= 0)
        {
            SceneManager.LoadScene("Victory");
        }
    }
}
