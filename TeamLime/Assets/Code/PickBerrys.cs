using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickBerrys : MonoBehaviour
{
    public GameObject berry;
    public bool withinReach = false;

    private PickFish fishScript; // Referenz auf das PickFish-Skript

    void Start()
    {
        fishScript = FindObjectOfType<PickFish>(); // Finde das PickFish-Skript im Spiel
    }

    void Update()
    {
        // �berpr�fe, ob die Taste "Return" gedr�ckt wurde
        if (Input.GetKeyDown(KeyCode.Return) && withinReach && !berry.activeSelf && !fishScript.IsFishActive())
        {
            berry.SetActive(true);
            Debug.Log("Berry ist am start!!");
        }
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
    public bool IsBerryActive()
    {
        return berry.activeSelf;
    }
}
