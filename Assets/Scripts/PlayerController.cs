using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float playerSpeed = 5f;
    private Rigidbody playerRb;

    public bool isInv = false;
    public int invTime;
    private float timeTrans;

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        PlayerMove();
    }

    void Update()
    {
        TimeInv();
    }

    void PlayerMove()
    {
        float mh = Input.GetAxis("Horizontal");
        float mv = Input.GetAxis("Vertical");

        // Crea un vector con la direccion de movimiento
        Vector3 move = new Vector3(mh, 0f, mv);
        // Aplica la velocidad al Rigidbody
        playerRb.linearVelocity = move * playerSpeed;
        // Si el jugador se mueve, rota hacia la direccion de movimiento
        if (move != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(move);
        }
    }

    void TimeInv()
    {
        if (isInv)
        {
            timeTrans += Time.deltaTime;
            invTime = Mathf.RoundToInt(timeTrans);

            if (invTime >= 10)
            {
                isInv = false;
                timeTrans = 0;
                invTime = 0;
            }
        }
    }
}
