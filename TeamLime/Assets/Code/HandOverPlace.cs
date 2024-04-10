using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandOverPlace : MonoBehaviour
{
    public GameObject berryAtPlayerGarden; // Beere am Spieler 1
    public GameObject berryAtPlayerHome; // Beere am Spieler 2
    public GameObject berryAtPlace; // Beere am HandOverPlace
    public GameObject fishAtPlayerGarden; // Fisch am Spieler 1
    public GameObject fishAtPlayerHome; // Fisch am Spieler 2
    public GameObject fishAtPlace; // Fisch am HandOverPlace

    public bool withinReach = false;

    private bool isReturnPressed = false;
    private bool isEPressed = false;

    void Update()
    {
        if (withinReach)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                isReturnPressed = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                isEPressed = true;
            }

            if (isReturnPressed && berryAtPlayerGarden.activeSelf && !berryAtPlace.activeSelf)
            {
                PlayerGardenPlaceBerry();
            }
            else if (isReturnPressed && !berryAtPlayerGarden.activeSelf && berryAtPlace.activeSelf)
            {
                PlayerGardenTakeBerry();
            }

            if (isEPressed && berryAtPlayerHome.activeSelf && !berryAtPlace.activeSelf)
            {
                PlayerHomePlaceBerry();
            }
            else if (isEPressed && !berryAtPlayerHome.activeSelf && berryAtPlace.activeSelf)
            {
                PlayerHomeTakeBerry();
            }

            if (isReturnPressed && fishAtPlayerGarden.activeSelf && !fishAtPlace.activeSelf)
            {
                PlayerGardenPlaceFish();
            }
            else if (isReturnPressed && !fishAtPlayerGarden.activeSelf && fishAtPlace.activeSelf)
            {
                PlayerGardenTakeFish();
            }

            if (isEPressed && fishAtPlayerHome.activeSelf && !fishAtPlace.activeSelf)
            {
                PlayerHomePlaceFish();
            }
            else if (isEPressed && !fishAtPlayerHome.activeSelf && fishAtPlace.activeSelf)
            {
                PlayerHomeTakeFish();
            }
        }

        isReturnPressed = false;
        isEPressed = false;
    }

    // Spieler 1: Beere am Spieler 1 ablegen
    public void PlayerGardenPlaceBerry()
    {
        if (Input.GetKeyDown(KeyCode.Return) && withinReach && berryAtPlayerGarden.activeSelf && !berryAtPlace.activeSelf)
        {
            berryAtPlayerGarden.SetActive(false);
            berryAtPlace.SetActive(true);
            Debug.Log("Spieler 1: Beere wurde am HandOverPlace abgelegt!");
        }
    }

    // Spieler 1: Beere vom HandOverPlace nehmen
    public void PlayerGardenTakeBerry()
    {
        if (Input.GetKeyDown(KeyCode.Return) && withinReach && !berryAtPlayerGarden.activeSelf && berryAtPlace.activeSelf)
        {
            berryAtPlayerGarden.SetActive(true);
            berryAtPlace.SetActive(false);
            Debug.Log("Spieler 1: Beere vom HandOverPlace genommen!");
        }
    }

    // Spieler 2: Beere am Spieler 2 ablegen
    public void PlayerHomePlaceBerry()
    {
        if (Input.GetKeyDown(KeyCode.E) && withinReach && berryAtPlayerHome.activeSelf && !berryAtPlace.activeSelf)
        {
            berryAtPlace.SetActive(true);
            berryAtPlayerHome.SetActive(false);
            Debug.Log("Spieler 2: Beere wurde am HandOverPlace abgelegt!");
        }
    }

    // Spieler 2: Beere vom HandOverPlace nehmen
    public void PlayerHomeTakeBerry()
    {
        if (Input.GetKeyDown(KeyCode.E) && withinReach && !berryAtPlayerHome.activeSelf && berryAtPlace.activeSelf)
        {
            berryAtPlace.SetActive(false);
            berryAtPlayerHome.SetActive(true);
            Debug.Log("Spieler 2: Beere vom HandOverPlace genommen!");
        }
    }

    // Spieler 1: Fisch am Spieler 1 ablegen
    public void PlayerGardenPlaceFish()
    {
        if (Input.GetKeyDown(KeyCode.Return) && withinReach && fishAtPlayerGarden.activeSelf && !fishAtPlace.activeSelf)
        {
            fishAtPlayerGarden.SetActive(false);
            fishAtPlace.SetActive(true);
            Debug.Log("Spieler 1: Fisch wurde am HandOverPlace abgelegt!");
        }
    }

    // Spieler 1: Fisch vom HandOverPlace nehmen
    public void PlayerGardenTakeFish()
    {
        if (Input.GetKeyDown(KeyCode.Return) && withinReach && !fishAtPlayerGarden.activeSelf && fishAtPlace.activeSelf)
        {
            fishAtPlayerGarden.SetActive(true);
            fishAtPlace.SetActive(false);
            Debug.Log("Spieler 1: Fisch vom HandOverPlace genommen!");
        }
    }

    // Spieler 2: Fisch am Spieler 2 ablegen
    public void PlayerHomePlaceFish()
    {
        if (Input.GetKeyDown(KeyCode.E) && withinReach && fishAtPlayerHome.activeSelf && !fishAtPlace.activeSelf)
        {
            fishAtPlace.SetActive(true);
            fishAtPlayerHome.SetActive(false);
            Debug.Log("Spieler 2: Fisch wurde am HandOverPlace abgelegt!");
        }
    }

    // Spieler 2: Fisch vom HandOverPlace nehmen
    public void PlayerHomeTakeFish()
    {
        if (Input.GetKeyDown(KeyCode.E) && withinReach && !fishAtPlayerHome.activeSelf && fishAtPlace.activeSelf)
        {
            fishAtPlace.SetActive(false);
            fishAtPlayerHome.SetActive(true);
            Debug.Log("Spieler 2: Fisch vom HandOverPlace genommen!");
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
