using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup_Info : MonoBehaviour
{
    [Header("Tea things")]
    
    public Tea tea_e;
    public float tea_Fill=0;
    [SerializeField] Material fill0;
    [SerializeField] Material fill1;
    [SerializeField] Material fill2;
    [SerializeField] Material fill3;
    [SerializeField] Material fill4;

    [Header("Syrup things")]
    public Syrup syrup_e;
    public float syrup_Fill = 0;
    [SerializeField] Material Sfill0;
    [SerializeField] Material Sfill1;
    [SerializeField] Material Sfill2;
    [SerializeField] Material Sfill3;
    [SerializeField] Material Sfill4;
    [SerializeField] GameObject SyrupHolder;

    [Header("Bubble things")]
    public Bubble bubble_e;
    public float bubble_Fill = 0;
    [SerializeField] Material Bfill0;
    [SerializeField] Material Bfill1;
    [SerializeField] Material Bfill2;
    [SerializeField] Material Bfill3;
    [SerializeField] Material Bfill4;
    [SerializeField] GameObject BubbleHolder;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("a");
            transform.SetParent(collision.transform);
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;
<<<<<<< Updated upstream
<<<<<<< Updated upstream

            collision.gameObject.GetComponent<ControllerPlayer>().HasPlayerTheCup(true);
=======
            collision.gameObject.GetComponent<ControllerPlayer>().PlayerHasCup(true);
>>>>>>> Stashed changes
=======
            collision.gameObject.GetComponent<ControllerPlayer>().PlayerHasCup(true);
>>>>>>> Stashed changes
        }
    }

    public void FillTea(Tea Machine_tea, float fill)
    {
        if(tea_e == Tea.none)
        {
            tea_e = Machine_tea;
        }
        else
        {
            if(tea_e == Machine_tea)
            {
                tea_Fill += fill;
            }
        }

        if(tea_Fill > 0)
        {
            
        }
        if (tea_Fill > 20)
        {
            SyrupHolder.GetComponent<Renderer>().material = fill0;
        }
        if (tea_Fill > 40)
        {
            SyrupHolder.GetComponent<Renderer>().material = fill1;
        }
        if (tea_Fill > 60)
        {
            SyrupHolder.GetComponent<Renderer>().material = fill2;
        }
        if (tea_Fill > 80)
        {
            SyrupHolder.GetComponent<Renderer>().material = fill3;
        }
        if (tea_Fill > 100)
        {
            SyrupHolder.GetComponent<Renderer>().material = fill4;
        }
    }

    public void FillSyrup(Syrup Machine_syrup, float fill)
    {
        if (syrup_e == Syrup.none)
        {
            syrup_e = Machine_syrup;
        }
        else
        {
            if (syrup_e == Machine_syrup)
            {
                syrup_Fill += fill;
            }

            if (syrup_Fill > 0)
            {

            }
            if (syrup_Fill > 20)
            {
                GetComponent<Renderer>().material = Sfill0;
            }
            if (syrup_Fill > 40)
            {
                GetComponent<Renderer>().material = Sfill1;
            }
            if (syrup_Fill > 60)
            {
                GetComponent<Renderer>().material = Sfill2;
            }
            if (syrup_Fill > 80)
            {
                GetComponent<Renderer>().material = Sfill3;
            }
            if (syrup_Fill > 100)
            {
                GetComponent<Renderer>().material = Sfill4;
            }
        }
    }

    public void FillBubble(Bubble Machine_bubble, float fill)
    {
        if (bubble_e == Bubble.none)
        {
            bubble_e = Machine_bubble;
        }
        else
        {
            if (bubble_e == Machine_bubble)
            {
                bubble_Fill += fill;
            }

            if (bubble_Fill > 0)
            {

            }
            if (bubble_Fill > 20)
            {
                BubbleHolder.GetComponent<Renderer>().material = Bfill0;
            }
            if (bubble_Fill > 40)
            {
                BubbleHolder.GetComponent<Renderer>().material = Bfill1;
            }
            if (bubble_Fill > 60)
            {
                BubbleHolder.GetComponent<Renderer>().material = Bfill2;
            }
            if (bubble_Fill > 80)
            {
                BubbleHolder.GetComponent<Renderer>().material = Bfill3;
            }
            if (bubble_Fill > 100)
            {
                BubbleHolder.GetComponent<Renderer>().material = Bfill4;
            }
        }
    }
}
