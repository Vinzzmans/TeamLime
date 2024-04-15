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

    private bool isReturning = false;

    private AudioSource audioSource;
    public AudioClip failClip;
    public AudioClip sucessClip;
    public AudioClip blubberClip;


    // Start is called before the first frame update
    void Start()
    {
        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnBrewingPotion();
        audioSource = GetComponentInChildren<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    void OnBrewingPotion()
    {
        if (withinReach && !isReturning)
        {
            if (ingredientCounter < 3 && berry.activeSelf)
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
            if (ingredientCounter == 3)
            {
                StartCoroutine(ActivatePotionAfterDelay(4f)); // Starte die Verzögerungsroutine mit einer Verzögerung von 2 Sekunden
                audioSource.clip = blubberClip;
                audioSource.Play();
            }
        }
    }

    private IEnumerator ActivatePotionAfterDelay(float delay)
    {
        isReturning = true; // Markiere den Rückrufprozess als aktiv
        yield return new WaitForSeconds(delay); // Warte für die angegebene Verzögerungszeit
        audioSource.Stop();

                if (hasWater)
                {
                    if (redCounter == 3)
                    {
                        redPotion.SetActive(true);
                        Debug.Log("Trank Rot erstellt");
                        PotionReset();
                    audioSource.clip = sucessClip;
                    audioSource.Play();
                }
                    else if(blueCounter == 3)
                    {
                        bluePotion.SetActive(true);
                        Debug.Log("Trank Blau erstellt");
                        PotionReset();
                    audioSource.clip = sucessClip;
                    audioSource.Play();
                }
                    else if(greenCounter == 3)
                    {
                        greenPotion.SetActive(true);
                        Debug.Log("Trank Grün erstellt");
                        PotionReset();
                    audioSource.clip = sucessClip;
                    audioSource.Play();

                }
                    else
                    {
                        Debug.Log("Trank fehlgeschlagen wegen Zutaten");
                        PotionReset();
                    audioSource.clip = failClip;
                    audioSource.Play();
                }
                }
                else
                {
                    Debug.Log("Trank fehlgeschlagen wegen Wasser");
                    PotionReset();

                audioSource.clip = failClip;
                audioSource.Play();
            }
                //PotionReset();


        isReturning = false; // Markiere den Rückrufprozess als abgeschlossen
       
    }


    void PotionReset()
    {
        blueCounter = 0;
        redCounter = 0;
        greenCounter = 0;
        ingredientCounter = 0;
        hasWater = false;
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
