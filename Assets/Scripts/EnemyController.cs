using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public Transform home;

    private NavMeshAgent enemy;
    private PlayerController playerScript;

    public float startDelay = 0f;

    void Start()
    {
        enemy = GetComponent<NavMeshAgent>();
        playerScript = FindFirstObjectByType<PlayerController>();
        StartCoroutine(StartDelay());
    }

    void Update()
    {
        if (!enemy.enabled) return;
        EnemyMove();
    }

    void EnemyMove()
    {
        if (playerScript.isInv)
        {
            enemy.destination = home.position;
        }
        else
        {
            enemy.destination = player.position;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        // Detecta si el fantasma toca al jugador
        if (!other.CompareTag("Player")) return;

        if (playerScript.isInv)
        {
            AudioManager.instance.PlayMunch();
            StartCoroutine(ReturnHome());
        }
        else
        {
            LifeManager.instance.LoseLife();
        }
    }

    IEnumerator StartDelay()
    {
        // Desactiva el movimiento
        enemy.enabled = false;
        yield return new WaitForSeconds(startDelay);
        // Activa el movimiento
        enemy.enabled = true;
    }

    IEnumerator ReturnHome()
    {
        // Desactiva el agente
        enemy.enabled = false;
        transform.position = home.position;
        yield return new WaitForSeconds(2f);
        // Vuelve a activar el agente
        enemy.enabled = true;
    }
}