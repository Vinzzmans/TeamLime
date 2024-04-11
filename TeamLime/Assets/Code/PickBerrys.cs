using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickBerrys : MonoBehaviour
{
    public GameObject berry;
    public bool withinReach = false;
    private PickFish fishScript; // Referenz auf das PickFish-Skript

    [SerializeField] private PlayerInput _inputActions;
    private InputAction _interactAction;


    void Start()
    {
        fishScript = FindObjectOfType<PickFish>(); // Finde das PickFish-Skript im Spiel

        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnPickUpBerry();
    }

    void OnPickUpBerry()
    {
        // Überprüfe, ob die Taste "Return" gedrückt wurde
        if (withinReach && !berry.activeSelf && !fishScript.IsFishActive())
        {
            berry.SetActive(true);
            Debug.Log("Berry ist am start!!");
        }
    }



    private void OnTriggerEnter2D(Collider2D other)
    {
        // Überprüfe, ob der Spieler sich im Trigger befindet
        if (other.CompareTag("Player2"))
        {
            withinReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // Überprüfe, ob der Spieler den Trigger verlassen hat
        if (other.CompareTag("Player2"))
        {
            withinReach = false;
        }
    }

    // Methode zur Überprüfung, ob der Fisch aktiv ist
    public bool IsBerryActive()
    {
        return berry.activeSelf;
    }
}
