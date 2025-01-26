using System.Collections;
using System.Collections.Generic;
using UnityEditor.Build.Player;
using UnityEngine;

public class Machine : MonoBehaviour
{

    [SerializeField] Machine_Enum machine_Type;

    [SerializeField] Tea tea;
    [SerializeField] Syrup syrup;
    [SerializeField] Bubble bubble;
    GameObject Player_Object;

    [SerializeField] float FillSpeed = 5f;
    bool isfilling;

    [SerializeField] Sprite []Tea_Sprite;
    [SerializeField] Sprite []Syrup_Sprite;
    [SerializeField] Sprite []Bubble_Sprite;
    [SerializeField] Material []Bubble_M;


    

    [SerializeField] SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        Player_Object = FindObjectOfType<ControllerPlayer>().gameObject;

        if(machine_Type == Machine_Enum.None)
        {
            print(gameObject.name + "not set");
        }

        switch(machine_Type)
        {
            case Machine_Enum.None:
                print(gameObject.name + " need a fill enum");
                break;

            case Machine_Enum.Tea:
                syrup = Syrup.none;
                bubble = Bubble.none;
                

                sr.sprite = Tea_Sprite[((int)tea)-1] ;
                break;

            case Machine_Enum.Syrup:
                tea = Tea.none;
                bubble = Bubble.none;
                

                sr.sprite = Syrup_Sprite[((int)syrup)-1];//
                break;

            case Machine_Enum.Bubble:
                syrup = Syrup.none;
                tea = Tea.none;


                sr.sprite = Bubble_Sprite[((int)bubble)-1];

                if (CompareTag("boba"))
                {
                    transform.GetChild(0).GetComponent<Renderer>().material = Bubble_M[((int)bubble) - 1];
                }
                break;
        }
    }

    private void Update()
    {
        if (isfilling)
        {

            float speed = Time.deltaTime * FillSpeed;

            if (Player_Object.transform.childCount != 0)
            {
                //play animation
                switch (machine_Type)
                {
                    case Machine_Enum.None:
                        break;
                    case Machine_Enum.Tea:
                        Player_Object.GetComponentInChildren<Cup_Info>().FillTea(tea,speed);
                        
                        break;
                    case Machine_Enum.Syrup:
                        Player_Object.GetComponentInChildren<Cup_Info>().FillSyrup(syrup, speed);
                        
                        break;
                    case Machine_Enum.Bubble:
                        Player_Object.GetComponentInChildren<Cup_Info>().FillBubble(bubble, speed);
                        
                        break;
                }
            }
        }
    }

    public void FillCup(bool hasToFill)
    {
        isfilling = hasToFill;
        print("boba filling");
    }
}
