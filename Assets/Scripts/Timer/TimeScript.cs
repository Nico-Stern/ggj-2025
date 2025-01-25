using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timerText;
    float elapsedTime;
    // Update is called once per frame
    void Update()
    {
        elapsedTime += Time.deltaTime;
        timerText.text = elapsedTime.ToString();
    }
}
