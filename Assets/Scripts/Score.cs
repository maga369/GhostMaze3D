using UnityEngine;

public class Score : MonoBehaviour
{
    public int points = 10;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            ScoreManager.instance.AddScore(points);
            GameManager.instance.CollectPoint();
            AudioManager.instance.PlayMunch();
            // Desactiva el objeto
            gameObject.SetActive(false);
        }
    }
}