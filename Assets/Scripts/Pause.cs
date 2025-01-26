using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pause : MonoBehaviour
{
    ControllerPlayer player;
    bool IsGamePaused = false;

    Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<ControllerPlayer>();
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyUp(KeyCode.Escape))
        {
            if(!IsGamePaused)
            {
                IsGamePaused = true;
                player.enabled = false;
                canvas.enabled = true;
            }
            else
            {
                IsGamePaused = false;
                player.enabled = true;
                canvas.enabled = false;
            }
        }
    }

    public void PausedGame(bool IsGamePaused)
    {
        IsGamePaused = IsGamePaused;
        player.enabled = !IsGamePaused;
        canvas.enabled = IsGamePaused;
    }
}
