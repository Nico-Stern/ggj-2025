using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : MonoBehaviour
{

    [SerializeField] Machine_Enum machine_Type;

    // Start is called before the first frame update
    void Start()
    {
        if(machine_Type == Machine_Enum.None)
        {
            print(gameObject.name + "not set");
        }
    }

    public void FillCup(bool isFilling)
    {
        if(isFilling)
        {

        }
        else
        {
            
        }
    }
}
