using UnityEngine;
using System.Collections;
using System;

public class StartGry : MonoBehaviour {

    public String poziom;                   //String z nazwą poziomu xD

    public void NowaGra()
    {
        Application.LoadLevel(poziom);      //Wczytuje wybrany poziom po wciśnięciu przycisku
    }

    public void Zakoncz()
    {
        Application.Quit();                 //Wyjście z gry
    }

}