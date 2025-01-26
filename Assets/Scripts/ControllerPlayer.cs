using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
    public float moveSpeed = 100; // Bewegungsgeschwindigkeit // Sprungkraft

    private Rigidbody rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; // Schicht f�r den Boden

    Animator animator;

    [SerializeField] float delay = .3f;
    [SerializeField] float currentDelay;

    bool IsTimerRunnig;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    public void HasPlayerTheCup(bool hasCup)
    {
        animator.SetBool("CupGrabbed", hasCup);
    }

    void Update()
    {

        Move();

        // Eingaben f�r die horizontale und vertikale Bewegung
        float moveInput_H = Input.GetAxis("Horizontal"); // -1 bis 1 f�r links/rechts
        float moveInput_V = Input.GetAxis("Vertical"); // -1 bis 1 f�r vor/zur�ck

        // Erzeuge den Bewegungsvektor
        Vector3 moveDirection = new Vector3(moveInput_H, 0f, moveInput_V);

        // Normalisiere den Vektor, falls er eine L�nge gr��er als 1 hat
        if (moveDirection.magnitude > 1f)
        {
            //moveDirection = moveDirection.normalized;
        }

        // Bewege den Spieler
        rb.velocity = moveDirection * moveSpeed;

        animator.SetFloat("Velocity", rb.velocity.x);

        print(moveSpeed);

        //weg werfen
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (transform.childCount != 0)
            {
                GameObject Index = transform.GetChild(0).gameObject;

                Index.GetComponent<Rigidbody>().isKinematic = false;

                Index.transform.SetParent(null);

                Index.GetComponent<Rigidbody>().AddForce(100, 300, 10);

                animator.SetTrigger("CupThrow");
                currentDelay = 0;
                IsTimerRunnig = true;
            }
        }
        else
        {
            if (currentDelay > delay && IsTimerRunnig)
            {

                HasPlayerTheCup(false);
                IsTimerRunnig = false;
            }
        }
        //maschine bet�tigen maybe?
        currentDelay += Time.deltaTime;
    }

    void Move()
    {
        // Eingaben f�r die horizontale und vertikale Bewegung
        float moveInput_H = Input.GetAxis("Horizontal"); // -1 bis 1 f�r links/rechts
        float moveInput_V = Input.GetAxis("Vertical"); // -1 bis 1 f�r vor/zur�ck

        // Erzeuge den Bewegungsvektor
        Vector3 moveDirection = new Vector3(moveInput_H, 0f, moveInput_V);

        // Normalisiere den Vektor, falls er eine L�nge gr��er als 1 hat
        if (moveDirection.magnitude > 1f)
        {
            //moveDirection = moveDirection.normalized;
        }

        // Bewege den Spieler
        rb.velocity = moveDirection * moveSpeed;

        animator.SetFloat("Velocity", rb.velocity.x);

        print(rb.velocity.x);
    }

}