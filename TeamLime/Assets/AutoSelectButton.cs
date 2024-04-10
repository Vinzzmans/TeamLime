using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AutoSelectButton : MonoBehaviour
{
    public Button buttonToSelect;

    void OnEnable()
    {
        // �berpr�fen, ob der Button vorhanden ist
        if (buttonToSelect != null)
        {
            // Button ausw�hlen
            buttonToSelect.Select();
        }
    }
}
