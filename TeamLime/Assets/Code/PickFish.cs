using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickFish : MonoBehaviour
{
    public GameObject fish;
    public GameObject handBucket2;
    public bool withinReach = false;
    private bool isReturning = false;

    [SerializeField] private PlayerInput _inputActions;
    private InputAction _interactAction;

    private PickBerrys berryScript; // Referenz auf das PickBerrys-Skript

    void Start()
    {
        berryScript = FindObjectOfType<PickBerrys>(); // Finde das PickBerrys-Skript im Spiel
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnPickUpFish();
    }

    void OnPickUpFish()
    {
        // Überprüfe, ob die Taste "E" gedrückt wurde
        if (withinReach && !fish.activeSelf && !handBucket2.activeSelf && !isReturning && !berryScript.IsBerryActive())
        {
            StartCoroutine(ActivateFishAfterDelay(2f)); // Starte die Verzögerungsroutine mit einer Verzögerung von 2 Sekunden
        }
    }

    private IEnumerator ActivateFishAfterDelay(float delay)
    {
        isReturning = true; // Markiere den Rückrufprozess als aktiv
        yield return new WaitForSeconds(delay); // Warte für die angegebene Verzögerungszeit
        fish.SetActive(true); // Aktiviere den Fisch
        Debug.Log("Fish ist am start!!");
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

    // Methode zur Überprüfung, ob der Fisch aktiv ist
    public bool IsFishActive()
    {
        return fish.activeSelf;
    }
}

