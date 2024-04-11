using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEventHandler : MonoBehaviour
{
    // Diese Methode wird vom AnimationEvent aufgerufen, um das GameObject zu deaktivieren
    public void DeactivateGameObject()
    {
        gameObject.SetActive(false);
    }
}