using System.Collections;
using System.Collections.Generic;
using UnityEditor.ShaderGraph;
using UnityEngine;
using UnityEngine.UI;

public class Cup_Info : MonoBehaviour
{
    [Header("Tea things")]
    
    public Tea tea_e;
    public float tea_Fill=0;
    [SerializeField] Sprite fill0;
    [SerializeField] Sprite fill1;
    [SerializeField] Sprite fill2;
    [SerializeField] Sprite fill3;
    [SerializeField] Sprite fill4;
    [SerializeField] GameObject TeaHolder;

    [Header("Syrup things")]
    public Syrup syrup_e;
    public float syrup_Fill = 0;
    [SerializeField] Sprite Sfill0;
    [SerializeField] Sprite Sfill1;
    [SerializeField] Sprite Sfill2;
    [SerializeField] Sprite Sfill3;
    [SerializeField] Sprite Sfill4;
    [SerializeField] GameObject SyrupHolder;

    [Header("Bubble things")]
    public Bubble bubble_e;
    public float bubble_Fill = 0;
    [SerializeField] Sprite Bfill0;
    [SerializeField] Sprite Bfill1;
    [SerializeField] Sprite Bfill2;
    [SerializeField] Sprite Bfill3;
    [SerializeField] Sprite Bfill4;
    [SerializeField] GameObject BubbleHolder;

    public bool isCupThrow;
    [SerializeField] float DeleteTimer = 1f;

    public Color thai;
    public Color matcha;
    public Color oolong;
    public Color peach;
    public Color choco;
    public Color sugar;
    public Color tapi;
    public Color blue;
    public Color aloe;
    public Color straw;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(isCupThrow)
        {
            DeleteTimer-=Time.deltaTime;
        }

        if(DeleteTimer< 0f)
        {
            Destroy(this); return;
        }
    }

    public void Set_CupThrown(bool isthrown)
    {
        isCupThrow = isthrown;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            print("a");
            transform.SetParent(collision.transform);
            GetComponent<Rigidbody>().isKinematic = true;
            GetComponent<Collider>().isTrigger = true;

            collision.gameObject.GetComponent<ControllerPlayer>().HasPlayerTheCup(true);
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
            TeaHolder.GetComponent<Image>().sprite = fill0;
        }
        if (tea_Fill > 40)
        {
            TeaHolder.GetComponent<Image>().sprite = fill1;
        }
        if (tea_Fill > 60)
        {
            TeaHolder.GetComponent<Image>().sprite = fill2;
        }
        if (tea_Fill > 80)
        {
            TeaHolder.GetComponent<Image>().sprite = fill3;
        }
        if (tea_Fill > 100)
        {
            TeaHolder.GetComponent<Image>().sprite = fill4;
        }

        switch(tea_e)
        {

            case Tea.Peach:
                TeaHolder.GetComponent<Image>().color = new Color32(0,0,0,0);
                break;
            case Tea.Matcha:
                TeaHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

            case Tea.Thai:
                TeaHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

            case Tea.Oolong:
                TeaHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;


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
                SyrupHolder.GetComponent<Image>().sprite = Sfill0;
            }
            if (syrup_Fill > 40)
            {
                SyrupHolder.GetComponent<Image>().sprite = Sfill1;
            }
            if (syrup_Fill > 60)
            {
                SyrupHolder.GetComponent<Image>().sprite = Sfill2;
            }
            if (syrup_Fill > 80)
            {
                SyrupHolder.GetComponent<Image>().sprite = Sfill3;
            }
            if (syrup_Fill > 100)
            {
                SyrupHolder.GetComponent<Image>().sprite = Sfill4;
            }
        }

        switch (syrup_e)
        {
            case Syrup.Chocolate:
                SyrupHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

            case Syrup.Brown_Sugar:
                SyrupHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

            

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
                BubbleHolder.GetComponent<Image>().sprite = Bfill0;
            }
            if (bubble_Fill > 40)
            {
                BubbleHolder.GetComponent<Image>().sprite = Bfill1;
            }
            if (bubble_Fill > 60)
            {
                BubbleHolder.GetComponent<Image>().sprite = Bfill2;
            }
            if (bubble_Fill > 80)
            {
                BubbleHolder.GetComponent<Image>().sprite = Bfill3;
            }
            if (bubble_Fill > 100)
            {
                BubbleHolder.GetComponent<Image>().sprite = Bfill4;
            }
        }

        switch(bubble_e)
        {
            case Bubble.Strawberry:

                BubbleHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

            case Bubble.Blueberry:

                BubbleHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

            case Bubble.Tapioca_Pearls:

                BubbleHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

            case Bubble.Aloe_Vera:

                BubbleHolder.GetComponent<Image>().color = new Color32(0, 0, 0, 0);
                break;

        }
    }
}
