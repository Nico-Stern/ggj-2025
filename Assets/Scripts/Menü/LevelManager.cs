using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    // Funktion zum Laden eines Levels
    public void LoadLevel(string levelName)
    {
        if (string.IsNullOrEmpty(levelName))
        {
            Debug.LogError("Levelname ist leer oder null!");
            return;
        }
       
        // Überprüfen, ob die Szene existiert
        if (Application.CanStreamedLevelBeLoaded(levelName))
        {
            LoadLevel(levelName);
        }
        else
        {
            Debug.LogError($"Die Szene '{levelName}' existiert nicht oder ist nicht im Build enthalten.");
        }
    }
}
