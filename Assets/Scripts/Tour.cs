using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour {

    public int valeur;
    private int degat;
    public float forceEffetModif;
    public float dureeEffetModif;
    
    public float attackspeed = 3;
    public Vector2 vitesse;
    public int niv;
    public Monstre.element element;
    public GameObject prefabtower;

    public Tour(int v, int d, float fem, float dem, Vector2 vi, Monstre.element el,GameObject obj)
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
        attackspeed *= 0.8f;
    }
}
