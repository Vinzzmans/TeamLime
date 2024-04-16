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

    private AudioSource audioSource;
    public AudioClip pickUpClip;


    void Start()
    {
        berryScript = FindObjectOfType<PickBerrys>(); // Finde das PickBerrys-Skript im Spiel
        fishScript = FindObjectOfType<PickFish>(); // Finde das PickFish-Skript im Spiel
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnPickUpWater();
    audioSource = GetComponentInChildren<AudioSource>();
    }

    void OnPickUpWater()
    {
        // �berpr�fe, ob die Interaktions-Aktion ausgel�st wurde
        if (withinReach && !water.activeSelf && handBucket2.activeSelf && !isReturning && !berryScript.IsBerryActive() && !fishScript.IsFishActive())
        {
            StartCoroutine(ActivateWaterAfterDelay(0f)); // Starte die Verz�gerungsroutine mit einer Verz�gerung von 2 Sekunden
        }
    }

    private IEnumerator ActivateWaterAfterDelay(float delay)
    {
        isReturning = true; // Markiere den R�ckrufprozess als aktiv
        yield return new WaitForSeconds(delay); // Warte f�r die angegebene Verz�gerungszeit
        water.SetActive(true); // Aktiviere das Wasser
        Debug.Log("Wasser ist am start!!");
        audioSource.clip = pickUpClip;
        audioSource.Play();
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

    // Methode zur �berpr�fung, ob das Wasser aktiv ist
    public bool IsWaterActive()
    {
        return water.activeSelf;
    }
}
