using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PickBucket : MonoBehaviour
{
    public GameObject handBucket;
    public GameObject bucket;
    public GameObject bucketPlace;

    [SerializeField] private PlayerInput _inputActions;
    private InputAction _interactAction;

    public bool withinReach = false;
    private bool isReturning = false;

    private PickBerrys berryScript; // Referenz auf das PickBerrys-Skript
    private PickFish fishScript; // Referenz auf das PickFish-Skript


    void Start()
    {
        berryScript = FindObjectOfType<PickBerrys>(); // Finde das PickBerrys-Skript im Spiel
        fishScript = FindObjectOfType<PickFish>(); // Finde das PickFish-Skript im Spiel

        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnBucketPickUp();
    }

    void OnBucketPickUp()
    {
        // �berpr�fe, ob die Taste "E" gedr�ckt wurde
        if (withinReach)
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

    // Methode zur �berpr�fung, ob das Wasser aktiv ist
    public bool IsHandBucketActive()
    {
        return handBucket.activeSelf;
    }
}
