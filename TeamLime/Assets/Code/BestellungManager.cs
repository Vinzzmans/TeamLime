using UnityEngine;

public class BestellungManager : MonoBehaviour
{
    public GameObject[] bestellungen; // Array der drei Bestellungen
    public GameObject Kunden;
    public int aktuelleBestellungIndex;

    public int rightOrder;

    void Start()
    {
        KundenAktivieren();
        NeueBestellung();
    }

    void KundenAktivieren()
    {
        // Setze alle Kunden aktiv
        Kunden.SetActive(true);
    }

    void NeueBestellung()
    {
        // Zuf�llig eine Bestellung ausw�hlen
        aktuelleBestellungIndex = Random.Range(0, bestellungen.Length);

        // Nur die ausgew�hlte Bestellung aktivieren
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
        }
        else
        {
            Debug.Log("Falscher Trank abgegeben. Versuche es erneut!");
            // Hier k�nntest du eine Strafe implementieren oder etwas anderes tun
        }
    }
}
