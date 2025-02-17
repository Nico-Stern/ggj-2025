using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;

[Serializable]
public class Order 
{
    //+ fill?

    [SerializeField] public Tea tea;
    [SerializeField] public Syrup syrup;
    [SerializeField] public Bubble bubble;
    [SerializeField] public float Time;
    [SerializeField] public int Price;
    [SerializeField] public int OrderShield=-1;
}

public class OrderSystem : MonoBehaviour
{
    [Header("Timer")]

    [SerializeField] float GameTimer=5;
    [SerializeField] GameObject WinScreen;
    [SerializeField] TMP_Text CoinsWin;
    [SerializeField] TMP_Text TimerText;


    [Header("Rest")]
    public UI_Coins UI;

    public List<Order> orders = new List<Order>();
    [SerializeField] int Max_Orders=3;
    [SerializeField] float NextOrderInSec = 2f;
    float CurrentOrderTimer;

    [SerializeField] float DrinkTimer = 30f;

    [SerializeField] int CurrentCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        WinScreen.SetActive(false);
        UI = GetComponent<UI_Coins>();
        UI.Set_TbxCoins(CurrentCoins);
    }

    // Update is called once per frame
    void Update()
    {
        GameTimer -= Time.deltaTime;

        {
            if (GameTimer > 0)
            {
                GameTimer -= Time.deltaTime;
            }

            int minutes = Mathf.FloorToInt(GameTimer / 60);
            int seconds = Mathf.FloorToInt(GameTimer % 60);
            TimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }


        if(GameTimer < 0)
        {
            FindObjectOfType<Pause>().PausedGame(true);
            WinScreen.SetActive(true);
            CoinsWin.text = CurrentCoins.ToString();
            TimerText.enabled=false;
        }

        CurrentOrderTimer += Time.deltaTime;
        if(CurrentOrderTimer >= NextOrderInSec)
        {
            CurrentOrderTimer = 0;
            newOrder();
        }

        for(int i=0; i<orders.Count; i++)
        {
            orders[i].Time -= Time.deltaTime;
            if (orders[i].Time <= 0)
            {
                if (CurrentCoins>=2)
                {
                    //CurrentCoins -= 2;
                }

                UI.OrderFinished(orders[i].OrderShield);
                orders.RemoveAt(i);
            }
        }

        for(int i=0;i<3; i++)
        {
            UI.UpdateSlider(orders[i].OrderShield, DrinkTimer, orders[i].Time);

        }
    }

    public void newOrder()
    {
        if (orders.Count < Max_Orders)
        {
            Order Index_Order = new Order();

            // Zuf�llige Werte f�r Tee und Sirup generieren
            int rdm_Tea = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(Tea)).Length); // 0 bis Anzahl der Tees
            int rdm_Syrup = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(Syrup)).Length); // 0 bis Anzahl der Sirups
            int rdm_Bubble = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(Bubble)).Length); 
            int rdm_Coins = UnityEngine.Random.Range(1, 6); 



            // Enum-Zuweisung basierend auf dem Index
            Index_Order.tea = (Tea)rdm_Tea;
            Index_Order.syrup = (Syrup)rdm_Syrup;
            Index_Order.bubble = (Bubble)rdm_Bubble;

            Index_Order.Price = rdm_Coins;

            Index_Order.Time = DrinkTimer;

            List<int> indexes = new List<int>();
            indexes.Add(0);
            indexes.Add(1);
            indexes.Add(2);

            // F�ge den neuen Auftrag der Liste hinzu
            orders.Add(Index_Order);

            for (int i = 0; i < 3; i++)
            {
                print("in " + i);

                if (orders[i].OrderShield == 0 || orders[i].OrderShield == 1 || orders[i].OrderShield == 2)
                {
                    indexes.Remove(orders[i].OrderShield);
                    print("remove " + orders[i].OrderShield);
                    
                }
                else
                {
                    break;
                }
            }


            Index_Order.OrderShield = indexes[0];



            UI.SetOrderUI(orders.Count-1, rdm_Tea, rdm_Syrup, rdm_Bubble, indexes[0]);

            print(Index_Order.OrderShield);
            UI.SetCoinsUI(Index_Order.OrderShield, Index_Order.Price);




        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cup_Info Cup = other.gameObject.transform.GetChild(1).gameObject.GetComponent<Cup_Info>();

            for (int i = 0; i < orders.Count; i++)
            {
                if (Cup.tea_e == orders[i].tea && Cup.syrup_e == orders[i].syrup && Cup.bubble_e == orders[i].bubble)
                {
                    Destroy(Cup.gameObject);

                    CurrentCoins+= orders[i].Price;
                    UI.Set_TbxCoins(CurrentCoins);

                    orders.RemoveAt(i);

                    other.gameObject.GetComponent<ControllerPlayer>().HasPlayerTheCup(false);

                    UI.OrderFinished(i);

                    break;
                }
            }
        }
    }
}
