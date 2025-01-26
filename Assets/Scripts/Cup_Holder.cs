using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cup_Holder : MonoBehaviour
{

    ControllerPlayer Player;
    [SerializeField] GameObject Cup;

    // Start is called before the first frame update
    void Start()
    {
        Player = FindObjectOfType<ControllerPlayer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")&&other.gameObject.transform.childCount<2)
        {
            // Erstelle eine Instanz des Cups über dem Spieler
            GameObject IndexCup = Instantiate(
                Cup,
                Player.transform.position , // Position: etwas über dem Spieler
                Quaternion.identity // Rotation: korrekt ausgerichtet
            );

            // Setze den Spieler als Elternobjekt des Cups
            IndexCup.transform.SetParent(Player.transform);
            

            // Passe die lokale Position des Cups an, damit er immer über dem Spieler bleibt
            IndexCup.transform.localPosition = new Vector3(1.3f, 9.5f, 0); // 2 Einheiten über dem Spieler

            IndexCup.transform.localScale = Vector3.one;

            Player.PlayerHasCup(true);
        }
    }

}
