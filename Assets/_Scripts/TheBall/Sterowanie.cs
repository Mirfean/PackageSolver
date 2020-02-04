using UnityEngine;
using System.Collections;

public class Sterowanie : MonoBehaviour {

	public float predkosc;                                          //Prędkość poruszania się kuli
	public Rigidbody2D Ball;                                        //Z dokumentacji "Rigidbody is the main component that enables physical behaviour"
    public float skok;                                              //Siła skoku kuli
	
	public Transform czujnik,czujnik2,czujnik3,czujnik4,czujnik5;   //Czujniki podłoża dla kuli - można dodać więcej dla lepszego efektu
	public float promienCzujnik;                                    //Promień wykrywania czujników
	public LayerMask warstwa;                                       //Rodzaj warstwy na jaką mają reagować czujniki (w tym przypadku "ziemia")
	public bool czujnik_on;                                         //Aktywność czujników
	public Transform[] czujniki;                                    //Transform to wartości na osi XYZ
	

	// Inicjalizacja
	void Start () {
		Ball = GetComponent<Rigidbody2D>();                         //Pobieranie ruchliwego elementu(naszej kuli)
        
        czujniki = new Transform[5];                                //Deklaracja 5 elementów do tablicy TRANFORM(ers)
        czujniki[0] = czujnik;
        czujniki[1] = czujnik2;
        czujniki[2] = czujnik3;
        czujniki[3] = czujnik4;
        czujniki[4] = czujnik5;
    }
	
	// Update niezależny od ilości klatek (w tej grze nie ma to znaczenia)
	void FixedUpdate() {
	
		foreach(Transform temp in czujniki)                                                 //Sprawdza czy którykolwiek z czujników...
		{
            czujnik_on = Physics2D.OverlapCircle(temp.position, promienCzujnik, warstwa);   //...koliduje z elementem warstwy "ziemia"...
            if (czujnik_on) { break; }                                                      //...jeżeli tak, to kończy sprawdzanie
        }
	}
	// Update is called once per frame
	void Update () {
		
		if(Input.GetKey(KeyCode.D)){                                
			Ball.velocity = new Vector2 (predkosc, Ball.velocity.y);    //Poruszanie się w prawo    (na osi X o wartość predkosc, na osi Y pozostaje gdzie jest)
		}
		if(Input.GetKey(KeyCode.A)){
			Ball.velocity = new Vector2 (-predkosc, Ball.velocity.y);   //Poruszanie się w lewo
        }
		if(Input.GetKeyDown(KeyCode.W) && czujnik_on){                  //Skakanie
			Ball.velocity = new Vector2 (Ball.velocity.x, skok);
		}
		
		
		
	}
}
