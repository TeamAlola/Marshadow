using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour {

    public int valeur;
    public int degat;
    
    public Tour(int v, int d)
    {
        valeur = v;
        degat = d;
    }

    //donne des gold au joueur et supprime la tour de la liste tours achetées
    public void Revendre()
    {
        GameManager.gameManager.joueur.GagnerArgent(valeur/3);
        GameManager.gameManager.toursAchetees.Remove(this);
    }
}
