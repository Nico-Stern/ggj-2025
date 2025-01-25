using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Renderer renderer;
    int currentFrame;

    [SerializeField] float AnimationSpeed = .07f;
    float currentTimer;

    [SerializeField] Material[] A_CarryRun;

    // Start is called before the first frame update
    void Start()
    {
        renderer = GetComponent<Renderer>();
        renderer.material = A_CarryRun[0];
        currentTimer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        currentTimer +=Time.deltaTime;
        if (currentTimer>=AnimationSpeed)
        {
            currentTimer = 0;
            currentFrame++;
            if(currentFrame>8)
            {
                currentFrame = 0;
            }

            renderer.material = A_CarryRun[currentFrame];  
        }
    }
}
