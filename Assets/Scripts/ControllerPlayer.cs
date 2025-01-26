using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    public float moveSpeed = 100; // Bewegungsgeschwindigkeit // Sprungkraft
=======
=======
>>>>>>> Stashed changes
    Animator animator;

    public float moveSpeed = 5f; // Bewegungsgeschwindigkeit // Sprungkraft
>>>>>>> Stashed changes

    private Rigidbody rb;
    private bool isGrounded;
    private float groundCheckRadius = 0.2f;
    public LayerMask groundLayer; // Schicht für den Boden

<<<<<<< Updated upstream
<<<<<<< Updated upstream
    Animator animator;

    [SerializeField] float delay = .3f;
    [SerializeField] float currentDelay;

    bool IsTimerRunnig;
=======
=======
>>>>>>> Stashed changes
    bool hasCup;

    public void PlayerHasCup(bool hascup)
    {
        hasCup = hascup;
        animator.SetBool("CupGrabbed", hascup);
    }
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
<<<<<<< Updated upstream
<<<<<<< Updated upstream
    }

    public void HasPlayerTheCup(bool hasCup)
    {
        animator.SetBool("CupGrabbed", hasCup);
=======
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

    void Update()
    {
<<<<<<< Updated upstream
<<<<<<< Updated upstream
=======
        
>>>>>>> Stashed changes
=======
        
>>>>>>> Stashed changes

        Move();

        // Eingaben für die horizontale und vertikale Bewegung
        float moveInput_H = Input.GetAxis("Horizontal"); // -1 bis 1 für links/rechts
        float moveInput_V = Input.GetAxis("Vertical"); // -1 bis 1 für vor/zurück

        // Erzeuge den Bewegungsvektor
        Vector3 moveDirection = new Vector3(moveInput_H, 0f, moveInput_V);

        // Normalisiere den Vektor, falls er eine Länge größer als 1 hat
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

<<<<<<< Updated upstream
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
=======
                Index.GetComponent<Rigidbody>().AddForce(100,300,10);

                PlayerHasCup(false);
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
            }
        }
        //maschine betätigen maybe?
        currentDelay += Time.deltaTime;
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
            //moveDirection = moveDirection.normalized;
        }

        // Bewege den Spieler
<<<<<<< Updated upstream
        rb.velocity = moveDirection * moveSpeed;

        animator.SetFloat("Velocity", rb.velocity.x);

        print(rb.velocity.x);
=======
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);

        animator.SetFloat("Velocity", rb.velocity.x);
<<<<<<< Updated upstream
>>>>>>> Stashed changes
=======
>>>>>>> Stashed changes
    }

}