using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickWater : MonoBehaviour
{
    public GameObject water;
    public GameObject handBucket2;
    public bool withinReach = false;
    private bool isReturning = false;

    [SerializeField] private PlayerInput _inputActions;
    private InputAction _interactAction;

    private PickBerrys berryScript; // Referenz auf das PickBerrys-Skript
    private PickFish fishScript; // Referenz auf das PickFish-Skript

    void Start()
    {
        berryScript = FindObjectOfType<PickBerrys>(); // Finde das PickBerrys-Skript im Spiel
        fishScript = FindObjectOfType<PickFish>(); // Finde das PickFish-Skript im Spiel
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnPickUpWater();
    }

    void OnPickUpWater()
    {
        // Überprüfe, ob die Interaktions-Aktion ausgelöst wurde
        if (withinReach && !water.activeSelf && handBucket2.activeSelf && !isReturning && !berryScript.IsBerryActive() && !fishScript.IsFishActive())
        {
            StartCoroutine(ActivateWaterAfterDelay(2f)); // Starte die Verzögerungsroutine mit einer Verzögerung von 2 Sekunden
        }
    }

    private IEnumerator ActivateWaterAfterDelay(float delay)
    {
        isReturning = true; // Markiere den Rückrufprozess als aktiv
        yield return new WaitForSeconds(delay); // Warte für die angegebene Verzögerungszeit
        water.SetActive(true); // Aktiviere das Wasser
        Debug.Log("Wasser ist am start!!");
        isReturning = false; // Markiere den Rückrufprozess als abgeschlossen
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

    // Methode zur Überprüfung, ob das Wasser aktiv ist
    public bool IsWaterActive()
    {
        return water.activeSelf;
    }
}
