using UnityEngine;
using System.Collections;

public enum dzialanie       // Stałe wartości jakie może przyjąć zmienna działanie
{
    dodac,
    odjac,
    mnozyc,
    dzielic,
    pierw,
    bezwzgl
}


public class Liczba : MonoBehaviour {
    public Zasady zasady;               //Drzwi zliczające wartości 
    public dzialanie typ;               //Rodzaj działania 
    public float wartosc;

	// Use this for initialization
	void Start () {
        zasady = FindObjectOfType<Zasady>();
	
	}
	
    void OnTriggerEnter2D(Collider2D kol)   //Odpala się gdy koliduje z czymś
    {
        if(kol.name == "TheBall")           //Jeżeli element koliduje z obiektem o nazwie "TheBall"
        {
            zasady.licz(this);              //Odpalenie metody drzwi, zliczającej po dotknięciu liczby
            //Destroy(gameObject); <-- Do ewentualnego usuwania elementu
        }
    }   




}
