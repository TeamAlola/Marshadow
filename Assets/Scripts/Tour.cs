﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tour {

    public int valeur;
    private int degat;
    public float forceEffetModif;
    public float dureeEffetModif;
    public Vector2 vitesse;

    public Tour(int v, int d)
    {
        valeur = v;
        Degat = d;
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
        dureeEffetModif *= 1.5f;
        forceEffetModif *= 1.5f;
    }
}
