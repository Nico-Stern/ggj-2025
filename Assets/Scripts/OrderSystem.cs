using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
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
}

public class OrderSystem : MonoBehaviour
{
    public List<Order> orders = new List<Order>();
    [SerializeField] int Max_Orders=3;
    [SerializeField] float NextOrderInSec = 2f;
    [SerializeField] float CurrentOrderTimer;

    // Start is called before the first frame update
    void Start()
    {
        newOrder();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentOrderTimer += Time.deltaTime;
        if(CurrentOrderTimer >= NextOrderInSec)
        {
            CurrentOrderTimer = 0;
            newOrder();
        }
    }

    public void newOrder()
    {
        if (orders.Count < Max_Orders)
        {
            Order Index_Order = new Order();

            // Zufällige Werte für Tee und Sirup generieren
            int rdm_Tea = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(Tea)).Length); // 0 bis Anzahl der Tees
            int rdm_Syrup = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(Syrup)).Length); // 0 bis Anzahl der Sirups
            int rdm_Bubble = UnityEngine.Random.Range(1, System.Enum.GetValues(typeof(Bubble)).Length); 

            // Enum-Zuweisung basierend auf dem Index
            Index_Order.tea = (Tea)rdm_Tea;
            Index_Order.syrup = (Syrup)rdm_Syrup;
            Index_Order.bubble = (Bubble)rdm_Syrup;

            // Füge den neuen Auftrag der Liste hinzu
            orders.Add(Index_Order);
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Cup_Info Cup = other.gameObject.transform.GetChild(0).gameObject.GetComponent<Cup_Info>();

            for (int i = 0; i < orders.Count; i++)
            {
                if (Cup.tea_e == orders[i].tea && Cup.syrup_e == orders[i].syrup && Cup.bubble_e == orders[i].bubble)
                {
                    Destroy(Cup.gameObject);

                    orders.RemoveAt(i);

                    break;
                }
            }
        }
    }
}
