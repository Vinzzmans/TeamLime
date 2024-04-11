using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBucket : MonoBehaviour
{
    public GameObject handBucket;
    public GameObject bucket;
    public GameObject bucketPlace;

    public bool withinReach = false;
    private bool isReturning = false;

    private PickBerrys berryScript; // Referenz auf das PickBerrys-Skript
    private PickFish fishScript; // Referenz auf das PickFish-Skript


    void Start()
    {
        berryScript = FindObjectOfType<PickBerrys>(); // Finde das PickBerrys-Skript im Spiel
        fishScript = FindObjectOfType<PickFish>(); // Finde das PickFish-Skript im Spiel
    }

    void Update()
    {
        // Überprüfe, ob die Taste "E" gedrückt wurde
        if (Input.GetKeyDown(KeyCode.E) && withinReach && !fishScript.IsFishActive())
        {
            if (handBucket.activeSelf)
            {
                // Handeimer deaktivieren
                handBucket.SetActive(false);
                // Eimer aktivieren
                bucket.SetActive(true);
                // Eimerplatz aktivieren
                bucketPlace.SetActive(false);
                Debug.Log("Eimer wurde deaktiviert. Eimerplatz deaktiviert.");
            }
            else
            {
                // Eimer deaktivieren
                bucket.SetActive(false);
                // Handeimer aktivieren
                handBucket.SetActive(true);
                // Eimerplatz deaktivieren
                bucketPlace.SetActive(true);
                Debug.Log("Eimer wurde aktiviert. Eimerplatz aktiviert.");
            }
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Überprüfe, ob der Spieler sich im Trigger befindet
        if (other.CompareTag("Player"))
        {
            withinReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Überprüfe, ob der Spieler den Trigger verlassen hat
        if (other.CompareTag("Player"))
        {
            withinReach = false;
        }
    }
}
