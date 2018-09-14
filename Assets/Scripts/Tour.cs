using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour : MonoBehaviour {

    public int valeur;
    int degat;

    public void Revendre()
    {
        GameManager.gameManager.joueur.GagnerArgent(valeur/3);
        GameManager.gameManager.toursAchetees.Remove(this);
    }
}
