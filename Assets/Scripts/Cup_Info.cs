using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup_Info : MonoBehaviour
{
    public Tea tea_e;
    public float tea_Fill=0;

    public Syrup syrup_e;
    public float syrup_Fill = 0;

    public Bubble bubble_e;
    public float buuble_Fill = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            print("a");
            transform.SetParent(other.transform);
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
                buuble_Fill += fill;
            }
        }
    }
}
