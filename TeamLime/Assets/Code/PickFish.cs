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

    private AudioSource audioSource;
    public AudioClip pickUpClip;


    void Start()
    {
        berryScript = FindObjectOfType<PickBerrys>(); // Finde das PickBerrys-Skript im Spiel
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnPickUpFish();
    audioSource = GetComponentInChildren<AudioSource>();
    }

    void OnPickUpFish()
    {
        // �berpr�fe, ob die Taste "E" gedr�ckt wurde
        if (withinReach && !fish.activeSelf && !handBucket2.activeSelf && !isReturning && !berryScript.IsBerryActive())
        {
            StartCoroutine(ActivateFishAfterDelay(0f)); // Starte die Verz�gerungsroutine mit einer Verz�gerung von 2 Sekunden
        }
    }

    private IEnumerator ActivateFishAfterDelay(float delay)
    {
        isReturning = true; // Markiere den R�ckrufprozess als aktiv
        yield return new WaitForSeconds(delay); // Warte f�r die angegebene Verz�gerungszeit
        fish.SetActive(true); // Aktiviere den Fisch
        audioSource.clip = pickUpClip;
        audioSource.Play();
        Debug.Log("Fish ist am start!!");
        isReturning = false; // Markiere den R�ckrufprozess als abgeschlossen
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        // �berpr�fe, ob der Spieler sich im Trigger befindet
        if (other.CompareTag("Player2"))
        {
            withinReach = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        // �berpr�fe, ob der Spieler den Trigger verlassen hat
        if (other.CompareTag("Player2"))
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

