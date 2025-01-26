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
    [SerializeField] List<Slider> SliderList = new List<Slider>();

    [SerializeField] TMP_Text[] CoinText;

    // Start is called before the first frame update
    void Awake()
    {
        for (int i = 0; i < Orders.Length; i++)
        {
            OrderFinished(i);
        }

        for(int i=0; i<Orders.Length; i++)
        {
            SliderList.Add(Orders[i].transform.GetComponentInChildren<Slider>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetCoinsUI(int Index, int coins)
    {
        CoinText[Index].text = coins.ToString();
    }

    public void UpdateSlider(int SliderIndex, float maxTimer, float currentTimer)
    {
        if (Orders[SliderIndex].IsActive())
        {
            SliderList[SliderIndex].value = currentTimer;
            SliderList[SliderIndex].maxValue = maxTimer;
        }

    }

    public void Set_TbxCoins(int coins)
    {
        CoinsText.text="Coins:" + coins.ToString();
    }

    public void SetOrderUI(int Index, int tea_index, int Syrup_Index, int Bubble_Index, int OrderShield)
    {

        Orders[OrderShield].transform.GetChild(2).GetComponent<Image>().color = ColorOfSprite[tea_index - 1];
        Orders[OrderShield].transform.GetChild(1).GetComponent<Image>().color = ColorOfSprite[Syrup_Index - 1];
        Orders[OrderShield].transform.GetChild(0).GetComponent<Image>().color = ColorOfSprite[Bubble_Index - 1];
        Orders[OrderShield].gameObject.active = true;

       
    }

    public void OrderFinished(int Index)
    {
        Orders[Index].gameObject.active=false;    
    }
}
