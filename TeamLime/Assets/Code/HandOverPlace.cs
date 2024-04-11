using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandOverPlace : MonoBehaviour
{
    public GameObject berryAtPlayerGarden; // Beere am Spieler 1
    public GameObject berryAtPlayerHome; // Beere am Spieler 2
    public GameObject berryAtPlace; // Beere am HandOverPlace
    public GameObject fishAtPlayerGarden; // Fisch am Spieler 1
    public GameObject fishAtPlayerHome; // Fisch am Spieler 2
    public GameObject fishAtPlace; // Fisch am HandOverPlace

    public GameObject bucketEmptyAtPlayerGarden; // Beere am Spieler 1
    public GameObject bucketEmptyAtPlayerHome; // Beere am Spieler 2
    public GameObject bucketEmptyAtPlace; // Beere am HandOverPlace

    public GameObject bucketFullAtPlayerGarden; // Beere am Spieler 1
    public GameObject bucketFullAtPlayerHome; // Beere am Spieler 2
    public GameObject bucketFullAtPlace; // Beere am HandOverPlace


    public bool withinReach = false;

    [SerializeField] private PlayerInput keyBoardInputActions;
    [SerializeField] private PlayerInput controllerInputActions;
    private InputAction keyBoardInteractAction;
    private InputAction controllerInteractAction;

    private void Start()
    {
        keyBoardInteractAction = keyBoardInputActions.actions["Interact"];
        keyBoardInteractAction.performed += _ => OnKeyboardHandOver();

        controllerInteractAction = controllerInputActions.actions["Interact"];
        controllerInteractAction.performed += _ => OnControllerHandOver();
    }

    void OnKeyboardHandOver()
    {
        if (withinReach)
        {
            if (berryAtPlayerHome.activeSelf && !berryAtPlace.activeSelf)
            {
                berryAtPlace.SetActive(true);
                berryAtPlayerHome.SetActive(false);
                Debug.Log("Spieler 2: Beere wurde am HandOverPlace abgelegt!");
            }
            else if (!berryAtPlayerHome.activeSelf && berryAtPlace.activeSelf)
            {
                berryAtPlace.SetActive(false);
                berryAtPlayerHome.SetActive(true);
                Debug.Log("Spieler 2: Beere vom HandOverPlace genommen!");
            }

            if (fishAtPlayerHome.activeSelf && !fishAtPlace.activeSelf)
            {
                fishAtPlace.SetActive(true);
                fishAtPlayerHome.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!fishAtPlayerHome.activeSelf && fishAtPlace.activeSelf)
            {
                fishAtPlace.SetActive(false);
                fishAtPlayerHome.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }

            if (bucketEmptyAtPlayerGarden.activeSelf && !bucketEmptyAtPlace.activeSelf)
            {
                bucketEmptyAtPlace.SetActive(true);
                bucketEmptyAtPlayerGarden.SetActive(false);
                Debug.Log("Spieler 2: EmptyBucket wurde am HandOverPlace abgelegt!");
            }
            else if (!bucketEmptyAtPlayerGarden.activeSelf && bucketEmptyAtPlace.activeSelf)
            {
                bucketEmptyAtPlace.SetActive(false);
                bucketEmptyAtPlayerGarden.SetActive(true);
                Debug.Log("Spieler 2: EmptyBucket vom HandOverPlace genommen!");
            }

            if (bucketFullAtPlayerGarden.activeSelf && !bucketFullAtPlace.activeSelf)
            {
                bucketFullAtPlace.SetActive(true);
                bucketFullAtPlayerGarden.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!bucketFullAtPlayerGarden.activeSelf && bucketFullAtPlace.activeSelf)
            {
                bucketFullAtPlace.SetActive(false);
                bucketFullAtPlayerGarden.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }
        }
    }

    void OnControllerHandOver()
    {
        if (withinReach)
        {

            if ( berryAtPlayerGarden.activeSelf && !berryAtPlace.activeSelf)
            {
                berryAtPlayerGarden.SetActive(false);
                berryAtPlace.SetActive(true);
                Debug.Log("Spieler 1: Beere wurde am HandOverPlace abgelegt!");
            }
            else if (!berryAtPlayerGarden.activeSelf && berryAtPlace.activeSelf)
            {
                berryAtPlayerGarden.SetActive(true);
                berryAtPlace.SetActive(false);
                Debug.Log("Spieler 1: Beere vom HandOverPlace genommen!");
            }

            if ( fishAtPlayerGarden.activeSelf && !fishAtPlace.activeSelf)
            {
                fishAtPlayerGarden.SetActive(false);
                fishAtPlace.SetActive(true);
                Debug.Log("Spieler 1: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!fishAtPlayerGarden.activeSelf && fishAtPlace.activeSelf)
            {
                fishAtPlayerGarden.SetActive(true);
                fishAtPlace.SetActive(false);
                Debug.Log("Spieler 1: Fisch vom HandOverPlace genommen!");
            }
            if (bucketEmptyAtPlayerHome.activeSelf && !bucketEmptyAtPlace.activeSelf)
            {
                bucketEmptyAtPlace.SetActive(true);
                bucketEmptyAtPlayerHome.SetActive(false);
                Debug.Log("Spieler 2: EmptyBucket wurde am HandOverPlace abgelegt!");
            }
            else if (!bucketEmptyAtPlayerHome.activeSelf && bucketEmptyAtPlace.activeSelf)
            {
                bucketEmptyAtPlace.SetActive(false);
                bucketEmptyAtPlayerHome.SetActive(true);
                Debug.Log("Spieler 2: EmptyBucket vom HandOverPlace genommen!");
            }

            if (bucketFullAtPlayerHome.activeSelf && !bucketFullAtPlace.activeSelf)
            {
                bucketFullAtPlace.SetActive(true);
                bucketFullAtPlayerHome.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!bucketFullAtPlayerHome.activeSelf && bucketFullAtPlace.activeSelf)
            {
                bucketFullAtPlace.SetActive(false);
                bucketFullAtPlayerHome.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }

        }
    }


    // Wenn ein Spieler den Bereich betritt
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Spieler betritt den Bereich!");

        if (other.CompareTag("Player"))
        {
            withinReach = true;
        }
    }

    // Wenn ein Spieler den Bereich verlässt
    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Spieler verlässt den Bereich!");

        if (other.CompareTag("Player"))
        {
            withinReach = false;
        }
    }
}
