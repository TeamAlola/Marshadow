using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour {

    public int valeur;
    private int degat;
    public float forceEffetModif;
    public float dureeEffetModif;
    public Vector2 vitesse;
    public int niv;
    public Tir.effet element;
    public GameObject prefabtower;

    public Tour(int v, int d, float fem, float dem, Vector2 vi, Tir.effet el,GameObject obj)
    {
        valeur = v;
        Degat = d;
        forceEffetModif = fem;
        dureeEffetModif = dem;
        vitesse = vi;
        element = el;
        prefabtower = obj;
    }

    public int Degat
    {
        get
        {
            return degat;
        }

        set
        {
            degat = value;
        }
    }

    //donne des gold au joueur et supprime la tour de la liste tours achetées
    public void Revendre()
    {
        GameManager.gameManager.joueur.GagnerArgent(valeur/3);
        GameManager.gameManager.toursAchetees.Remove(this);
    }

    public void Upgrade()
    {
        niv++;
        dureeEffetModif *= 1.5f;
        forceEffetModif *= 1.5f;
        degat *= (int) 1.8;
        vitesse *= 1.2f;
    }
}
