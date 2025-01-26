using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerPlayer : MonoBehaviour
{

    public float moveSpeed = 100; // Bewegungsgeschwindigkeit // Sprungkraft

    [SerializeField] Animator animator;

    private Rigidbody rb;
    public LayerMask groundLayer; // Schicht für den Boden


    [SerializeField] float delay = .3f;
    [SerializeField] float currentDelay;


    bool hasCup;

    public void PlayerHasCup(bool hascup)
    {
        hasCup = hascup;
        animator.SetBool("CupGrabbed", hascup);
    }


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

        //weg werfen
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (transform.childCount != 0)
            {
                RectTransform Index = transform.GetComponentInChildren<RectTransform>();

                Index.GetComponent<Rigidbody>().isKinematic = false;

                Index.transform.SetParent(null);

                //offset 
                //Index.transform.position = new Vector3(transform.position.x,transform.position.y+Index.transform.position.y,transform.position.z);

                Index.localPosition = new Vector3(transform.position.x, 4, transform.position.z);

                if((rb.velocity.z * 120f >0))
                {
                    Index.GetComponent<Rigidbody>().AddForce((new Vector3(rb.velocity.x, rb.velocity.y, 0) * 120f + new Vector3(0, 300, 0)));
                }
                else
                {
                    Index.GetComponent<Rigidbody>().AddForce((rb.velocity * 120f + new Vector3(0, 300, 0)));
                }

                


                PlayerHasCup(false);
            }
        }
        else
        {
           
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

        rb.velocity = moveDirection * moveSpeed;

        animator.SetFloat("Velocity", rb.velocity.x);


    }

}