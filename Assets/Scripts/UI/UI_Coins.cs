using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UI_Coins : MonoBehaviour
{
    public TMP_Text CoinsText;

    [SerializeField] Color[] ColorOfSprite;
    [SerializeField] public Image[] Orders;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < Orders.Length; i++)
        {
            OrderFinished(i);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Set_TbxCoins(int coins)
    {
        CoinsText.text="Coins:" + coins.ToString();
    }

    public void SetOrderUI(int Index, int tea_index, int Syrup_Index, int Bubble_Index)
    {
        for(int i = 0;i < Orders.Length; i++)
        {
            if (!Orders[i].IsActive())
            {
                Orders[i].transform.GetChild(2).GetComponent<Image>().color = ColorOfSprite[tea_index - 1];
                Orders[i].transform.GetChild(1).GetComponent<Image>().color = ColorOfSprite[Syrup_Index - 1];
                Orders[i].transform.GetChild(0).GetComponent<Image>().color = ColorOfSprite[Bubble_Index - 1];
                Orders[i].enabled = true;

                break;
            }
        }        
    }

    public void OrderFinished(int Index)
    {
        Orders[Index].transform.GetChild(2).GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Orders[Index].transform.GetChild(1).GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Orders[Index].transform.GetChild(0).GetComponent<Image>().color = new Color(0, 0, 0, 0);
        Orders[Index].enabled=false;    
    }
}
