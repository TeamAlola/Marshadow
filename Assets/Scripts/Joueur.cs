using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Joueur {

    public int pv;
    public int argent;

    public Joueur(int p, int a)
    {
        pv = p;
        argent = a;
        GameManager.gameManager.hud.PrintLives(pv);
        GameManager.gameManager.hud.PrintMoney(argent);
    }

    public void PerdreArgent(int i)
    {
        argent -= i;
        if (argent <= 0) { argent = 0; }
        GameManager.gameManager.hud.PrintMoney(argent);
    }

    public void GagnerArgent(int i)
    {
        argent += i;
        GameManager.gameManager.hud.PrintMoney(argent);
    }

    //Le joueur subit i degats. S'il tombe a zero pv, lance la fonction Perdre
    public void PrendreDegats(int i)
    {
        pv -= i;
        if (pv <= 0) { GameManager.gameManager.Perdre(); }
        GameManager.gameManager.hud.PrintLives(pv);
    }
}
