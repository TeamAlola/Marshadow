using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur {

    int pv;
    int argent;

    public void PerdreArgent(int i)
    {
        argent -= i;
        if (argent <= 0) { argent = 0; }
    }

    public void GagnerArgent(int i)
    {
        argent += i;
    }

    public void AcheterTour(Tour t)
    {
        if (argent >= t.valeur)
        {
            PerdreArgent(t.valeur);
        }
        else
        {
            Debug.Log("T'es pauvre gros PD");
        }
    }

    public void PrendreDegats(int i)
    {
        pv -= i;
        if (pv <= 0) { GameManager.gameManager.Perdre(); }
    }
}
