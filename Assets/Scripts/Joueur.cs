﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur {

    public int pv;
    public int argent;

    public Joueur(int p, int a)
    {
        pv = p;
        argent = a;
    }

    public void PerdreArgent(int i)
    {
        argent -= i;
        if (argent <= 0) { argent = 0; }
    }

    public void GagnerArgent(int i)
    {
        argent += i;
    }

    //Vérifie que le joueur a assez d'argent, déduit l'argent puis ajoute la tour aux tours achetées
    public void AcheterTour(Tour t)
    {
        if (argent >= t.valeur)
        {
            PerdreArgent(t.valeur);
            GameManager.gameManager.toursAchetees.Add(new Tour(t.valeur, t.degat));
        }
        else
        {
            Debug.Log("T'es pauvre gros PD");
        }
    }

    //Le joueur subit i degats. S'il tombe a zero pv, lance la fonction Perdre
    public void PrendreDegats(int i)
    {
        pv -= i;
        if (pv <= 0) { GameManager.gameManager.Perdre(); }
    }
}