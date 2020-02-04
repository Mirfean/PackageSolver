using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Zasady : MonoBehaviour {       //Skrypt do ściany

    public float wynik;         // Obecny wynik
    public float zamek;         // Wymagany wynik do przejścia poziomu
    Canvas can;                 // "Mother of UI"
    public Text obecny_wynik;   // Tekst wyświetlający wynik

    // Inicjalizacja
	void Start () {
        obecny_wynik = can.GetComponent<Text>();    // Pobieram startowy wynik
    }

    void Update()
    {
        //obecny_wynik.text = wynik.ToString();       // Zmiana wyniku co klatkę
        //if (wynik == zamek) { Destroy(gameObject); }
    }
    // Fixed nie sprawdza co klatkę, co zmniejsza obciążenie komputera
    void FixedUpdate () {
        obecny_wynik.text = wynik.ToString();           // Zmiana wyniku
        if (wynik == zamek) { Destroy(gameObject); }    // Usunięcie ściany, gdy wynik się zgadza z zamkiem
    }
    public void licz(Liczba liczba)
    {
        switch (liczba.typ)
        {
            case dzialanie.dodac:
                wynik += liczba.wartosc;
                break;
            case dzialanie.odjac:
                wynik -= liczba.wartosc;
                break;
            case dzialanie.mnozyc:
                wynik = wynik * liczba.wartosc;
                break;
            case dzialanie.dzielic:
                wynik = wynik / liczba.wartosc;
                break;
            case dzialanie.bezwzgl:                 //Wartość bezwględna
                wynik = Mathf.Abs(wynik);
                break;
            case dzialanie.pierw:                   //Pierwiastek kwadratowy
                wynik = Mathf.Sqrt(wynik);
                break;
            // to be continued
        }

    }
}
