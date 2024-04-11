using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class BrewPotion : MonoBehaviour
{
    [SerializeField] private PlayerInput _inputActions;
    private InputAction _interactAction;
    public bool withinReach = false;

    public GameObject berry;
    public GameObject fish;
    public GameObject stompedBerry;
    public GameObject stompedFish;
    public GameObject bucketFull;

    public GameObject greenPotion;
    public GameObject redPotion;
    public GameObject bluePotion;

    public int ingredientCounter;
    public int blueCounter;
    public int redCounter;
    public int greenCounter;

    public bool hasWater;

    // Start is called before the first frame update
    void Start()
    {
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnBrewingPotion();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnBrewingPotion()
    {
        if (withinReach)
        {
            if(ingredientCounter < 3 && berry.activeSelf)
            {
                berry.SetActive(false);
                redCounter += 1;
                ingredientCounter += 1;
            }
            if (ingredientCounter < 3 && fish.activeSelf)
            {
                fish.SetActive(false);
                blueCounter += 1;
                ingredientCounter += 1;
            }
            if (ingredientCounter < 3 && stompedBerry.activeSelf)
            {
                stompedBerry.SetActive(false);
                blueCounter += 2;
                greenCounter += 1;
                ingredientCounter += 1;
            }
            if (ingredientCounter < 3 && stompedFish.activeSelf)
            {
                stompedFish.SetActive(false);
                redCounter += 2;
                greenCounter += 1;
                ingredientCounter += 1;
            }
            if (ingredientCounter < 3 && bucketFull.activeSelf)
            {
                bucketFull.SetActive(false);
                greenCounter += 1;
                hasWater = true;
                ingredientCounter += 1;
            }
            if(ingredientCounter == 3)
            {
                if (hasWater)
                {
                    if (redCounter == 3)
                    {
                        redPotion.SetActive(true);
                        Debug.Log("Trank Rot erstellt");
                    }
                    if(blueCounter == 3)
                    {
                        bluePotion.SetActive(true);
                        Debug.Log("Trank Blau erstellt");
                    }
                    if(greenCounter == 3)
                    {
                        greenPotion.SetActive(true);
                        Debug.Log("Trank Grün erstellt");
                    }
                    else
                    {
                        Debug.Log("Trank fehlgeschlagen wegen Zutaten");
                    }
                }
                else
                {
                    Debug.Log("Trank fehlgeschlagen wegen Wasser");
                }
                PotionReset();
            }
        }
    }

    void PotionReset()
    {
        blueCounter = 0;
        redCounter = 0;
        greenCounter = 0;
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
}
