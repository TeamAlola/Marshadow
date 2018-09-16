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
    public Monstre.element element;
    public GameObject prefabtower;

    public Tour(int val, int dmg, float forcemod, float dureemod, Vector2 vit, Monstre.element el,GameObject pref)
    {
        valeur = val;
        Degat = dmg;
        forceEffetModif = forcemod;
        dureeEffetModif = dureemod;
        vitesse = vit;
        element = el;
        prefabtower = pref;
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

    public Tour CloneTour()
    {
        return new Tour(valeur,degat,forceEffetModif,dureeEffetModif,vitesse,element,prefabtower);
    }
}
