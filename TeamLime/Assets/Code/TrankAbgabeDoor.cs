using UnityEngine;
using UnityEngine.InputSystem;

public class TrankAbgabeDoor : MonoBehaviour
{
    public GameObject trankRot;
    public GameObject trankBlau;
    public GameObject trankGreen;

    private BestellungManager bestellungManager; 
    private bool withinReach = false; 

    [SerializeField] private PlayerInput _inputActions;
    private InputAction _interactAction;

    void Start()
    {
        bestellungManager = FindObjectOfType<BestellungManager>(); // Finde den BestellungManager im Spiel
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnTrankAbgeben();
    }

    void OnTrankAbgeben()
    {
        // Überprüfe, ob die Taste "Return" gedrückt wurde und der Spieler sich in Reichweite befindet
        if (withinReach)
        {
            // Überprüfe, welcher Trank aktiv ist und setze den entsprechenden Index
            int trankIndex = -1; // -1 als Standardwert
            if (trankRot.activeSelf)
                trankIndex = trankRot.GetComponent<TrankIndex>().trankIndex;
            else if (trankBlau.activeSelf)
                trankIndex = trankBlau.GetComponent<TrankIndex>().trankIndex;
            else if (trankGreen.activeSelf)
                trankIndex = trankGreen.GetComponent<TrankIndex>().trankIndex;

            if (trankIndex != -1)
            {
                // Rufe die Methode TrankAbgeben im BestellungManager auf
                bestellungManager.TrankAbgeben(trankIndex);

                trankRot.SetActive(false);
                trankBlau.SetActive(false);
                trankGreen.SetActive(false);

            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Überprüfe, ob der Spieler sich im Trigger befindet
        if (other.CompareTag("Player2"))
        {
            withinReach = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Überprüfe, ob der Spieler den Trigger verlassen hat
        if (other.CompareTag("Player2"))
        {
            withinReach = false;
        }
    }
}
