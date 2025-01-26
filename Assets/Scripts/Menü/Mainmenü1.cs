using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Integration Scene
using UnityEngine.SceneManagement;

public class Mainmenü1: MonoBehaviour
{
    public string sceneName;
    // Start is called before the first frame update
    public void StartNew()
    {
        //New Scene - Spiel starten
        SceneManager.LoadScene(0);
    }

}
