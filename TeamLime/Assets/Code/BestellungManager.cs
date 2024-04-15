using UnityEngine;

public class BestellungManager : MonoBehaviour
{
    public GameObject[] bestellungen; // Array der drei Bestellungen
    public GameObject Kunden;
    public int aktuelleBestellungIndex;

    public int rightOrder;


    public AudioSource audioSource;
    public AudioClip failClip;
    public AudioClip sucessClip;
    void Start()
    {
        KundenAktivieren();
        NeueBestellung();
    //audioSource = GetComponentInChildren<AudioSource>();
    }

    void KundenAktivieren()
    {
        // Setze alle Kunden aktiv
        Kunden.SetActive(true);
    }

    void NeueBestellung()
    {
        // Zufällig eine Bestellung auswählen
        aktuelleBestellungIndex = Random.Range(0, bestellungen.Length);

        // Nur die ausgewählte Bestellung aktivieren
        for (int i = 0; i < bestellungen.Length; i++)
        {
            if (i == aktuelleBestellungIndex)
            {
                bestellungen[i].SetActive(true);
            }
            else
            {
                bestellungen[i].SetActive(false);
            }
        }
    }

    public void TrankAbgeben(int trankIndex)
    {
        if (trankIndex == aktuelleBestellungIndex)
        {
            Debug.Log("Richtiger Trank abgegeben!");
            rightOrder ++;
            NeueBestellung(); // Neue Bestellung generieren
            audioSource.clip = sucessClip;
            audioSource.Play();
        }
        else
        {
            Debug.Log("Falscher Trank abgegeben. Versuche es erneut!");
            // Hier könntest du eine Strafe implementieren oder etwas anderes tun
            audioSource.clip = failClip;
            audioSource.Play();
        }
    }
}
