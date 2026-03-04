using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuperPill : MonoBehaviour
{
    private PlayerController playerScript;

    void Start()
    {
        playerScript = FindFirstObjectByType<PlayerController>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerScript.isInv = true;
            ScoreManager.instance.AddScore(50);
            AudioManager.instance.PlayPowerPellet();
            gameObject.SetActive(false);
        }
    }
}
