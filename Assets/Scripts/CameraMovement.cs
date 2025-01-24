using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement: MonoBehaviour
{
    public Transform player; // Der Spieler, dem die Kamera folgen soll
    public Vector3 offset = new Vector3(0f, 5f, -10f); // Abstand zur Kamera
    public float smoothSpeed = 0.125f; // Glättungsfaktor für die Kamerabewegung

    void LateUpdate()
    {
        if (player != null)
        {
            // Zielposition basierend auf dem Spieler und dem Offset
            Vector3 desiredPosition = player.position + offset;

            // Sanft zur Zielposition interpolieren
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);

            // Kamera auf die geglättete Position setzen
            transform.position = smoothedPosition;

            // Optional: Kamera auf den Spieler ausrichten
            transform.LookAt(player);
        }
    }
}
