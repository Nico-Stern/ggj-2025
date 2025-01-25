using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float moveSpeed = 5f; // Bewegungsgeschwindigkeit // Sprungkraft

    private Rigidbody rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; // Schicht für den Boden

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Move();

        //weg werfen
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(transform.childCount != 0)
            {
                transform.GetChild(0).gameObject.transform.SetParent(null);
            }
        }
        //maschine betätigen maybe?
    }

    void Move()
    {
        // Eingaben für die horizontale und vertikale Bewegung
        float moveInput_H = Input.GetAxis("Horizontal"); // -1 bis 1 für links/rechts
        float moveInput_V = Input.GetAxis("Vertical"); // -1 bis 1 für vor/zurück

        // Erzeuge den Bewegungsvektor
        Vector3 moveDirection = new Vector3(moveInput_H, 0f, moveInput_V);

        // Normalisiere den Vektor, falls er eine Länge größer als 1 hat
        if (moveDirection.magnitude > 1f)
        {
            moveDirection = moveDirection.normalized;
        }

        // Bewege den Spieler
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }

}
