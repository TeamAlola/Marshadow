using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monstre  {

    int degat;
    int or;
    int pv;

    /// <param name="d">degat</param>
    /// <param name="o">or</param>
    /// <param name="p">pv</param>
    public Monstre(int d, int o, int p)
    {
        degat = d;
        or = o;
        pv = p;
    }

    public void Mourir()
    {
        GameManager.gameManager.joueur.GagnerArgent(or);
        GameManager.gameManager.monstres.Remove(this);
        if (GameManager.gameManager.monstres.Count == 0) { GameManager.gameManager.Gagner(); }
    }

    public void InfligerDegats()
    {
        GameManager.gameManager.joueur.PrendreDegats(degat);
        GameManager.gameManager.monstres.Remove(this);
        if (GameManager.gameManager.monstres.Count == 0 && GameManager.gameManager.joueur.pv>0) { GameManager.gameManager.Gagner(); }
    }
}
