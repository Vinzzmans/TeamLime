using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class TimerScript : MonoBehaviour
{
    public float countdownTime = 60f; // Die Dauer des Timers in Sekunden
    public GameObject objectToActivate; // Das GameObject, das aktiviert werden soll
    public TextMeshProUGUI timerText; // Das TextMeshPro-Objekt, um den Timer anzuzeigen
    public Color warningColor; // Die Farbe f�r die Warnung
    public float warningDisplayDuration = 1f; // Die Dauer, f�r die die Warnungsfarbe angezeigt wird

    private float timer; // Der aktuelle Timer-Z�hler
    private bool timerActive = true; // Ob der Timer aktiv ist

    private bool twoMinutesLeftWarningShown = false;
    private bool oneMinuteLeftWarningShown = false;

    public BestellungManager bestellungManager;
    public TextMeshProUGUI deliveredText;


    public AudioSource audioSource;
    public AudioClip pickUpClip;

    void Start()
    {
        timer = countdownTime; // Timer auf die Anfangszeit setzen

    }

    void Update()
    {
        if (timerActive)
        {
            timer -= Time.deltaTime; // Den Timer herunterz�hlen

            if (timer <= 0f)
            {
                timer = 0f; // Timer stoppen, wenn er abgelaufen ist
                timerActive = false; // Timer als inaktiv markieren
                ActivateObject(); // Die Methode aufrufen, um das GameObject zu aktivieren
            }

            UpdateTimerText(); // Die Methode aufrufen, um den Timer-Text zu aktualisieren
        }
    }

    void UpdateTimerText()
    {
        if (timerText != null)
        {
            // Nur die verbleibenden Sekunden anzeigen
            int seconds = Mathf.FloorToInt(timer);
            timerText.text = seconds.ToString();

            // Warnung f�r 2 Minuten verbleibende Zeit
            if (timer <= 121 && !twoMinutesLeftWarningShown)
            {
                audioSource.clip = pickUpClip;
                audioSource.Play();
                StartCoroutine(DisplayWarning());
                twoMinutesLeftWarningShown = true;
            }
            // Warnung f�r 1 Minute verbleibende Zeit
            else if (timer <= 61 && !oneMinuteLeftWarningShown)
            {
                StartCoroutine(DisplayWarning());
                oneMinuteLeftWarningShown = true;
            }
        }
    }

    IEnumerator DisplayWarning()
    {
        timerText.color = warningColor; // Farbe setzen

        // Warte f�r die angegebene Dauer
        yield return new WaitForSeconds(warningDisplayDuration);

        // Farbe zur�cksetzen
        timerText.color = Color.white;
    }

    void ActivateObject()
    {
        if (objectToActivate != null)
        {
            objectToActivate.SetActive(true); // Das GameObject aktivieren

            deliveredText.text = bestellungManager.rightOrder.ToString();
        }
    }
}
