using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre  {

    int degat;
    int or;
    int pv;

    public void Mourir()
    {
        if (GameManager.gameManager.monstres.Count == 1) { GameManager.gameManager.Gagner(); }
        GameManager.gameManager.joueur.GagnerArgent(or);
        GameManager.gameManager.monstres.Remove(this);
    }

    public void InfligerDegats()
    {
        GameManager.gameManager.joueur.PrendreDegats(degat);
        GameManager.gameManager.monstres.Remove(this);
        if (GameManager.gameManager.monstres.Count == 1) { GameManager.gameManager.Gagner(); }
    }
}
