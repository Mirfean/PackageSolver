using UnityEngine;
using System.Collections;

public class NextLevel : MonoBehaviour {        //PORTAL DO NASTĘPNEGO POZIOMU

    public string poziom;

    void OnTriggerEnter2D(Collider2D obiekt)    //Odpala się gdy koliduje z czymś
    {
        Application.LoadLevel(poziom);          //Przejście do następnego poziomu po dotknięciu
    }
}
