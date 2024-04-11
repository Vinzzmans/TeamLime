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


    public GameObject redPotionHome; // Beere am Spieler 2
    public GameObject bluePotionHome; // Beere am Spieler 2
    public GameObject greenPotionHome; // Beere am Spieler 2

    public GameObject redPotionGarden; // Beere am Spieler 1
    public GameObject bluePotionGarden; // Beere am Spieler 1
    public GameObject greenPotionGarden; // Beere am Spieler 1

    public GameObject redPotionPlace; // Beere am HandOverPlace
    public GameObject bluePotionPlace; // Beere am HandOverPlace
    public GameObject greenPotionPlace; // Beere am HandOverPlace


    public bool withinReach = false;
    public bool withinReach2 = false;

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
                Debug.Log("Spieler 2: BucketFull wurde am HandOverPlace abgelegt!");
            }
            else if (!bucketFullAtPlayerHome.activeSelf && bucketFullAtPlace.activeSelf)
            {
                bucketFullAtPlace.SetActive(false);
                bucketFullAtPlayerHome.SetActive(true);
                Debug.Log("Spieler 2: BucketFull vom HandOverPlace genommen!");
            }

            //Potion Stuff
            if (redPotionHome.activeSelf && !redPotionPlace.activeSelf)
            {
                redPotionPlace.SetActive(true);
                redPotionHome.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!redPotionHome.activeSelf && redPotionPlace.activeSelf)
            {
                redPotionPlace.SetActive(false);
                redPotionHome.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }

            if (bluePotionHome.activeSelf && !bluePotionPlace.activeSelf)
            {
                bluePotionPlace.SetActive(true);
                bluePotionHome.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!bluePotionHome.activeSelf && bluePotionPlace.activeSelf)
            {
                bluePotionPlace.SetActive(false);
                bluePotionHome.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }

            if (greenPotionHome.activeSelf && !greenPotionPlace.activeSelf)
            {
                greenPotionPlace.SetActive(true);
                greenPotionHome.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!greenPotionHome.activeSelf && greenPotionPlace.activeSelf)
            {
                greenPotionPlace.SetActive(false);
                greenPotionHome.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }
        }
    }

    void OnControllerHandOver()
    {
        if (withinReach2)
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

            /////Potion Stuff
            if (redPotionGarden.activeSelf && !redPotionPlace.activeSelf)
            {
                redPotionPlace.SetActive(true);
                redPotionGarden.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!redPotionGarden.activeSelf && redPotionPlace.activeSelf)
            {
                redPotionPlace.SetActive(false);
                redPotionGarden.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }

            if (bluePotionGarden.activeSelf && !bluePotionPlace.activeSelf)
            {
                bluePotionPlace.SetActive(true);
                bluePotionGarden.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!bluePotionGarden.activeSelf && bluePotionPlace.activeSelf)
            {
                bluePotionPlace.SetActive(false);
                bluePotionGarden.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }

            if (greenPotionGarden.activeSelf && !greenPotionPlace.activeSelf)
            {
                greenPotionPlace.SetActive(true);
                greenPotionGarden.SetActive(false);
                Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
            }
            else if (!greenPotionGarden.activeSelf && greenPotionPlace.activeSelf)
            {
                greenPotionPlace.SetActive(false);
                greenPotionGarden.SetActive(true);
                Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
            }
        }
    }


    // Wenn ein Spieler den Bereich betritt
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            withinReach = true;
            Debug.Log("Spieler1 betritt den Bereich!");
        }
        if (other.CompareTag("Player2"))
        {
            withinReach2 = true;
            Debug.Log("Spieler2 betritt den Bereich!");
        }

    }

    // Wenn ein Spieler den Bereich verlässt
    private void OnTriggerExit2D(Collider2D other)
    {

        if (other.CompareTag("Player"))
        {
            withinReach = false;
            Debug.Log("Spieler1 verlässt den Bereich!");
        }

        if (other.CompareTag("Player2"))
        {
            withinReach2 = false;
            Debug.Log("Spieler2 verlässt den Bereich!");
        }
    }
}
