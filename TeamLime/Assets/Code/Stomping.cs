using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Stomping : MonoBehaviour
{
    public bool withinReach = false;

    public GameObject berryAtPlayerHome;
    public GameObject fishAtPlayerHome;
    public GameObject stick;

    public GameObject stompedBerryAtHome;
    public GameObject stompedFishAtHome;

    private bool isBerry = false;
    private bool isFish = false;

    [SerializeField] private PlayerInput _inputActions;
    private InputAction _interactAction;
    private PickFish fishScript;
    private PickBerrys berryScript;

    public int stompingProgress = 0;
    // Start is called before the first frame update
    void Start()
    {
        fishScript = FindObjectOfType<PickFish>();

        _interactAction = _inputActions.actions["Interact"];
        _interactAction.performed += _ => OnStomping();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnStomping()
    {
        if(stompingProgress == 0)
        {

            if(withinReach && berryAtPlayerHome.activeInHierarchy)
            {
                berryAtPlayerHome.SetActive(false);
           
                isBerry = true;
                stompingProgress += 1;
                Debug.Log("Berry reingeworfen");
            }
            if (withinReach && fishAtPlayerHome.activeInHierarchy)
            {
                fishAtPlayerHome.SetActive(false);
              
                isFish = true;
                stompingProgress += 1;
            }
        }
        else if (stompingProgress == 11)
        {
            if (isBerry)
            {
                stompedBerryAtHome.SetActive(true);
                stompingProgress = 0;
                isBerry = false;

            }
            if (isFish)
            {
                stompedFishAtHome.SetActive(true);
                stompingProgress = 0;
                isFish = false;
            }

        }
        else
        {
            stompingProgress += 1;
            stick.SetActive(true);
        }
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
