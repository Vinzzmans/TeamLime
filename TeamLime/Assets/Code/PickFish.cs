using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFish : MonoBehaviour
{
    public GameObject fish;
    public bool withinReach = false;
    private bool isReturning = false;

    private PickBerrys berryScript; // Referenz auf das PickBerrys-Skript

    void Start()
    {
        berryScript = FindObjectOfType<PickBerrys>(); // Finde das PickBerrys-Skript im Spiel
    }

    void Update()
    {
        // �berpr�fe, ob die Taste "E" gedr�ckt wurde
        if (Input.GetKeyDown(KeyCode.Return) && withinReach && !fish.activeSelf && !isReturning && !berryScript.IsBerryActive())
        {
            StartCoroutine(ActivateFishAfterDelay(2f)); // Starte die Verz�gerungsroutine mit einer Verz�gerung von 2 Sekunden
        }
    }

    private IEnumerator ActivateFishAfterDelay(float delay)
    {
        isReturning = true; // Markiere den R�ckrufprozess als aktiv
        yield return new WaitForSeconds(delay); // Warte f�r die angegebene Verz�gerungszeit
        fish.SetActive(true); // Aktiviere den Fisch
        Debug.Log("Fish ist am start!!");
        isReturning = false; // Markiere den R�ckrufprozess als abgeschlossen
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �berpr�fe, ob der Spieler sich im Trigger befindet
        if (other.CompareTag("Player"))
        {
            withinReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // �berpr�fe, ob der Spieler den Trigger verlassen hat
        if (other.CompareTag("Player"))
        {
            withinReach = false;
        }
    }

    // Methode zur �berpr�fung, ob der Fisch aktiv ist
    public bool IsFishActive()
    {
        return fish.activeSelf;
    }
}

